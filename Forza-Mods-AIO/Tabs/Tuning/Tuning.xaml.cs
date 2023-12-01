﻿using System.Collections.Generic;
using System.Windows;
using Forza_Mods_AIO.Resources;

namespace Forza_Mods_AIO.Tabs.Tuning;

public partial class Tuning
{
    public static Tuning? T;
    public readonly UiManager UiManager;

    public Tuning()
    {
        InitializeComponent();
        T = this;
        UiManager = new UiManager(this, AOBProgressBar, Sizes, IsClicked);
        UiManager.ToggleUiElements(false);
    }

    #region Interaction
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        UiManager.ToggleDropDown(sender);
    }
        
    private static readonly Dictionary<string, double> Sizes = new()
    {
        { "TiresButton" , 240 }, // Button name for page, height of page
        { "GearingButton" , 275 },
        { "AlignmentButton" , 120 },
        { "SpringsButton" , 295 },
        { "DampingButton" , 460 },
        { "AeroButton", 120 },
        { "SteeringButton", 275 },
        { "OthersButton", 395 },
    };

    private static readonly Dictionary<string, bool> IsClicked = new()
    {
        // Tuning
        {"TiresButton", false },
        {"GearingButton", false },
        {"AlignmentButton", false },
        {"SpringsButton", false },
        {"DampingButton", false },
        {"AeroButton", false },
        {"SteeringButton", false },
        {"OthersButton", false }
    };
    #endregion
}