﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using Forza_Mods_AIO.Cheats.ForzaHorizon5;
using Forza_Mods_AIO.Models;
using Forza_Mods_AIO.ViewModels.SubPages.SelfVehicle;
using MahApps.Metro.Controls;
using static Forza_Mods_AIO.Resources.Memory;

namespace Forza_Mods_AIO.Views.SubPages.SelfVehicle;

public partial class Misc
{
    public Misc()
    {
        ViewModel = new MiscViewModel();
        DataContext = this;
        
        InitializeComponent();
    }

    public MiscViewModel ViewModel { get; }
    private static MiscCheats MiscCheatsFh5 => Forza_Mods_AIO.Resources.Cheats.GetClass<MiscCheats>();
    private static Cheats.ForzaHorizon4.MiscCheats MiscCheatsFh4 =>
        Forza_Mods_AIO.Resources.Cheats.GetClass<Cheats.ForzaHorizon4.MiscCheats>();
    private static CarCheats CarCheatsFh5 => Forza_Mods_AIO.Resources.Cheats.GetClass<CarCheats>();
    
    private async void NameSpooferSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggleSwitch)
        {
            return;
        }

        ViewModel.SpooferUiElementsEnabled = false;
        if (MiscCheatsFh5.NameDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatName();
        }
        ViewModel.SpooferUiElementsEnabled = true;

        if (MiscCheatsFh5.NameDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.NameDetourAddress + 0x55, toggleSwitch.IsOn ? (byte)1 : (byte)0);
        if (string.IsNullOrEmpty(NameBox.Text)) return;
        var name = Encoding.Unicode.GetBytes(NameBox.Text);
        GetInstance().WriteArrayMemory(MiscCheatsFh5.NameDetourAddress + 0x56, name);
    }

    private void NameBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (MiscCheatsFh5.NameDetourAddress == 0) return;
        if (string.IsNullOrEmpty(NameBox.Text)) return;
        var name = Encoding.Unicode.GetBytes(NameBox.Text);
        GetInstance().WriteArrayMemory(MiscCheatsFh5.NameDetourAddress + 0x56, name);
    }

    private async void TpSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggleSwitch)
        {
            return;
        }

        toggleSwitch.IsEnabled = false;
        if (CarCheatsFh5.WaypointDetourAddress == 0)
        {
            await CarCheatsFh5.CheatWaypoint();
        }
        toggleSwitch.IsEnabled = true;

        if (CarCheatsFh5.WaypointDetourAddress == 0) return;
        GetInstance().WriteMemory(CarCheatsFh5.WaypointDetourAddress + 0x32, toggleSwitch.IsOn ? (byte)1 : (byte)0);
    }

    private void MainComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not ComboBox comboBox || MainToggleSwitch == null || MainValueBox == null)
        {
            return;
        }

        MainToggleSwitch.Toggled -= MainToggleSwitch_OnToggled;
        MainValueBox.ValueChanged -= MainValueBox_OnValueChanged;
        
        switch (comboBox.SelectedIndex)
        {
            case 0:
            {        
                MainValueBox.Value = ViewModel.SpinPrizeScaleValue;
                MainToggleSwitch.IsOn = ViewModel.SpinPrizeScaleEnabled;
                break;
            }
            case 1:
            {            
                MainValueBox.Value = ViewModel.SpinSellFactorValue;
                MainToggleSwitch.IsOn = ViewModel.SpinSellFactorEnabled;
                break;
            }
            case 2:
            {              
                MainValueBox.Value = ViewModel.SkillScoreMultiplierValue;
                MainToggleSwitch.IsOn = ViewModel.SkillScoreMultiplierEnabled;
                break;
            }
            case 3:
            {           
                MainValueBox.Value = ViewModel.DriftScoreMultiplierValue;
                MainToggleSwitch.IsOn = ViewModel.DriftScoreMultiplierEnabled;
                break;
            }
            case 4:
            {              
                MainValueBox.Value = ViewModel.SkillTreeWideEditValue;
                MainToggleSwitch.IsOn = ViewModel.SkillTreeWideEditEnabled;
                break;
            }
            case 5:
            {             
                MainValueBox.Value = ViewModel.SkillTreeCostValue;
                MainToggleSwitch.IsOn = ViewModel.SkillTreeCostEnabled;
                break;
            }
            case 6:
            {            
                MainValueBox.Value = ViewModel.MissionTimeScaleValue;
                MainToggleSwitch.IsOn = ViewModel.MissionTimeScaleEnabled;
                break;
            }
            case 7:
            {           
                MainValueBox.Value = ViewModel.TrailblazerTimeScaleValue;
                MainToggleSwitch.IsOn = ViewModel.TrailblazerTimeScaleEnabled;
                break;
            }
            case 8:
            {           
                MainValueBox.Value = ViewModel.SpeedZoneMultiplierValue;
                MainToggleSwitch.IsOn = ViewModel.SpeedZoneMultiplierEnabled;
                break;
            }
            case 9:
            {           
                MainValueBox.Value = ViewModel.RaceTimeScaleValue;
                MainToggleSwitch.IsOn = ViewModel.RaceTimeScaleEnabled;
                break;
            }
            case 10:
            {           
                MainValueBox.Value = ViewModel.DangerSignMultiplierValue;
                MainToggleSwitch.IsOn = ViewModel.DangerSignMultiplierEnabled;
                break;
            }
            case 11:
            {           
                MainValueBox.Value = ViewModel.SpeedTrapMultiplierValue;
                MainToggleSwitch.IsOn = ViewModel.SpeedTrapMultiplierEnabled;
                break;
            }
            case 12:
            {           
                MainValueBox.Value = ViewModel.DroneModeHeightValue;
                MainToggleSwitch.IsOn = ViewModel.DroneModeHeightEnabled;
                break;
            }
        }

        MainValueBox.Minimum = comboBox.SelectedIndex switch
        { 
            0 or 1 or 2 or 3 or 4 or 6 or 7 or 8 or 9 or 10 or 11 => 0,
            5 => int.MinValue,
            12 => 1,
            _ => throw new IndexOutOfRangeException()
        };

        MainValueBox.Maximum = comboBox.SelectedIndex switch
        { 
            0 or 1 or 2 or 4 or 5 or 12 => int.MaxValue,
            3 or 8 or 10 or 11 => 10,
            6 or 7 or 9 => 1,
            _ => throw new IndexOutOfRangeException()
        };

        MainValueBox.Interval = comboBox.SelectedIndex switch
        { 
            0 or 1 or 2 or 3 or 4 or 5 or 8 or 10 or 11 or 12 => 1,
            6 or 7 or 9 => 0.1,
            _ => throw new IndexOutOfRangeException()
        };
        
        MainValueBox.ValueChanged += MainValueBox_OnValueChanged;
        MainToggleSwitch.Toggled += MainToggleSwitch_OnToggled;
    }

    private void MainValueBox_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
    {
        switch (GameVerPlat.GetInstance().Type)
        {
            case GameVerPlat.GameType.Fh4:
                WriteValueFh4(e);
                break;
            case GameVerPlat.GameType.Fh5:
                WriteValue(e);
                break;
            case GameVerPlat.GameType.None:
            default:
                throw new IndexOutOfRangeException();
        }
    }

    private void WriteValue(RoutedPropertyChangedEventArgs<double?> e)
    {
        switch (MainComboBox.SelectedIndex)
        {
            case 0:
            {        
                ViewModel.SpinPrizeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.PrizeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.PrizeScaleDetourAddress + 0x1C, ViewModel.SpinPrizeScaleValue);
                break;
            }
            case 1:
            {            
                ViewModel.SpinSellFactorValue = Convert.ToInt32(e.NewValue);
                if (MiscCheatsFh5.SellFactorDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.SellFactorDetourAddress + 0x1D, ViewModel.SpinSellFactorValue);
                break;
            }
            case 2:
            {              
                ViewModel.SkillScoreMultiplierValue = Convert.ToInt32(e.NewValue);
                if (MiscCheatsFh5.SkillScoreMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.SkillScoreMultiplierDetourAddress + 0x1D, ViewModel.SkillScoreMultiplierValue);
                break;
            }
            case 3:
            {           
                ViewModel.DriftScoreMultiplierValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.DriftScoreMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.DriftScoreMultiplierDetourAddress + 0x20, ViewModel.DriftScoreMultiplierValue);
                break;
            }
            case 4:
            {              
                ViewModel.SkillTreeWideEditValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.SkillTreeWideEditDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.SkillTreeWideEditDetourAddress + 0x1C, ViewModel.SkillTreeWideEditValue);
                break;
            }
            case 5:
            {             
                ViewModel.SkillTreeCostValue = Convert.ToInt32(e.NewValue);
                if (MiscCheatsFh5.SkillTreePerksCostDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.SkillTreePerksCostDetourAddress + 0x1B, ViewModel.SkillTreeCostValue);
                break;
            }
            case 6:
            {            
                ViewModel.MissionTimeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.MissionTimeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.MissionTimeScaleDetourAddress + 0x23, ViewModel.MissionTimeScaleValue);
                break;
            }
            case 7:
            {           
                ViewModel.TrailblazerTimeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.TrailblazerTimeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.TrailblazerTimeScaleDetourAddress + 0x23, ViewModel.TrailblazerTimeScaleValue);
                break;
            }
            case 8:
            {           
                ViewModel.SpeedZoneMultiplierValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.SpeedZoneMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.SpeedZoneMultiplierDetourAddress + 0x20, ViewModel.SpeedZoneMultiplierValue);
                break;
            }
            case 9:
            {
                ViewModel.RaceTimeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.RaceTimeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.RaceTimeScaleDetourAddress + 0x35,
                    ViewModel.RaceTimeScaleValue);
                break;
            }
            case 10:
            {                   
                ViewModel.DangerSignMultiplierValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.DangerSign1DetourAddress == 0 ||
                    MiscCheatsFh5.DangerSign2DetourAddress == 0 ||
                    MiscCheatsFh5.DangerSign3DetourAddress == 0)
                {
                    return;
                }
        
                GetInstance().WriteMemory(MiscCheatsFh5.DangerSign1DetourAddress + 0x38, ViewModel.DangerSignMultiplierValue);
                GetInstance().WriteMemory(MiscCheatsFh5.DangerSign2DetourAddress + 0x35, ViewModel.DangerSignMultiplierValue);
                GetInstance().WriteMemory(MiscCheatsFh5.DangerSign3DetourAddress + 0x35, ViewModel.DangerSignMultiplierValue);
                break;
            }
            case 11:
            {           
                ViewModel.SpeedTrapMultiplierValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.SpeedTrapMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.SpeedTrapMultiplierDetourAddress + 0x35, ViewModel.SpeedTrapMultiplierValue);
                break;
            }
            case 12:
            {           
                ViewModel.DroneModeHeightValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh5.DroneModeMaxHeightMultiDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh5.DroneModeMaxHeightMultiDetourAddress + 0x1E, ViewModel.DroneModeHeightValue);
                break;
            }
        }
    }

    private void WriteValueFh4(RoutedPropertyChangedEventArgs<double?> e)
    {
        switch (MainComboBox.SelectedIndex)
        {
            case 0:
            {        
                ViewModel.SpinPrizeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh4.PrizeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.PrizeScaleDetourAddress + 0x1C, ViewModel.SpinPrizeScaleValue);
                break;
            }
            case 1:
            {            
                ViewModel.SpinSellFactorValue = Convert.ToInt32(e.NewValue);
                if (MiscCheatsFh4.SellFactorDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.SellFactorDetourAddress + 0x1C, ViewModel.SpinSellFactorValue);
                break;
            }
            case 2:
            {              
                ViewModel.SkillScoreMultiplierValue = Convert.ToInt32(e.NewValue);
                if (MiscCheatsFh4.SkillScoreMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.SkillScoreMultiplierDetourAddress + 0x1C, ViewModel.SkillScoreMultiplierValue);
                break;
            }
            case 3:
            {           
                ViewModel.DriftScoreMultiplierValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh4.DriftScoreMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.DriftScoreMultiplierDetourAddress + 0x1D, ViewModel.DriftScoreMultiplierValue);
                break;
            }
            case 6:
            {            
                ViewModel.MissionTimeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh4.MissionTimeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.MissionTimeScaleDetourAddress + 0x20, ViewModel.MissionTimeScaleValue);
                break;
            }
            case 7:
            {           
                ViewModel.TrailblazerTimeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh4.TrailblazerTimeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.TrailblazerTimeScaleDetourAddress + 0x20, ViewModel.TrailblazerTimeScaleValue);
                break;
            }
            case 8:
            {           
                ViewModel.SpeedZoneMultiplierValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh4.SpeedZoneMultiplierDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.SpeedZoneMultiplierDetourAddress + 0x1F, ViewModel.SpeedZoneMultiplierValue);
                break;
            }
            case 9:
            {           
                ViewModel.RaceTimeScaleValue = Convert.ToSingle(e.NewValue);
                if (MiscCheatsFh4.RaceTimeScaleDetourAddress == 0) return;
                GetInstance().WriteMemory(MiscCheatsFh4.RaceTimeScaleDetourAddress + 0x1F, ViewModel.RaceTimeScaleValue);
                break;
            }
        }
    }
    
    private async void MainToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggleSwitch)
        {
            return;
        }

        ViewModel.MainUiElementsEnabled = false;
        switch (GameVerPlat.GetInstance().Type)
        {
            case GameVerPlat.GameType.Fh4:
                await EnableCheatFh4(toggleSwitch);
                break;
            case GameVerPlat.GameType.Fh5:
                await EnableCheat(toggleSwitch);
                break;
            case GameVerPlat.GameType.None:
            default:
                throw new IndexOutOfRangeException();
        }
        ViewModel.MainUiElementsEnabled = true;
    }

    private async Task EnableCheat(ToggleSwitch toggleSwitch)
    {
        switch (MainComboBox.SelectedIndex)
        {
            case 0:
            {
                await PrizeScale(toggleSwitch.IsOn);
                break;
            }
            case 1:
            {
                await SellFactor(toggleSwitch.IsOn);
                break;
            }
            case 2:
            {
                await SkillScoreMultiplier(toggleSwitch.IsOn);
                break;
            }
            case 3:
            {
                await DriftScoreMultiplier(toggleSwitch.IsOn);
                break;
            }
            case 4:
            {
                await SkillTreeWideEdit(toggleSwitch.IsOn);
                break;
            }
            case 5:
            {
                await SkillTreePerksCost(toggleSwitch.IsOn);
                break;
            }
            case 6:
            {
                await MissionTimeScale(toggleSwitch.IsOn);
                break;
            }
            case 7:
            {
                await TrailblazerTimeScale(toggleSwitch.IsOn);
                break;
            }
            case 8:
            {
                await SpeedZoneMultiplier(toggleSwitch.IsOn);
                break;
            }
            case 9:
            {
                await RaceTimeScale(toggleSwitch.IsOn);
                break;
            }
            case 10:
            {
                await DangerSignMultiplier(toggleSwitch.IsOn);
                break;
            }
            case 11:
            {
                await SpeedTrapMultiplier(toggleSwitch.IsOn);
                break;
            }
            case 12:
            {
                await DroneModeHeight(toggleSwitch.IsOn);
                break;
            }
        }
    }

    private async Task EnableCheatFh4(ToggleSwitch toggleSwitch)
    {
        switch (MainComboBox.SelectedIndex)
        {
            case 0:
            {
                await PrizeScaleFh4(toggleSwitch.IsOn);
                break;
            }
            case 1:
            {
                await SellFactorFh4(toggleSwitch.IsOn);
                break;
            }
            case 2:
            {
                await SkillScoreMultiplierFh4(toggleSwitch.IsOn);
                break;
            }
            case 3:
            {
                await DriftScoreMultiplierFh4(toggleSwitch.IsOn);
                break;
            }
            case 6:
            {
                await MissionTimeScaleFh4(toggleSwitch.IsOn);
                break;
            }
            case 7:
            {
                await TrailblazerTimeScaleFh4(toggleSwitch.IsOn);
                break;
            }
            case 8:
            {
                await SpeedZoneMultiplierFh4(toggleSwitch.IsOn);
                break;
            }
            case 9:
            {
                await RaceTimeScaleFh4(toggleSwitch.IsOn);
                break;
            }
        }
    }

    private async Task PrizeScale(bool toggled)
    {
        if (MiscCheatsFh5.PrizeScaleDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatPrizeScale();
        }

        if (MiscCheatsFh5.PrizeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.PrizeScaleDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.PrizeScaleDetourAddress + 0x1C, Convert.ToSingle(MainValueBox.Value));
        ViewModel.SpinPrizeScaleEnabled = toggled;
    }

    private async Task PrizeScaleFh4(bool toggled)
    {
        if (MiscCheatsFh4.PrizeScaleDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatPrizeScale();
        }

        if (MiscCheatsFh4.PrizeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.PrizeScaleDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.PrizeScaleDetourAddress + 0x1C, Convert.ToSingle(MainValueBox.Value));
        ViewModel.SpinPrizeScaleEnabled = toggled;
    }

    private async Task SellFactor(bool toggled)
    {
        if (MiscCheatsFh5.SellFactorDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatSellFactor();
        }
        
        if (MiscCheatsFh5.SellFactorDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.SellFactorDetourAddress + 0x1C, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.SellFactorDetourAddress + 0x1D, Convert.ToInt32(MainValueBox.Value));
        ViewModel.SpinSellFactorEnabled = toggled;
    }

    private async Task SellFactorFh4(bool toggled)
    {
        if (MiscCheatsFh4.SellFactorDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatSellFactor();
        }
        
        if (MiscCheatsFh4.SellFactorDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.SellFactorDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.SellFactorDetourAddress + 0x1C, Convert.ToInt32(MainValueBox.Value));
        ViewModel.SpinSellFactorEnabled = toggled;
    }

    private async Task SkillScoreMultiplier(bool toggled)
    {
        if (MiscCheatsFh5.SkillScoreMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatSkillScoreMultiplier();
        }
        
        if (MiscCheatsFh5.SkillScoreMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.SkillScoreMultiplierDetourAddress + 0x1C, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.SkillScoreMultiplierDetourAddress + 0x1D, Convert.ToInt32(MainValueBox.Value));
        ViewModel.SkillScoreMultiplierEnabled = toggled;
    }

    private async Task SkillScoreMultiplierFh4(bool toggled)
    {
        if (MiscCheatsFh4.SkillScoreMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatSkillScoreMultiplier();
        }
        
        if (MiscCheatsFh4.SkillScoreMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.SkillScoreMultiplierDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.SkillScoreMultiplierDetourAddress + 0x1C, Convert.ToInt32(MainValueBox.Value));
        ViewModel.SkillScoreMultiplierEnabled = toggled;
    }
    
    private async Task DriftScoreMultiplier(bool toggled)
    {
        if (MiscCheatsFh5.DriftScoreMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatDriftScoreMultiplier();
        }
        
        if (MiscCheatsFh5.DriftScoreMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.DriftScoreMultiplierDetourAddress + 0x1F, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.DriftScoreMultiplierDetourAddress + 0x20, Convert.ToSingle(MainValueBox.Value));
        ViewModel.DriftScoreMultiplierEnabled = toggled;
    }
    
    private async Task DriftScoreMultiplierFh4(bool toggled)
    {
        if (MiscCheatsFh4.DriftScoreMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatDriftScoreMultiplier();
        }
        
        if (MiscCheatsFh4.DriftScoreMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.DriftScoreMultiplierDetourAddress + 0x1C, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.DriftScoreMultiplierDetourAddress + 0x1D, Convert.ToSingle(MainValueBox.Value));
        ViewModel.DriftScoreMultiplierEnabled = toggled;
    }
    
    private async Task SkillTreeWideEdit(bool toggled)
    {
        if (MiscCheatsFh5.SkillTreeWideEditDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatSkillTreeWideEdit();
        }
        
        if (MiscCheatsFh5.SkillTreeWideEditDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.SkillTreeWideEditDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.SkillTreeWideEditDetourAddress + 0x1C, Convert.ToSingle(MainValueBox.Value));
        ViewModel.SkillTreeWideEditEnabled = toggled;
    }
    
    private async Task SkillTreePerksCost(bool toggled)
    {
        if (MiscCheatsFh5.SkillTreePerksCostDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatSkillTreePerksCost();
        }
        
        if (MiscCheatsFh5.SkillTreePerksCostDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.SkillTreePerksCostDetourAddress + 0x1A, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.SkillTreePerksCostDetourAddress + 0x1B, Convert.ToInt32(MainValueBox.Value));
        ViewModel.SkillTreeCostEnabled = toggled;
    }
    
    private async Task MissionTimeScale(bool toggled)
    {
        if (MiscCheatsFh5.MissionTimeScaleDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatMissionTimeScale();
        }
        
        if (MiscCheatsFh5.MissionTimeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.MissionTimeScaleDetourAddress + 0x22, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.MissionTimeScaleDetourAddress + 0x23, Convert.ToSingle(MainValueBox.Value));
        ViewModel.MissionTimeScaleEnabled = toggled;
    }
    
    private async Task MissionTimeScaleFh4(bool toggled)
    {
        if (MiscCheatsFh4.MissionTimeScaleDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatMissionTimeScale();
        }
        
        if (MiscCheatsFh4.MissionTimeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.MissionTimeScaleDetourAddress + 0x1F, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.MissionTimeScaleDetourAddress + 0x20, Convert.ToSingle(MainValueBox.Value));
        ViewModel.MissionTimeScaleEnabled = toggled;
    }
    
    private async Task TrailblazerTimeScale(bool toggled)
    {
        if (MiscCheatsFh5.TrailblazerTimeScaleDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatTrailblazerTimeScale();
        }
        
        if (MiscCheatsFh5.TrailblazerTimeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.TrailblazerTimeScaleDetourAddress + 0x22, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.TrailblazerTimeScaleDetourAddress + 0x23, Convert.ToSingle(MainValueBox.Value));
        ViewModel.TrailblazerTimeScaleEnabled = toggled;
    }
    
    private async Task TrailblazerTimeScaleFh4(bool toggled)
    {
        if (MiscCheatsFh4.TrailblazerTimeScaleDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatTrailblazerTimeScale();
        }
        
        if (MiscCheatsFh4.TrailblazerTimeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.TrailblazerTimeScaleDetourAddress + 0x1F, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.TrailblazerTimeScaleDetourAddress + 0x20, Convert.ToSingle(MainValueBox.Value));
        ViewModel.TrailblazerTimeScaleEnabled = toggled;
    }

    private async Task SpeedZoneMultiplier(bool toggled)
    {
        if (MiscCheatsFh5.SpeedZoneMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatSpeedZoneMultiplier();
        }
        
        if (MiscCheatsFh5.SpeedZoneMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.SpeedZoneMultiplierDetourAddress + 0x1F, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.SpeedZoneMultiplierDetourAddress + 0x20, Convert.ToSingle(MainValueBox.Value));
        ViewModel.SpeedZoneMultiplierEnabled = toggled;
    }

    private async Task SpeedZoneMultiplierFh4(bool toggled)
    {
        if (MiscCheatsFh4.SpeedZoneMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatSpeedZoneMultiplier();
        }
        
        if (MiscCheatsFh4.SpeedZoneMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.SpeedZoneMultiplierDetourAddress + 0x1E, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.SpeedZoneMultiplierDetourAddress + 0x1F, Convert.ToSingle(MainValueBox.Value));
        ViewModel.SpeedZoneMultiplierEnabled = toggled;
    }
    
    private async Task RaceTimeScale(bool toggled)
    {
        if (MiscCheatsFh5.RaceTimeScaleDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatRaceTimeScale();
        }
        
        if (MiscCheatsFh5.RaceTimeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.RaceTimeScaleDetourAddress + 0x34, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.RaceTimeScaleDetourAddress + 0x35, Convert.ToSingle(MainValueBox.Value));
        ViewModel.RaceTimeScaleEnabled = toggled;
    }
    
    private async Task RaceTimeScaleFh4(bool toggled)
    {
        if (MiscCheatsFh4.RaceTimeScaleDetourAddress == 0)
        {
            await MiscCheatsFh4.CheatRaceTimeScale();
        }
        
        if (MiscCheatsFh4.RaceTimeScaleDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh4.RaceTimeScaleDetourAddress + 0x1E, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh4.RaceTimeScaleDetourAddress + 0x1F, MainValueBox.Value.GetValueOrDefault());
        ViewModel.RaceTimeScaleEnabled = toggled;
    }
    
    private async Task DangerSignMultiplier(bool toggled)
    {
        if (MiscCheatsFh5.DangerSign1DetourAddress == 0 ||
            MiscCheatsFh5.DangerSign2DetourAddress == 0 ||
            MiscCheatsFh5.DangerSign3DetourAddress == 0)
        {
            await MiscCheatsFh5.CheatDangerSignMultiplier();
        }

        if (MiscCheatsFh5.DangerSign1DetourAddress == 0 ||
            MiscCheatsFh5.DangerSign2DetourAddress == 0 ||
            MiscCheatsFh5.DangerSign3DetourAddress == 0)
        {
            return;
        }
        
        GetInstance().WriteMemory(MiscCheatsFh5.DangerSign1DetourAddress + 0x37, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.DangerSign1DetourAddress + 0x38, Convert.ToSingle(MainValueBox.Value));
        GetInstance().WriteMemory(MiscCheatsFh5.DangerSign2DetourAddress + 0x34, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.DangerSign2DetourAddress + 0x35, Convert.ToSingle(MainValueBox.Value));
        GetInstance().WriteMemory(MiscCheatsFh5.DangerSign3DetourAddress + 0x34, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.DangerSign3DetourAddress + 0x35, Convert.ToSingle(MainValueBox.Value));
        ViewModel.DangerSignMultiplierEnabled = toggled;
    }

    private async Task SpeedTrapMultiplier(bool toggled)
    {
        if (MiscCheatsFh5.SpeedTrapMultiplierDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatSpeedTrapMultiplier();
        }
        
        if (MiscCheatsFh5.SpeedTrapMultiplierDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.SpeedTrapMultiplierDetourAddress + 0x34, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.SpeedTrapMultiplierDetourAddress + 0x35, Convert.ToSingle(MainValueBox.Value));
        ViewModel.SpeedTrapMultiplierEnabled = toggled;
    }

    private async Task DroneModeHeight(bool toggled)
    {
        if (MiscCheatsFh5.DroneModeMaxHeightMultiDetourAddress == 0)
        {
            await MiscCheatsFh5.CheatDroneModeMaxHeightMulti();
        }
        
        if (MiscCheatsFh5.DroneModeMaxHeightMultiDetourAddress == 0) return;
        GetInstance().WriteMemory(MiscCheatsFh5.DroneModeMaxHeightMultiDetourAddress + 0x1D, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(MiscCheatsFh5.DroneModeMaxHeightMultiDetourAddress + 0x1E, Convert.ToSingle(MainValueBox.Value));
        ViewModel.DroneModeHeightEnabled = toggled;
    }

    private async void UnbreakableSkillScoreSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggleSwitch)
        {
            return;
        }

        toggleSwitch.IsEnabled = false;
        switch (GameVerPlat.GetInstance().Type)
        {
            case GameVerPlat.GameType.Fh4:
            {
                if (MiscCheatsFh4.UnbreakableSkillScoreDetourAddress == 0)
                {
                    await MiscCheatsFh4.CheatUnbreakableSkillScore();
                }
                break;
            }
            case GameVerPlat.GameType.Fh5:
            {
                if (MiscCheatsFh5.UnbreakableSkillScoreDetourAddress == 0)
                {
                    await MiscCheatsFh5.CheatUnbreakableSkillScore();
                }
                break;
            }
            case GameVerPlat.GameType.None:
            default:
                throw new IndexOutOfRangeException();
        }
        toggleSwitch.IsEnabled = true;
        
        var detourAddress = GameVerPlat.GetInstance().Type switch
        {
            GameVerPlat.GameType.Fh4 => MiscCheatsFh4.UnbreakableSkillScoreDetourAddress,
            GameVerPlat.GameType.Fh5 => MiscCheatsFh5.UnbreakableSkillScoreDetourAddress,
            _ => throw new IndexOutOfRangeException()
        };
        
        if (detourAddress == 0) return;
        GetInstance().WriteMemory(detourAddress + 0x1A, toggleSwitch.IsOn ? (byte)1 : (byte)0);
    }

    private async void RemoveBuildCapSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggleSwitch)
        {
            return;
        }

        toggleSwitch.IsEnabled = false;
        switch (GameVerPlat.GetInstance().Type)
        {
            case GameVerPlat.GameType.Fh4:
            {
                if (MiscCheatsFh4.RemoveBuildCapDetourAddress == 0)
                {
                    await MiscCheatsFh4.CheatRemoveBuildCap();
                }
                break;
            }
            case GameVerPlat.GameType.Fh5:
            {
                if (MiscCheatsFh5.RemoveBuildCapDetourAddress == 0)
                {
                    await MiscCheatsFh5.CheatRemoveBuildCap();
                }
                break;
            }
            case GameVerPlat.GameType.None:
            default:
                throw new IndexOutOfRangeException();
        }
        toggleSwitch.IsEnabled = true;
        
        var detourAddress = GameVerPlat.GetInstance().Type switch
        {
            GameVerPlat.GameType.Fh4 => MiscCheatsFh4.RemoveBuildCapDetourAddress,
            GameVerPlat.GameType.Fh5 => MiscCheatsFh5.RemoveBuildCapDetourAddress,
            _ => throw new IndexOutOfRangeException()
        };
        
        if (detourAddress == 0) return;
        GetInstance().WriteMemory(detourAddress + 0x16, toggleSwitch.IsOn ? (byte)1 : (byte)0);
    }
}