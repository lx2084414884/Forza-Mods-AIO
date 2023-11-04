﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Forza_Mods_AIO.Resources;

namespace Forza_Mods_AIO.Tabs.AutoShowTab;

/// <summary>
///     Interaction logic for AutoShow.xaml
/// </summary>
public partial class AutoShow
{
    public static AutoShow AS;
    public static readonly byte[] Sql13OriginalBytes = { 0x55, 0x50, 0x44, 0x41, 0x54, 0x45, 0x20, 0x25, 0x73, 0x43, 0x61, 0x72, 0x65, 0x65, 0x72, 0x5F, 0x47, 0x61, 0x72, 0x61, 0x67, 0x65, 0x20, 0x53, 0x45, 0x54, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x44, 0x6F, 0x77, 0x6E, 0x66, 0x6F, 0x72, 0x63, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x44, 0x6F, 0x77, 0x6E, 0x66, 0x6F, 0x72, 0x63, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x69, 0x6E, 0x61, 0x6C, 0x44, 0x72, 0x69, 0x76, 0x65, 0x52, 0x61, 0x74, 0x69, 0x6F, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x69, 0x72, 0x73, 0x74, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x73, 0x65, 0x63, 0x6F, 0x6E, 0x64, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x74, 0x68, 0x69, 0x72, 0x64, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x6F, 0x75, 0x72, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x69, 0x66, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x73, 0x69, 0x78, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x73, 0x65, 0x76, 0x65, 0x6E, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x65, 0x69, 0x67, 0x68, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x6E, 0x69, 0x6E, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x74, 0x65, 0x6E, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x62, 0x72, 0x61, 0x6B, 0x65, 0x42, 0x61, 0x6C, 0x61, 0x6E, 0x63, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x62, 0x72, 0x61, 0x6B, 0x65, 0x50, 0x72, 0x65, 0x73, 0x73, 0x75, 0x72, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x63, 0x65, 0x6E, 0x74, 0x65, 0x72, 0x54, 0x6F, 0x72, 0x71, 0x75, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x54, 0x69, 0x72, 0x65, 0x50, 0x72, 0x65, 0x73, 0x73, 0x75, 0x72, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x43, 0x61, 0x6D, 0x62, 0x65, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x54, 0x6F, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x43, 0x61, 0x73, 0x74, 0x65, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x53, 0x70, 0x72, 0x69, 0x6E, 0x67, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x53, 0x77, 0x61, 0x79, 0x62, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x52, 0x69, 0x64, 0x65, 0x48, 0x65, 0x69, 0x67, 0x68, 0x74, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x44, 0x61, 0x6D, 0x70, 0x69, 0x6E, 0x67, 0x53, 0x74, 0x69, 0x66, 0x66, 0x6E, 0x65, 0x73, 0x73, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x42, 0x75, 0x6D, 0x70, 0x52, 0x61, 0x74, 0x69, 0x6F, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x41, 0x63, 0x63, 0x65, 0x6C, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x44, 0x65, 0x63, 0x65, 0x6C, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x54, 0x69, 0x72, 0x65, 0x50, 0x72, 0x65, 0x73, 0x73, 0x75, 0x72, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x43, 0x61, 0x6D, 0x62, 0x65, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x54, 0x6F, 0x65, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x53, 0x70, 0x72, 0x69, 0x6E, 0x67, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x53, 0x77, 0x61, 0x79, 0x62, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x52, 0x69, 0x64, 0x65, 0x48, 0x65, 0x69, 0x67, 0x68, 0x74, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x44, 0x61, 0x6D, 0x70, 0x69, 0x6E, 0x67, 0x53, 0x74, 0x69, 0x66, 0x66, 0x6E, 0x65, 0x73, 0x73, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x42, 0x75, 0x6D, 0x70, 0x52, 0x61, 0x74, 0x69, 0x6F, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x41, 0x63, 0x63, 0x65, 0x6C, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x44, 0x65, 0x63, 0x65, 0x6C, 0x20, 0x3D, 0x20, 0x25, 0x31, 0x2E, 0x38, 0x65, 0x2C, 0x20, 0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x65, 0x64, 0x54, 0x75, 0x6E, 0x65, 0x49, 0x64, 0x20, 0x3D, 0x20, 0x27, 0x25, 0x73, 0x27, 0x20, 0x57, 0x48, 0x45, 0x52, 0x45, 0x20, 0x49, 0x64, 0x20, 0x3D, 0x20, 0x25, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55, 0x50, 0x44, 0x41, 0x54, 0x45, 0x20, 0x25, 0x73, 0x43, 0x61, 0x72, 0x65, 0x65, 0x72, 0x5F, 0x47, 0x61, 0x72, 0x61, 0x67, 0x65, 0x20, 0x53, 0x45, 0x54, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x44, 0x6F, 0x77, 0x6E, 0x66, 0x6F, 0x72, 0x63, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x44, 0x6F, 0x77, 0x6E, 0x66, 0x6F, 0x72, 0x63, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x69, 0x6E, 0x61, 0x6C, 0x44, 0x72, 0x69, 0x76, 0x65, 0x52, 0x61, 0x74, 0x69, 0x6F, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x69, 0x72, 0x73, 0x74, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x73, 0x65, 0x63, 0x6F, 0x6E, 0x64, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x74, 0x68, 0x69, 0x72, 0x64, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x6F, 0x75, 0x72, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x69, 0x66, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x73, 0x69, 0x78, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x73, 0x65, 0x76, 0x65, 0x6E, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x65, 0x69, 0x67, 0x68, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x6E, 0x69, 0x6E, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x74, 0x65, 0x6E, 0x74, 0x68, 0x47, 0x65, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x62, 0x72, 0x61, 0x6B, 0x65, 0x42, 0x61, 0x6C, 0x61, 0x6E, 0x63, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x62, 0x72, 0x61, 0x6B, 0x65, 0x50, 0x72, 0x65, 0x73, 0x73, 0x75, 0x72, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x63, 0x65, 0x6E, 0x74, 0x65, 0x72, 0x54, 0x6F, 0x72, 0x71, 0x75, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x54, 0x69, 0x72, 0x65, 0x50, 0x72, 0x65, 0x73, 0x73, 0x75, 0x72, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x43, 0x61, 0x6D, 0x62, 0x65, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x54, 0x6F, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x43, 0x61, 0x73, 0x74, 0x65, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x53, 0x70, 0x72, 0x69, 0x6E, 0x67, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x53, 0x77, 0x61, 0x79, 0x62, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x52, 0x69, 0x64, 0x65, 0x48, 0x65, 0x69, 0x67, 0x68, 0x74, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x44, 0x61, 0x6D, 0x70, 0x69, 0x6E, 0x67, 0x53, 0x74, 0x69, 0x66, 0x66, 0x6E, 0x65, 0x73, 0x73, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x42, 0x75, 0x6D, 0x70, 0x52, 0x61, 0x74, 0x69, 0x6F, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x41, 0x63, 0x63, 0x65, 0x6C, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x66, 0x72, 0x6F, 0x6E, 0x74, 0x44, 0x65, 0x63, 0x65, 0x6C, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x54, 0x69, 0x72, 0x65, 0x50, 0x72, 0x65, 0x73, 0x73, 0x75, 0x72, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x43, 0x61, 0x6D, 0x62, 0x65, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x54, 0x6F, 0x65, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x53, 0x70, 0x72, 0x69, 0x6E, 0x67, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E, 0x67, 0x5F, 0x72, 0x65, 0x61, 0x72, 0x53, 0x77, 0x61, 0x79, 0x62, 0x61, 0x72, 0x20, 0x3D, 0x20, 0x2D, 0x31, 0x2E, 0x30, 0x2C, 0x20, 0x54, 0x75, 0x6E, 0x69, 0x6E };
    private string ClearGarageString = "DELETE FROM Profile0_Career_Garage WHERE Id > 0;";
    private const string FreePerfString = "UPDATE List_UpgradeAntiSwayFront SET price=0;UPDATE List_UpgradeAntiSwayRear SET price=0;UPDATE List_UpgradeBrakes SET price=0;UPDATE List_UpgradeCarBodyChassisStiffness SET price=0;UPDATE List_UpgradeCarBody SET price=0;UPDATE List_UpgradeCarBodyTireWidthFront SET price=0;UPDATE List_UpgradeCarBodyTireWidthRear SET price=0;UPDATE List_UpgradeCarBodyTrackSpacingFront SET price=0;UPDATE List_UpgradeCarBodyTrackSpacingRear SET price=0;UPDATE List_UpgradeCarBodyWeight SET price=0;UPDATE List_UpgradeDrivetrain SET price=0;UPDATE List_UpgradeDrivetrainClutch SET price=0;UPDATE List_UpgradeDrivetrainDifferential  SET price=0;UPDATE List_UpgradeDrivetrainDriveline SET price=0;UPDATE List_UpgradeDrivetrainTransmission SET price=0;UPDATE List_UpgradeEngine SET price=0;UPDATE List_UpgradeEngineCamshaft SET price=0;UPDATE List_UpgradeEngineCSC SET price=0;UPDATE List_UpgradeEngineDisplacement SET price=0;UPDATE List_UpgradeEngineDSC SET price=0;UPDATE List_UpgradeEngineExhaust SET price=0;UPDATE List_UpgradeEngineFlywheel SET price=0;UPDATE List_UpgradeEngineFuelSystem SET price=0;UPDATE List_UpgradeEngineIgnition SET price=0;UPDATE List_UpgradeEngineIntake SET price=0;UPDATE List_UpgradeEngineIntercooler SET price=0;UPDATE List_UpgradeEngineManifold SET price=0;UPDATE List_UpgradeEngineOilCooling SET price=0;UPDATE List_UpgradeEnginePistonsCompression SET price=0;UPDATE List_UpgradeEngineRestrictorPlate SET price=0;UPDATE List_UpgradeEngineTurboQuad SET price=0;UPDATE List_UpgradeEngineTurboSingle SET price=0;UPDATE List_UpgradeEngineTurboTwin SET price=0;UPDATE List_UpgradeEngineValves SET price=0;UPDATE List_UpgradeMotor SET price=0;UPDATE List_UpgradeMotorParts SET price=0;UPDATE List_UpgradeSpringDamper SET price=0;UPDATE List_UpgradeTireCompound SET price=0;UPDATE List_Wheels SET price=1;";
    private const string FreeVisualString = "UPDATE List_UpgradeCarBody SET price=0;UPDATE List_UpgradeCarBodyFrontBumper SET price=0;UPDATE List_UpgradeCarBodyHood SET price=0;UPDATE List_UpgradeCarBodyRearBumper SET price=0;UPDATE List_UpgradeCarBodySideSkirt SET price=0;UPDATE List_UpgradeRearWing SET price=0;UPDATE List_Wheels SET price=1;";
    private const string Sql12OriginalString = "UPDATE %s SET TopSpeed=%f, DistanceDriven=%u, TimeDriven=%u, TotalWinnings=%u, TotalRepairs=%u, NumPodiums=%u, NumVictories=%u, NumRaces=%u, NumOwners=%u, NumTimesSold=%u, TimeDrivenInRoadTrips=%u, CurOwnerNumRaces=%u, CurOwnerWinnings=%u, NumSkillPointsEarned=%u, HighestSkillScore=%u, HasCurrentOwnerViewedCar=%u WHERE Id=%u                                     ";
    private const string Sql12EraseString = "                                                                                                                                                                                                                                                                                                                                                                           ";
    private const string Sql13EraseString = "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                ";
    
