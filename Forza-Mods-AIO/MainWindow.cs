﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Windows.Forms;
using Memory;
using GlobalLowLevelHooks;

namespace Forza_Mods_AIO
{
    public partial class MainWindow : Form
    {
        Mem m = new Mem();
        KeyboardHook keyboardHook = new KeyboardHook();
        bool IsAttached = false;
        bool BreakToggle = false;
        bool StopToggle = false;
        bool BreakStart = false;
        bool VelHackStart = false;
        bool VelHackToggle = false;
        bool SpeedHackToggle = false;
        bool SpeedHackStart = false;
        bool TurnAssistToggle = false;
        bool TurnAssistLeftStart = false;
        bool TurnAssistRightStart = false;
        bool NoClipToggle = false;
        bool CheckPointTPToggle = false;
        long BaseAddrLong;      long Base2AddrLong; long Base3AddrLong; long Car1AddrLong; long Car2AddrLong; long Wall1AddrLong; long Wall2AddrLong;
        string Base = "43 3a 5c 57 ? 4e 44 4f 57 53 5c 53 59 53 54 45 4d 33 32 5c 44";
        string Car1 = "48 89 ?? ?? ?? 44 8B ?? 48 89 ?? ?? ?? BA";
        string Car2 = "0F 28 ?? 41 0F ?? ?? ?? 0F C6 D6 ?? 41 0F";
        string Wall1 = "F3 0F ?? ?? ?? 0F 59 ?? 0F C6 ED ?? 0F C6 F6";
        string Wall2 = "0F 28 ?? 0F C6 C1 ?? 0F 28 ?? 0F C6 CB ?? 41 0F ?? ?? F3 0F ?? ?? 41 0F ?? ?? 0F C6 C0 ?? 0F C6 E4";
        string BaseAddr;        string Base2Addr;       string Base3Addr;
        string Car1Addr;        string Car2Addr;
        string Wall1Addr;       string Wall2Addr;
        string FrontLeftAddr;   string FrontRightAddr;  string BackLeftAddr;    string BackRightAddr;
        string OnGroundAddr;    string InRaceAddr;
        string xVelocityAddr;   string yVelocityAddr;   string zVelocityAddr;
        string xAddr;           string yAddr;           string zAddr;
        string CheckPointxAddr; string CheckPointyAddr; string CheckPointzAddr;
        string YawAddr;         string RollAddr;        string PitchAddr;      string yAngVelAddr;
        string GasAddr;
        float xVelocityVal;     float yVelocityVal;     float zVelocityVal;
        float x;                float y;                float z;
        float CheckPointx;      float CheckPointy;      float CheckPointz;
        float BoostSpeed1;      float BoostSpeed2;      float BoostSpeed3;      float BoostLim; //speed
        float TurnRatio;        float TurnStrength;
        float VelMult;
        int times1;             int times2;             int times3;             int times4; //boost
        int BoostInterval1;     int BoostInterval2;     int BoostInterval3;     int BoostInterval4; /*interval*/ int TurnInterval;
        int cycles;


