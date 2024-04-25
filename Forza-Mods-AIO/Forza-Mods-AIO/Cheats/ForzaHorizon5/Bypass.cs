using Forza_Mods_AIO.Models;
using static Forza_Mods_AIO.Resources.Cheats;
using static Forza_Mods_AIO.Resources.Memory;
using Timer = System.Timers.Timer;

namespace Forza_Mods_AIO.Cheats.ForzaHorizon5;

public class Bypass : CheatsUtilities, ICheatsBase
{
    public readonly DebugSession BypassDebug = new("Bypass", []);

    public UIntPtr CallAddress;
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
        CallAddress = 0;

        const string sig = "49 8B ? FF 50 ? 48 8D ? ? ? ? ? FF 15 ? ? ? ? 8B 8D";
        CallAddress = await SmartAobScan(sig) + 3;

        if (CallAddress > 3)
        {
            _antiCheatTimer = new Timer();
            _antiCheatTimer.Interval = 25000;
            _antiCheatTimer.Elapsed += async (_, _) =>
            {
                var mem = GetInstance();
                foreach (var pair in CachedInstances.Where(kv => typeof(IRevertBase).IsAssignableFrom(kv.Key)))
                {
                    ((IRevertBase)pair.Value).Revert();
                }
                mem.WriteArrayMemory(CallAddress, new byte[] { 0xFF, 0x50, 0x30 });
                await Task.Delay(500);
                mem.WriteArrayMemory(CallAddress, new byte[] { 0x90, 0x90, 0x90 });
                foreach (var pair in CachedInstances.Where(kv => typeof(IRevertBase).IsAssignableFrom(kv.Key)))
                {
                    ((IRevertBase)pair.Value).Continue();
                }
            };
        
            GetInstance().WriteArrayMemory(CallAddress, new byte[] { 0x90, 0x90, 0x90 });
            _antiCheatTimer.Start();
            _scanning = false;
            return;
        }
        
        _scanning = false;
        ShowError("Bypass", sig);
    }
    
    public void Cleanup()
    {
        var mem = GetInstance();
        if (CallAddress <= 3) return;
        _antiCheatTimer.Stop();
        mem.WriteArrayMemory(CallAddress, new byte[] { 0xFF, 0x50, 0x30 });
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