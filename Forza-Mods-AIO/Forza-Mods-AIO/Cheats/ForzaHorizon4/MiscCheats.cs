using static Forza_Mods_AIO.Resources.Memory;

namespace Forza_Mods_AIO.Cheats.ForzaHorizon4;

public class MiscCheats : CheatsUtilities, ICheatsBase
{
    private UIntPtr _raceTimeScaleAddress;
    public UIntPtr RaceTimeScaleDetourAddress;
    private UIntPtr _driftScoreMultiplierAddress;
    public UIntPtr DriftScoreMultiplierDetourAddress;
    private UIntPtr _skillScoreMultiplierAddress;
    public UIntPtr SkillScoreMultiplierDetourAddress;
    private UIntPtr _speedZoneMultiplierAddress;
    public UIntPtr SpeedZoneMultiplierDetourAddress;
    private UIntPtr _missionTimeScaleAddress;
    public UIntPtr MissionTimeScaleDetourAddress;
    private UIntPtr _trailblazerTimeScaleAddress;
    public UIntPtr TrailblazerTimeScaleDetourAddress;
    
    public async Task CheatRaceTimeScale()
    {
        _raceTimeScaleAddress = 0;
        RaceTimeScaleDetourAddress = 0;

        const string sig = "48 8B ? F3 0F ? ? F2 0F";
        _raceTimeScaleAddress = await SmartAobScan(sig) + 7;

        if (_raceTimeScaleAddress > 7)
        {
            var asm = new byte[]
            {
                0x80, 0x3D, 0x17, 0x00, 0x00, 0x00, 0x01, 0x75, 0x08, 0xF2, 0x0F, 0x59, 0x05, 0x0E, 0x00, 0x00, 0x00,
                0xF2, 0x0F, 0x58, 0x81, 0xA8, 0x00, 0x00, 0x00
            };

            RaceTimeScaleDetourAddress = GetInstance().CreateDetour(_raceTimeScaleAddress, asm, 8);
            return;
        }
        
        ShowError("Race Time Scale", sig);
    }
    
    public async Task CheatDriftScoreMultiplier()
    {
        _driftScoreMultiplierAddress = 0;
        DriftScoreMultiplierDetourAddress = 0;
        
        const string sig = "F3 41 ? ? ? F3 0F ? ? ? ? ? ? 48 8D ? ? ? ? ? 48 89";
        _driftScoreMultiplierAddress = await SmartAobScan(sig);

        if (_driftScoreMultiplierAddress > 5)
        {
            var asm = new byte[]
            {
                0x80, 0x3D, 0x15, 0x00, 0x00, 0x00, 0x01, 0x75, 0x09, 0xF3, 0x44, 0x0F, 0x59, 0x1D, 0x0B, 0x00, 0x00,
                0x00, 0xF3, 0x41, 0x0F, 0x58, 0xC3
            };

            DriftScoreMultiplierDetourAddress = GetInstance().CreateDetour(_driftScoreMultiplierAddress, asm, 5);
            return;
        }
        
        ShowError("Drift score multiplier", sig);
    }
    
    public async Task CheatSkillScoreMultiplier()
    {
        _skillScoreMultiplierAddress = 0;
        SkillScoreMultiplierDetourAddress = 0;
        
        const string sig = "FF 50 ? 8B 78 ? 48 85";
        _skillScoreMultiplierAddress = await SmartAobScan(sig) + 3;

        if (_skillScoreMultiplierAddress > 3)
        {
            var asm = new byte[]
            {
                0x8B, 0x78, 0x04, 0x80, 0x3D, 0x11, 0x00, 0x00, 0x00, 0x01, 0x75, 0x07, 0x0F, 0xAF, 0x3D, 0x09, 0x00,
                0x00, 0x00, 0x48, 0x85, 0xDB
            };

            SkillScoreMultiplierDetourAddress = GetInstance().CreateDetour(_skillScoreMultiplierAddress, asm, 6);
            return;
        }
        
        ShowError("Skill score multiplier", sig);
    }

    
    public async Task CheatSpeedZoneMultiplier()
    {
        _speedZoneMultiplierAddress = 0;
        SpeedZoneMultiplierDetourAddress = 0;
        
        const string sig = "F3 0F ? ? ? ? ? ? F3 0F ? ? ? 4C 8B ? 48 8B";
        _speedZoneMultiplierAddress = await SmartAobScan(sig);

        if (_speedZoneMultiplierAddress > 0)
        {
            var asm = new byte[]
            {
                0x80, 0x3D, 0x17, 0x00, 0x00, 0x00, 0x01, 0x75, 0x08, 0xF3, 0x0F, 0x59, 0x35, 0x0E, 0x00, 0x00, 0x00,
                0xF3, 0x0F, 0x5E, 0xB7, 0xD0, 0x01, 0x00, 0x00
            };

            SpeedZoneMultiplierDetourAddress = GetInstance().CreateDetour(_speedZoneMultiplierAddress, asm, 8);
            return;
        }
        
        ShowError("Speedzone multiplier", sig);
    }
    