        public MainWindow()
        {
            InitializeComponent();
            keyboardHook.Install();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);
            CheckForIllegalCrossThreadCalls = false;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
        //dragging functionality
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void TopPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = System.Windows.Forms.Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void TopPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(System.Windows.Forms.Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void TopPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragging = false;
        }
        //end of dragging functionality
        //keyboard hooks
        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            key.ToString();
            if (key == KeyboardHook.VKeys.SPACE)
            {
                if (BreakToggle)
                {
                    BreakStart = true;
                }
                if (StopToggle)
                {
                    StopAllWheels();
                }
            }
            if (key == KeyboardHook.VKeys.LSHIFT)
            {
                if(VelHackToggle)
                {
                    VelHackStart = true;
                }
                if(SpeedHackToggle)
                {
                    SpeedHackStart = true;
                }
            }
            if (key == KeyboardHook.VKeys.KEY_A)
            {
                if (TurnAssistToggle)
                {
                    TurnAssistLeftStart = true;
                }
            }
            if (key == KeyboardHook.VKeys.KEY_D)
            {
                if (TurnAssistToggle)
                {
                    TurnAssistRightStart = true;
                }
            }
        }
        private void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            key.ToString();
            if (key == KeyboardHook.VKeys.SPACE)
            {
                 if (BreakToggle)
                {
                    BreakStart = false;
                }
                if (StopToggle)
                {
                    StopAllWheels();
                }
            }
            if (key == KeyboardHook.VKeys.LSHIFT)
            {
                if (VelHackToggle)
                {
                    VelHackStart = false;
                }
                if (SpeedHackToggle)
                {
                    SpeedHackStart = false;
                }
            }
            if (key == KeyboardHook.VKeys.KEY_A)
            {
                if (TurnAssistToggle)
                {
                    TurnAssistLeftStart = false;
                }
            }
            if (key == KeyboardHook.VKeys.KEY_D)
            {
                if (TurnAssistToggle)
                {
                    TurnAssistRightStart = false;
                }
            }
        }
        //end of hooks
        //setup
        public async void AoBscan()
        {
            if (BaseAddr == "1DD0" || BaseAddr == null)
            {
                BaseAddr = BaseAddrLong.ToString("X");
                BaseAddrLong = (await m.AoBScan(Base, false, true)).FirstOrDefault() + 7632;
            }
            if (Base2Addr == "2F70" || Base2Addr == null)
            {
                Base2Addr = Base2AddrLong.ToString("X");
                Base2AddrLong = (await m.AoBScan(Base, false, true)).FirstOrDefault() + 12144;
            }
            if (Base3Addr == "-D00" || Base3Addr == null)
            {
                Base3Addr = Base3AddrLong.ToString("X");
                Base3AddrLong = (await m.AoBScan(Base, false, true)).FirstOrDefault() - 3328;
            }
            if (Car1Addr == "6A" || Car1Addr == null)
            {
                Car1Addr = Car1AddrLong.ToString("X");
                Car1AddrLong = (await m.AoBScan(Car1, false, true)).FirstOrDefault() + 106;
            }
            if (Car2Addr == "-19B" || Car2Addr == null)
            {
                Car2Addr = Car2AddrLong.ToString("X");
                Car2AddrLong = (await m.AoBScan(Car2, false, true)).FirstOrDefault() - 411;
            }
            if (Wall1Addr == "191" || Wall1Addr == null)
            {
                Wall1Addr = Wall1AddrLong.ToString("X");
                Wall1AddrLong = (await m.AoBScan(Wall1, false, true)).FirstOrDefault() + 401;
            }
            if (Wall2Addr == "-1BE" || Wall2Addr == null)
            {
                Wall2Addr = Wall2AddrLong.ToString("X");
                Wall2AddrLong = (await m.AoBScan(Wall2, false, true)).FirstOrDefault() - 446;
            }
        }
        public void Addresses()
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
            CheckPointxAddr = (Base3Addr + ",0x618,0x2F8,0xE0,0x198,0xA8,0x168,0x118,0xAA0");
            CheckPointyAddr = (Base3Addr + ",0x618,0x2F8,0xE0,0x198,0xA8,0x168,0x118,0xAA4");
            CheckPointzAddr = (Base3Addr + ",0x618,0x2F8,0xE0,0x198,0xA8,0x168,0x118,0xAA8");
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
        }
        //end of setup
        //break hack methods + BGworker
        public void Breakworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (BreakToggle)
            {
                SuperBreak();
            }
        }
        public void SuperBreak()
        {
            while (BreakStart)
            {
                xVelocityVal = Math.Abs(m.ReadFloat(xVelocityAddr));
                zVelocityVal = Math.Abs(m.ReadFloat(zVelocityAddr));
                if (xVelocityVal < 5 || xVelocityVal < 5)
                {
                    xVelocityVal = 0;
                    zVelocityVal = 0;
                }
                else
                {
                    xVelocityVal = m.ReadFloat(xVelocityAddr) * (float)0.98;
                    zVelocityVal = m.ReadFloat(zVelocityAddr) * (float)0.98;
                }

                m.WriteMemory(xVelocityAddr, "float", xVelocityVal.ToString());
                m.WriteMemory(yVelocityAddr, "float", "0");
                m.WriteMemory(zVelocityAddr, "float", zVelocityVal.ToString());
                m.WriteMemory(YawAddr, "float", "0");
            }
        }
        public void StopAllWheels()
        {
            m.WriteMemory(FrontLeftAddr, "float", "0");
            m.WriteMemory(FrontRightAddr, "float", "0");
            m.WriteMemory(BackLeftAddr, "float", "0");
            m.WriteMemory(BackRightAddr, "float", "0");
        }
        //end of break hacks
        //speed hack methods + BGworkers
        public void VelHackworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (VelHackToggle)
            {
                SpeedHackVel();
            }
        }
        public void SpeedHackVel()
        {
            while (VelHackStart)
            {
                cycles++;
                xVelocityVal = m.ReadFloat(xVelocityAddr) * (float)VelMult;
                zVelocityVal = m.ReadFloat(zVelocityAddr) * (float)VelMult;
                y = m.ReadFloat(yAddr);
                if (cycles % 2 == 0)
                {
                    y = m.ReadFloat(yAddr) - (float)0.01;
                    cycles = 0;
                }

                m.WriteMemory(xVelocityAddr, "float", xVelocityVal.ToString());
                m.WriteMemory(zVelocityAddr, "float", zVelocityVal.ToString());
                m.WriteMemory(yAddr, "float", y.ToString());
                Thread.Sleep(50);
            }
        }
        public void SpeedHackworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (SpeedHackToggle)
            {
                SpeedHack();
            }
        }
        public void SpeedHack()
        {
            while (SpeedHackStart)
            {
                m.WriteMemory(GasAddr, "float", "1");
                float boost = (float)Math.Ceiling(m.ReadFloat(FrontLeftAddr));
                if (boost < BoostSpeed1)
                {
                    for (int i = 0; i < times1; i++)
                    {
                        boost++;
                    }
                    Thread.Sleep(BoostInterval1);
                }
                else if (boost < BoostSpeed2)
                {
                    for (int i = 0; i < times2; i++)
                    {
                        boost++;
                    }
                    Thread.Sleep(BoostInterval2);
                }
                else if (boost < BoostSpeed3)
                {
                    for (int i = 0; i < times3; i++)
                    {
                        boost++;
                    }
                    Thread.Sleep(BoostInterval3);
                }
                else
                {
                    for (int i = 0; i < times4; i++)
                    {
                        boost++;
                    }
                    Thread.Sleep(BoostInterval4);
                }
                if (boost >= BoostLim)
                {
                    boost = BoostLim;
                }
                m.WriteMemory(FrontLeftAddr, "float", boost.ToString());
                m.WriteMemory(FrontRightAddr, "float", boost.ToString());
                m.WriteMemory(BackLeftAddr, "float", boost.ToString());
                m.WriteMemory(BackRightAddr, "float", boost.ToString());
            }
        }
        //end of speed hacks
        //Turn assist methods + workers
        public void TurnAssistworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (TurnAssistToggle)
            {
                TurnAssistLeft();
                TurnAssistRight();
            }
        }
        public void TurnAssistLeft()
        {
            while(TurnAssistLeftStart)
            {
                float FrontLeft = m.ReadFloat(FrontLeftAddr);
                float FrontRight = m.ReadFloat(FrontRightAddr);
                float BackLeft = m.ReadFloat(BackLeftAddr);
                float BackRight = m.ReadFloat(BackRightAddr);
                if ((float)Math.Abs(FrontRight - FrontLeft) < (FrontRight / TurnRatio) && (float)Math.Abs(BackRight - FrontLeft) < (BackRight / TurnRatio))
                {
                    FrontLeft = FrontLeft - TurnStrength;
                    BackLeft = BackLeft - TurnStrength;
                    FrontRight = FrontRight + TurnStrength;
                    BackRight = BackRight + TurnStrength;
                    Thread.Sleep(TurnInterval);
                }
                m.WriteMemory(FrontLeftAddr, "float", FrontLeft.ToString());
                m.WriteMemory(FrontRightAddr, "float", FrontRight.ToString());
                m.WriteMemory(BackLeftAddr, "float", BackLeft.ToString());
                m.WriteMemory(BackRightAddr, "float", BackRight.ToString());
            }
        }
        public void TurnAssistRight()
        {
            while(TurnAssistRightStart)
            {
                float FrontLeft = m.ReadFloat(FrontLeftAddr);
                float FrontRight = m.ReadFloat(FrontRightAddr);
                float BackLeft = m.ReadFloat(BackLeftAddr);
                float BackRight = m.ReadFloat(BackRightAddr);
                if ((float)Math.Abs(FrontLeft - FrontRight) < (FrontLeft / TurnRatio) && (float)Math.Abs(BackLeft - FrontRight) < (BackLeft / TurnRatio))
                {
                    FrontRight = FrontRight - TurnStrength;
                    BackRight = BackRight - TurnStrength;
                    FrontLeft = FrontLeft + TurnStrength;
                    BackLeft = BackLeft + TurnStrength;
                    Thread.Sleep(TurnInterval);
                }
                m.WriteMemory(FrontLeftAddr, "float", FrontLeft.ToString());
                m.WriteMemory(FrontRightAddr, "float", FrontRight.ToString());
                m.WriteMemory(BackLeftAddr, "float", BackLeft.ToString());
                m.WriteMemory(BackRightAddr, "float", BackRight.ToString());
            }
        }
        //end of turn assists
        //teleport "script"
        public void CheckPointTPworker_DoWork(object sender, DoWorkEventArgs e)
        {   
            while (CheckPointTPToggle)
            {
                float InRace = m.ReadFloat(InRaceAddr);
                if (InRace == 1)
                {
                    Thread.Sleep(3750);
                    while (InRace == 1)
                    {
                        InRace = m.ReadFloat(InRaceAddr);
                        CheckPointTP();
                    }
                    m.UnfreezeValue(yAngVelAddr);
                }
            }
        }
        public void CheckPointTP()
        {
            Thread.Sleep(25);
            //CheckPointx = m.ReadFloat(CheckPointxAddr);     CheckPointy = m.ReadFloat(CheckPointyAddr);     CheckPointz = m.ReadFloat(CheckPointzAddr);
            m.WriteMemory(xAddr, "float", (m.ReadFloat(CheckPointxAddr)).ToString());
            m.WriteMemory(yAddr, "float", (m.ReadFloat(CheckPointyAddr)+ 4).ToString());
            m.WriteMemory(zAddr, "float", (m.ReadFloat(CheckPointzAddr)).ToString());
            m.FreezeValue(yAngVelAddr, "float", "100");
        }
        //end of teleport "script"
        //NoClip handler
        public void NoClipworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (NoClipToggle)
            {
                Noclip();
            }
        }
        public void Noclip()
        {
            var Jmp1 = new byte[6] { 0xE9, 0x2A, 0x02, 0x00, 0x00, 0x90 };
            var Jmp2 = new byte[6] { 0xE9, 0x2B, 0x02, 0x00, 0x00, 0x90 };
            var Jmp1before = new byte[6] { 0x0F, 0x84, 0x29, 0x02, 0x00, 0x00 };
            var Jmp2before = new byte[6] { 0x0F, 0x84, 0x2A, 0x02, 0x00, 0x00 };
            float OnGround = m.ReadFloat(OnGroundAddr);
            if (OnGround == 0)
            {
                cycles++;
                if (cycles % 10 == 0)
                {
                    OnGround = m.ReadFloat(OnGroundAddr);
                    if (OnGround == 0)
                    {
                        m.WriteBytes(Wall1Addr, Jmp1before);
                        m.WriteBytes(Wall2Addr, Jmp2before);
                    }
                    cycles = 0;
                }
            }
            if (OnGround == 1)
            {
                cycles++;
                if (cycles % 10 == 0)
                {
                    m.WriteBytes(Wall1Addr, Jmp1);
                    m.WriteBytes(Wall2Addr, Jmp2);
                    cycles = 0;
                }
            }

        }
        //end of noclip
        //used to clear all the colours before setting accent and highlight for the tab
        private void ClearColours()
        {
            BTN_TabInfo.BackColor = Color.FromArgb(28, 28, 28);
            Panel_Info.BackColor = Color.FromArgb(28, 28, 28);
            BTN_TabAddCars.BackColor = Color.FromArgb(28, 28, 28);
            Panel_AddCars.BackColor = Color.FromArgb(28, 28, 28);
            BTN_TabStatsEditor.BackColor = Color.FromArgb(28, 28, 28);
            Panel_StatsEditor.BackColor = Color.FromArgb(28, 28, 28);
            BTN_TabSaveswap.BackColor = Color.FromArgb(28, 28, 28);
            Panel_Saveswap.BackColor = Color.FromArgb(28, 28, 28);
            BTN_TabLiveTuning.BackColor = Color.FromArgb(28, 28, 28);
            Panel_LiveTuning.BackColor = Color.FromArgb(28, 28, 28);
            BTN_TabSpeedhack.BackColor = Color.FromArgb(28, 28, 28);
            Panel_Speedhack.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void ClearTabItems()
        {
            Tab_1Info.Hide();
            Tab_2AddCars.Hide();
            Tab_3StatsEditor.Hide();
            Tab_4Saveswap.Hide();
            Tab_5LiveTuning.Hide();
            Tab_6Speedhack.Hide();
        }
        private void DisableButtons()
        {
            BTN_TabAddCars.Enabled = false;
            BTN_TabStatsEditor.Enabled = false;
            BTN_TabLiveTuning.Enabled = false;
            BTN_TabSpeedhack.Enabled = false;

        }
        private void EnableButtons()
        {
            BTN_TabAddCars.Enabled = true;
            BTN_TabStatsEditor.Enabled = true;
            BTN_TabLiveTuning.Enabled = true;
            BTN_TabSpeedhack.Enabled = true;
        }
        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BTN_TabInfo_Click(object sender, EventArgs e)
        {
            ClearColours();
            BTN_TabInfo.BackColor = Color.FromArgb(45, 45, 48);
            Panel_Info.BackColor = Color.FromArgb(150, 11, 166);
            ClearTabItems();
            Tab_1Info.Show();
        }
        private void BTN_TabAddCars_Click(object sender, EventArgs e)
        {
            if (IsAttached)
            {
                //do colours and hide/show ui
                ClearColours();
                BTN_TabAddCars.BackColor = Color.FromArgb(45, 45, 48);
                Panel_AddCars.BackColor = Color.FromArgb(150, 11, 166);
                ClearTabItems();
                Tab_2AddCars.Show();
            }
            else
            {
                ;
            }
        }
        private void BTN_TabStatsEditor_Click(object sender, EventArgs e)
        {
            if (IsAttached)
            {
                ClearColours();
                BTN_TabStatsEditor.BackColor = Color.FromArgb(45, 45, 48);
                Panel_StatsEditor.BackColor = Color.FromArgb(150, 11, 166);
                ClearTabItems();
                Tab_3StatsEditor.Show();
            }
            else
            {
                ;
            }
        }
        private void BTN_TabSaveswap_Click(object sender, EventArgs e)
        {
                ClearColours();
                BTN_TabSaveswap.BackColor = Color.FromArgb(45, 45, 48);
                Panel_Saveswap.BackColor = Color.FromArgb(150, 11, 166);
                ClearTabItems();
            Tab_4Saveswap.Show();

        }
        private void BTN_TabLiveTuning_Click(object sender, EventArgs e)
        {
            if (IsAttached)
            {
                ClearColours();
                BTN_TabLiveTuning.BackColor = Color.FromArgb(45, 45, 48);
                Panel_LiveTuning.BackColor = Color.FromArgb(150, 11, 166);
                ClearTabItems();
                Tab_5LiveTuning.Show();
            }
            else
            {
                ;
            }
        }
        private void BTN_TabSpeedhack_Click(object sender, EventArgs e)
        {
            if (IsAttached)
            {
                ClearColours();
                BTN_TabSpeedhack.BackColor = Color.FromArgb(45, 45, 48);
                Panel_Speedhack.BackColor = Color.FromArgb(150, 11, 166);
                ClearTabItems();
                Tab_6Speedhack.Show();
                SetSpeedhackVal();
            }
            else
            {
                ;
            }
        }
        private void BTN_TabInfo_MouseEnter(object sender, EventArgs e)
        {
            if (Tab_1Info.Visible==false)
                Panel_Info.BackColor = Color.FromArgb(93, 93, 100);
        }
        private void BTN_TabInfo_MouseLeave(object sender, EventArgs e)
        {
            if (Tab_1Info.Visible == false)
            Panel_Info.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void BTN_TabAddCars_MouseEnter(object sender, EventArgs e)
        {
            if (Tab_2AddCars.Visible == false)
                Panel_AddCars.BackColor = Color.FromArgb(93, 93, 100);
        }
        private void BTN_TabAddCars_MouseLeave(object sender, EventArgs e)
        {
            if (Tab_2AddCars.Visible == false)
                Panel_AddCars.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void BTN_TabStatsEditor_MouseEnter(object sender, EventArgs e)
        {
            if (Tab_3StatsEditor.Visible == false)
                Panel_StatsEditor.BackColor = Color.FromArgb(93, 93, 100);
        }
        private void BTN_TabStatsEditor_MouseLeave(object sender, EventArgs e)
        {
            if (Tab_3StatsEditor.Visible == false)
                Panel_StatsEditor.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void BTN_TabSaveswap_MouseEnter(object sender, EventArgs e)
        {
            if (Tab_4Saveswap.Visible == false)
                Panel_Saveswap.BackColor = Color.FromArgb(93, 93, 100);
        }
        private void BTN_TabSaveswap_MouseLeave(object sender, EventArgs e)
        {
            if (Tab_4Saveswap.Visible == false)
                Panel_Saveswap.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void BTN_TabLiveTuning_MouseEnter(object sender, EventArgs e)
        {
            if (Tab_5LiveTuning.Visible == false)
                Panel_LiveTuning.BackColor = Color.FromArgb(93, 93, 100);
        }
        private void BTN_TabLiveTuning_MouseLeave(object sender, EventArgs e)
        {
            if (Tab_5LiveTuning.Visible == false)
                Panel_LiveTuning.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void BTN_TabSpeedhack_MouseEnter(object sender, EventArgs e)
        {
            if (Tab_6Speedhack.Visible == false)
                Panel_Speedhack.BackColor = Color.FromArgb(93, 93, 100);
        }
        private void BTN_TabSpeedhack_MouseLeave(object sender, EventArgs e)
        {
            if (Tab_6Speedhack.Visible == false)
                Panel_Speedhack.BackColor = Color.FromArgb(28, 28, 28);
        }
        private void InitialBGworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Addresses();
                if(!m.OpenProcess("ForzaHorizon4"))
                {
                    IsAttached = false;
                    InitialBGworker.ReportProgress(0);
                    Thread.Sleep(1000);
                    continue;
                }
                if (BaseAddr == "1DD0" || (BaseAddr == null)
                    || (Base2Addr == "2F70") || (Base2Addr == null)
                    || (Base3Addr == "-D00") || (Base3Addr == null)
                    || (Car1Addr == "6A") || (Car1Addr == null)
                    || (Car2Addr == "-19B") || (Car2Addr == null)
                    || (Wall1Addr == "191") || (Wall1Addr == null)
                    || (Wall2Addr == "-1BE") || (Wall2Addr == null))
                {
                    AoBscan();
                    continue;
                }
                IsAttached = true;
                Thread.Sleep(1000);
                InitialBGworker.ReportProgress(0);
            }
        }
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            InitialBGworker.RunWorkerAsync();
            CheckAttachedworker.RunWorkerAsync();
        }
        private void CheckAttachedworker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(50);
                if (IsAttached == false && Tab_1Info.Visible == false && Tab_4Saveswap.Visible == false)
                {
                   ClearColours();
                   BTN_TabInfo.BackColor = Color.FromArgb(45, 45, 48);
                   Panel_Info.BackColor = Color.FromArgb(150, 11, 166);
                   ClearTabItems();
                   Tab_1Info.Show();
                }
            }
        }
        private void InitialBGworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (IsAttached)
            {
                LBL_Attached.Text = "Attached to FH4";
                LBL_Attached.ForeColor = Color.Green;
                EnableButtons();
            }
            else
            {
                LBL_Attached.Text = "Not Attached to FH4";
                LBL_Attached.ForeColor = Color.Red;
                DisableButtons();
            }
        }
        private void InitialBGworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitialBGworker.RunWorkerAsync();
        }
        private void TB_ACAutoshow_CheckStateChanged(object sender, EventArgs e)
        {
            if (TB_ACAutoshow.Checked == false)
            {
                m.WriteMemory("base+4C4B7EC","string","0");
            }
            else
            {
                m.WriteMemory("base+4C4B7EC", "string", "1");
            }
        }
        private void Tab_6Speedhack_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        //noclip buttons
        private void TB_SHCarNoClip_CheckedChanged(object sender, EventArgs e)
        {
            var Jmp3before = new byte[6] { 0x0F, 0x84, 0xB5, 0x01, 0x00, 0x00 };
            var Jmp4before = new byte[6] { 0x0F, 0x84, 0x3A, 0x03, 0x00, 0x00 };
            var Jmp3 = new byte[6] { 0xE9, 0xB6, 0x01, 0x00, 0x00, 0x90 };
            var Jmp4 = new byte[6] { 0xE9, 0x3B, 0x03, 0x00, 0x00, 0x90 };

            if (TB_SHCarNoClip.Checked == false)
            {
                m.WriteBytes(Car1Addr, Jmp3before);
                m.WriteBytes(Car2Addr, Jmp4before);
            }
            else
            {
                m.WriteBytes(Car1Addr, Jmp3);
                m.WriteBytes(Car2Addr, Jmp4);
            }
        }
        private void TB_SHWallNoClip_CheckedChanged(object sender, EventArgs e)
        {
            var Jmp1before = new byte[6] { 0x0F, 0x84, 0x29, 0x02, 0x00, 0x00 };
            var Jmp2before = new byte[6] { 0x0F, 0x84, 0x2A, 0x02, 0x00, 0x00 };
            if (TB_SHWallNoClip.Checked == false)
            {
                NoClipToggle = false;
                NoClipworker.CancelAsync();
                m.WriteBytes(Wall1Addr, Jmp1before);
                m.WriteBytes(Wall2Addr, Jmp2before);
            }
            else
            {
                NoClipworker.RunWorkerAsync();
                NoClipToggle = true;
            }
        }
        //end of noclip
        //speedhack buttons
        private void SuperBreakButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SuperBreakButton.Checked == false)
            {
                BreakToggle = false;
                Breakworker.CancelAsync();
            }
            else
            {
                BreakToggle = true;
                Breakworker.RunWorkerAsync();
            }
        }
        private void StopAllWheelsButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StopAllWheelsButton.Checked == false)
            {
                StopToggle = false;
            }
            else
            {
                StopToggle = true;
            }
        }
        private void VelHackButton_CheckedChanged(object sender, EventArgs e)
        {
            if (VelHackButton.Checked == false)
            {
                VelHackToggle = false;
                VelHackworker.CancelAsync();
            }
            else
            {
                VelHackToggle = true;
                VelHackworker.RunWorkerAsync();
            }
        }
        private void WheelSpeedButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WheelSpeedButton.Checked == false)
            {
                SpeedHackToggle = false;
                SpeedHackworker.CancelAsync();
            }
            else
            {
                SpeedHackToggle = true;
                SpeedHackworker.RunWorkerAsync();
            }
        }
        //end of speedhack stuff
        //turnassist button
        private void TurnAssistButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TurnAssistButton.Checked == false)
            {
                TurnAssistToggle = false;
                TurnAssistworker.CancelAsync();
            }
            else
            {
                TurnAssistToggle = true;
                TurnAssistworker.RunWorkerAsync();
            }
        }
        //end of turn assist
        //teleports
        private void LST_TeleportLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LST_TeleportLocation.Text == "Festival")
            {
                x = (float)-2753.350098;
                y = (float)349.7218018;
                z = (float)-4357.629883;
            }
            if (LST_TeleportLocation.Text == "Start of Motorway")
            {
                x = (float)2657.887451;
                y = (float)270.7128906;
                z = (float)-4353.087402;
            }
            if (LST_TeleportLocation.Text == "Broadway")
            {
                x = (float)-237.2871857;
                y = (float)239.5045471;
                z = (float)-5816.858398;
            }

            if (LST_TeleportLocation.Text == "Greendale Airstrip")
            {
                x = (float)3409.570068;
                y = (float)159.2418976;
                z = (float)661.2498779;
            }
        }
        private void TPButton_Click(object sender, EventArgs e)
        {
            m.WriteMemory(xAddr, "float", x.ToString());
            m.WriteMemory(yAddr, "float", y.ToString());
            m.WriteMemory(zAddr, "float", z.ToString());
        }
        private void BTN_MIN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CheckpointBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckpointBox.Checked == false)
            {
                CheckPointTPToggle = false;
                CheckPointTPworker.CancelAsync();
                m.UnfreezeValue(yAngVelAddr);
            }
            else
            {
                CheckPointTPToggle = true;
                CheckPointTPworker.RunWorkerAsync();
            }
        }
        //end of teleports
        private void SetSpeedhackVal()
        {
            TurnIntervalBox.Value = Convert.ToDecimal(TurnInterval);
            RatioBox.Value = Convert.ToDecimal(TurnRatio);
            TurnStrengthBox.Value = Convert.ToDecimal(TurnStrength);
            VelMultBar.Value = Convert.ToInt32(VelMult);
            VelMultBox.Value = Convert.ToDecimal(VelMult);
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
        }
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

        private void VelMultBar_Scroll(object sender, EventArgs e)
        {
            VelMultBox.Value = Convert.ToDecimal(VelMultBar.Value);
            VelMult = Decimal.ToSingle(VelMultBar.Value);
        }

        private void VelMultBox_ValueChanged(object sender, EventArgs e)
        {
            VelMultBar.Value = Decimal.ToInt32(VelMultBox.Value);
            VelMult = Decimal.ToSingle(VelMultBox.Value);
        }
    }
}
