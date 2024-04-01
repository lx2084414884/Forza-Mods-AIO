using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Forza_Mods_AIO.Cheats.ForzaHorizon5;
using static Forza_Mods_AIO.Resources.Cheats;

namespace Forza_Mods_AIO.ViewModels.Pages;

public partial class AutoshowViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _uiElementsEnabled = true;
    
    private static Sql SqlFh5 => GetClass<Sql>();

    [RelayCommand]
    private async Task ExecuteSql(object parameter)
    {
        if (parameter is not string sParam)
        {
            return;
        }
        
        UiElementsEnabled = false;
        if (!SqlFh5.WereScansSuccessful)
        {
            await SqlFh5.SqlExecAobScan();
        }

        if (!SqlFh5.WereScansSuccessful)
        {
            goto SkipQuerying;
        }
        
        await SqlFh5.Query(sParam);
        
        SkipQuerying:
        UiElementsEnabled = true;
    }
}