    public async Task CheatMissionTimeScale()
    {
        _missionTimeScaleAddress = 0;
        MissionTimeScaleDetourAddress = 0;
        
        const string sig = "F3 0F ? ? F3 0F ? ? ? F3 0F ? ? ? ? ? ? 48 81 C1";
        _missionTimeScaleAddress = await SmartAobScan(sig);

        if (_missionTimeScaleAddress > 0)
        {
            var asm = new byte[]
            {
                0x80, 0x3D, 0x18, 0x00, 0x00, 0x00, 0x01, 0x75, 0x08, 0xF3, 0x0F, 0x59, 0x0D, 0x0F, 0x00, 0x00, 0x00,
                0xF3, 0x0F, 0x5C, 0xC1, 0xF3, 0x0F, 0x11, 0x45, 0x10
            };

            MissionTimeScaleDetourAddress = GetInstance().CreateDetour(_missionTimeScaleAddress, asm, 9);
            return;
        }
        
        ShowError("Mission time scale", sig);
    }
    
    public async Task CheatTrailblazerTimeScale()
    {
        _trailblazerTimeScaleAddress = 0;
        TrailblazerTimeScaleDetourAddress = 0;
        
        const string sig = "F3 0F ? ? F3 0F ? ? ? 48 8D ? ? ? ? ? 48 89 ? ? 40 88";
        _trailblazerTimeScaleAddress = await SmartAobScan(sig);

        if (_trailblazerTimeScaleAddress > 0)
        {
            var asm = new byte[]
            {
                0x80, 0x3D, 0x18, 0x00, 0x00, 0x00, 0x01, 0x75, 0x08, 0xF3, 0x0F, 0x59, 0x35, 0x0F, 0x00, 0x00, 0x00,
                0xF3, 0x0F, 0x5C, 0xC6, 0xF3, 0x0F, 0x11, 0x45, 0x6F
            };

            TrailblazerTimeScaleDetourAddress = GetInstance().CreateDetour(_trailblazerTimeScaleAddress, asm, 9);
            return;
        }
        
        ShowError("Trailblazer time scale", sig);
    }

    public void Cleanup()
    {
        var mem = GetInstance();

        if (_raceTimeScaleAddress > 7)
        {
            mem.WriteArrayMemory(_raceTimeScaleAddress, new byte[] { 0xF2, 0x0F, 0x58, 0x81, 0xA8, 0x00, 0x00, 0x00 });
            Free(RaceTimeScaleDetourAddress);
        }

        if (_driftScoreMultiplierAddress > 0)
        {
            mem.WriteArrayMemory(_driftScoreMultiplierAddress, new byte[] { 0xF3, 0x41, 0x0F, 0x58, 0xC3 });
            Free(DriftScoreMultiplierDetourAddress);
        }
        
        if (_skillScoreMultiplierAddress > 3)
        {
            mem.WriteArrayMemory(_skillScoreMultiplierAddress, new byte[] { 0x8B, 0x78, 0x04, 0x48, 0x85, 0xDB });
            Free(SkillScoreMultiplierDetourAddress);
        }
        
        if (_speedZoneMultiplierAddress > 0)
        {
            mem.WriteArrayMemory(_speedZoneMultiplierAddress, new byte[] { 0xF3, 0x0F, 0x5E, 0xB7, 0xD0, 0x01, 0x00, 0x00 });
            Free(SpeedZoneMultiplierDetourAddress);
        }

        if (_missionTimeScaleAddress > 0)
        {
            mem.WriteArrayMemory(_missionTimeScaleAddress, new byte[] { 0xF3, 0x0F, 0x5C, 0xC1, 0xF3, 0x0F, 0x11, 0x45, 0x10 });
            Free(MissionTimeScaleDetourAddress);
        }

        if (_trailblazerTimeScaleAddress > 0)
        {
            mem.WriteArrayMemory(_trailblazerTimeScaleAddress, new byte[] { 0xF3, 0x0F, 0x5C, 0xC6, 0xF3, 0x0F, 0x11, 0x45, 0x6F });
            Free(TrailblazerTimeScaleDetourAddress);
        }
    }

    public void Reset()
    {  
        var fields = typeof(MiscCheats).GetFields().Where(f => f.FieldType == typeof(UIntPtr));
        foreach (var field in fields)
        {
            field.SetValue(this, UIntPtr.Zero);
        }
    }
}