    public AutoShow()
    {
        InitializeComponent();
        AS = this;
        UpdateUi.UpdateUI(false, this);
    }

    private void ToggleAllCars_Toggled(object sender, RoutedEventArgs e)
    {
        ToggleRareCars.IsEnabled = !ToggleRareCars.IsEnabled;
        switch (ToggleAllCars.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ToggleAllCars.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("CREATE TABLE AutoshowTable(Id INT, NotAvailableInAutoshow INT); INSERT INTO AutoshowTable SELECT Id, NotAvailableInAutoshow FROM Data_Car; UPDATE Data_Car SET NotAvailableInAutoshow = 0;");
                    if (!Done)
                    {
                        Dispatcher.BeginInvoke(delegate () 
                        { 
                            ToggleAllCars.Toggled -= ToggleAllCars_Toggled; 
                            ToggleAllCars.IsOn = false;
                            ToggleAllCars.Toggled += ToggleAllCars_Toggled;
                        });
                    }

                    Dispatcher.BeginInvoke(delegate () { ToggleAllCars.IsEnabled = true; });
                });
                break;
            }
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql5, "                            ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql3, "                  ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql7, "                                           ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql1, "    Garage.IsInstalled            AS PurchasableCar,");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql9, "                                    ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql8, "           1215=");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql4, "      1215=");
                if (AutoshowVars.sql17 != "0")
                    MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql17, "                     ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ToggleAllCars.IsEnabled = false; });
                    AutoshowVars.ExecSQL("UPDATE Data_Car SET NotAvailableInAutoshow = (SELECT NotAvailableInAutoshow FROM AutoshowTable WHERE Data_Car.Id == AutoshowTable.Id); DROP TABLE AutoshowTable;");
                    Dispatcher.BeginInvoke(delegate () { ToggleAllCars.IsEnabled = true; });
                });
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql5, "AND NotAvailableInAutoshow=0");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql3, "AND NOT IsBarnFind");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql7, "AND IsCarVisibleAndReleased(Garage.ModelId)"); 
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql1, "NOT Garage.NotAvailableInAutoshow AS PurchasableCar,");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql9, "AND UnobtainableCars.Ordinal IS NULL");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql8, "Garage.ModelId!=");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql4, "Garage.Id!=");

                if (AutoshowVars.sql17 != "0")
                    MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql17,  "AND NOT IsMidnightCar"); 
                break;
            }
        }
    }

    private void ToggleRareCars_Toggled(object sender, RoutedEventArgs e)
    {
        ToggleAllCars.IsEnabled = !ToggleAllCars.IsEnabled;
            
        switch (ToggleRareCars.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ToggleRareCars.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("CREATE TABLE AutoshowTable(Id INT, NotAvailableInAutoshow INT); INSERT INTO AutoshowTable SELECT Id, NotAvailableInAutoshow FROM Data_Car; UPDATE Data_Car SET NotAvailableInAutoshow = CASE WHEN 1 THEN 0 WHEN 0 THEN 1 END;");
                    if (!Done)
                    {
                        Dispatcher.BeginInvoke(delegate () 
                        { 
                            ToggleRareCars.Toggled -= ToggleRareCars_Toggled; 
                            ToggleRareCars.IsOn = false;
                            ToggleRareCars.Toggled += ToggleRareCars_Toggled;
                        });
                    }

                    Dispatcher.BeginInvoke(delegate () { ToggleRareCars.IsEnabled = true; });
                });
                break;
            }
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql6, "=1                                    ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql3, "                  ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql1, "    Garage.IsInstalled            AS PurchasableCar,");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql9, "                                    ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql8, "           1215=");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql4, "      1215=");
                if (AutoshowVars.sql17 != "0")
                    MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql17, "                     ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ToggleRareCars.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("UPDATE Data_Car SET NotAvailableInAutoshow = (SELECT NotAvailableInAutoshow FROM AutoshowTable WHERE Data_Car.Id == AutoshowTable.Id); DROP TABLE AutoshowTable;");
                    if (!Done)
                    {
                        Dispatcher.BeginInvoke(delegate()
                        {
                            ToggleRareCars.Toggled -= ToggleRareCars_Toggled; 
                            ToggleRareCars.IsOn = false;
                            ToggleRareCars.Toggled += ToggleRareCars_Toggled;
                        });
                    }

                    Dispatcher.BeginInvoke(delegate () { ToggleRareCars.IsEnabled = true; });
                });
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql6, "=0                                    ");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql3, "AND NOT IsBarnFind");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql1, "NOT Garage.NotAvailableInAutoshow AS PurchasableCar,");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql9, "AND UnobtainableCars.Ordinal IS NULL");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql8, "Garage.ModelId!=");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql4, "Garage.Id!=");

                if (AutoshowVars.sql17 != "0")
                    MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql17, "AND NOT IsMidnightCar"); 
                break;
            }
        }
    }

    private void ToggleFreeCars_Toggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            UnlockHiddenPresets.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            FixThumbnails.IsEnabled = !FixThumbnails.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            ClearGarage.IsEnabled = !ClearGarage.IsEnabled;
            ClearTag.IsEnabled = !ClearTag.IsEnabled;
        }
            
        switch (ToggleFreeCars.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ToggleFreeCars.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("CREATE TABLE CostTable(Id INT, BaseCost INT,); INSERT INTO CostTable(Id, BaseCost) SELECT Id, BaseCost FROM Data_car; UPDATE Data_Car SET BaseCost = 0;");
                    if (!Done)
                    {
                        Dispatcher.BeginInvoke(delegate()
                        {
                            ToggleFreeCars.Toggled -= ToggleFreeCars_Toggled; 
                            ToggleFreeCars.IsOn = false;
                            ToggleFreeCars.Toggled += ToggleFreeCars_Toggled;
                        });
                    }

                    Dispatcher.BeginInvoke(delegate () { ToggleFreeCars.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12,"UPDATE Data_Car SET BaseCost = 0 WHERE BaseCost >0                                                                                                                                                                                                                                                                                                                         ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ToggleFreeCars.IsEnabled = false; });
                    AutoshowVars.ExecSQL("UPDATE Data_Car SET BaseCost = (SELECT BaseCost FROM CostTable WHERE Id = Data_Car.Id); DROP TABLE CostTable;");
                    Dispatcher.BeginInvoke(delegate () { ToggleFreeCars.IsEnabled = true; });
                });
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, Sql12OriginalString);
                break;
            }
        }
    }

    private void PaintLegoCars_OnToggled(object sender, RoutedEventArgs e)
    {
        switch (PaintLegoCars.IsOn)
        {
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql15, "b");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql16, "b");
                break;
            }
            case false:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql15, "H");
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql16, "H");
                break;
            }
        }
    }


    private void RemoveAnyCar_OnToggled(object sender, RoutedEventArgs e)
    {
        if (RemoveAnyCar.IsOn)
        {
            MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql11, "b");
            MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql2, "b");
        }
        else
        {
            MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql11, "D");
            MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql2, "I");
        }
    }

    private void ClearGarage_OnToggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            ToggleFreeCars.IsEnabled = !ToggleFreeCars.IsEnabled;
            UnlockHiddenPresets.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            FixThumbnails.IsEnabled = !FixThumbnails.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            ClearTag.IsEnabled = !ClearTag.IsEnabled;
        }
            
        switch (ClearGarage.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ClearGarage.IsEnabled = false; });
                    var Done = AutoshowVars.ExecSQL(ClearGarageString);
                    if (!Done)
                    {
                        Dispatcher.BeginInvoke(delegate () { ClearGarage.IsOn = false; });
                    }
                        
                    Dispatcher.BeginInvoke(delegate () { ClearGarage.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, Sql12EraseString);
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, ClearGarageString);
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, Sql12OriginalString);
                break;
            }
        }
    }

    private void FixThumbnails_OnToggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            ToggleFreeCars.IsEnabled = !ToggleFreeCars.IsEnabled;
            UnlockHiddenPresets.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            ClearGarage.IsEnabled = !ClearGarage.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            ClearTag.IsEnabled = !ClearTag.IsEnabled;
        }
            
        switch (FixThumbnails.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { FixThumbnails.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("UPDATE Profile0_Career_Garage SET Thumbnail=(SELECT Thumbnail FROM Data_Car WHERE Data_Car.Id = Profile0_Career_Garage.CarId); UPDATE Profile0_Career_Garage; UPDATE Profile0_Career_Garage SET NumOwners=69");
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { FixThumbnails.IsOn = false; });

                    Dispatcher.BeginInvoke(delegate () { FixThumbnails.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE Profile0_Career_Garage SET Thumbnail=(SELECT Thumbnail FROM Data_Car WHERE Data_Car.Id = Profile0_Career_Garage.CarId); UPDATE Profile0_Career_Garage SET OriginalOwner='r/ForzaModding'; UPDATE Profile0_Career_Garage SET NumOwners=69                                                                                                                            ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12,Sql12OriginalString);
                break;
            }
        }
    }

    private void QuickAddRareCars_OnToggled(object sender, RoutedEventArgs e)
    {
        const string CarList = "3300";
        string String = "INSERT INTO ContentOffersMapping (OfferId, ContentId, ContentType, IsPromo, IsAutoRedeem, ReleaseDateUTC, Quantity) SELECT 3, Id, 1, 0, 1, NULL, 1 FROM Data_Car WHERE Id NOT IN (SELECT ContentId AS Id FROM ContentOffersMapping WHERE ContentId IS NOT NULL);" +
                        " INSERT INTO Profile0_FreeCars SELECT Id, 1 FROM Data_Car WHERE Id NOT IN (SELECT CarId AS Id FROM Profile0_FreeCars WHERE CarID IS NOT NULL);" +
                        " UPDATE ContentOffersMapping SET Quantity = 9999 ;" +
                        " UPDATE Profile0_FreeCars SET FreeCount = 1;" +
                        " UPDATE ContentOffersMapping SET IsAutoRedeem = 1;" +
                        " UPDATE ContentOffersMapping SET IsAutoRedeem = 0 WHERE ContentId IN(" + CarList + ");" +
                        " UPDATE ContentOffersMapping SET IsAutoRedeem = 0 WHERE ContentId IN(SELECT Id AS ContentId FROM Data_Car WHERE NotAvailableInAutoshow = 0);" +
                        " UPDATE ContentOffersMapping SET IsAutoRedeem = 0 WHERE ContentId IN(SELECT ContentId FROM ContentOffersMapping WHERE ReleaseDateUTC > '" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + " 00:00');";
            
        switch (QuickAddRareCars.IsEnabled)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { QuickAddRareCars.IsEnabled = false; });

                    bool Done = AutoshowVars.ExecSQL(String);
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { QuickAddRareCars.IsOn = false; });

                    Dispatcher.BeginInvoke(delegate () { QuickAddRareCars.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, Sql13EraseString);
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql14, new byte[] { 0x00 });
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, String);
                QuickAddAllCars.IsEnabled = false;
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql13, Sql13OriginalBytes);
                QuickAddAllCars.IsEnabled = true;
                break;
            }
        }
    }

    private void QuickAddAllCars_OnToggled(object sender, RoutedEventArgs e)
    {
        const string CarList = "3300";
        var String = "INSERT INTO ContentOffersMapping (OfferId, ContentId, ContentType, IsPromo, IsAutoRedeem, ReleaseDateUTC, Quantity) SELECT 3, Id, 1, 0, 1, NULL, 1 FROM Data_Car WHERE Id NOT IN (SELECT ContentId AS Id FROM ContentOffersMapping WHERE ContentId IS NOT NULL);" +
                     " INSERT INTO Profile0_FreeCars SELECT ContentId, 1 FROM ContentOffersMapping;" +
                     " UPDATE ContentOffersMapping SET IsAutoRedeem = 1 WHERE ContentId NOT IN(SELECT ContentId FROM ContentOffersMapping WHERE ReleaseDateUTC > '" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + " 00:00');" +
                     " UPDATE ContentOffersMapping SET Quantity = 1;" +
                     " UPDATE ContentOffersMapping SET IsAutoRedeem = 0 WHERE ContentId IN(" + CarList + ");" +
                     " UPDATE ContentOffersMapping SET IsAutoRedeem = 0 WHERE ContentId IN(SELECT CarId AS ContentId FROM Profile0_Career_Garage WHERE CarId IS NOT NULL);";
            
        switch (QuickAddAllCars.IsEnabled)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { QuickAddAllCars.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL(String);
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { QuickAddAllCars.IsOn = false; });
                        
                    Dispatcher.BeginInvoke(delegate () { QuickAddAllCars.IsEnabled = true; });
                });
                break;
            }
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, Sql13EraseString);
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql14, new byte[] { 0x00 });
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, String);
                QuickAddRareCars.IsEnabled = false;
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql13, Sql13OriginalBytes);
                QuickAddRareCars.IsEnabled = true;
                break;
            }
        }
    }

    private void FreeVisualUpgrades_OnToggled(object sender, RoutedEventArgs e)
    {
        switch (FreeVisualUpgrades.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { FreeVisualUpgrades.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL(FreeVisualString);
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { FreeVisualUpgrades.IsOn = false; });
                        
                    Dispatcher.BeginInvoke(delegate () { FreeVisualUpgrades.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, Sql13EraseString);
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql14, new byte[] { 0x00 });
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, FreeVisualString);
                FreePerfUpgrades.IsEnabled = false;
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql13, Sql13OriginalBytes);
                FreePerfUpgrades.IsEnabled = true;
                break;
            }
        }
    }

    private void FreePerfUpgrades_OnToggled(object sender, RoutedEventArgs e)
    {
        switch (FreePerfUpgrades.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { FreePerfUpgrades.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL(FreePerfString);
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { FreePerfUpgrades.IsOn = false; });
                        
                    Dispatcher.BeginInvoke(delegate () { FreePerfUpgrades.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, Sql13EraseString);
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql14, new byte[] { 0x00 });
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql13, FreePerfString);
                FreeVisualUpgrades.IsEnabled = false;
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteArrayMemory(AutoshowVars.sql13, Sql13OriginalBytes);
                FreeVisualUpgrades.IsEnabled = true;
                break;
            }
        }
    }

    private void ShowTrafficHSNull_OnToggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            ToggleFreeCars.IsEnabled = !ToggleFreeCars.IsEnabled;
            UnlockHiddenPresets.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            FixThumbnails.IsEnabled = !FixThumbnails.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            ClearGarage.IsEnabled = !ClearGarage.IsEnabled;
            ClearTag.IsEnabled = !ClearTag.IsEnabled;
        }
            
        switch (ShowTrafficHSNull.IsEnabled)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ShowTrafficHSNull.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("DROP VIEW Drivable_Data_Car; CREATE VIEW Drivable_Data_Car AS SELECT Data_Car.* FROM Data_Car; INSERT INTO Data_Car_Buckets(CarId) SELECT Id FROM Data_Car WHERE Id NOT IN (SELECT CarId FROM Data_Car_Buckets); UPDATE Data_Car_Buckets SET CarBucket=0, BucketHero=0 WHERE CarBucket IS NULL");
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { ShowTrafficHSNull.IsOn = false; });
                        
                    Dispatcher.BeginInvoke(delegate () { ShowTrafficHSNull.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12,  "DROP VIEW Drivable_Data_Car; CREATE VIEW Drivable_Data_Car AS SELECT Data_Car.* FROM Data_Car; INSERT INTO Data_Car_Buckets(CarId) SELECT Id FROM Data_Car WHERE Id NOT IN (SELECT CarId FROM Data_Car_Buckets); UPDATE Data_Car_Buckets SET CarBucket=0, BucketHero=0 WHERE CarBucket IS NULL                                                                             ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE %s SET TopSpeed=%f, DistanceDriven=%u, TimeDriven=%u, TotalWinnings=%u, TotalRepairs=%u, NumPodiums=%u, NumVictories=%u, NumRaces=%u, NumOwners=%u, NumTimesSold=%u, TimeDrivenInRoadTrips=%u, CurOwnerNumRaces=%u, CurOwnerWinnings=%u, NumSkillPointsEarned=%u, HighestSkillScore=%u, HasCurrentOwnerViewedCar=%u WHERE Id=%u                                     ");
                break;
            }
        }
    }

    private void UnlockHiddenDecals_OnToggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            ToggleFreeCars.IsEnabled = !ToggleFreeCars.IsEnabled;
            UnlockHiddenPresets.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            FixThumbnails.IsEnabled = !FixThumbnails.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            ClearGarage.IsEnabled = !ClearGarage.IsEnabled;
            ClearTag.IsEnabled = !ClearTag.IsEnabled;
        }
            
        switch (UnlockHiddenDecals.IsEnabled)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "DROP VIEW Drivable_Data_Car; CREATE VIEW Drivable_Data_Car AS SELECT Data_Car.* FROM Data_Car; INSERT INTO Data_Car_Buckets(CarId) SELECT Id FROM Data_Car WHERE Id NOT IN (SELECT CarId FROM Data_Car_Buckets); UPDATE Data_Car_Buckets SET CarBucket=0, BucketHero=0 WHERE CarBucket IS NULL                                                                             ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE %s SET TopSpeed=%f, DistanceDriven=%u, TimeDriven=%u, TotalWinnings=%u, TotalRepairs=%u, NumPodiums=%u, NumVictories=%u, NumRaces=%u, NumOwners=%u, NumTimesSold=%u, TimeDrivenInRoadTrips=%u, CurOwnerNumRaces=%u, CurOwnerWinnings=%u, NumSkillPointsEarned=%u, HighestSkillScore=%u, HasCurrentOwnerViewedCar=%u WHERE Id=%u                                     ");
                break;
            }
        }
    }

    private void UnlockHiddenPresets_OnToggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            ToggleFreeCars.IsEnabled = !ToggleFreeCars.IsEnabled;
            UnlockHiddenDecals.IsEnabled = !UnlockHiddenDecals.IsEnabled;
            FixThumbnails.IsEnabled = !FixThumbnails.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            ClearGarage.IsEnabled = !ClearGarage.IsEnabled;
            ClearTag.IsEnabled = !ClearTag.IsEnabled;
        }
            
        switch (UnlockHiddenPresets.IsEnabled)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { UnlockHiddenPresets.IsEnabled = false; });

                    bool Done = AutoshowVars.ExecSQL("UPDATE UpgradePresetPackages SET Purchasable = 1 WHERE Purchasable = 0");
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { UnlockHiddenPresets.IsOn = false; });

                    Dispatcher.BeginInvoke(delegate () { UnlockHiddenPresets.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE UpgradePresetPackages SET Purchasable=1 WHERE Purchasable=0                                                                                                                                                                                                                                                                                                         ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE %s SET TopSpeed=%f, DistanceDriven=%u, TimeDriven=%u, TotalWinnings=%u, TotalRepairs=%u, NumPodiums=%u, NumVictories=%u, NumRaces=%u, NumOwners=%u, NumTimesSold=%u, TimeDrivenInRoadTrips=%u, CurOwnerNumRaces=%u, CurOwnerWinnings=%u, NumSkillPointsEarned=%u, HighestSkillScore=%u, HasCurrentOwnerViewedCar=%u WHERE Id=%u                                     ");
                break;
            }
        }
    }

    private void ClearGarageComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ClearGarageString = ClearGarageComboBox.SelectedIndex switch
        {
            0 => // All
                "DELETE FROM Profile0_Career_Garage WHERE Id > 0;",
            1 => // Dupes
                "DELETE FROM Profile0_Career_Garage WHERE Id NOT IN (select min(Id) from Profile0_Career_Garage group by CarId);",
            2 => // Non favorites
                "DELETE FROM Profile0_Career_Garage WHERE IsFavorite IS NOT 1;",
            3 => // Rare cars
                "DELETE FROM Profile0_Career_Garage WHERE CarId NOT IN (SELECT Id FROM Data_Car WHERE NotAvailableInAutoshow = 0);",
            4 => // Autoshow cars
                "DELETE FROM Profile0_Career_Garage WHERE CarId NOT IN (SELECT Id FROM Data_Car WHERE NotAvailableInAutoshow = 1);",
            5 => // Only untuned
                "DELETE FROM Profile0_Career_Garage WHERE VersionedTuneId IS \"00000000-0000-0000-0000-000000000000\";",
            6 => // Only unpainted
                "DELETE FROM Profile0_Career_Garage WHERE VersionedLiveryId IS \"00000000-0000-0000-0000-000000000000\";",
            _ => ClearGarageString
        };
    }

    private void ClearTag_OnToggled(object sender, RoutedEventArgs e)
    {
        if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
        {
            ToggleFreeCars.IsEnabled = !ToggleFreeCars.IsEnabled;
            UnlockHiddenPresets.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            ClearGarage.IsEnabled = !ClearGarage.IsEnabled;
            ShowTrafficHSNull.IsEnabled = !ShowTrafficHSNull.IsEnabled;
            UnlockHiddenDecals.IsEnabled = !UnlockHiddenPresets.IsEnabled;
            FixThumbnails.IsEnabled = !FixThumbnails.IsEnabled;
        }
        else if (MainWindow.mw.gvp.Name == "Forza Horizon 5")
        {
            var result = System.Windows.Forms.MessageBox.Show("This feature is unstable on FH5. do you wanna continue?",  "Clear \"new\" tag on cars", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;  
        }
            
        switch (ClearTag.IsOn)
        {
            case true when MainWindow.mw.gvp.Name == "Forza Horizon 5":
            {
                Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(delegate () { ClearTag.IsEnabled = false; });
                    bool Done = AutoshowVars.ExecSQL("UPDATE Profile0_Career_Garage SET HasCurrentOwnerViewedCar = 1;");
                    if (!Done)
                        Dispatcher.BeginInvoke(delegate () { ClearTag.IsOn = false; });

                    Dispatcher.BeginInvoke(delegate () { ClearTag.IsEnabled = true; });
                });
                break;
            }
            case true:
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE Profile0_Career_Garage SET HasCurrentOwnerViewedCar = 1;                                                                                                                                                                                                                                                                                                            ");
                break;
            }
            case false when MainWindow.mw.gvp.Name == "Forza Horizon 4":
            {
                MainWindow.mw.m.WriteStringMemory(AutoshowVars.sql12, "UPDATE %s SET TopSpeed=%f, DistanceDriven=%u, TimeDriven=%u, TotalWinnings=%u, TotalRepairs=%u, NumPodiums=%u, NumVictories=%u, NumRaces=%u, NumOwners=%u, NumTimesSold=%u, TimeDrivenInRoadTrips=%u, CurOwnerNumRaces=%u, CurOwnerWinnings=%u, NumSkillPointsEarned=%u, HighestSkillScore=%u, HasCurrentOwnerViewedCar=%u WHERE Id=%u                                     ");
                break;
            }
        }
    }
}