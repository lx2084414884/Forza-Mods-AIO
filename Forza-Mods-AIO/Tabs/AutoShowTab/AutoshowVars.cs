﻿using System;
using System.Linq;
using System.Windows;
using System.IO.Pipes;
using System.Threading;
using System.IO;
using Lunar;
using Forza_Mods_AIO.Resources;

namespace Forza_Mods_AIO.Tabs.AutoShowTab
{
    internal class AutoshowVars
    {
        #region Address Vars
        public static string sql1;  //FH4 NOT Garage.NotAvailableInAutoshow AS PurchasableCar,
        public static string sql2;  // IsBarnFind
        public static string sql3;  // AND NOT IsBarnFind 
        public static string sql4;  // Garage.Id!=
        public static string sql5;  //FH4 AND NotAvailableInAutoshow=0
        public static string sql6;  //FH4 (basically just above address + 26)
        public static string sql7;  // AND IsCarVisibleAndReleased(Garage.ModelId) 
        public static string sql8;  // Garage.ModelId!=
        public static string sql9;  // AND UnobtainableCars.Ordinal IS NULL
        //public static string sql10; // INNER JOIN Livery_DecalsSortOrder ON (Livery_Decals.ID = Livery_DecalsSortOrder.Livery_DecalID) WHERE MakeID = %d ORDER BY Sequence, AlphaSort
        public static string sql11; // DoNotAllowRemovalFromGarage
        public static string sql12; // UPDATE %s SET TopSpeed=%f
        public static string sql13; // UPDATE %sCareer_Garage SET Tuning_frontDownforce = %1.8e, Tuning_rearDownforce = %1.8e,
        public static string sql14; // sql13 but +2047
        public static string sql15; //FH4 HideNormalColors for lego cars
        public static string sql16; //FH4 HideSpecialColors for lego cars
        public static string sql17; //FH4 AND NOT IsMidnightCar 
        #endregion

