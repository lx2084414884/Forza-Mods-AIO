using System.Windows;
using System.Windows.Controls;
using Forza_Mods_AIO.Cheats.ForzaHorizon5;
using Forza_Mods_AIO.Models;
using Forza_Mods_AIO.ViewModels.SubPages.SelfVehicle;
using MahApps.Metro.Controls;
using static Forza_Mods_AIO.Resources.Cheats;
using static Forza_Mods_AIO.Resources.Memory;

namespace Forza_Mods_AIO.Views.SubPages.SelfVehicle;

public partial class Unlocks
{
    public Unlocks()
    {
        ViewModel = new UnlocksViewModel();
        DataContext = this;
        
        InitializeComponent();
    }

    public UnlocksViewModel ViewModel { get; }
    private static UnlocksCheats UnlocksCheatsFh5 => GetClass<UnlocksCheats>();
    private static Cheats.ForzaHorizon4.UnlocksCheats UnlocksCheatsFh4 =>
        GetClass<Cheats.ForzaHorizon4.UnlocksCheats>();
    
    private async void ToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggleSwitch)
        {
            return;
        }

        ViewModel.AreUiElementsEnabled = false;

        switch (UnlockBox.SelectedIndex)
        {
            case 0:
            {
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    await CreditsFh4(toggleSwitch.IsOn);
                }
                else
                {
                    await Credits(toggleSwitch.IsOn);
                }
                break;
            }
            case 1:
            {
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    await XpFh4(toggleSwitch.IsOn);
                }
                else
                {
                    await Xp(toggleSwitch.IsOn);
                }
                break;
            }
            case 2:
            {
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    await WheelspinsFh4(toggleSwitch.IsOn);
                }
                else
                {
                    await Wheelspins(toggleSwitch.IsOn);
                }
                break;
            }
            case 3:
            {
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    await SkillPointsFh4(toggleSwitch.IsOn);
                }
                else
                {
                    await SkillPoints(toggleSwitch.IsOn);
                }
                break;
            }
            case 4:
            {
                await Series(toggleSwitch.IsOn);
                break;
            }
            case 5:
            {
                await Seasonal(toggleSwitch.IsOn);
                break;
            }
        }

        ViewModel.AreUiElementsEnabled = true;
    }

    private async Task Credits(bool toggled)
    {
        if (UnlocksCheatsFh5.CreditsDetourAddress == 0)
        {
            await UnlocksCheatsFh5.CheatCredits();
        }

        if (UnlocksCheatsFh5.CreditsDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh5.CreditsDetourAddress + 0x31, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.CreditsDetourAddress + 0x32, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsCreditsEnabled = toggled;
    }
    
    private async Task CreditsFh4(bool toggled)
    {
        if (UnlocksCheatsFh4.CreditsDetourAddress == 0)
        {
            await UnlocksCheatsFh4.CheatCredits();
        }

        if (UnlocksCheatsFh4.CreditsDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh4.CreditsDetourAddress + 0x24, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh4.CreditsDetourAddress + 0x25, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsCreditsEnabled = toggled;
    }

    private async Task Xp(bool toggled)
    {
        if (UnlocksCheatsFh5.XpDetourAddress == 0)
        {
            await UnlocksCheatsFh5.CheatXp();
        }

        if (UnlocksCheatsFh5.XpDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh5.XpPointsDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.XpDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.XpDetourAddress + 0x1C, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsXpEnabled = toggled;
    }
    
    private async Task XpFh4(bool toggled)
    {
        if (UnlocksCheatsFh4.XpDetourAddress == 0)
        {
            await UnlocksCheatsFh4.CheatXp();
        }

        if (UnlocksCheatsFh4.XpDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh4.XpPointsDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh4.XpDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh4.XpDetourAddress + 0x1C, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsXpEnabled = toggled;
    }

    private async Task Wheelspins(bool toggled)
    {
        if (UnlocksCheatsFh5.SpinsDetourAddress == 0)
        {
            await UnlocksCheatsFh5.CheatSpins();
        }

        if (UnlocksCheatsFh5.SpinsDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh5.SpinsDetourAddress + 0x1C, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.SpinsDetourAddress + 0x1D, ViewModel.WheelspinsValue);  
        ViewModel.IsWheelspinsEnabled = toggled;
    }

    private async Task WheelspinsFh4(bool toggled)
    {
        if (UnlocksCheatsFh4.SpinsDetourAddress == 0)
        {
            await UnlocksCheatsFh4.CheatSpins();
        }

        if (UnlocksCheatsFh4.SpinsDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh4.SpinsDetourAddress + 0x1A, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh4.SpinsDetourAddress + 0x1B, ViewModel.WheelspinsValue);  
        ViewModel.IsWheelspinsEnabled = toggled;
    }

    private async Task SkillPoints(bool toggled)
    {
        if (UnlocksCheatsFh5.SkillPointsDetourAddress == 0)
        {
            await UnlocksCheatsFh5.CheatSkillPoints();
        }

        if (UnlocksCheatsFh5.SkillPointsDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh5.SkillPointsDetourAddress + 0x19, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.SkillPointsDetourAddress + 0x1A, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsSkillPointsEnabled = toggled;
    }

    private async Task SkillPointsFh4(bool toggled)
    {
        if (UnlocksCheatsFh4.SkillPointsDetourAddress == 0)
        {
            await UnlocksCheatsFh4.CheatSkillPoints();
        }

        if (UnlocksCheatsFh4.SkillPointsDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh4.SkillPointsDetourAddress + 0x1C, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh4.SkillPointsDetourAddress + 0x1D, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsSkillPointsEnabled = toggled;
    }
    
    private async Task Seasonal(bool toggled)
    {
        if (UnlocksCheatsFh5.SeasonalDetourAddress == 0)
        {
            await UnlocksCheatsFh5.CheatSeasonal();
        }

        if (UnlocksCheatsFh5.SeasonalDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh5.SeasonalDetourAddress + 0x23, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.SeasonalDetourAddress + 0x24, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsSeasonalEnabled = toggled;
    }
    
    private async Task Series(bool toggled)
    {
        if (UnlocksCheatsFh5.SeriesDetourAddress == 0)
        {
            await UnlocksCheatsFh5.CheatSeries();
        }

        if (UnlocksCheatsFh5.SeriesDetourAddress <= 0) return;
        GetInstance().WriteMemory(UnlocksCheatsFh5.SeriesDetourAddress + 0x1B, toggled ? (byte)1 : (byte)0);
        GetInstance().WriteMemory(UnlocksCheatsFh5.SeriesDetourAddress + 0x1C, Convert.ToInt32(ValueBox.Value));  
        ViewModel.IsSeriesEnabled = toggled;
    }

    private void UnlockBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (UnlockSwitch == null || sender is not ComboBox comboBox)
        {
            return;
        }

        // ReSharper disable once AssignNullToNotNullAttribute
        while (((ComboBoxItem)comboBox.Items[comboBox.SelectedIndex]).Visibility == Visibility.Collapsed)
        {
            comboBox.SelectedIndex -= 1;
        }
        
        UnlockSwitch.Toggled -= ToggleSwitch_OnToggled;

        switch (UnlockBox.SelectedIndex)
        {
            case 0:
            {
                ValueBox.Value = ViewModel.CreditsValue;
                UnlockSwitch.IsOn = ViewModel.IsCreditsEnabled;
                break;
            }
            case 1:
            {
                ValueBox.Value = ViewModel.XpValue;
                UnlockSwitch.IsOn = ViewModel.IsXpEnabled;
                break;
            }
            case 2:
            {
                ValueBox.Value = ViewModel.WheelspinsValue;
                UnlockSwitch.IsOn = ViewModel.IsWheelspinsEnabled;
                break;
            }
            case 3:
            {
                ValueBox.Value = ViewModel.SkillPointsValue;
                UnlockSwitch.IsOn = ViewModel.IsSkillPointsEnabled;
                break;
            }
            case 4:
            {
                ValueBox.Value = ViewModel.SeriesValue;
                UnlockSwitch.IsOn = ViewModel.IsSeriesEnabled;
                break;
            }
            case 5:
            {
                ValueBox.Value = ViewModel.SeasonalValue;
                UnlockSwitch.IsOn = ViewModel.IsSeasonalEnabled;
                break;
            }
        }
        
        UnlockSwitch.Toggled += ToggleSwitch_OnToggled;
    }

    private void ValueBox_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
    {
        switch (UnlockBox.SelectedIndex)
        {
            case 0:
            {
                ViewModel.CreditsValue = Convert.ToInt32(ValueBox.Value);
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    if (UnlocksCheatsFh4.CreditsDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh4.CreditsDetourAddress + 0x25, ViewModel.CreditsValue);
                }
                else
                {
                    if (UnlocksCheatsFh5.CreditsDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh5.CreditsDetourAddress + 0x32, ViewModel.CreditsValue);
                }
                break;
            }
            case 1:
            {
                ViewModel.XpValue = Convert.ToInt32(ValueBox.Value);
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    if (UnlocksCheatsFh4.XpDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh4.XpDetourAddress + 0x1C, ViewModel.XpValue);  
                }
                else
                {
                    if (UnlocksCheatsFh5.XpDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh5.XpDetourAddress + 0x1C, ViewModel.XpValue);  
                }
                break;
            }
            case 2:
            {
                ViewModel.WheelspinsValue = Convert.ToInt32(ValueBox.Value);
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    if (UnlocksCheatsFh4.SpinsDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh4.SpinsDetourAddress + 0x1B, ViewModel.WheelspinsValue);  
                }
                else
                {
                    if (UnlocksCheatsFh5.SpinsDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh5.SpinsDetourAddress + 0x1D, ViewModel.WheelspinsValue);  
                }
                break;
            }
            case 3:
            {
                ViewModel.SkillPointsValue = Convert.ToInt32(ValueBox.Value);
                if (GameVerPlat.GetInstance().Type == GameVerPlat.GameType.Fh4)
                {
                    if (UnlocksCheatsFh5.SkillPointsDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh5.SkillPointsDetourAddress + 0x1D, ViewModel.SkillPointsValue);  
                }
                else
                {
                    if (UnlocksCheatsFh5.SkillPointsDetourAddress <= 0) return;
                    GetInstance().WriteMemory(UnlocksCheatsFh5.SkillPointsDetourAddress + 0x1A, ViewModel.SkillPointsValue);  
                }
                break;
            }
            case 4:
            {
                ViewModel.SeriesValue = Convert.ToInt32(ValueBox.Value);
                if (UnlocksCheatsFh5.SeriesDetourAddress <= 0) return;
                GetInstance().WriteMemory(UnlocksCheatsFh5.SeriesDetourAddress + 0x1C, Convert.ToInt32(ValueBox.Value));  
                break;
            }
            case 5:
            {
                ViewModel.SeasonalValue = Convert.ToInt32(ValueBox.Value);
                if (UnlocksCheatsFh5.SeasonalDetourAddress <= 0) return;
                GetInstance().WriteMemory(UnlocksCheatsFh5.SeasonalDetourAddress + 0x24, Convert.ToInt32(ValueBox.Value));  
                break;
            }
        }
    }
}