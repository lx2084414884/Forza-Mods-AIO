using System.Diagnostics;
using Forza_Mods_AIO.Models;
using static Memory.Imps;
using static System.BitConverter;
using static Forza_Mods_AIO.Resources.Memory;
using Timer = System.Timers.Timer;

namespace Forza_Mods_AIO.Cheats.ForzaHorizon5;

public class Bypass : CheatsUtilities, ICheatsBase
{
    public readonly DebugSession BypassDebug = new("Bypass", []);

    private UIntPtr _crcFuncAddress, _memCopyAddress, _callAddress;
    public UIntPtr CrcFuncDetourAddress;
    private bool _scanning;
    private Timer _antiCheatTimer = null!;
    
    public async Task DisableCrcChecks()
    {
        var wasScanning = _scanning;
        while (_scanning)
        {
            await Task.Delay(1);
        }

        if (wasScanning)
        {
            return;
        }

        _scanning = true;
        _crcFuncAddress = 0;
        CrcFuncDetourAddress = 0;

        const string sig = "E8 ? ? ? ? 48 83 C4 ? 5F 5B C3 CC CC CC ? ? ? ? ? ? ? 74 ? ? ? ? ? ? 48";
        _crcFuncAddress = await SmartAobScan(sig);
        
        BypassDebug.DebugInfoReports.Add(new DebugInfoReport($"Address: {_crcFuncAddress:X}"));
        
        if (_crcFuncAddress > 0)
        {
            var mem = GetInstance();
            var scanResult = (IntPtr)_crcFuncAddress + mem.ReadMemory<int>(_crcFuncAddress + 1) + 5;
            _crcFuncAddress = (UIntPtr)(scanResult + 311);
            
            var procHandle = mem.MProc.Process.Handle;
            var memSize = mem.MProc.Process.MainModule!.ModuleMemorySize;
            var baseAddress = (UIntPtr)mem.MProc.Process.MainModule!.BaseAddress;
        
            var memCopy = new byte[memSize];
            ReadProcessMemory(procHandle, baseAddress, memCopy, memSize);
            
            _memCopyAddress = VirtualAllocEx(procHandle, UIntPtr.Zero, (uint)memSize, MemCommit | MemReserve, ReadWrite);
            WriteProcessMemory(procHandle, _memCopyAddress, memCopy, (uint)memSize, nint.Zero);

             var currentProcess = Process.GetCurrentProcess();
            currentProcess.MinWorkingSet = 300000;
            
            var endAddress = baseAddress + (uint)memSize;
            var varBytes = GetBytes(baseAddress).Concat(GetBytes(endAddress)).Concat(GetBytes(_memCopyAddress)).ToArray();
            
            var asm = new byte[]
            {
                0x48, 0x3B, 0x05, 0x23, 0x00, 0x00, 0x00, 0x72, 0x17, 0x48, 0x3B, 0x05, 0x22, 0x00, 0x00, 0x00, 0x77,
                0x0E, 0x48, 0x2B, 0x05, 0x11, 0x00, 0x00, 0x00, 0x48, 0x03, 0x05, 0x1A, 0x00, 0x00, 0x00, 0xF3, 0x0F,
                0x6F, 0x40, 0xF0
            };
            
            CrcFuncDetourAddress = mem.CreateDetour(_crcFuncAddress, asm, 5, varBytes: varBytes);
            BypassDebug.DebugInfoReports.Add(new DebugInfoReport($"Hook Addr: {CrcFuncDetourAddress:X}"));
            _scanning = false;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(DisableDynamicCodeCalls);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            return;
        }
        
        _scanning = false;
        ShowError("Bypass", sig);
    }

    private async Task DisableDynamicCodeCalls()
    {
        _callAddress = 0;

        const string sig = "49 8B ? FF 50 ? 48 8D ? ? ? ? ? FF 15 ? ? ? ? 8B 8D";
        _callAddress = await SmartAobScan(sig) + 3;

        if (_callAddress > 3)
        {
            _antiCheatTimer = new Timer();
            _antiCheatTimer.Interval = 30000;
            _antiCheatTimer.Elapsed += async (_, _) =>
            {
                var mem = GetInstance();
                mem.WriteArrayMemory(_callAddress, new byte[] { 0xFF, 0x50, 0x30 });
                await Task.Delay(1000);
                mem.WriteArrayMemory(_callAddress, new byte[] { 0x90, 0x90, 0x90 });
            };
        
            GetInstance().WriteArrayMemory(_callAddress, new byte[] { 0x90, 0x90, 0x90 });
            _antiCheatTimer.Start();
        }
    }
    
    public void Cleanup()
    {
        var mem = GetInstance();
        
        if (_callAddress > 3)
        {
            _antiCheatTimer.Stop();
            mem.WriteArrayMemory(_callAddress, new byte[] { 0xFF, 0x50, 0x30 });
        }
        
        if (CrcFuncDetourAddress <= 0) return;
        mem.WriteArrayMemory(_crcFuncAddress, new byte[] { 0xF3, 0x0F, 0x6F, 0x40, 0xF0 });
        Free(CrcFuncDetourAddress);
        Free(_memCopyAddress);
    }

    public void Reset()
    {
        _scanning = false;
        if (_antiCheatTimer != null!)
        {
            _antiCheatTimer.Stop();
            _antiCheatTimer = null!;
        }
        var fields = typeof(Bypass).GetFields().Where(f => f.FieldType == typeof(UIntPtr));
        foreach (var field in fields)
        {
            field.SetValue(this, UIntPtr.Zero);
        }
    }
}