        public static void Scan()
        {
            if (MainWindow.mw.gvp.Name == "Forza Horizon 4")
            {
                sql2 = (MainWindow.mw.m.ScanForSig("49 73 42 61 72 6E 46 69 6E 64")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 1, AutoShow.AS.AOBProgressBar);
                sql3 = (MainWindow.mw.m.ScanForSig("41 4E 44 20 4E 4F 54 20 49 73 42 61 72 6E 46 69 6E 64")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 2, AutoShow.AS.AOBProgressBar);
                sql4 = (MainWindow.mw.m.ScanForSig("47 61 72 61 67 65 2E 49 64 21 3D")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 3, AutoShow.AS.AOBProgressBar);
                sql7 = (MainWindow.mw.m.ScanForSig("41 4E 44 20 49 73 43 61 72 56 69 73 69 62 6C 65 41 6E 64 52 65 6C 65 61 73 65 64 28 47 61 72 61 67 65 2E 4D 6F 64 65 6C 49 64 29 00 00 00 00 20")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 4, AutoShow.AS.AOBProgressBar);
                sql8 = (MainWindow.mw.m.ScanForSig("47 61 72 61 67 65 2E 4D 6F 64 65 6C 49 64 21 3D")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 5, AutoShow.AS.AOBProgressBar);
                sql9 = (MainWindow.mw.m.ScanForSig("41 4E 44 20 55 6E 6F 62 74 61 69 6E 61 62 6C 65 43 61 72 73 2E 4F 72 64 69 6E 61 6C 20 49 53 20 4E 55 4C 4C")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 6, AutoShow.AS.AOBProgressBar);
                /*sql10 = (await MainWindow.mw.m.AoBScan(MainWindow.mw.gvp.Process.MainModule.BaseAddress, MainWindow.mw.gvp.Process.MainModule.BaseAddress + MainWindow.mw.gvp.Process.MainModule.ModuleMemorySize, "49 4E 4E 45 52 20 4A 4F 49 4E 20 4C 69 76 65 72 79 5F 44 65 63 61 6C 73 53 6F 72 74 4F 72 64 65 72 20 4F 4E 20 28 4C 69 76 65 72 79 5F 44 65 63 61 6C 73 2E 49 44 20 3D 20 4C 69 76 65 72 79 5F 44 65 63 61 6C 73 53 6F 72 74 4F 72 64 65 72 2E 4C 69 76 65 72 79 5F 44 65 63 61 6C 49 44 29 20 57 48 45 52 45 20 4D 61 6B 65 49 44 20 3D 20 25 64 20 4F 52 44 45 52 20 42 59 20 53 65 71 75 65 6E 63 65 2C 20 41 6C 70 68 61 53 6F 72 74")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 7, AutoShow.AS.AOBProgressBar);*/
                sql11 = (MainWindow.mw.m.ScanForSig("44 6F 4E 6F 74 41 6C 6C 6F 77 52 65 6D 6F 76 61 6C 46 72 6F 6D 47 61 72 61 67 65 00 00 00 00 00")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 8, AutoShow.AS.AOBProgressBar);
                sql12 = (MainWindow.mw.m.ScanForSig("55 50 44 41 54 45 20 25 73 20 53 45 54 20 54 6F 70 53 70 65 65 64 3D 25 66")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 9, AutoShow.AS.AOBProgressBar);
                sql13 = (MainWindow.mw.m.ScanForSig( "55 50 44 41 54 45 20 25 73 43 61 72 65 65 72 5F 47 61 72 61 67 65 20 53 45 54 20 54 75 6E 69 6E 67 5F 66 72 6F 6E 74 44 6F 77 6E 66 6F 72 63 65 20 3D 20 25 31 2E 38 65 2C 20 54 75 6E 69 6E 67 5F 72 65 61 72 44 6F 77 6E 66 6F 72 63 65 20 3D 20 25 31 2E 38 65 2C")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 10, AutoShow.AS.AOBProgressBar);
                sql14 = ((MainWindow.mw.m.ScanForSig("55 50 44 41 54 45 20 25 73 43 61 72 65 65 72 5F 47 61 72 61 67 65 20 53 45 54 20 54 75 6E 69 6E 67 5F 66 72 6F 6E 74 44 6F 77 6E 66 6F 72 63 65 20 3D 20 25 31 2E 38 65 2C 20 54 75 6E 69 6E 67 5F 72 65 61 72 44 6F 77 6E 66 6F 72 63 65 20 3D 20 25 31 2E 38 65 2C")).FirstOrDefault() + 2047).ToString("X");
                UpdateUi.AddProgress(17, 11, AutoShow.AS.AOBProgressBar);
                sql1 = (MainWindow.mw.m.ScanForSig("4E 4F 54 20 47 61 72 61 67 65 2E 4E 6F 74 41 76 61 69 6C 61 62 6C 65 49 6E 41 75 74 6F 73 68 6F 77 20 41 53 20 50 75 72 63 68 61 73 61 62 6C 65 43 61 72 2C")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 12, AutoShow.AS.AOBProgressBar);
                sql5 = (MainWindow.mw.m.ScanForSig("41 4E 44 20 4E 6F 74 41 76 61 69 6C 61 62 6C 65 49 6E 41 75 74 6F 73 68 6F 77 3D 30")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 13, AutoShow.AS.AOBProgressBar);
                sql6 = ((MainWindow.mw.m.ScanForSig("41 4E 44 20 4E 6F 74 41 76 61 69 6C 61 62 6C 65 49 6E 41 75 74 6F 73 68 6F 77 3D 30")).FirstOrDefault() + 26).ToString("X");
                UpdateUi.AddProgress(17, 14, AutoShow.AS.AOBProgressBar);
                sql15 = (MainWindow.mw.m.ScanForSig( "48 69 64 65 4E 6F 72 6D 61 6C 43 6F 6C 6F 72 73 00 00 00 00 00 00 00 00 48 69 64 65 4D 61 6E 75 66 61 63 74 75 72 65 72 43 6F 6C 6F 72 73 00 00")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 15, AutoShow.AS.AOBProgressBar);
                sql16 = ((MainWindow.mw.m.ScanForSig("48 69 64 65 53 70 65 63 69 61 6C 43 6F 6C 6F 72 73 00 00 00 00 00 00 00 41 6C 6C 6F 77 53 74 6F 63 6B 4D 61 6E 75 66 61 63 74 75 72 65 72 43 6F 6C 6F 72 73 46 6F 72 57 68 65 65 6C 73")).FirstOrDefault() + 2047).ToString("X");
                UpdateUi.AddProgress(17, 16, AutoShow.AS.AOBProgressBar);
                sql17 = (MainWindow.mw.m.ScanForSig("41 4E 44 20 4E 4F 54 20 49 73 4D 69 64 6E 69 67 68 74 43 61 72 00 00 20 41 4E 44 20 4E 4F 54 20 49 73 42 61 72 6E 46 69 6E 64 00 00 00 00 00 20")).FirstOrDefault().ToString("X");
                UpdateUi.AddProgress(17, 17, AutoShow.AS.AOBProgressBar);
                Overlay.Overlay.AutoshowGarageOption.IsEnabled = true;
                Overlay.AutoShowMenu.SubMenus.GarageModifications.PaintLegoCarsToggle.IsEnabled = true;
                UpdateUi.UpdateUI(true, AutoShow.AS);
                return;
            }
            
            MainWindow.mw.Mapper = new LibraryMapper(MainWindow.mw.gvp.Process, Properties.Resources.SQL_DLL);
            UpdateUi.AddProgress(2, 1, AutoShow.AS.AOBProgressBar);
            try
            {
                MainWindow.mw.Mapper.MapLibrary();
            }
            catch
            {
                MessageBox.Show("Failed, sowwy oomfie :3");
            }
            UpdateUi.AddProgress(2, 2, AutoShow.AS.AOBProgressBar);
        
            Overlay.Overlay.AutoshowGarageOption.IsEnabled = MainWindow.mw.Mapper.DllBaseAddress != IntPtr.Zero;
            UpdateUi.UpdateUI(MainWindow.mw.Mapper.DllBaseAddress != IntPtr.Zero, AutoShow.AS);
            
            AutoShow.AS.Dispatcher.Invoke(() =>
            {
                AutoShow.AS.PaintLegoCars.IsEnabled = false;
                Overlay.AutoShowMenu.SubMenus.GarageModifications.PaintLegoCarsToggle.IsEnabled = false;
                AutoShow.AS.PaintLegoCarsLabel.ToolTip = "Painting lego cars is disabled on FH5";
            });    
        }

