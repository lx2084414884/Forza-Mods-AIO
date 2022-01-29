﻿using System;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.Runtime.InteropServices;
using SharpDX.XInput;
using SharpDX.DirectInput;
using System.Globalization;
using Forza_Mods_AIO.Properties;
using System.Collections;
using Forza_Mods_AIO.TabForms.PopupForms;

namespace Forza_Mods_AIO.TabForms
{

    public partial class Speedhack : Form
    {
        assembly a = new assembly();
        public static Speedhack s;

        #region Global Variables
        public static bool IsAttached = false;
        bool BreakToggle = false;
        bool StopToggle = false;
        bool BreakStart = false;
        bool VelHackStart = false;
        bool VelHackToggle = false;
        bool JumpHackToggleToggle = false;
        bool SpeedHackToggle = false;
        bool SpeedHackStart = false;
        bool TurnAssistToggle = false;
        bool TurnAssistLeftStart = false;
        bool TurnAssistRightStart = false;
        bool WallNoClipToggle = false;
        bool CarNoClipToggle = false;
        bool CheckPointTPToggle = false;
        bool WayPointTPToggle = false;
        bool TimerToggle = false;
        bool OOB = false;
        public bool g2g = false;
        public static bool done = false;
        public static bool JumpStart = false; public static bool Velstart = false; public static bool NCstart = false; public static bool FOVstart = false; public static bool Timestart = false; public static bool Breakstart = false; public static bool Speedstart = false; public static bool Turnstart = false;
        bool FovIncreaseStart = false; bool FovDecreaseStart = false;
        bool TimeToggle = false;  bool TimeForwardStart = false; bool TimeBackStart = false;
        bool GravityFreeze = false; bool WeirdFreeze = false;

        public static long TimeNOPAddrLong; public static long CheckPointxASMAddrLong; public static long WayPointxASMAddrLong;
        public static long BaseAddrLong; public static long Base2AddrLong; public static long Base3AddrLong; public static long Base4AddrLong; public static long Car1AddrLong; public static long Car2AddrLong; public static long Wall1AddrLong; public static long Wall2AddrLong; public static long FOVnopOutAddrLong; public static long FOVnopInAddrLong;
        public static long FirstPersonAddrLong; public static long DashAddrLong; public static long FrontAddrLong; public static long LowAddrLong; public static long BonnetAddrLong;
        public static long CurrentIDAddrLong;
        public static long OOBnopAddrLong;
        public static long SuperCarAddrLong;
        public static long WorldRGBAddrLong;
        public static long FOVJmpAddrLong;
        public static long DiscoverRoadsAddrLong;
        public static long WaterAddrLong;
        public static long AIXAobAddrLong;

        public static string Base;
        public static string Base2;
        public static string RGBAob;
        public static string Car1;
        public static string Car2;
        public static string Wall1;
        public static string Wall2;
        public static string FOVOutsig;
        public static string FOVInsig;
        public static string FOVJmp;
        public static string Timesig;
        public static string CheckPointxASMsig;
        public static string WayPointxASMsig;
        public static string FirstPerson;
        public static string Dash;
        public static string Low;
        public static string Bonnet;
        public static string Front;
        public static string XPaob;
        public static string XPAmountaob;
        public static string CurrentIDaob;
        public static string OOBaob;
        public static string SuperCaraob;
        public static string DLCPatchaob;
        public static string CarIdAob;
        public static string DiscoverRoadsAob;
        public static string WaterAob;
        public static string AIXAob;

        public static string KBSpeedKey = "LShiftKey"; public static string XBSpeedKey = "LeftShoulder";
        public static string KBBrakeKey = "Space"; public static string XBBrakeKey = "A";
        public static string KBJumpKey = "LControlKey"; public static string XBJumpKey = "RightThumb";
        public static string GravityAddr; public static string WeirdAddr;
        public static string BaseAddr; public static string Base2Addr; public static string Base3Addr; public static string Base4Addr;
        public static string Car1Addr; public static string Car2Addr; public static string FOVnopOutAddr; public static string FOVnopInAddr;
        public static string TimeNOPAddr; public static string TimeAddr;
        public static string Wall1Addr; public static string Wall2Addr;
        public static string FrontLeftAddr; public static string FrontRightAddr; public static string BackLeftAddr; public static string BackRightAddr;
        public static string OnGroundAddr; public static string InRaceAddr; public static string PastStartAddr; public static string PastIntroAddr = null;
        public static string xVelocityAddr; public static string yVelocityAddr; public static string zVelocityAddr;
        public static string xAddr; public static string yAddr; public static string zAddr;
        public static string CheckPointxAddr; public static string CheckPointyAddr; public static string CheckPointzAddr; public static string CheckPointxASMAddr;
        public static string WayPointxAddr; public static string WayPointyAddr; public static string WayPointzAddr; public static string WayPointxASMAddr;
        public static string YawAddr; public static string RollAddr; public static string PitchAddr; public static string yAngVelAddr;
        public static string GasAddr;
        public static string FOVHighAddr; public static string FOVInAddr; public static string FirstPersonAddr; public static string DashAddr; public static string FrontAddr; public static string BonnetAddr; public static string LowAddr; public static string LowCompare;
        public static string CurrentIDAddr;
        public static string TimeAddrAddr;
        public static string allocationstring;
        public static string OOBnopAddr;
        public static string SuperCarAddr;
        public static string WorldRGBAddr;
        public static string InPauseAddr;
        public static string InHouseAddr;
        public static string TestAddr;
        public static string FOVJmpAddr;
        public static string CheckPointBaseAddr = null; public static string WayPointBaseAddr = null;
        public static string DiscoverRoadsAddr = null;
        public static string TotalXpAddr = null;
        public static string WaterAddr = null;
        public static string AIXAobAddr = null;
        public static string XPaddr = null; public static long XPaddrLong = 0; public static string XPAmountaddr = null; public static long XPAmountaddrLong = 0;

        public static IntPtr CCBA = (IntPtr)0; public static IntPtr CCBA2 = (IntPtr)0; public static IntPtr CCBA3 = (IntPtr)0; public static IntPtr CCBA4 = (IntPtr)0; public static IntPtr CCBA5 = (IntPtr)0; public static IntPtr CCBA6 = (IntPtr)0;
        public static IntPtr CodeCave = (IntPtr)0; public static IntPtr CodeCave2 = (IntPtr)0; public static IntPtr CodeCave3 = (IntPtr)0; public static IntPtr CodeCave4 = (IntPtr)0; public static IntPtr CodeCave5 = (IntPtr)0; public static IntPtr CodeCave6 = (IntPtr)0;
        public static IntPtr InjectAddress;
        float xVelocityVal; float yVelocityVal; float zVelocityVal;
        float x; float y; float z;
        float CheckPointx; float CheckPointy; float CheckPointz;
        float BoostSpeed1; float BoostSpeed2; float BoostSpeed3; float BoostLim;
        float TurnRatio; float TurnStrength; public float boost;
        float VelMult = 1; float FOVVal;
        float LastWPx = 0; float LastWPy = 0; float LastWPz = 0;
        float WeirdVal; float NewWeirdVal; float GravityVal; float NewGravityVal;
        float basegrav;

        public int StorageAddress;
        int IncreaseCycles = 0; int DecreaseCycles = 0;
        int times1; int times2; int times3; int times4;
        int BoostInterval1; int BoostInterval2; int BoostInterval3; int BoostInterval4; int TurnInterval;
        int Velcycles; int NoClipcycles;

        long ScanStartAddr;
        long ScanEndAddr;

        List<string> RearAddresses = new List<string>();
        List<string> RestAddresses = new List<string>();

        public static int cycles = 0;

        Controller controller = null;
        Joystick joystick = null;
        Guid joystickGuid = Guid.Empty;

        private static CultureInfo resourceCulture;
        internal static byte[] FclvYGRQ1w
        {
            get
            {
                return (byte[])Resources.ResourceManager.GetObject("FclvYGRQ1w", resourceCulture);
            }
        }
        internal static byte[] cYdXosu7SL
        {
            get
            {
                return (byte[])Resources.ResourceManager.GetObject("cYdXosu7SL", resourceCulture);
            }
        }
        private static Dictionary<int, string> DInputmap = new Dictionary<int, string>()
        {
            { 0, "X" },{ 1, "Circle" },{ 2, "Square" },{ 3, "Triangle" },
            { 4, "LeftShoulder" },{ 5, "RightShoulder" },{ 6, "Select" },{ 7, "Start" },
            { 8, "LeftStick" },{ 9, "RightStick" }
        };

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey);
        public RGB RGB = new RGB();
        public Map map = new Map();
        public Controls ControlsPopUp = new Controls();
        #endregion

        public Speedhack()
        {
            InitializeComponent();
            FOVWaitingBar.Visible = false;
            CheckForIllegalCrossThreadCalls = false;
            ControllerWorker.RunWorkerAsync();
            ToolTip.SetToolTip(TimerButton, @"Logs go to \Documents\Forza Mods Tool\Cool Shit\[GAME]\0-60 Logs\");
            s = this;
        }
        public static void Addresses()
        {
            FrontLeftAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,0xD18,0xC");
            FrontRightAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,0xD20,0xC");
            BackLeftAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,0xD38,0xC");
            BackRightAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,0xD30,0xC");
            OnGroundAddr = (BaseAddr + ",0x550,0x260,0x258,0x4B0,0x640,0x368,0x10C");
            InRaceAddr = (Base2Addr + ",0x80,0x8,0x38,0x58,0x28,0x18,0x230");
            xVelocityAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x540");
            yVelocityAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x53C");
            zVelocityAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x538");
            yAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x51C");
            zAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x518");
            xAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x520");
            yAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x51C");
            zAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x518");
            YawAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x3FC");
            RollAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x418");
            PitchAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x410");
            yAngVelAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x52C");
            GasAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,0xD18,-0x53C");
            PastStartAddr = (Base2Addr + ",0x80,0x8,0x38,0x58,0x28,0x18,0x5C");
            InPauseAddr = (Base2Addr + ",0x80,0x8,0x38,0x58,0x28,0x18,0x3D8");
            FOVHighAddr = (BaseAddr + ",0x568,0x270,0x258,0xB8,0x348,0x70,0x5B0");
            WeirdAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x554");
            GravityAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,-0x558");
            s.LST_TeleportLocation.Items.Clear();
            s.LST_TeleportLocation.Items.Add("Waypoint");
            s.LST_TeleportLocation.Items.Add("Adventure Park");
            s.LST_TeleportLocation.Items.Add("Ambleside");
            s.LST_TeleportLocation.Items.Add("Beach");
            s.LST_TeleportLocation.Items.Add("Broadway");
            s.LST_TeleportLocation.Items.Add("Dam");
            s.LST_TeleportLocation.Items.Add("Edinburgh");
            s.LST_TeleportLocation.Items.Add("Festival");
            s.LST_TeleportLocation.Items.Add("Greendale Airstrip");
            s.LST_TeleportLocation.Items.Add("Lake Island");
            s.LST_TeleportLocation.Items.Add("Mortimer Gardens");
            s.LST_TeleportLocation.Items.Add("Quarry");
            s.LST_TeleportLocation.Items.Add("Railyard");
            s.LST_TeleportLocation.Items.Add("Start of Motorway");
            s.LST_TeleportLocation.Items.Add("Top of Mountain");
            s.g2gWorker.RunWorkerAsync();
        }
        public static void AddressesSteam()
        {
            FrontRightAddr = (BaseAddr + ",0x2E0,0x58,0x60,0x1A0,0x60,0xD20,0xC");
        }
        public static void AddressesFive()
        {
            FrontLeftAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,0x10");
            FrontRightAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,0xA80");
            BackLeftAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,0x1F60");
            BackRightAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,0x14F0");
            xVelocityAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2618");
            yVelocityAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x261C");
            zVelocityAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2620");
            yAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x25EC");
            zAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x25E8");
            xAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x25F0");
            WeirdAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2634");
            GravityAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2638");
            OnGroundAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0xB84");
            GasAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0xBC8");
            YawAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2550");
            RollAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x254C");
            PitchAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2538");
            yAngVelAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x260C");
            InRaceAddr = (Base2Addr + ",0x50,0x3D8");
            InPauseAddr = (Base2Addr + ",0x50,0x480");
            InHouseAddr = (Base2Addr + ",0x50,0x368");
            TestAddr = (Base2Addr + ",0x50,0x218");
            FOVHighAddr = (Base3Addr + ",0x538,0xF0,0xD80,0x6F0");
            s.LST_TeleportLocation.Items.Clear();
            s.LST_TeleportLocation.Items.Add("Waypoint");
            s.LST_TeleportLocation.Items.Add("Airstrip");
            s.LST_TeleportLocation.Items.Add("Bridge");
            s.LST_TeleportLocation.Items.Add("Dirt Circuit");
            s.LST_TeleportLocation.Items.Add("Dunes");
            s.LST_TeleportLocation.Items.Add("Golf Course");
            s.LST_TeleportLocation.Items.Add("Guanajuato (Main City)");
            s.LST_TeleportLocation.Items.Add("Motorway");
            s.LST_TeleportLocation.Items.Add("Mulege");
            s.LST_TeleportLocation.Items.Add("Playa Azul");
            s.LST_TeleportLocation.Items.Add("River");
            s.LST_TeleportLocation.Items.Add("Stadium");
            s.LST_TeleportLocation.Items.Add("Temple");
            s.LST_TeleportLocation.Items.Add("Temple Drag");
            s.LST_TeleportLocation.Items.Add("Top Of Volcano");
            s.g2gWorker.RunWorkerAsync();
        }
        public static void VolumeSetup()
        {
            PastIntroAddr = (Base2Addr + ",0x80,0x8,0x38,0x58,0x28,0x18,0x21820");
        }
        public static void Aobs()
        {
            Base = "43 3a 5c 57 ? 4e 44 4f 57 53 5c 53 59 53 54 45 4d 33 32 5c 44";
            Car1 = "48 89 ? ? ? 44 8B ? 48 89 ? ? ? BA";
            Car2 = "0F 28 ? 41 0F ? ? ? 0F C6 D6 ? 41 0F";
            Wall1 = "F3 0F ? ? ? 0F 59 ? 0F C6 ED ? 0F C6 F6";
            Wall2 = "0F 28 ? 0F C6 C1 ? 0F 28 ? 0F C6 CB ? 41 0F ? ? F3 0F ? ? 41 0F ? ? 0F C6 C0 ? 0F C6 E4";
            FOVOutsig = "4C 8D ? ? ? 0F 29 ? ? ? F3 0F";
            FOVInsig = "48 81 EC ? ? ? ? 48 8B ? E8 ? ? ? ? 48 8B ? ? 48 8B";
            Timesig = "20 F2 0F 11 43 08 48 83";
            CheckPointxASMsig = "0F 28 ? ? ? ? ? 0F 29 ? ? 0F 29 ? ? C3 90 48 8B ? 55";
            WayPointxASMsig = "0F 10 ? ? ? ? ? 0F 28 ? 0F C2 ? 00 0F 50 C1 83 E0 07 3C 07";
            FirstPerson = "80 00 80 82 43";
            Dash = "3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 01 ?? 00 00 00 00 00 00 00 00 A0 40";
            Low = "80 CD CC 4C 3E CD CC CC 3E 9A 99 19 3F 00 00 80 3F";
            Bonnet = "00 80 3E 63 B8 1E 3F 00 00 80 3F";
            //Front = "A0 41 01 00 8C 42 00 00 11 43 00 00 3E 43 00 00 00 80 00 00 00 80 00 00 80 3E 7B 14 2E 3F";
            Front = "80 3E 7B 14 2E 3F 00 00 80 3F";
            XPaob = "F3 0F ? ? 89 45 ? 48 8D ? ? ? ? ? 41 83 BD C0 00 00 00";
            XPAmountaob = "8B 89 ? ? ? ? 85 C9 0F 8E";
            CurrentIDaob = "00 00 50 4C 41 59 45 52 5F 43 41 52 00 00";
            OOBaob = "0F 11 ? ? ? ? ? 0F 5C ? 0F 59 ? 0F 28 ? 0F C6 CA ? F3 0F";
            SuperCaraob = "0F 10 ? ? 0F 11 ? ? 0F 10 ? ? 0F 11 ? ? 0F 10 ? ? 0F 11 ? ? 0F 10 ? ? 48 83 C2 ? 0F 11 ? ? 48 83 C1 ? E8 ? ? ? ? 0F 10";
            DiscoverRoadsAob = "00 96 42 ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? 40 1C 45 ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? 03 00";
            WaterAob = "3D ? ? ? ? 00 00 A0 ? ? ? ? ? ? ? ? 3F 00 00";
            AIXAob = "48 89 ? ? ? 57 48 83 EC ? 0F 10 ? 48 8B ? 0F 11 ? ? 48 8B";
        }
        public static void AobsSteam()
        {
            Base = "7F ? 00 01 00 00 00 03 00 00 00 01 00 00 00 00 00 00 00 64";
        }
        public static void AobsFive()
        {
            Base = "7F ? 00 AC ? ? ? ? ? 6E 27 00 24";
            RGBAob = "0A D7 23 3C ? 00 00 3F 9A ? ? ? ? ? ? 00";
            Base2 = "E0 ? 41 ? E1 ? 00 00";
            XPaob = "F3 0F ? ? 89 45 ? 48 8D ? ? ? ? ? 41 83";
            XPAmountaob = "8B 89 ? ? ? ? 85 C9 0F 8E";
            Car1 = "0F 84 ? ? ? ? 4C 8B ? ? ? ? ? ? 45 0F ? ? 4C 8B";
            Wall1 = "0F 84 ? ? ? ? 4C 8B ? ? ? ? ? ? 49 83 C1 ? 66 44 ? ? ? ? ? ? ? 49 83 C0 ? 66 44 ? ? ? ? ? ? ? 45 0F ? ? 4D 8B ? 90";
            Wall2 = "0F 84 ? ? ? ? 4C 8B ? ? ? ? ? ? 49 83 C1 ? 66 44 ? ? ? ? ? ? ? 49 83 C0 ? 66 44 ? ? ? ? ? ? ? 45 0F ? ? 4D 8B ? 0F";
            Timesig = "20 F2 0F 11 43 08 48 83";
            SuperCaraob = "0F 10 ? ? 0F 11 ? ? 0F 10 ? ? 0F 11 ? ? 0F 10 ? ? 0F 11 ? ? 0F 10 ? ? 48 83 C2 ? 0F 11 ? ? 48 83 C1 ? E8 ? ? ? ? 0F 10";
            WayPointxASMsig = "0F 10 ? ? ? ? ? 0F 28 ? 0F C2 ? 00 0F 50 C1 83 E0 07 3C 07";
            FOVJmp = "0F 2F ? ? ? 0F 10 ? ? 0F 28 ? 0F 10";
            OOBaob = "0F 28 ? 0F 28 ? 0F C6 D1 ? 0F 59 ? ? ? ? ? 0F C6 C1 ? 0F 59 ? ? ? ? ? 0F C6 C9 ? 0F 59 ? ? ? ? ? 0F 58 ? 0F 58 ? 0F 58 ? ? 0F 11";
            //CheckPointxASMsig = "48 85 ? 74 ? 48 ? ? ? ? ? C7 0F";
            CheckPointxASMsig = "33 C0 48 89 ? 48 89 ? ? 48 E9 ? ? ? ? 90 40 F3";
            CarIdAob = "00 B0 ? ? ? ? 7F ? 00 D8 6E";
            DiscoverRoadsAob = "63 70 ? B7 ? 5D";
            WaterAob = "3D ? ? ? ? 00 00 A0 ? ? ? ? ? ? ? ? 3F 00 00";
            AIXAob = "48 89 ? ? ? 57 48 83 EC ? 0F 10 ? 48 8B ? 0F 11 ? ? 48 8B";
            //TotalXpAddr = (Base3Addr + ",0xEE8,0x408,0x70,0x28,0x30,0x20,0x270");
        }
        public static void AobsFiveSteam()
        {
            Base = "26 21 ? ? 0F ? 00 48";
        }
        public static void StartSetupFive()
        {
            xAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x25F0");
            WeirdAddr = (BaseAddr + ",0x1F0,0xDB8,0x780,0x8,-0x2634");
            InRaceAddr = (Base2Addr + ",0x50,0x3D8");
            InPauseAddr = (Base2Addr + ",0x50,0x480");
            InHouseAddr = (Base2Addr + ",0x50,0x368");
            TestAddr = (Base2Addr + ",0x50,0x218");
            FOVHighAddr = (Base3Addr + ",0x538,0xF0,0xD80,0x6F0");
        }
        #region BG Workers
        public void ControllerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            var controllers = new[] { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };
            var directInput = new DirectInput();

            while (true)
            {
                foreach (var selectControler in controllers)
                {
                    if (selectControler.IsConnected)
                    {
                        controller = selectControler;
                        break;
                    }
                    Thread.Sleep(500);
                }
                if (controller == null)
                {
                    PopupForms.Controls.c.XBChangeSpeed.Enabled = false;
                    PopupForms.Controls.c.XBChangeBrake.Enabled = false;
                    PopupForms.Controls.c.XBChangeJump.Enabled = false;
                    if (count == 0)
                        Debug.WriteLine("No XInput controller installed");
                    count++;
                    Thread.Sleep(500);
                    try
                    {
                        foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                            joystickGuid = deviceInstance.InstanceGuid;
                        if (joystickGuid != Guid.Empty)
                        {
                            PopupForms.Controls.c.XBChangeSpeed.Enabled = true;
                            PopupForms.Controls.c.XBChangeBrake.Enabled = true;
                            PopupForms.Controls.c.XBChangeJump.Enabled = true;
                            joystick = new Joystick(directInput, joystickGuid);
                            joystick.Properties.BufferSize = 128;
                            joystick.Acquire();
                            joystick.Poll();
                            var datas = joystick.GetCurrentState().Buttons;
                            var LastDatas = datas;
                            while (directInput.IsDeviceAttached(joystickGuid))
                            {
                                datas = joystick.GetCurrentState().Buttons;
                                Thread.Sleep(100);
                            }
                        }
                    }
                    catch
                    {
                        joystickGuid = Guid.Empty;
                    }
                }
                else
                {
                    try
                    {
                        count = 0;
                        Debug.WriteLine("Found an XInput controller available");
                        var previousState = controller.GetState();
                        while (controller.IsConnected)
                        {
                            PopupForms.Controls.c.XBChangeSpeed.Enabled = true;
                            PopupForms.Controls.c.XBChangeBrake.Enabled = true;
                            PopupForms.Controls.c.XBChangeJump.Enabled = true;
                            var state = controller.GetState();
                            if (previousState.PacketNumber != state.PacketNumber)
                                Debug.WriteLine(state.Gamepad);
                            Thread.Sleep(10);
                            previousState = state;
                        }
                    }
                    catch
                    {
                        controller = null;
                    }
                }
                Thread.Sleep(500);
            }
        }
        public void VelHackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Velstart)
            {
                Keys KBKey = (Keys)Enum.Parse(typeof(Keys), KBSpeedKey);
                if (g2g)
                {
                    if (controller != null)
                    {
                        var XBState = controller.GetState();
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                        || XBState.Gamepad.Buttons.ToString().Contains(XBSpeedKey)
                        || XBSpeedKey == "LeftTrigger" && Convert.ToInt64(XBState.Gamepad.LeftTrigger) >= 235
                        || XBSpeedKey == "RightTrigger" && Convert.ToInt64(XBState.Gamepad.RightTrigger) >= 235)
                        {
                            SpeedHackVel();
                        }
                    }
                    else if (joystickGuid != Guid.Empty)
                    {
                        var datas = joystick.GetCurrentState();
                        bool[] ControllerButtonstate = datas.Buttons;
                        int test = DInputmap.SingleOrDefault(x => x.Value == XBSpeedKey).Key;
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                            || ControllerButtonstate[DInputmap.SingleOrDefault(x => x.Value == XBSpeedKey).Key]
                            || XBSpeedKey == "LeftTrigger" && datas.Z > 50000
                            || XBSpeedKey == "RightTrigger" && datas.Z < 20000
                            || XBSpeedKey == "DpadUp" && datas.PointOfViewControllers[0] == 0
                            || XBSpeedKey == "DpadRight" && datas.PointOfViewControllers[0] == 90000
                            || XBSpeedKey == "DpadDown" && datas.PointOfViewControllers[0] == 18000
                            || XBSpeedKey == "DpadLeft" && datas.PointOfViewControllers[0] == 27000)
                        {
                            SpeedHackVel();
                        }
                    }
                    else if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue)
                    {
                        SpeedHackVel();
                    }
                    if (VelHackWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        Velstart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        public void NoClipWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (NCstart)
            {
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//(PastStart == 1)
                {
                    if (WallNoClipToggle)
                    {
                        Noclip();
                    }
                    if (CarNoClipToggle)
                    {
                        var Jmp3 = new byte[6] { 0xE9, 0xB6, 0x01, 0x00, 0x00, 0x90 };
                        var Jmp4 = new byte[6] { 0xE9, 0x3B, 0x03, 0x00, 0x00, 0x90 };
                        if (!MainWindow.main.ForzaFour)
                            Jmp3 = new byte[6] { 0xE9, 0x66, 0x03, 0x00, 0x00, 0x90 };
                        for (int i = 0; i < 10; i++)
                        {
                            MainWindow.m.WriteBytes(Car1Addr, Jmp3);
                            if(MainWindow.main.ForzaFour)
                                MainWindow.m.WriteBytes(Car2Addr, Jmp4);
                        }
                        CarNoClipToggle = false;
                    }
                    if (NoClipWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        NCstart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        public void SpeedHackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Speedstart)
            {
                Keys KBKey = (Keys)Enum.Parse(typeof(Keys), KBSpeedKey);
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//(PastStart == 1)
                {
                    if (controller != null)
                    {
                        var XBState = controller.GetState();
                        while (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                        || XBState.Gamepad.Buttons.ToString().Contains(XBSpeedKey)
                        || XBSpeedKey == "LeftTrigger" && Convert.ToInt64(XBState.Gamepad.LeftTrigger) >= 235
                        || XBSpeedKey == "RightTrigger" && Convert.ToInt64(XBState.Gamepad.RightTrigger) >= 235)
                        {
                            XBState = controller.GetState();
                            SpeedHack();
                            continue;
                        }
                    }
                    else if (joystickGuid != Guid.Empty)
                    {
                        var datas = joystick.GetCurrentState();
                        bool[] ControllerButtonstate = datas.Buttons;
                        int test = DInputmap.SingleOrDefault(x => x.Value == XBSpeedKey).Key;
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                            || ControllerButtonstate[DInputmap.SingleOrDefault(x => x.Value == XBSpeedKey).Key]
                            || XBSpeedKey == "LeftTrigger" && datas.Z > 50000
                            || XBSpeedKey == "RightTrigger" && datas.Z < 20000
                            || XBSpeedKey == "UpDpad" && datas.PointOfViewControllers[0] == 0
                            || XBSpeedKey == "RightDpad" && datas.PointOfViewControllers[0] == 90000
                            || XBSpeedKey == "DownDpad" && datas.PointOfViewControllers[0] == 18000
                            || XBSpeedKey == "LeftDpad" && datas.PointOfViewControllers[0] == 27000)
                        {
                            SpeedHack();
                            continue;
                        }
                    }
                    else while (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue)
                    {
                        SpeedHack();
                        continue;
                    }
                    boost = MainWindow.m.ReadFloat(FrontLeftAddr);
                    if (SpeedHackWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        Speedstart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        public void TurnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Turnstart)
            {
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//if (PastStart == 1)
                {
                    if (controller != null)
                    {
                        var XBState = controller.GetState();
                        if (GetAsyncKeyState(Keys.A) is 1 or Int16.MinValue || Convert.ToInt64(XBState.Gamepad.LeftThumbX) <= -17000)
                        {
                            TurnAssistLeft();
                        }
                        if (GetAsyncKeyState(Keys.D) is 1 or Int16.MinValue || Convert.ToInt64(XBState.Gamepad.LeftThumbX) >= 17000)
                        {
                            TurnAssistRight();
                        }
                    }
                    else if (GetAsyncKeyState(Keys.A) is 1 or Int16.MinValue)
                    {
                        TurnAssistLeft();
                    }
                    else if (GetAsyncKeyState(Keys.D) is 1 or Int16.MinValue)
                    {
                        TurnAssistRight();
                    }
                    if (TurnWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        Turnstart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        public void FOVWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (FOVstart)
            {
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//if (PastStart == 1)
                {
                    if (GetAsyncKeyState(Keys.NumPad6) is 1 or Int16.MinValue)
                    {
                        Thread.Sleep(1);
                        FOVIncrease();
                    }
                    if (GetAsyncKeyState(Keys.NumPad4) is 1 or Int16.MinValue)
                    {
                        Thread.Sleep(1);
                        FOVdecrease();
                    }
                    if (FOVWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        FOVstart = false;
                        return;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        public void SuperBreakWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Breakstart)
            {
                Keys KBKey = (Keys)Enum.Parse(typeof(Keys), KBBrakeKey);
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//if (true)//(PastStart == 1)
                {
                    if (controller != null)
                    {
                        var XBState = controller.GetState();
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue || XBState.Gamepad.Buttons.ToString().Contains(XBBrakeKey))
                        {
                            SuperBreak();
                        }
                    }
                    else if (joystickGuid != Guid.Empty)
                    {
                        var datas = joystick.GetCurrentState();
                        bool[] ControllerButtonstate = datas.Buttons;
                        int test = DInputmap.SingleOrDefault(x => x.Value == XBBrakeKey).Key;
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                            || ControllerButtonstate[DInputmap.SingleOrDefault(x => x.Value == XBBrakeKey).Key]
                            || XBBrakeKey == "LeftTrigger" && datas.Z > 50000
                            || XBBrakeKey == "RightTrigger" && datas.Z < 20000
                            || XBBrakeKey == "UpDpad" && datas.PointOfViewControllers[0] == 0
                            || XBBrakeKey == "RightDpad" && datas.PointOfViewControllers[0] == 90000
                            || XBBrakeKey == "DownDpad" && datas.PointOfViewControllers[0] == 18000
                            || XBBrakeKey == "LeftDpad" && datas.PointOfViewControllers[0] == 27000)
                        {
                            SuperBreak();
                        }
                    }
                    else if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue)
                    {
                        SuperBreak();
                    }
                    if (SuperBreakWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        Breakstart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        private void StopWheelsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (StopToggle)
            {
                Keys KBKey = (Keys)Enum.Parse(typeof(Keys), KBBrakeKey);
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//if (true)//(PastStart == 1)
                {
                    if (controller != null)
                    {
                        var XBState = controller.GetState();
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue || XBState.Gamepad.Buttons.ToString().Contains(XBBrakeKey))
                        {
                            StopAllWheels();
                        }
                    }
                    else if (joystickGuid != Guid.Empty)
                    {
                        var datas = joystick.GetCurrentState();
                        bool[] ControllerButtonstate = datas.Buttons;
                        int test = DInputmap.SingleOrDefault(x => x.Value == XBSpeedKey).Key;
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                            || ControllerButtonstate[DInputmap.SingleOrDefault(x => x.Value == XBBrakeKey).Key]
                            || XBBrakeKey == "LeftTrigger" && datas.Z > 50000
                            || XBBrakeKey == "RightTrigger" && datas.Z < 20000
                            || XBBrakeKey == "UpDpad" && datas.PointOfViewControllers[0] == 0
                            || XBBrakeKey == "RightDpad" && datas.PointOfViewControllers[0] == 90000
                            || XBBrakeKey == "DownDpad" && datas.PointOfViewControllers[0] == 18000
                            || XBBrakeKey == "LeftDpad" && datas.PointOfViewControllers[0] == 27000)
                        {
                            StopAllWheels();
                        }
                    }
                    else if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue)
                    {
                        StopAllWheels();
                    }
                    if (StopWheelsWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        StopToggle = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        public void TimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var NOP = new byte[5] { 0x90, 0x90, 0x90, 0x90, 0x90 };
            //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
            bool get = true;
            while (Timestart)
            {
                if (g2g)//(PastStart == 1)
                {
                    if (get)
                    {
                        a.GetTimeAddr(CodeCave2);
                        MainWindow.m.WriteBytes(TimeNOPAddr, NOP);
                        get = false;
                    }
                    short one = GetAsyncKeyState(Keys.LShiftKey);
                    short two = GetAsyncKeyState(Keys.Right);
                    if (GetAsyncKeyState(Keys.NumPad6) is 1 or Int16.MinValue
                        || (GetAsyncKeyState(Keys.LShiftKey) is 1 or Int16.MinValue && (GetAsyncKeyState(Keys.Right) is 1 or Int16.MinValue)))
                    {
                        TimeForward();
                    }
                    if (GetAsyncKeyState(Keys.NumPad4) is 1 or Int16.MinValue
                        || ((GetAsyncKeyState(Keys.LShiftKey) is 1 or Int16.MinValue) && (GetAsyncKeyState(Keys.Left) is 1 or Int16.MinValue)))
                    {
                        TimeBack();
                    }
                    if (TimeWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        Timestart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        private void TimerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            string logdir = @"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit\Fh4\0-60 Logs\";
            if (!MainWindow.main.ForzaFour)
                logdir = @"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit\Fh5\0-60 Logs\";
            string filename = DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string path = Path.Combine(logdir, filename);
            if (!Directory.Exists(logdir))
            {
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool");
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit");
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit\Fh4");
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit\Fh5");
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit\Fh4\0-60 Logs");
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\Forza Mods Tool\Cool Shit\Fh5\0-60 Logs");
            }
            bool under = false;
            while (TimerToggle)
            {
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//(PastStart == 1)
                {
                    string value = null;
                    float Speed = (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694);
                    if (Speed < 0.01)
                        under = true;
                    while (under)
                    {
                        Speed = (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694);
                        if (Speed > 0.05 && Speed < 0.5)
                        {
                            stopWatch.Reset();
                            stopWatch.Start();
                            TimerIndicator.BackColor = Color.Green;
                        }
                        while (Speed > 0.05 && Speed < 61 && under && stopWatch.IsRunning)
                        {
                            Speed = (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694);
                            if (Speed >= 60)
                            {
                                stopWatch.Stop();
                                TimerIndicator.BackColor = Color.Red;
                                string FileName = "";
                                string CurrentID = MainWindow.m.Read2Byte(CurrentIDAddr).ToString();
                                if(MainWindow.main.ForzaFour)
                                {
                                    File.WriteAllBytes(Path.Combine(Path.GetTempPath(), "FclvYGRQ1w.csv"), FclvYGRQ1w);
                                    FileName = "FclvYGRQ1w.csv";
                                }
                                else
                                {
                                    File.WriteAllBytes(Path.Combine(Path.GetTempPath(), "cYdXosu7SL.csv"), cYdXosu7SL);
                                    FileName = "cYdXosu7SL.csv";
                                }
                                string nameColumnName = "ID";
                                string valueColumnName = "Short Name";
                                using (CsvReader csvReader = new CsvReader(new StreamReader(Path.Combine(Path.GetTempPath(), FileName)), hasHeaders: true))
                                {
                                    int nameColumnIndex = csvReader.GetFieldIndex(nameColumnName);
                                    int valueColumnIndex = csvReader.GetFieldIndex(valueColumnName);

                                    while (csvReader.ReadNextRecord())
                                    {
                                        if (csvReader[nameColumnIndex] == CurrentID)
                                        {
                                            value = csvReader[valueColumnIndex];
                                            break;
                                        }
                                        if (TimerWorker.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            TimerToggle = false;
                                        }
                                    }
                                }
                                File.Delete(Path.Combine(Path.GetTempPath(), FileName));
                                if (!File.Exists(path))
                                    using (FileStream fs = File.Create(path)) ;

                                if (new FileInfo(path).Length == 0)
                                {
                                    using StreamWriter sw = new StreamWriter(path, false);
                                    sw.WriteLine(DateTime.Now.ToString("h\\:mm tt - ") + value + " - " + stopWatch.Elapsed.TotalSeconds.ToString() + " seconds");
                                }
                                else
                                {
                                    using StreamWriter sw = new StreamWriter(path, true);
                                    sw.WriteLine(DateTime.Now.ToString("h\\:mm tt - ") + value + " - " + stopWatch.Elapsed.TotalSeconds.ToString() + " seconds");
                                }
                                under = false;
                            }
                            Thread.Sleep(1);
                            if (TimerWorker.CancellationPending)
                            {
                                e.Cancel = true;
                                TimerToggle = false;
                            }
                        }
                        if (TimerWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            TimerToggle = false;
                        }
                    }
                    stopWatch.Stop();
                    if (stopWatch.Elapsed.TotalSeconds > 0.001)
                        TimerLabel.Text = stopWatch.Elapsed.TotalSeconds.ToString();
                    if (TimerWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        TimerToggle = false;
                    }
                }
            }
        }
        private void WayPointWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!g2g)//(MainWindow.m.ReadFloat(PastStartAddr) == 0)
            {
                Thread.Sleep(100);
            }
            a.GetWayPointXAddr(CodeCave4, out WayPointBaseAddr);
            if (WayPointWorker.CancellationPending)
                e.Cancel = true;
        }
        private void WayPointTPworker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!WayPointWorker.IsBusy)
                WayPointWorker.RunWorkerAsync();
            while (WayPointTPToggle)
            {
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g && WayPointxAddr != null && WayPointyAddr != null && WayPointzAddr != null && WayPointBaseAddr != null && WayPointBaseAddr != "000000000000")//(PastStart == 1 && WayPointBaseAddr != null && WayPointBaseAddr != "000000000000")
                {
                    float NewWPx = MainWindow.m.ReadFloat(WayPointxAddr, round: false);
                    float NewWPy = MainWindow.m.ReadFloat(WayPointyAddr, round: false);
                    float NewWPz = MainWindow.m.ReadFloat(WayPointzAddr, round: false);
                    if ((LastWPx != NewWPx || LastWPy != NewWPy || LastWPz != NewWPz) && (NewWPx != 0 && NewWPy != 0 && NewWPz != 0
                    && NewWPx < 10000 && NewWPx > -10000
                    && NewWPy < 1000 && NewWPy > -1000
                    && NewWPz < 10000 && NewWPz > -10000))
                    {
                        try
                        {
                            MainWindow.m.WriteMemory(xAddr, "float", NewWPx.ToString());
                            MainWindow.m.WriteMemory(yAddr, "float", (NewWPy + 2).ToString());
                            MainWindow.m.WriteMemory(zAddr, "float", NewWPz.ToString());
                            LastWPx = NewWPx;
                            LastWPy = NewWPy;
                            LastWPz = NewWPz;
                        }
                        catch
                        {
                            if (!WayPointWorker.IsBusy)
                                WayPointWorker.RunWorkerAsync();
                        }
                    }
                    else if (!WayPointWorker.IsBusy)
                        WayPointWorker.RunWorkerAsync();
                    if (WayPointTPworker.CancellationPending)
                    {
                        e.Cancel = true;
                        WayPointTPToggle = false;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private void OOBworker_DoWork(object sender, DoWorkEventArgs e)
        {
            var before = new byte[] { 0x0F, 0x11, 0x9B, 0xE0, 0xFA, 0xFF, 0xFF };
            var nop = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            if (!MainWindow.main.ForzaFour)
            {
                before = new byte[] { 0x0F, 0x11, 0x51, 0x50 };
                nop = new byte[] { 0x90, 0x90, 0x90, 0x90 };
            }
            Stopwatch stopWatch = new Stopwatch();
            //string LastID = MainWindow.m.Read2Byte(CurrentIDAddr).ToString();
            MainWindow.m.WriteBytes(OOBnopAddr, nop);
            while (OOB)
            {
                if (OOBWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                try
                {
                    if(MainWindow.main.ForzaFour)
                    {
                        if (MainWindow.m.ReadFloat(InPauseAddr) == 1 || (MainWindow.m.ReadFloat(OnGroundAddr) == 0 && (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694) == 0))
                            MainWindow.m.WriteBytes(OOBnopAddr, before);
                        else
                            MainWindow.m.WriteBytes(OOBnopAddr, nop);
                    }
                    else
                    {
                        if (MainWindow.m.ReadFloat(InPauseAddr) == 1 || (MainWindow.m.ReadFloat(OnGroundAddr) > 0 && (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694) == 0))
                            MainWindow.m.WriteBytes(OOBnopAddr, before);
                        else
                            MainWindow.m.WriteBytes(OOBnopAddr, nop);
                    }
                }
                catch
                {
                    MainWindow.m.WriteBytes(OOBnopAddr, before);
                }
                Thread.Sleep(1);
            }
        }
        private void JumpHackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (JumpStart)
            {
                Keys KBKey = (Keys)Enum.Parse(typeof(Keys), KBJumpKey);
                //float PastStart = MainWindow.m.ReadFloat(PastStartAddr);
                if (g2g)//if (PastStart == 1)
                {
                    if (controller != null)
                    {
                        var XBState = controller.GetState();
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                        || XBState.Gamepad.Buttons.ToString().Contains(XBJumpKey)
                        || XBJumpKey == "LeftTrigger" && Convert.ToInt64(XBState.Gamepad.LeftTrigger) >= 235
                        || XBJumpKey == "RightTrigger" && Convert.ToInt64(XBState.Gamepad.RightTrigger) >= 235)
                        {
                            JumpHack();
                        }
                    }
                    else if (joystickGuid != Guid.Empty)
                    {
                        var datas = joystick.GetCurrentState();
                        bool[] ControllerButtonstate = datas.Buttons;
                        int test = DInputmap.SingleOrDefault(x => x.Value == XBJumpKey).Key;
                        if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue
                            || ControllerButtonstate[DInputmap.SingleOrDefault(x => x.Value == XBJumpKey).Key]
                            || XBJumpKey == "LeftTrigger" && datas.Z > 50000
                            || XBJumpKey == "RightTrigger" && datas.Z < 20000
                            || XBJumpKey == "DpadUp" && datas.PointOfViewControllers[0] == 0
                            || XBJumpKey == "DpadRight" && datas.PointOfViewControllers[0] == 90000
                            || XBJumpKey == "DpadDown" && datas.PointOfViewControllers[0] == 18000
                            || XBJumpKey == "DpadLeft" && datas.PointOfViewControllers[0] == 27000)
                        {
                            JumpHack();
                        }
                    }
                    else if (GetAsyncKeyState(KBKey) is 1 or Int16.MinValue)
                    {
                        JumpHack();
                    }
                    if (JumpHackWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        JumpStart = false;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
        #endregion

        #region Break Hack
        private void SuperBreakButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SuperBreakButton.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)SuperBreakButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                BreakToggle = false;
                if (BreakToggle == false)
                {
                    SuperBreakWorker.CancelAsync();
                }
            }
            else
            {

                ((Telerik.WinControls.Primitives.BorderPrimitive)SuperBreakButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                BreakToggle = true;
                Breakstart = true;
                if (SuperBreakWorker.IsBusy == false)
                {
                    SuperBreakWorker.RunWorkerAsync();
                }
            }
        }
        private void StopAllWheelsButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StopAllWheelsButton.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)StopAllWheelsButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                StopToggle = false;
                StopWheelsWorker.CancelAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)StopAllWheelsButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                StopToggle = true;
                if (StopWheelsWorker.IsBusy == false)
                {
                    StopWheelsWorker.RunWorkerAsync();
                }
            }
        }
        public void SuperBreak()
        {
            xVelocityVal = MainWindow.m.ReadFloat(xVelocityAddr) * (float)0.50;
            zVelocityVal = MainWindow.m.ReadFloat(zVelocityAddr) * (float)0.50;
            MainWindow.m.WriteMemory(xVelocityAddr, "float", xVelocityVal.ToString());
            MainWindow.m.WriteMemory(yVelocityAddr, "float", "0");
            MainWindow.m.WriteMemory(zVelocityAddr, "float", zVelocityVal.ToString());
            MainWindow.m.WriteMemory(yAngVelAddr, "float", "0");
            Thread.Sleep(50);
        }
        public void StopAllWheels()
        {
            MainWindow.m.WriteMemory(FrontLeftAddr, "float", "0");
            MainWindow.m.WriteMemory(FrontRightAddr, "float", "0");
            MainWindow.m.WriteMemory(BackLeftAddr, "float", "0");
            MainWindow.m.WriteMemory(BackRightAddr, "float", "0");
        }
        #endregion

        #region Jump Hack
        private void JumpHackToggle_CheckStateChanged(object sender, EventArgs e)
        {
            if (JumpHackToggle.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)JumpHackToggle.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                JumpHackToggleToggle = false;
                JumpStart = false;
                if (JumpHackToggleToggle == false)
                {
                    JumpHackWorker.CancelAsync();
                }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)JumpHackToggle.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                JumpHackToggleToggle = true;
                JumpStart = true;
                if (JumpHackWorker.IsBusy == false)
                {
                    JumpHackWorker.RunWorkerAsync();
                }
            }
        }
        #endregion

        #region Speed Hack
        private void VelHackButton_CheckedChanged(object sender, EventArgs e)
        {
            if (VelHackButton.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)VelHackButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                VelHackToggle = false;
                if (VelHackToggle == false)
                {
                    VelHackWorker.CancelAsync();
                }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)VelHackButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                VelHackToggle = true;
                Velstart = true;
                if (VelHackWorker.IsBusy == false)
                {
                    VelHackWorker.RunWorkerAsync();
                }
            }
        }
        private void WheelSpeedButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WheelSpeedButton.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)WheelSpeedButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                SpeedHackToggle = false;
                if (SpeedHackToggle == false)
                {
                    SpeedHackWorker.CancelAsync();
                }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)WheelSpeedButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                SpeedHackToggle = true;
                Speedstart = true;
                if (SpeedHackWorker.IsBusy == false)
                {
                    SpeedHackWorker.RunWorkerAsync();
                }
            }
        }
        public void SpeedHackVel()
        {
            var speed = (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694);
            if (speed < (float)VelLimitBox.Value)
            {
                xVelocityVal = MainWindow.m.ReadFloat(xVelocityAddr) * (float)VelMult;
                zVelocityVal = MainWindow.m.ReadFloat(zVelocityAddr) * (float)VelMult;
                y = MainWindow.m.ReadFloat(yAddr) - (float)0.02;
                MainWindow.m.WriteMemory(xVelocityAddr, "float", xVelocityVal.ToString());
                MainWindow.m.WriteMemory(zVelocityAddr, "float", zVelocityVal.ToString());
                //MainWindow.m.WriteMemory(yAddr, "float", y.ToString());
                Thread.Sleep(50);
            }
        }
        public void JumpHack()
        {
            if(MainWindow.m.ReadFloat(InPauseAddr) != 1)
                MainWindow.m.WriteMemory(yVelocityAddr, "float", (MainWindow.m.ReadFloat(yVelocityAddr, round:false) + (float)JumpAmountBox.Value).ToString());
            Thread.Sleep(50);
        }
        public void SpeedHack()
        {
            MainWindow.m.WriteMemory(GasAddr, "float", "1");
            float speed = (float)(Math.Sqrt(Math.Pow(MainWindow.m.ReadFloat(xVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(yVelocityAddr, round: false), 2) + Math.Pow(MainWindow.m.ReadFloat(zVelocityAddr, round: false), 2)) * 2.23694);
            if (speed < BoostSpeed1)
            {
                /*for (int i = 0; i < times1; i++)
                {
                    boost++;
                }*/
                boost += times1;
                Thread.Sleep(BoostInterval1);
            }
            else if (speed < BoostSpeed2)
            {
                boost += times2;
                Thread.Sleep(BoostInterval2);
            }
            else if (speed < BoostSpeed3)
            {
                boost += times3;
                Thread.Sleep(BoostInterval3);
            }
            else
            {
                boost += times4;
                Thread.Sleep(BoostInterval4);
            }
            try
            {
                if(speed < BoostLim)
                {
                    MainWindow.m.WriteMemory(FrontLeftAddr, "float", boost.ToString());
                    MainWindow.m.WriteMemory(FrontRightAddr, "float", boost.ToString());
                    MainWindow.m.WriteMemory(BackLeftAddr, "float", boost.ToString());
                    MainWindow.m.WriteMemory(BackRightAddr, "float", boost.ToString());
                }
            }
            catch { }
        }
        #endregion

        #region Turn Assist
        private void TurnAssistButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TurnAssistButton.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TurnAssistButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                TurnAssistToggle = false;
                if (TurnAssistToggle == false)
                {
                    TurnWorker.CancelAsync();
                }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TurnAssistButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                TurnAssistToggle = true;
                Turnstart = true;
                if (TurnWorker.IsBusy == false)
                {
                    TurnWorker.RunWorkerAsync();
                }
            }
        }
        public void TurnAssistLeft()
        {
            float FrontLeft = MainWindow.m.ReadFloat(FrontLeftAddr);
            float FrontRight = MainWindow.m.ReadFloat(FrontRightAddr);
            float BackLeft = MainWindow.m.ReadFloat(BackLeftAddr);
            float BackRight = MainWindow.m.ReadFloat(BackRightAddr);
            if ((float)Math.Abs(FrontRight - FrontLeft) < (FrontRight / TurnRatio) && (float)Math.Abs(BackRight - FrontLeft) < (BackRight / TurnRatio))
            {
                FrontLeft = FrontLeft - TurnStrength;
                BackLeft = BackLeft - TurnStrength;
                FrontRight = FrontRight + TurnStrength;
                BackRight = BackRight + TurnStrength;
                Thread.Sleep(TurnInterval);
            }
            MainWindow.m.WriteMemory(FrontLeftAddr, "float", FrontLeft.ToString());
            MainWindow.m.WriteMemory(FrontRightAddr, "float", FrontRight.ToString());
            MainWindow.m.WriteMemory(BackLeftAddr, "float", BackLeft.ToString());
            MainWindow.m.WriteMemory(BackRightAddr, "float", BackRight.ToString());
        }
        public void TurnAssistRight()
        {
            float FrontLeft = MainWindow.m.ReadFloat(FrontLeftAddr);
            float FrontRight = MainWindow.m.ReadFloat(FrontRightAddr);
            float BackLeft = MainWindow.m.ReadFloat(BackLeftAddr);
            float BackRight = MainWindow.m.ReadFloat(BackRightAddr);
            if ((float)Math.Abs(FrontLeft - FrontRight) < (FrontLeft / TurnRatio) && (float)Math.Abs(BackLeft - FrontRight) < (BackLeft / TurnRatio))
            {
                FrontRight = FrontRight - TurnStrength;
                BackRight = BackRight - TurnStrength;
                FrontLeft = FrontLeft + TurnStrength;
                BackLeft = BackLeft + TurnStrength;
                Thread.Sleep(TurnInterval);
            }
            MainWindow.m.WriteMemory(FrontLeftAddr, "float", FrontLeft.ToString());
            MainWindow.m.WriteMemory(FrontRightAddr, "float", FrontRight.ToString());
            MainWindow.m.WriteMemory(BackLeftAddr, "float", BackLeft.ToString());
            MainWindow.m.WriteMemory(BackRightAddr, "float", BackRight.ToString());
        }
        #endregion

        #region Time
        private void TimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var NOPBefore = new byte[5] { 0xF2, 0x0F, 0x11, 0x43, 0x08 };
            if (TimeCheckBox.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TimeCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                MainWindow.m.WriteBytes(TimeNOPAddr, NOPBefore);
                TimeToggle = false;
                if (TimeToggle == false)
                {
                    TimeWorker.CancelAsync();
                }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TimeCheckBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                TimeToggle = true;
                Timestart = true;
                if (TimeWorker.IsBusy == false)
                {
                    TimeWorker.RunWorkerAsync();
                }
            }
        }
        private void TimeBack()
        {
            if(GetAsyncKeyState(Keys.LControlKey) is 1 or Int16.MinValue)
            {
                Thread.Sleep(300);//Thread.Sleep(250);
                double TimeValDouble = MainWindow.m.ReadDouble(TimeAddr);
                string TimeVal = (TimeValDouble - 1000).ToString();//string TimeVal = (TimeValDouble + 10000).ToString();
                MainWindow.m.WriteMemory(TimeAddr, "double", TimeVal);
            }
            else
            {
                Thread.Sleep(10);//Thread.Sleep(50);
                double TimeValDouble = MainWindow.m.ReadDouble(TimeAddr);
                string TimeVal = (TimeValDouble - 20).ToString();//string TimeVal = (TimeValDouble - 100).ToString();
                MainWindow.m.WriteMemory(TimeAddr, "double", TimeVal);
            }
        }
        private void TimeForward()
        {
            if (GetAsyncKeyState(Keys.LControlKey) is 1 or Int16.MinValue)
            {
                Thread.Sleep(300);//Thread.Sleep(250);
                double TimeValDouble = MainWindow.m.ReadDouble(TimeAddr);
                string TimeVal = (TimeValDouble + 1000).ToString();//string TimeVal = (TimeValDouble + 10000).ToString();
                MainWindow.m.WriteMemory(TimeAddr, "double", TimeVal);
            }
            else
            {
                Thread.Sleep(10);//Thread.Sleep(50);
                double TimeValDouble = MainWindow.m.ReadDouble(TimeAddr);
                string TimeVal = (TimeValDouble + 20).ToString();//string TimeVal = (TimeValDouble + 100).ToString();
                MainWindow.m.WriteMemory(TimeAddr, "double", TimeVal);
            }
        }
        #endregion

        #region Autowin
        public void CheckPointTPworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (CheckPointTPToggle)
            {
                float InRace = MainWindow.m.ReadFloat(InRaceAddr);
                if (InRace == 1)
                {
                    Thread.Sleep(5000);
                    while (InRace == 1)
                    {
                        try
                        {
                            if (CheckPointTPworker.CancellationPending)
                            {
                                e.Cancel = true;
                                CheckPointTPToggle = false;
                                break;
                            }
                            a.GetCheckXAddr(CodeCave, out CheckPointBaseAddr);
                            CheckPointxAddr = (Int64.Parse(CheckPointBaseAddr, NumberStyles.HexNumber) + 608).ToString("X");
                            CheckPointyAddr = (Int64.Parse(CheckPointBaseAddr, NumberStyles.HexNumber) + 612).ToString("X");
                            CheckPointzAddr = (Int64.Parse(CheckPointBaseAddr, NumberStyles.HexNumber) + 616).ToString("X");
                            InRace = MainWindow.m.ReadFloat(InRaceAddr);
                            Thread.Sleep(200);
                            if (MainWindow.m.ReadFloat(CheckPointxAddr) != 0 && MainWindow.m.ReadFloat(CheckPointyAddr) != 0 && MainWindow.m.ReadFloat(CheckPointzAddr) != 0
                                && MainWindow.m.ReadFloat(CheckPointxAddr) > -9800 && MainWindow.m.ReadFloat(CheckPointxAddr) < 6600
                                && MainWindow.m.ReadFloat(CheckPointyAddr) > 0 && MainWindow.m.ReadFloat(CheckPointyAddr) < 1000
                                && MainWindow.m.ReadFloat(CheckPointzAddr) > -4300 && MainWindow.m.ReadFloat(CheckPointzAddr) < 5700
                                && Math.Abs(MainWindow.m.ReadFloat(CheckPointxAddr) - MainWindow.m.ReadFloat(xAddr)) < 750
                                && Math.Abs(MainWindow.m.ReadFloat(CheckPointyAddr) - MainWindow.m.ReadFloat(yAddr)) < 750
                                && Math.Abs(MainWindow.m.ReadFloat(CheckPointzAddr) - MainWindow.m.ReadFloat(zAddr)) < 750)
                                CheckPointTP();
                        }
                        catch
                        {
                            if (CheckPointTPworker.CancellationPending)
                            {
                                e.Cancel = true;
                                CheckPointTPToggle = false;
                                break;
                            }
                            a.GetCheckXAddr(CodeCave, out CheckPointBaseAddr);
                        }
                    }
                    MainWindow.m.UnfreezeValue(yAngVelAddr);
                    if (CheckPointTPworker.CancellationPending)
                    {
                        e.Cancel = true;
                        CheckPointTPToggle = false;
                        break;
                    }
                }
                if (CheckPointTPworker.CancellationPending)
                {
                    e.Cancel = true;
                    CheckPointTPToggle = false;
                    break;
                }
                Thread.Sleep(1);
            }
        }
        public void CheckPointTP()
        {
            MainWindow.m.WriteMemory(xAddr, "float", (MainWindow.m.ReadFloat(CheckPointxAddr)).ToString());
            MainWindow.m.WriteMemory(yAddr, "float", (MainWindow.m.ReadFloat(CheckPointyAddr) + 4).ToString());
            MainWindow.m.WriteMemory(zAddr, "float", (MainWindow.m.ReadFloat(CheckPointzAddr)).ToString());
            MainWindow.m.FreezeValue(yAngVelAddr, "float", "100");
            Thread.Sleep(1);
        }
        #endregion

        #region Noclip
        public void Noclip()
        {
            var Jmp1 = new byte[6] { 0xE9, 0x2A, 0x02, 0x00, 0x00, 0x90 };
            var Jmp2 = new byte[6] { 0xE9, 0x2B, 0x02, 0x00, 0x00, 0x90 };
            var Jmp1before = new byte[6] { 0x0F, 0x84, 0x29, 0x02, 0x00, 0x00 };
            var Jmp2before = new byte[6] { 0x0F, 0x84, 0x2A, 0x02, 0x00, 0x00 };
            if (!MainWindow.main.ForzaFour)
            {
                Jmp1 = new byte[6] { 0xE9, 0x61, 0x02, 0x00, 0x00, 0x90 };
                Jmp2 = new byte[6] { 0xE9, 0x7F, 0x02, 0x00, 0x00, 0x90 };
                Jmp1before = new byte[6] { 0x0F, 0x84, 0x60, 0x02, 0x00, 0x00 };
                Jmp2before = new byte[6] { 0x0F, 0x84, 0x7E, 0x02, 0x00, 0x00 };
            }
            float OnGround = MainWindow.m.ReadFloat(OnGroundAddr);
            if (!MainWindow.main.ForzaFour)
            {
                if (OnGround > 0)
                {
                    OnGround = MainWindow.m.ReadFloat(OnGroundAddr);
                    if (OnGround > 0)
                    {
                        MainWindow.m.WriteBytes(Wall1Addr, Jmp1before);
                        MainWindow.m.WriteBytes(Wall2Addr, Jmp2before);
                    }
                }
                if (OnGround == 0)
                {
                    NoClipcycles++;
                    if (NoClipcycles % 10 == 0)
                    {
                        MainWindow.m.WriteBytes(Wall1Addr, Jmp1);
                        MainWindow.m.WriteBytes(Wall2Addr, Jmp2);
                        NoClipcycles = 0;
                    }
                }
            }
            else
            {
                if (OnGround == 0)
                {
                    NoClipcycles++;
                    if (NoClipcycles % 10 == 1)
                    {
                        OnGround = MainWindow.m.ReadFloat(OnGroundAddr);
                        if (OnGround == 0)
                        {
                            MainWindow.m.WriteBytes(Wall1Addr, Jmp1before);
                            MainWindow.m.WriteBytes(Wall2Addr, Jmp2before);
                        }
                        NoClipcycles = 0;
                    }
                }
                if (OnGround == 1)
                {
                    NoClipcycles++;
                    if (NoClipcycles % 10 == 0)
                    {
                        MainWindow.m.WriteBytes(Wall1Addr, Jmp1);
                        MainWindow.m.WriteBytes(Wall2Addr, Jmp2);
                        NoClipcycles = 0;
                    }
                }
            }
        }
        private void TB_SHCarNoClip_CheckedChanged(object sender, EventArgs e)
        {
            var Jmp3before = new byte[6] { 0x0F, 0x84, 0xB5, 0x01, 0x00, 0x00 };
            var Jmp4before = new byte[6] { 0x0F, 0x84, 0x3A, 0x03, 0x00, 0x00 };
            if(!MainWindow.main.ForzaFour)
                Jmp3before = new byte[6] { 0x0F, 0x84, 0x65, 0x03, 0x00, 0x00 };

            if (TB_SHCarNoClip.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TB_SHCarNoClip.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                MainWindow.m.WriteBytes(Car1Addr, Jmp3before);
                if(MainWindow.main.ForzaFour)
                    MainWindow.m.WriteBytes(Car2Addr, Jmp4before);
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TB_SHCarNoClip.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                CarNoClipToggle = true;
                NCstart = true;
                if (NoClipWorker.IsBusy == false)
                {
                    NoClipWorker.RunWorkerAsync();
                }
            }
        }
        private void TB_SHWallNoClip_CheckedChanged(object sender, EventArgs e)
        {
            var Jmp1before = new byte[6] { 0x0F, 0x84, 0x29, 0x02, 0x00, 0x00 };
            var Jmp2before = new byte[6] { 0x0F, 0x84, 0x2A, 0x02, 0x00, 0x00 };
            if(!MainWindow.main.ForzaFour)
            {
                Jmp1before = new byte[6] { 0x0F, 0x84, 0x60, 0x02, 0x00, 0x00 };
                Jmp2before = new byte[6] { 0x0F, 0x84, 0x7E, 0x02, 0x00, 0x00 };
            }
            if (TB_SHWallNoClip.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TB_SHWallNoClip.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                WallNoClipToggle = false;
                if (WallNoClipToggle == false)
                {
                    NoClipWorker.CancelAsync();
                }
                MainWindow.m.WriteBytes(Wall1Addr, Jmp1before);
                MainWindow.m.WriteBytes(Wall2Addr, Jmp2before);
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TB_SHWallNoClip.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                WallNoClipToggle = true;
                NCstart = true;
                if (NoClipWorker.IsBusy == false)
                {
                    NoClipWorker.RunWorkerAsync();
                }
            }
        }
        #endregion

        #region Key Change Buttons
        public void KeyboardChangeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool done = false;
            if ((int)e.Argument == 1)
            {
                PopupForms.Controls.c.KBChangeSpeed.Text = "Press Key";
            }
            if ((int)e.Argument == 2)
            {
                PopupForms.Controls.c.KBChangeBrake.Text = "Press Key";
            }
            if ((int)e.Argument == 3)
            {
                PopupForms.Controls.c.KBChangeJump.Text = "Press Key";
            }
            while (!done)
            {
                string keyBuffer = string.Empty;
                foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
                {
                    int x = GetAsyncKeyState(i);
                    if ((x == 1) || (x == Int16.MinValue))
                    {
                        if (i != 0 && i != 1 && i != 2 && i != 3 && i != 4 && i != 12)
                        {
                            keyBuffer += Enum.GetName(typeof(Keys), i);
                        }
                    }
                }
                if (keyBuffer != "" && keyBuffer != "Clear")
                {
                    if (keyBuffer == "ShiftKeyLShiftKey")
                        keyBuffer = "LShiftKey";
                    if (keyBuffer == "ControlKeyLControlKey")
                        keyBuffer = "LControlKey";
                    if (keyBuffer == "AltKeyLAltKey")
                        keyBuffer = "LAltKey";
                    if((int)e.Argument == 1)
                    {
                        PopupForms.Controls.c.KBChangeSpeed.Text = keyBuffer;
                        KBSpeedKey = keyBuffer;
                    }
                    if ((int)e.Argument == 2)
                    {
                        PopupForms.Controls.c.KBChangeBrake.Text = keyBuffer;
                        KBBrakeKey = keyBuffer;
                    }
                    if ((int)e.Argument == 3)
                    {
                        PopupForms.Controls.c.KBChangeJump.Text = keyBuffer;
                        KBJumpKey = keyBuffer;
                    }
                    done = true;
                }
                Thread.Sleep(1);
            }
        }
        private void ControllerChangeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)e.Argument == 1)
            {
                PopupForms.Controls.c.XBChangeSpeed.Text = "Press button";
            }
            if ((int)e.Argument == 2)
            {
                PopupForms.Controls.c.XBChangeBrake.Text = "Press button";
            }
            if ((int)e.Argument == 3)
            {
                PopupForms.Controls.c.XBChangeJump.Text = "Press button";
            }
            bool done = false;
            if (controller != null)
            {
                while (!done)
                {
                    var State = controller.GetState();
                    string ControllerButtonstate = State.Gamepad.Buttons.ToString();
                    long ControllerRTstate = Convert.ToInt64(State.Gamepad.RightTrigger);
                    long ControllerLTstate = Convert.ToInt64(State.Gamepad.LeftTrigger);
                    if (ControllerButtonstate != "None")
                    {
                        if ((int)e.Argument == 1)
                        {
                            PopupForms.Controls.c.XBChangeSpeed.Text = ControllerButtonstate;
                            XBSpeedKey = ControllerButtonstate;
                        }
                        if ((int)e.Argument == 2)
                        {
                            PopupForms.Controls.c.XBChangeBrake.Text = ControllerButtonstate;
                            XBBrakeKey = ControllerButtonstate;
                        }
                        if ((int)e.Argument == 3)
                        {
                            PopupForms.Controls.c.XBChangeJump.Text = ControllerButtonstate;
                            XBJumpKey = ControllerButtonstate;
                        }
                        done = true;
                    }
                    if (ControllerRTstate > 240)
                    {
                        if ((int)e.Argument == 1)
                        {
                            PopupForms.Controls.c.XBChangeSpeed.Text = "RightTrigger";
                            XBSpeedKey = "RightTrigger";
                        }
                        if ((int)e.Argument == 2)
                        {
                            PopupForms.Controls.c.XBChangeBrake.Text = "RightTrigger";
                            XBBrakeKey = "RightTrigger";
                        }
                        if ((int)e.Argument == 3)
                        {
                            PopupForms.Controls.c.XBChangeJump.Text = "RightTrigger";
                            XBJumpKey = "RightTrigger";
                        }
                        done = true;
                    }
                    if (ControllerLTstate > 240)
                    {
                        if ((int)e.Argument == 1)
                        {
                            PopupForms.Controls.c.XBChangeSpeed.Text = "LeftTrigger";
                            XBSpeedKey = "LeftTrigger";
                        }
                        if ((int)e.Argument == 2)
                        {
                            PopupForms.Controls.c.XBChangeBrake.Text = "LeftTrigger";
                            XBBrakeKey = "LeftTrigger";
                        }
                        if ((int)e.Argument == 3)
                        {
                            PopupForms.Controls.c.XBChangeJump.Text = "LeftTrigger";
                            XBJumpKey = "LeftTrigger";
                        }
                        done = true;
                    }
                    Thread.Sleep(10);
                }
            }
            else if (joystickGuid != Guid.Empty)
            {
                while (!done)
                {
                    try
                    {
                        var datas = joystick.GetCurrentState();
                        bool[] ControllerButtonstate = datas.Buttons;
                        List<int> indices = new List<int>();
                        string Analogue = null;
                        for (int i = 0; i < 9; ++i)
                        {
                            if (datas.Z > 50000) { Analogue = "LeftTrigger"; }
                            if (datas.Z < 20000) { Analogue = "RightTrigger"; }
                            if (datas.PointOfViewControllers[0] == 0) { Analogue = "DpadUp"; }
                            if (datas.PointOfViewControllers[0] == 9000) { Analogue = "DpadRight"; }
                            if (datas.PointOfViewControllers[0] == 18000) { Analogue = "DpadDown"; }
                            if (datas.PointOfViewControllers[0] == 27000) { Analogue = "DpadLeft"; }
                            if (ControllerButtonstate[i])
                            {
                                indices.Add(i);
                            }
                        }
                        if (indices.Count == 1)
                        {
                            int XBButtonIndex = indices[0];
                            if (XBButtonIndex <= 9)
                            {
                                if ((int)e.Argument == 1)
                                {
                                    PopupForms.Controls.c.XBChangeSpeed.Text = DInputmap[XBButtonIndex];
                                    XBSpeedKey = DInputmap[XBButtonIndex];
                                }
                                if ((int)e.Argument == 2)
                                {
                                    PopupForms.Controls.c.XBChangeBrake.Text = DInputmap[XBButtonIndex];
                                    XBBrakeKey = DInputmap[XBButtonIndex];
                                }
                                if ((int)e.Argument == 3)
                                {
                                    PopupForms.Controls.c.XBChangeJump.Text = DInputmap[XBButtonIndex];
                                    XBJumpKey = DInputmap[XBButtonIndex];
                                }
                                done = true;
                            }
                        }
                        else if (Analogue != null)
                        {
                            if ((int)e.Argument == 1)
                            {
                                PopupForms.Controls.c.XBChangeSpeed.Text = Analogue;
                                XBSpeedKey = Analogue;
                            }
                            if ((int)e.Argument == 2)
                            {
                                PopupForms.Controls.c.XBChangeBrake.Text = Analogue;
                                XBBrakeKey = Analogue;
                            }
                            if ((int)e.Argument == 3)
                            {
                                PopupForms.Controls.c.XBChangeJump.Text = Analogue;
                                XBJumpKey = Analogue;
                            }
                            done = true;
                        }
                        indices = null;
                        Thread.Sleep(1);
                    }
                    catch
                    {
                        //joystick.Acquire();
                        Thread.Sleep(1);
                    }
                    Thread.Sleep(1);
                }
            }
        }
        #endregion

        # region Teleports
        private void LST_TeleportLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LST_TeleportLocation.Text)
            {
                #region fh4
                case "Adventure Park":
                    x = (float)2267.335449;
                    y = (float)304.2393494;
                    z = (float)-2611.638428;
                    break;
                case "Ambleside":
                    x = (float)-5112.047363;
                    y = (float)154.1546478;
                    z = (float)-3534.503906;
                    break;
                case "Beach":
                    x = (float)4874.382812;
                    y = (float)124.9019775;
                    z = (float)-1392.215454;
                    break;
                case "Broadway":
                    x = (float)-237.2871857;
                    y = (float)239.5045471;
                    z = (float)-5816.858398;
                    break;
                case "Dam":
                    x = (float)-854.6953125;
                    y = (float)209.1066284;
                    z = (float)-2031.137329;
                    break;
                case "Edinburgh":
                    x = (float)2045.383179;
                    y = (float)204.0559845;
                    z = (float)2511.078613;
                    break;
                case "Festival":
                    x = (float)-2753.350098;
                    y = (float)349.7218018;
                    z = (float)-4357.629883;
                    break;
                case "Greendale Airstrip":
                    x = (float)3409.570068;
                    y = (float)159.2418976;
                    z = (float)661.2498779;
                    break;
                case "Lake Island":
                    x = (float)-4001.890869;
                    y = (float)175.7261353;
                    z = (float)-196.6170197;
                    break;
                case "Mortimer Gardens":
                    x = (float)-4314.36377;
                    y = (float)153.261261;
                    z = (float)1804.139282;
                    break;
                case "Quarry":
                    x = (float)-1569.987305;
                    y = (float)206.0023804;
                    z = (float)-2843.05249;
                    break;
                case "Railyard":
                    x = (float)-935.0923462;
                    y = (float)161.055069;
                    z = (float)1745.383667;
                    break;
                case "Start of Motorway":
                    x = (float)2657.887451;
                    y = (float)270.7128906;
                    z = (float)-4353.087402;
                    break;
                case "Top of Mountain":
                    x = (float)-2285.739746;
                    y = (float)364.6417236;
                    z = (float)2576.946533;
                    break;
                #endregion
                #region fh5
                case "Top Of Volcano":
                    x = (float)-5594.330078;
                    y = (float)1023.229919;
                    z = (float)2392.037109;
                    break;
                case "Stadium":
                    x = (float)-762.8079834;
                    y = (float)169.0338593;
                    z = (float)1615.112183;
                    break;
                case "Guanajuato (Main City)":
                    x = (float)355.9811096;
                    y = (float)258.8370056;
                    z = (float)3135.321533;
                    break;
                case "Bridge":
                    x = (float)-5820.825684;
                    y = (float)122.3475876;
                    z = (float)-2550.383545;
                    break;
                case "Golf Course":
                    x = (float)-8316.630859;
                    y = (float)125.8156357;
                    z = (float)-1150.103271;
                    break;
                case "Dunes":
                    x = (float)-8615.027344;
                    y = (float)143.9117279;
                    z = (float)1966.912109;
                    break;
                case "Motorway":
                    x = (float)2855.958252;
                    y = (float)195.1608429;
                    z = (float)1465.902954;
                    break;
                case "Airstrip":
                    x = (float)-3891.084717;
                    y = (float)174.4389496;
                    z = (float)-3841.428467;
                    break;
                case "Mulege":
                    x = (float)-4174.963867;
                    y = (float)122.9130783;
                    z = (float)-2227.120605;
                    break;
                case "Temple":
                    x = (float)3643.609375;
                    y = (float)230.227066;
                    z = (float)-2646.405029;
                    break;
                case "River":
                    x = (float)923.4258423;
                    y = (float)246.7331696;
                    z = (float)-2980.020264;
                    break;
                case "Dirt Circuit":
                    x = (float)-8344.927734;
                    y = (float)200.0671387;
                    z = (float)3197.32959;
                    break;
                case "Pllaya Azul":
                    x = (float)5550.070801;
                    y = (float)105.1047897;
                    z = (float)497.8027649;
                    break;
                case "Temple Drag":
                    x = (float)751.5328979;
                    y = (float)190.3298645;
                    z = (float)-110.3424072;
                    break;
                #endregion
            }
        }
        private void TPButton_Click(object sender, EventArgs e)
        {
            if (LST_TeleportLocation.Text == "Waypoint")
            {
                if(WayPointBaseAddr == "000000000000" || WayPointBaseAddr == null)
                {
                    if(!WayPointWorker.IsBusy)
                        WayPointWorker.RunWorkerAsync();
                    else
                        MessageBox.Show("Make a new waypoint");
                }
                else
                {
                    float WayPointX = MainWindow.m.ReadFloat(WayPointxAddr, round: false);
                    float WayPointY = MainWindow.m.ReadFloat(WayPointyAddr, round: false);
                    float WayPointZ = MainWindow.m.ReadFloat(WayPointzAddr, round: false);
                    if (WayPointX != 0 && WayPointY != 0 && WayPointZ != 0)
                    {
                        MainWindow.m.WriteMemory(xAddr, "float", WayPointX.ToString());
                        MainWindow.m.WriteMemory(yAddr, "float", (WayPointY + 2).ToString());
                        MainWindow.m.WriteMemory(zAddr, "float", WayPointZ.ToString());
                    }
                    else
                        MessageBox.Show("Set a waypoint first smh my head");
                }
            }
            else if (LST_TeleportLocation.Text == "Lake Island")
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.Elapsed < TimeSpan.FromSeconds(1))
                {
                    MainWindow.m.WriteMemory(xAddr, "float", x.ToString());
                    MainWindow.m.WriteMemory(yAddr, "float", y.ToString());
                    MainWindow.m.WriteMemory(zAddr, "float", z.ToString());
                }
                stopWatch.Stop();
            }
            else
            {
                MainWindow.m.WriteMemory(xAddr, "float", x.ToString());
                MainWindow.m.WriteMemory(yAddr, "float", y.ToString());
                MainWindow.m.WriteMemory(zAddr, "float", z.ToString());
            }
        }
        private void CheckpointBox_CheckedChanged(object sender, EventArgs e)
        {
            byte[] original = new byte[7]{ 0x0F, 0x28, 0x89, 0x60, 0x02, 0x00, 0x00 };
            if(!MainWindow.main.ForzaFour)
                original = new byte[7] { 0x0F, 0x10, 0x89, 0x60, 0x02, 0x00, 0x00 };
            if (CheckpointBox.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)CheckpointBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                CheckPointTPToggle = false;
                CheckPointTPworker.CancelAsync();
                MainWindow.m.UnfreezeValue(RollAddr);
                MainWindow.m.UnfreezeValue(PitchAddr);
                MainWindow.m.UnfreezeValue(yAngVelAddr);
                MainWindow.m.WriteBytes(CheckPointxASMAddr, original);
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)CheckpointBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                CheckPointTPToggle = true;
                CheckPointTPworker.RunWorkerAsync();
            }
        }
        private void WayPointBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoWayPoint.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)AutoWayPoint.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                WayPointTPToggle = false;
                WayPointTPworker.CancelAsync();
                WayPointWorker.CancelAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)AutoWayPoint.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                WayPointTPToggle = true;
                if(!WayPointTPworker.IsBusy)
                    WayPointTPworker.RunWorkerAsync();
            }
        }
        #endregion

        #region Variables
        private void TurnIntervalBox_ValueChanged(object sender, EventArgs e)
        {
            TurnInterval = Decimal.ToInt32(TurnIntervalBox.Value);
        }
        private void RatioBox_ValueChanged(object sender, EventArgs e)
        {
            TurnRatio = Decimal.ToSingle(RatioBox.Value);
        }
        private void TurnStrengthBox_ValueChanged(object sender, EventArgs e)
        {
            TurnStrength = Decimal.ToSingle(TurnStrengthBox.Value);
        }
        private void Speed1Box_ValueChanged(object sender, EventArgs e)
        {
            BoostSpeed1 = Decimal.ToSingle(Speed1Box.Value);
        }
        private void Speed2Box_ValueChanged(object sender, EventArgs e)
        {
            BoostSpeed2 = Decimal.ToSingle(Speed2Box.Value);
        }
        private void Speed3Box_ValueChanged(object sender, EventArgs e)
        {
            BoostSpeed3 = Decimal.ToSingle(Speed3Box.Value);
        }
        private void LimitBox_ValueChanged(object sender, EventArgs e)
        {
            BoostLim = Decimal.ToSingle(LimitBox.Value);
        }
        private void Interval1Box_ValueChanged(object sender, EventArgs e)
        {
            BoostInterval1 = Decimal.ToInt32(Interval1Box.Value);
        }
        private void Interval2Box_ValueChanged(object sender, EventArgs e)
        {
            BoostInterval2 = Decimal.ToInt32(Interval2Box.Value);
        }
        private void Interval3Box_ValueChanged(object sender, EventArgs e)
        {
            BoostInterval3 = Decimal.ToInt32(Interval3Box.Value);
        }
        private void Interval4Box_ValueChanged(object sender, EventArgs e)
        {
            BoostInterval4 = Decimal.ToInt32(Interval4Box.Value);
        }
        private void Boost1Box_ValueChanged(object sender, EventArgs e)
        {
            times1 = Decimal.ToInt32(Boost1Box.Value);
        }
        private void Boost2Box_ValueChanged(object sender, EventArgs e)
        {
            times2 = Decimal.ToInt32(Boost2Box.Value);
        }
        private void Boost3Box_ValueChanged(object sender, EventArgs e)
        {
            times3 = Decimal.ToInt32(Boost3Box.Value);
        }
        private void Boost4Box_ValueChanged(object sender, EventArgs e)
        {
            times4 = Decimal.ToInt32(Boost4Box.Value);
        }
        private void VelMultBar_Scroll(LimitlessUI.Slider_WOC slider, float value)
        {
            VelMultBox.Value = Convert.ToDecimal(Math.Round(VelMultBar.Value)) / 100000;
            VelMult = Decimal.ToSingle(VelMultBox.Value);
        }
        private void VelMultBox_ValueChanged(object sender, EventArgs e)
        {
            VelMultBar.Value = Decimal.ToInt32(VelMultBox.Value * 100000);
            VelMult = Decimal.ToSingle(VelMultBox.Value);
        }
        private void JumpAmountBar_Scroll(LimitlessUI.Slider_WOC slider, float value)
        {
            JumpAmountBox.Value = Convert.ToDecimal(Math.Round(JumpAmountBar.Value)) / 100000;
        }
        private void JumpAmountBox_ValueChanged(object sender, EventArgs e)
        {
            JumpAmountBar.Value = Decimal.ToInt32(JumpAmountBox.Value * 100000);
        }
        #endregion

        #region FOV
        private void FOVBar_Scroll(LimitlessUI.Slider_WOC slider, float value)
        {
            //FOVBar.Value = FOVBar.Value / 100;
            FOVVal = (float)FOVBar.Value / 100;
            if (FOV.Checked == true)
            {
                if (MainWindow.main.ForzaFour)
                {
                    MainWindow.m.FreezeValue(FOVHighAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(FirstPersonAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(DashAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(LowAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(BonnetAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(FrontAddr, "float", FOVVal.ToString());
                }
                else
                {
                    foreach (string address in RearAddresses)
                    {
                        MainWindow.m.UnfreezeValue(address);
                        MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                    }
                    foreach (string address in RestAddresses)
                    {
                        MainWindow.m.UnfreezeValue(address);
                        MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                    }
                }
                /*if(MainWindow.main.ForzaFour)
                {
                    MainWindow.m.UnfreezeValue(FOVHighAddr); MainWindow.m.FreezeValue(FOVHighAddr, "float", FOVVal.ToString());
                    MainWindow.m.UnfreezeValue(FirstPersonAddr); MainWindow.m.FreezeValue(FirstPersonAddr, "float", FOVVal.ToString());
                    MainWindow.m.UnfreezeValue(DashAddr); MainWindow.m.FreezeValue(DashAddr, "float", FOVVal.ToString());
                    MainWindow.m.UnfreezeValue(LowAddr); MainWindow.m.FreezeValue(LowAddr, "float", FOVVal.ToString());
                    MainWindow.m.UnfreezeValue(BonnetAddr); MainWindow.m.FreezeValue(BonnetAddr, "float", FOVVal.ToString());
                    MainWindow.m.UnfreezeValue(FrontAddr); MainWindow.m.FreezeValue(FrontAddr, "float", FOVVal.ToString());
                }
                else
                {
                    foreach (string address in RearAddresses)
                    {
                        MainWindow.m.UnfreezeValue(address);
                        MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                    }
                    foreach (string address in RestAddresses)
                    {
                        MainWindow.m.UnfreezeValue(address);
                        MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                    }
                }*/
            }
        }
        private async void FOVScan_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                FOVScan_BTN.Hide();
                bool scan = true;
                cycles = 0;
                if (MainWindow.main.ForzaFour)
                {
                    FOVScan_bar.Show();
                    while (scan)
                    {
                        Thread.Sleep(1);
                        if (FirstPersonAddr == "FFFFFFFFFFFFFFB5" || FirstPersonAddr == null || FirstPersonAddr == "0")
                        {
                            FirstPersonAddrLong = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, FirstPerson, true, true)).FirstOrDefault() - 75;
                            FirstPersonAddr = FirstPersonAddrLong.ToString("X");
                        }
                        else if (DashAddr == "FFFFFFFFFFFFFF45" || DashAddr == null || DashAddr == "0")
                        {
                            for (int i = FOVScan_bar.Value1; i <= 20; i++)
                            { Thread.Sleep(15); FOVScan_bar.Value1 = i; }
                            DashAddrLong = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, Dash, true, true)).FirstOrDefault() - 187;
                            DashAddr = DashAddrLong.ToString("X");
                        }
                        else if (FrontAddr == "FFFFFFFFFFFFFF42" || FrontAddr == null || FrontAddr == "0")
                        {
                            for (int i = FOVScan_bar.Value1; i <= 40; i++)
                            { Thread.Sleep(15); FOVScan_bar.Value1 = i; }
                            FrontAddrLong = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, Front, true, true)).FirstOrDefault() - 190;
                            FrontAddr = FrontAddrLong.ToString("X");
                        }
                        else if (LowAddr == "FFFFFFFFFFFFFF49" || LowAddr == null || LowAddr == "0")
                        {
                            for (int i = FOVScan_bar.Value1; i <= 60; i++)
                            { Thread.Sleep(15); FOVScan_bar.Value1 = i; }
                            LowAddrLong = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, Low, true, true)).FirstOrDefault() - 183;
                            LowCompare = LowAddrLong.ToString();
                            if (LowCompare == MainWindow.m.GetCode(FOVHighAddr).ToString())
                            {
                                LowAddrLong = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, Low, true, true)).LastOrDefault() - 183;
                            }
                            LowAddr = LowAddrLong.ToString("X");
                        }
                        else if (BonnetAddr == "FFFFFFFFFFFFFF43" || BonnetAddr == null || DashAddr == "0")
                        {
                            for (int i = FOVScan_bar.Value1; i <= 80; i++)
                            { Thread.Sleep(15); FOVScan_bar.Value1 = i; }
                            BonnetAddrLong = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, Bonnet, true, true)).FirstOrDefault() - 189;
                            BonnetAddr = BonnetAddrLong.ToString("X");
                        }
                        if (FirstPersonAddr == "FFFFFFFFFFFFFFB5" || FirstPersonAddr == null || FirstPersonAddr == "0"
                            || DashAddr == "FFFFFFFFFFFFFF45" || DashAddr == null || DashAddr == "0"
                            || FrontAddr == "FFFFFFFFFFFFFF42" || FrontAddr == null || FrontAddr == "0"
                            || LowAddr == "FFFFFFFFFFFFFF49" || LowAddr == null || LowAddr == "0"
                            || BonnetAddr == "FFFFFFFFFFFFFF43" || BonnetAddr == null || BonnetAddr == "0")
                        {
                            ;
                        }
                        else
                        {
                            for (int i = FOVScan_bar.Value1; i <= 100; i++)
                            { Thread.Sleep(15); FOVScan_bar.Value1 = i; }
                            Thread.Sleep(1000);
                            FOVScan_bar.Hide();
                            //FOVScan_BTN.Enabled = false;
                            FOV.Show();//FOV.Enabled = true;
                            scan = false;
                        }
                    }
                }
                else
                {
                    FOVWaitingBar.Visible = true;
                    FOVWaitingBar.StartWaiting();
                    RearAddresses.Clear();
                    RestAddresses.Clear();
                    int count = 0;
                    ScanStartAddr = (long)MainWindow.m.GetCode(InPauseAddr) - 50000000000;//ScanStartAddr = (long)MainWindow.m.GetCode(FOVHighAddr) - 2000000000;
                    ScanEndAddr = (long)MainWindow.m.GetCode(InPauseAddr) - 49000000000;//ScanEndAddr = (long)MainWindow.m.GetCode(FOVHighAddr) + 2000000000;
                    while (scan)
                    {
                        while (count < 100)
                        {
                            Thread.Sleep(1);
                            List<long> Outside = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, "EC 41 00 00 80 3F 00 00 20 41", true, true)).ToList();
                            List<long> Rest = (await MainWindow.m.AoBScan(ScanStartAddr, ScanEndAddr, "16 43 00 00 C0 3F 00 00 20 41", true, true)).ToList();
                            if(Outside.Count != 0)
                            {
                                foreach (long address in Outside)
                                {
                                    RearAddresses.Add((address - 38).ToString("X"));
                                }
                            }
                            if (Outside.Count != 0)
                            {
                                foreach (long address in Rest)
                                {
                                    RestAddresses.Add((address - 38).ToString("X"));
                                }

                            }
                            ScanStartAddr +=  1000000000;
                            ScanEndAddr += 1000000000;
                            count++;
                            if (count == 100 || (RearAddresses.Count == 4 && RestAddresses.Count == 8))
                            {
                                if (RearAddresses.Count >= 2 && RestAddresses.Count >= 4)
                                {
                                    FOVWaitingBar.Hide();
                                    FOV.Show();
                                    scan = false;
                                }
                                else
                                {
                                    FOVScan_BTN.Show();
                                    //FOVScan_BTN.Enabled = false;
                                    FOVWaitingBar.Hide();
                                    MessageBox.Show("FOV could not be found, sowwy");
                                    scan = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                FOVScan_BTN.Show();
                FOVScan_bar.Hide();
                MessageBox.Show("Error: " + error.Data);
            }
        }
        private void FOV_CheckedChanged(object sender, EventArgs e)
        {
            var nopoutbefore = new byte[4] { 0x0F, 0x11, 0x43, 0x10 };
            var nopinbefore = new byte[4] { 0x0F, 0x11, 0x73, 0x10 };
            var nop = new byte[4] { 0x90, 0x90, 0x90, 0x90 };
            SHReset();
            if (FOV.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)FOV.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                FOVstart = false;
                FOVWorker.CancelAsync();
                if(MainWindow.main.ForzaFour)
                {
                    MainWindow.m.WriteBytes(FOVnopOutAddr, nopoutbefore);
                    MainWindow.m.WriteBytes(FOVnopInAddr, nopinbefore);
                    MainWindow.m.UnfreezeValue(FOVHighAddr);
                    MainWindow.m.UnfreezeValue(FirstPersonAddr);
                    MainWindow.m.UnfreezeValue(DashAddr);
                    MainWindow.m.UnfreezeValue(LowAddr);
                    MainWindow.m.UnfreezeValue(BonnetAddr);
                    MainWindow.m.UnfreezeValue(FrontAddr);
                }
                else
                {
                    MainWindow.m.WriteMemory(FOVJmpAddr, "byte", "0x76");
                    foreach (string address in RearAddresses)
                        MainWindow.m.UnfreezeValue(address);
                    foreach (string address in RestAddresses)
                        MainWindow.m.UnfreezeValue(address);
                }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)FOV.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                FOVstart = true;
                if (FOVWorker.IsBusy == false)
                {
                    FOVWorker.RunWorkerAsync();
                }
                if(MainWindow.main.ForzaFour)
                {
                    MainWindow.m.WriteBytes(FOVnopOutAddr, nop);
                    MainWindow.m.WriteBytes(FOVnopInAddr, nop);
                    MainWindow.m.FreezeValue(FOVHighAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(FirstPersonAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(DashAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(LowAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(BonnetAddr, "float", FOVVal.ToString());
                    MainWindow.m.FreezeValue(FrontAddr, "float", FOVVal.ToString());
                }
                else
                {
                    MainWindow.m.WriteMemory(FOVJmpAddr, "byte", "0xEB");
                    foreach (string address in RearAddresses)
                        MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                    foreach (string address in RestAddresses)
                        MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                }
            }
        }
        private void FOVIncrease()
        {
            if (FOVBar.Value > 149)
                FOVBar.Value = 149;
            FOVBar.Value++;
            FOVBar.OnMouseMove(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            //FOVVal = (float)FOVBar.Value / 100;
            /*if (MainWindow.main.ForzaFour)
            {
                MainWindow.m.WriteMemory(FOVHighAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(FirstPersonAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(DashAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(LowAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(BonnetAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(FrontAddr, "float", FOVVal.ToString());
            }
            else
            {
                foreach (string address in RearAddresses)
                    MainWindow.m.WriteMemory(address, "float", FOVVal.ToString());
                foreach (string address in RestAddresses)
                    MainWindow.m.WriteMemory(address, "float", FOVVal.ToString());
            }*/
            /*if (MainWindow.main.ForzaFour)
            {
                MainWindow.m.FreezeValue(FOVHighAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(FirstPersonAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(DashAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(LowAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(BonnetAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(FrontAddr, "float", FOVVal.ToString());
            }
            else
            {
                foreach (string address in RearAddresses)
                    MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                foreach (string address in RestAddresses)
                    MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
            }*/
        }
        private void FOVdecrease()
        {
            if (FOVBar.Value < -94)
                FOVBar.Value = -94;
            FOVBar.Value--;
            FOVBar.OnMouseMove(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            //FOVVal = (float)FOVBar.Value / 100;
            /*if (MainWindow.main.ForzaFour)
            {
                MainWindow.m.WriteMemory(FOVHighAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(FirstPersonAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(DashAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(LowAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(BonnetAddr, "float", FOVVal.ToString());
                MainWindow.m.WriteMemory(FrontAddr, "float", FOVVal.ToString());
            }
            else
            {
                foreach (string address in RearAddresses)
                    MainWindow.m.WriteMemory(address, "float", FOVVal.ToString());
                foreach (string address in RestAddresses)
                    MainWindow.m.WriteMemory(address, "float", FOVVal.ToString());
            }*/
            /*if (MainWindow.main.ForzaFour)
            {
                MainWindow.m.FreezeValue(FOVHighAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(FirstPersonAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(DashAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(LowAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(BonnetAddr, "float", FOVVal.ToString());
                MainWindow.m.FreezeValue(FrontAddr, "float", FOVVal.ToString());
            }
            else
            {
                foreach (string address in RearAddresses)
                    MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
                foreach (string address in RestAddresses)
                    MainWindow.m.FreezeValue(address, "float", FOVVal.ToString());
            }*/
        }
        #endregion

        #region Weird + Grav
        public void WeirdPullVal()
        {
            WeirdVal = MainWindow.m.ReadFloat(WeirdAddr, round: false);
            WeirdBox.Value = (decimal)WeirdVal;
            NewWeirdVal = WeirdVal;
        }
        public void GravityPullVal()
        {
            GravityVal = MainWindow.m.ReadFloat(GravityAddr);
            GravityBox.Value = (decimal)GravityVal;
            NewGravityVal = GravityVal;
        }
        private void WeirdPull_Click(object sender, EventArgs e)
        {
            if (g2g)//if (MainWindow.m.ReadFloat(PastStartAddr) == 1)
                WeirdPullVal();
        }
        private void WeridSet_CheckStateChanged(object sender, EventArgs e)
        {
            if (WeirdSet.Checked)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)WeirdSet.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                WeirdFreeze = true;
                if (!WeirdWorker.IsBusy)
                    WeirdWorker.RunWorkerAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)WeirdSet.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                WeirdFreeze = false;
                WeirdWorker.CancelAsync();
            }
        }
        private void GravityPull_Click(object sender, EventArgs e)
        {
            if (g2g)//if (MainWindow.m.ReadFloat(PastStartAddr) == 1)
                GravityPullVal();
        }
        private void GravitySet_CheckStateChanged(object sender, EventArgs e)
        {
            if (GravitySet.Checked)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)GravitySet.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                GravityFreeze = true;
                if (!GravityWorker.IsBusy)
                    GravityWorker.RunWorkerAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)GravitySet.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                GravityFreeze = false;
                GravityWorker.CancelAsync();
            }
        }
        private void WeirdBox_ValueChanged(object sender, EventArgs e)
        {
            if (g2g)//(MainWindow.m.ReadFloat(PastStartAddr) == 1)
                NewWeirdVal = (float)WeirdBox.Value;
        }
        private void GravityBox_ValueChanged(object sender, EventArgs e)
        {
            if (g2g)//if(MainWindow.m.ReadFloat(PastStartAddr) == 1)
                NewGravityVal = (float)GravityBox.Value;
        }
        #endregion

        #region Other misc
        private void XPBox_CheckedChanged(object sender, EventArgs e)
        {
            byte[] XPGiveBefore = new byte[7] { 0xF3, 0x0F, 0x2C, 0xC6, 0x89, 0x45, 0xB8 };
            byte[] Normal = new byte[6] { 0x8B, 0x89, 0xC0, 0x00, 0x00, 0x00 };
            if (!MainWindow.main.ForzaFour)
                Normal = new byte[6] { 0x8B, 0x89, 0xB8, 0x00, 0x00, 0x00 };
            if (XPBox.Checked == false)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)XPBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                MainWindow.m.WriteBytes(XPaddr, XPGiveBefore);
                MainWindow.m.WriteBytes(XPAmountaddr, Normal);
                XPnup.Enabled = true;
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)XPBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                MessageBox.Show("WARNING:\nThere have been reports of bans when using XP hacks.\nUse at your own risk.");
                a.StartXPtool(CodeCave3);
                XPnup.Enabled = false;
            }
        }
        private void TimerButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TimerButton.Checked == false)
            {

                ((Telerik.WinControls.Primitives.BorderPrimitive)TimerButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                TimerToggle = false;
                TimerWorker.CancelAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)TimerButton.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                TimerToggle = true;
                TimerWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region Save / Load
        public void SHReset()
        {
            TurnIntervalBox.Value = TurnInterval;
            RatioBox.Value = Convert.ToDecimal(TurnRatio);
            TurnStrengthBox.Value = Convert.ToDecimal(TurnStrength);
            Speed1Box.Value = Convert.ToDecimal(BoostSpeed1);
            Speed2Box.Value = Convert.ToDecimal(BoostSpeed2);
            Speed3Box.Value = Convert.ToDecimal(BoostSpeed3);
            LimitBox.Value = Convert.ToDecimal(BoostLim);
            Interval1Box.Value = Convert.ToDecimal(BoostInterval1);
            Interval2Box.Value = Convert.ToDecimal(BoostInterval2);
            Interval3Box.Value = Convert.ToDecimal(BoostInterval3);
            Interval4Box.Value = Convert.ToDecimal(BoostInterval4);
            Boost1Box.Value = Convert.ToDecimal(times1);
            Boost2Box.Value = Convert.ToDecimal(times2);
            Boost3Box.Value = Convert.ToDecimal(times3);
            Boost4Box.Value = Convert.ToDecimal(times4);
            VelMultBox.Value = Convert.ToDecimal(VelMult);
            VelMultBar.Value = Decimal.ToInt32(VelMultBox.Value * 100000);
            JumpAmountBox.Value = Convert.ToDecimal(JumpAmountBox.Value);
            JumpAmountBar.Value = Decimal.ToInt32(JumpAmountBox.Value * 100000);
            FOVVal = (float)FOVBar.Value / 100;
            LST_TeleportLocation.Text = "Waypoint";
        }
        public void ReadSpeedDefaultValues()
        {
            string SHini = "SpeedHackDefault.ini";
            bool Exists = File.Exists(SHini);
            if (Exists == true)
            {
                var SpeedHackparser = new FileIniDataParser();
                IniData SpeedHack = SpeedHackparser.ReadFile("SpeedHackDefault.ini");
                string CarNoClipStr = SpeedHack["No-Clip"]["Car"]; TB_SHCarNoClip.Checked = bool.Parse(CarNoClipStr);
                string WallNoClipStr = SpeedHack["No-Clip"]["Wall"]; TB_SHWallNoClip.Checked = bool.Parse(WallNoClipStr);
                string VelocityToggleStr = SpeedHack["Velocity"]["On"]; VelHackButton.Checked = bool.Parse(VelocityToggleStr);
                string VelocityMultStr = SpeedHack["Velocity"]["Multiplication"]; VelMult = float.Parse(VelocityMultStr);
                string SpeedHackToggleStr = SpeedHack["SpeedHack"]["On"]; WheelSpeedButton.Checked = bool.Parse(SpeedHackToggleStr);
                string Speed1Str = SpeedHack["SpeedHack"]["Speed 1"]; BoostSpeed1 = float.Parse(Speed1Str);
                string Speed2Str = SpeedHack["SpeedHack"]["Speed 2"]; BoostSpeed2 = float.Parse(Speed2Str);
                string Speed3Str = SpeedHack["SpeedHack"]["Speed 3"]; BoostSpeed3 = float.Parse(Speed3Str);
                string LimitStr = SpeedHack["SpeedHack"]["Limit"]; BoostLim = float.Parse(LimitStr);
                string Interval1Str = SpeedHack["SpeedHack"]["Interval up to speed 1"]; BoostInterval1 = Int32.Parse(Interval1Str);
                string Interval2Str = SpeedHack["SpeedHack"]["Interval up to speed 2"]; BoostInterval2 = Int32.Parse(Interval2Str);
                string Interval3Str = SpeedHack["SpeedHack"]["Interval up to speed 3"]; BoostInterval3 = Int32.Parse(Interval3Str);
                string Interval4Str = SpeedHack["SpeedHack"]["Interval above speed 3"]; BoostInterval4 = Int32.Parse(Interval4Str);
                string Boost1Str = SpeedHack["SpeedHack"]["Boost up to speed 1"]; times1 = Int32.Parse(Boost1Str);
                string Boost2Str = SpeedHack["SpeedHack"]["Boost up to speed 2"]; times2 = Int32.Parse(Boost2Str);
                string Boost3Str = SpeedHack["SpeedHack"]["Boost up to speed 3"]; times3 = Int32.Parse(Boost3Str);
                string Boost4Str = SpeedHack["SpeedHack"]["Boost above speed 3"]; times4 = Int32.Parse(Boost4Str);
                string SuperBreakStr = SpeedHack["Break"]["Superbreak on"]; SuperBreakButton.Checked = bool.Parse(SuperBreakStr);
                string StopWheelsStr = SpeedHack["Break"]["Stop all wheels on"]; StopAllWheelsButton.Checked = bool.Parse(StopWheelsStr);
                string TurnToggleStr = SpeedHack["Turn assist"]["On"]; TurnAssistButton.Checked = bool.Parse(TurnToggleStr);
                string TurnStrengthStr = SpeedHack["Turn assist"]["Strength"]; TurnStrength = float.Parse(TurnStrengthStr);
                string TurnRatioStr = SpeedHack["Turn assist"]["Ratio"]; TurnRatio = float.Parse(TurnRatioStr);
                string TurnIntervalStr = SpeedHack["Turn assist"]["Interval"]; TurnInterval = Int32.Parse(TurnIntervalStr);
                string AutoWinStr = SpeedHack["Teleports"]["Auto-Win"]; CheckpointBox.Checked = bool.Parse(AutoWinStr);
                string AutoTPStr = SpeedHack["Teleports"]["Auto-Tp to waypoint"]; AutoWayPoint.Checked = bool.Parse(AutoTPStr);
                try { string VelocityLimitStr = SpeedHack["Velocity"]["Limit"]; VelLimitBox.Value = decimal.Parse(VelocityLimitStr); }
                catch { VelLimitBox.Value = 445; WriteSpeedDefaultValues(); }
                if (SpeedHack["Keys"].ContainsKey("SpeedHack Keyboard"))
                {
                    string KBSpeedKeyStr = SpeedHack["Keys"]["SpeedHack Keyboard"]; KBSpeedKey = KBSpeedKeyStr;
                    string XBSpeedKeyStr = SpeedHack["Keys"]["SpeedHack Controller"]; XBSpeedKey = XBSpeedKeyStr;
                    string KBBrakeKeyStr = SpeedHack["Keys"]["SuperBrake Keyboard"]; KBBrakeKey = KBBrakeKeyStr;
                    string XBBrakeKeyStr = SpeedHack["Keys"]["SuperBrake Controller"]; XBBrakeKey = XBBrakeKeyStr;
                    string KBJumpKeyStr = SpeedHack["Keys"]["Jump Keyboard"]; KBJumpKey = KBJumpKeyStr;
                    string XBJumpKeyStr = SpeedHack["Keys"]["Jump Controller"]; XBJumpKey = XBJumpKeyStr;
                    string JumpHackStr = SpeedHack["JumpHack"]["On"]; JumpHackToggle.Checked = bool.Parse(JumpHackStr);
                    string JumpAmountStr = SpeedHack["JumpHack"]["Amount"]; JumpAmountBox.Value = decimal.Parse(JumpAmountStr);
                }
                else
                {
                    JumpHackToggle.Checked = false;
                    JumpAmountBox.Value = 1;
                    WriteSpeedDefaultValues();
                }
            }
            else
            {
                CreateSHini();
                ReadSpeedDefaultValues();
            }
        }
        public void WriteSpeedDefaultValues()
        {
            var SpeedHackparser = new FileIniDataParser();
            IniData SpeedHack = new IniData();
            SpeedHack["Keys"]["SpeedHack Keyboard"] = KBSpeedKey;
            SpeedHack["Keys"]["SpeedHack Controller"] = XBSpeedKey;
            SpeedHack["Keys"]["SuperBrake Keyboard"] = KBBrakeKey;
            SpeedHack["Keys"]["SuperBrake Controller"] = XBBrakeKey;
            SpeedHack["Keys"]["Jump Keyboard"] = KBJumpKey;
            SpeedHack["Keys"]["Jump Controller"] = XBJumpKey;
            SpeedHack["No-Clip"]["Car"] = TB_SHCarNoClip.Checked.ToString();
            SpeedHack["No-Clip"]["Wall"] = TB_SHWallNoClip.Checked.ToString();
            SpeedHack["Velocity"]["On"] = VelHackButton.Checked.ToString();
            SpeedHack["Velocity"]["Multiplication"] = VelMult.ToString();
            SpeedHack["Velocity"]["Limit"] = VelLimitBox.Value.ToString();
            SpeedHack["SpeedHack"]["On"] = WheelSpeedButton.Checked.ToString();
            SpeedHack["SpeedHack"]["Speed 1"] = BoostSpeed1.ToString();
            SpeedHack["SpeedHack"]["Speed 2"] = BoostSpeed2.ToString();
            SpeedHack["SpeedHack"]["Speed 3"] = BoostSpeed3.ToString();
            SpeedHack["SpeedHack"]["Limit"] = BoostLim.ToString();
            SpeedHack["SpeedHack"]["Interval up to speed 1"] = BoostInterval1.ToString();
            SpeedHack["SpeedHack"]["Interval up to speed 2"] = BoostInterval2.ToString();
            SpeedHack["SpeedHack"]["Interval up to speed 3"] = BoostInterval3.ToString();
            SpeedHack["SpeedHack"]["Interval above speed 3"] = BoostInterval4.ToString();
            SpeedHack["SpeedHack"]["Boost up to speed 1"] = times1.ToString();
            SpeedHack["SpeedHack"]["Boost up to speed 2"] = times2.ToString();
            SpeedHack["SpeedHack"]["Boost up to speed 3"] = times3.ToString();
            SpeedHack["SpeedHack"]["Boost above speed 3"] = times4.ToString();
            SpeedHack["JumpHack"]["On"] = JumpHackToggle.Checked.ToString();
            SpeedHack["JumpHack"]["Amount"] = JumpAmountBox.Value.ToString();
            SpeedHack["Break"]["Superbreak on"] = SuperBreakButton.Checked.ToString();
            SpeedHack["Break"]["Stop all wheels on"] = StopAllWheelsButton.Checked.ToString();
            SpeedHack["Turn assist"]["On"] = TurnAssistButton.Checked.ToString();
            SpeedHack["Turn assist"]["Strength"] = TurnStrength.ToString();
            SpeedHack["Turn assist"]["Ratio"] = TurnRatio.ToString();
            SpeedHack["Turn assist"]["Interval"] = TurnInterval.ToString();
            SpeedHack["Teleports"]["Auto-Win"] = CheckpointBox.Checked.ToString();
            SpeedHack["Teleports"]["Auto-Tp to waypoint"] = AutoWayPoint.Checked.ToString();
            SpeedHackparser.WriteFile("SpeedHackDefault.ini", SpeedHack);
        }
        public void CreateSHini()
        {
            var SpeedHackparser = new FileIniDataParser();
            IniData SpeedHack = new IniData();
            SpeedHack["Keys"]["SpeedHack Keyboard"] = "LShiftKey";
            SpeedHack["Keys"]["SpeedHack Controller"] = "LeftShoulder";
            SpeedHack["Keys"]["SuperBrake Keyboard"] = "Space";
            SpeedHack["Keys"]["SuperBrake Controller"] = "A";
            SpeedHack["Keys"]["Jump Keyboard"] = "LControlKey";
            SpeedHack["Keys"]["Jump Controller"] = "RightThumb";
            SpeedHack["No-Clip"]["Car"] = "false";
            SpeedHack["No-Clip"]["Wall"] = "false";
            SpeedHack["Velocity"]["On"] = "false";
            SpeedHack["Velocity"]["Multiplication"] = "1";
            SpeedHack["Velocity"]["Limit"] = "445";
            SpeedHack["SpeedHack"]["On"] = "false";
            SpeedHack["SpeedHack"]["Speed 1"] = "0";
            SpeedHack["SpeedHack"]["Speed 2"] = "0";
            SpeedHack["SpeedHack"]["Speed 3"] = "0";
            SpeedHack["SpeedHack"]["Limit"] = "0";
            SpeedHack["SpeedHack"]["Interval up to speed 1"] = "0";
            SpeedHack["SpeedHack"]["Interval up to speed 2"] = "0";
            SpeedHack["SpeedHack"]["Interval up to speed 3"] = "0";
            SpeedHack["SpeedHack"]["Interval above speed 3"] = "0";
            SpeedHack["SpeedHack"]["Boost up to speed 1"] = "0";
            SpeedHack["SpeedHack"]["Boost up to speed 2"] = "0";
            SpeedHack["SpeedHack"]["Boost up to speed 3"] = "0";
            SpeedHack["SpeedHack"]["Boost above speed 3"] = "0";
            SpeedHack["JumpHack"]["On"] = "false";
            SpeedHack["JumpHack"]["Amount"] = "1";
            SpeedHack["Break"]["Superbreak on"] = "false";
            SpeedHack["Break"]["Stop all wheels on"] = "false";
            SpeedHack["Turn assist"]["On"] = "false";
            SpeedHack["Turn assist"]["Strength"] = "0";
            SpeedHack["Turn assist"]["Ratio"] = "0";
            SpeedHack["Turn assist"]["Interval"] = "0";
            SpeedHack["Teleports"]["Auto-Win"] = "false";
            SpeedHack["Teleports"]["Auto-Tp to waypoint"] = "false";
            SpeedHackparser.SaveFile("SpeedHackDefault.ini", SpeedHack);
        }
        private void SaveSHDefault_Click(object sender, EventArgs e)
        {
            WriteSpeedDefaultValues();
        }
        private void LoadSHDefault_Click(object sender, EventArgs e)
        {
            ReadSpeedDefaultValues();
            SHReset();
        }
        #endregion

        private void Bypassoob_CheckStateChanged(object sender, EventArgs e)
        {
            var before = new byte[] { 0x0F, 0x11, 0x9B, 0xE0, 0xFA, 0xFF, 0xFF };
            if(!MainWindow.main.ForzaFour)
                before = new byte[] { 0x0F, 0x11, 0x51, 0x50 };
            if (Bypassoob.Checked)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)Bypassoob.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                OOB = true;
                if (!OOBWorker.IsBusy)
                    OOBWorker.RunWorkerAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)Bypassoob.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                OOBWorker.CancelAsync();
                MainWindow.m.WriteBytes(OOBnopAddr, before);
                OOB = false;
            }
        }

        private void SuperCarBox_CheckStateChanged(object sender, EventArgs e)
        {
            var before1 = new byte[] { 0x0F, 0x11, 0x41, 0x10 };
            var before2 = new byte[] { 0x0F, 0x11, 0x49, 0x20 };
            var before3 = new byte[] { 0x0F, 0x11, 0x41, 0x30 };
            var before4 = new byte[] { 0x0F, 0x11, 0x49, 0x40 };
            if(!MainWindow.main.ForzaFour)
            {
                before1 = new byte[] { 0x0F, 0x11, 0x49, 0x20 };
                before2 = new byte[] { 0x0F, 0x11, 0x41, 0x30 };
                before3 = new byte[] { 0x0F, 0x11, 0x49, 0x40 };
                before4 = new byte[] { 0x0F, 0x11, 0x41, 0x50 };
            }
            var nop = new byte[] { 0x90, 0x90, 0x90, 0x90 };
            if (SuperCarBox.Checked)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)SuperCarBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                if (!g2g)
                    SuperCarCheck.RunWorkerAsync();
                else try
                {
                    MainWindow.m.WriteBytes((SuperCarAddrLong + 4).ToString("X"), nop);
                    MainWindow.m.WriteBytes((SuperCarAddrLong + 12).ToString("X"), nop);
                    MainWindow.m.WriteBytes((SuperCarAddrLong + 20).ToString("X"), nop);
                    MainWindow.m.WriteBytes((SuperCarAddrLong + 32).ToString("X"), nop);
                }
                catch { }
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)SuperCarBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                if (g2g)
                {
                    try
                    {
                        MainWindow.m.WriteBytes((SuperCarAddrLong + 4).ToString("X"), before1);
                        MainWindow.m.WriteBytes((SuperCarAddrLong + 12).ToString("X"), before2);
                        MainWindow.m.WriteBytes((SuperCarAddrLong + 20).ToString("X"), before3);
                        MainWindow.m.WriteBytes((SuperCarAddrLong + 32).ToString("X"), before4);
                    }
                    catch { }
                }
            }
        }

        private void TimeCheckBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show(@"Numpad 4 to go back, 6 to go forward, ctrl to go faster", TimeCheckBox);
        }

        private void WeirdWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(WeirdFreeze)
            {
                try
                {
                    MainWindow.m.WriteMemory(WeirdAddr, "float", NewWeirdVal.ToString());
                    Thread.Sleep(1);
                    if (WeirdWorker.CancellationPending)
                        e.Cancel = true;
                }
                catch
                {
                    if (WeirdWorker.CancellationPending)
                        e.Cancel = true;
                }
            }
        }

        private void GravityWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (GravityFreeze)
            {
                try
                {
                    if (MainWindow.m.ReadFloat(GravityAddr) != NewGravityVal)
                        MainWindow.m.WriteMemory(GravityAddr, "float", NewGravityVal.ToString());
                    Thread.Sleep(1);
                    if (GravityWorker.CancellationPending)
                        e.Cancel = true;
                }
                catch
                {
                    if (GravityWorker.CancellationPending)
                        e.Cancel = true;
                }
            }
        }

        private void WorldRGButton_Click(object sender, EventArgs e)
        {
            RGB.Show(this);
            RGB.Focus();
        }

        private void g2gWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(!g2g)
            {
                try { MainWindow.m.ReadFloat(GasAddr); Thread.Sleep(0);
                    g2g = true; if (g2gWorker.CancellationPending) { e.Cancel = true; } }
                catch { Thread.Sleep(1000); if (g2gWorker.CancellationPending) { e.Cancel = true; } }
            }
        }

        private void SuperCarCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!g2g)//(MainWindow.m.ReadFloat(PastStartAddr) == 0)
            {
                Thread.Sleep(100);
            }
            if(SuperCarBox.Checked == true)
            {
                SuperCarBox.Checked = false;
                SuperCarBox.Checked = true;
            }
        }

        private void KeyBinds_Click(object sender, EventArgs e)
        {
            ControlsPopUp.Show(this);
            ControlsPopUp.Focus();
        }

        private void DiscoverRoadsBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(DiscoverRoadsBox.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("If you don't have one house and one outpost, your game will crash.\nDo", "Discover all roads", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ((Telerik.WinControls.Primitives.BorderPrimitive)DiscoverRoadsBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                    long BytesOne = (long)MainWindow.m.GetCode(DiscoverRoadsAddr);
                    long BytesTwo = BytesOne + 24;
                    long BytesThree = BytesOne + 119;
                    if (!MainWindow.main.ForzaFour)
                    {
                        BytesOne += 675;
                        BytesTwo += 675;
                        BytesThree += 675;
                    }
                    if (MainWindow.m.ReadBytes(BytesOne.ToString("X"), 3).SequenceEqual(new byte[] { 0x00, 0x96, 0x42 }))
                    {
                        MainWindow.m.WriteBytes(BytesOne.ToString("X"), new byte[] { 0x1B, 0x37, 0x49 });
                        MainWindow.m.WriteBytes(BytesTwo.ToString("X"), new byte[] { 0x24, 0x74, 0x48 });
                        MainWindow.m.WriteBytes(BytesThree.ToString("X"), new byte[] { 0x30, 0x75 });
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    DiscoverRoadsBox.Checked = false;
                }
            }
            else
                ((Telerik.WinControls.Primitives.BorderPrimitive)DiscoverRoadsBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
        }

        private void WaterBox_CheckStateChanged(object sender, EventArgs e)
        {
            byte[] Enable = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] Disable = new byte[] { 0xCD, 0xCC, 0x4C, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x67, 0x45, 0x00, 0xF0, 0x52, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0xCD, 0xCC, 0xCC, 0x3D, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0xC4, 0x44, 0x00, 0x00, 0xFF, 0x44, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x42, 0x00, 0x00, 0xC8, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x40, 0x00, 0x00, 0x70, 0x41 };
            if (WaterBox.Checked)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)WaterBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                MainWindow.m.WriteBytes(WaterAddr, Enable);
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)WaterBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                MainWindow.m.WriteBytes(WaterAddr, Disable);
            }
        }

        private void FreezeAIBox_CheckStateChanged(object sender, EventArgs e)
        {
            byte[] Disable = new byte[] { 0x0F, 0x11, 0x41, 0x40, 0x48, 0x8B, 0xFA };
            if (!MainWindow.main.ForzaFour)
                Disable = new byte[] { 0x0F, 0x11, 0x41, 0x50, 0x48, 0x8B, 0xD9 };
            if (FreezeAIBox.Checked)
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)FreezeAIBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = ColorTranslator.FromHtml(MainWindow.ThemeColour);
                if (!FreezeAIWorker.IsBusy)
                    FreezeAIWorker.RunWorkerAsync();
            }
            else
            {
                ((Telerik.WinControls.Primitives.BorderPrimitive)FreezeAIBox.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = Color.FromArgb(45, 45, 48);
                if (FreezeAIWorker.IsBusy)
                    FreezeAIWorker.CancelAsync();
                MainWindow.m.WriteBytes(AIXAobAddr, Disable);
            }
        }

        private void FreezeAIWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            a.GetAIXAddr(CodeCave6);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            map.Show(this);
            map.Focus();
        }
    }
}