        internal static void ResetMem()
        {
            if (MainWindow.mw.gvp.Name != "Forza Horizon 4") return;
            try
            {
                MainWindow.mw.m.WriteStringMemory(sql1, "NOT Garage.NotAvailableInAutoshow AS PurchasableCar,");
                MainWindow.mw.m.WriteStringMemory(sql2, "I");
                MainWindow.mw.m.WriteStringMemory(sql3, "AND NOT IsBarnFind");
                MainWindow.mw.m.WriteStringMemory(sql4, "Garage.Id!=");
                MainWindow.mw.m.WriteStringMemory(sql5, "AND NotAvailableInAutoshow=0");
                MainWindow.mw.m.WriteStringMemory(sql6, "=0                                    ");
                MainWindow.mw.m.WriteStringMemory(sql7, "AND IsCarVisibleAndReleased(Garage.ModelId)");
                MainWindow.mw.m.WriteStringMemory(sql8, "Garage.ModelId!=");
                MainWindow.mw.m.WriteStringMemory(sql9, "AND UnobtainableCars.Ordinal IS NULL");
                //MainWindow.mw.m.WriteMemory(sql10, "string", "INNER JOIN Livery_DecalsSortOrder ON (Livery_Decals.ID = Livery_DecalsSortOrder.Livery_DecalID) WHERE MakeID = %d ORDER BY Sequence, AlphaSort");
                MainWindow.mw.m.WriteStringMemory(sql11, "D");
                MainWindow.mw.m.WriteStringMemory(sql12, "UPDATE %s SET TopSpeed=%f, DistanceDriven=%u, TimeDriven=%u, TotalWinnings=%u, TotalRepairs=%u, NumPodiums=%u, NumVictories=%u, NumRaces=%u, NumOwners=%u, NumTimesSold=%u, TimeDrivenInRoadTrips=%u, CurOwnerNumRaces=%u, CurOwnerWinnings=%u, NumSkillPointsEarned=%u, HighestSkillScore=%u, HasCurrentOwnerViewedCar=%u WHERE Id=%u                                     ");
                MainWindow.mw.m.WriteArrayMemory(sql13, AutoShow.Sql13OriginalBytes);
                MainWindow.mw.m.WriteStringMemory(sql15, "HideNormalColors");
                MainWindow.mw.m.WriteStringMemory(sql16, "HideSpecialColors");
                MainWindow.mw.m.WriteStringMemory(sql17, "AND NOT IsMidnightCar");
            }
            catch {}
        }

        public static bool ExecSQL(string SQL, bool SuppressMessagebox = false)
        {
            using var Client = new NamedPipeClientStream("PogPipe");
            int Count = 0;
            while (!Client.IsConnected && Count < 25)
            {
                Thread.Sleep(10);
                try
                { Client.Connect(100); }
                catch { }
                Count++;
            }

            if (Count == 25)
            {
                if (!SuppressMessagebox)
                    MessageBox.Show("Failed, sowwy oomfie :3");
                return false;
            }

            using StreamWriter sw = new StreamWriter(Client);
            if (sw.AutoFlush == false)
                sw.AutoFlush = true;
            sw.WriteLine(SQL);
            
            return true;
        }
    }
}