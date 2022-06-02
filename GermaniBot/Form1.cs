using BOTLIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;




namespace GermaniBot
{
    public partial class Form1 : Form
    {
        public struct S_ImageSearching
        {
            public string name;
            public int tolerance;
            public Point regionBegin;
            public Point regionEnd;
            public Bitmap[] imagesToFind;
        }

        public enum Factions
        {
            NoFaction,
            Roman,
            Greece,
            Carthage,
            Barbarian,
            China
        }
        Factions factions;

        [Flags]
        public enum Commanders
        {
            NoSelected = 0,
            Selected = 1 << 0,
            Germanicus = 1 << 1,
            Cynane = 1 << 2,
            Caesar = 1 << 3,
            Scipio = 1 << 4,
        }
        Commanders currentSelectedCommander;
        Commanders currentCommanderInGame;
        Commanders currentDeadCommander;

        public delegate void delegateUpdateRichTextBox(string text, RichTextBox richbox, Color color);
        public delegate void delegateUpdateLabelBox(string text, Label label);

        delegateUpdateRichTextBox DelegateUpdateUiTextBox = new delegateUpdateRichTextBox(SetConsoleText);
        delegateUpdateLabelBox DelegateUpdateLabelBox = new delegateUpdateLabelBox(SetLabelText);

        bool process;
        bool is_qwerty = false;
        bool is_azerty = true;

        bool isArmiesButtonSelected = false;
        bool isCommanderButtonSelected = false;
        bool isFactionButtonSelected = false;

        bool isPartyLaunching = false;
        bool isInGame = false;

        // STATS //
        int numberOfPlayedGame;

        //Time Variable
        int hh;
        int mm;
        int ss;

        // Commanders Ability
        //bool isInFormation;
        //bool IsInMeleeUnit1;
        //bool IsInMeleeUnit2;
        //bool IsInMeleeUnit3;
        bool[] IsUnitsInMelee = { false, false, false };

        //ROMAN
        bool isGermanicus_Desired = false;
        bool IsSulla_Desired = false;
        bool isCaesarDesired = false;
        bool isScipioDesired = false;

        //GREECE
        bool isCynane_Desired = false;
        bool isAlexander_Desired = false;
        bool isLeonidas_Desired = false;
        bool isMilitiade_Desired = false;

        //BARBARIAN
        bool isVercingetorix_Desired = false;
        bool isBoudica_Desired = false;
        bool isAmbiorix_Desired = false;
        bool isArminius_Desired = false;

        //CARTHAGE
        bool isHannibal_Desired = false;
        bool isHasdrubal_Desired = false;


        bool isCancelButtonFound = false;

        Point enemyBaseLocation = Point.Empty;
        Point selfBaseLocation = Point.Empty;
        IntPtr gameHandle;

        BotUtilityNative bot = new BotUtilityNative();

        int autoAttackCounter;

       
        #region Commanders

        S_ImageSearching germanicus = new S_ImageSearching
        {
            name = "Germanicus",
            tolerance = 10,
            regionBegin = new Point(160, 250),
            regionEnd = new Point(400, 400),
            imagesToFind = new Bitmap[] { Resource1.Germanicus0, Resource1.germanicus1, Resource1.germanicus2 }
        };
        S_ImageSearching cynane = new S_ImageSearching
        {
            name = "Cynane",
            tolerance = 10,
            regionBegin = new Point(160, 250),
            regionEnd = new Point(400, 400),
            imagesToFind = new Bitmap[] { Resource1.cynane0, Resource1.cynane1, Resource1.cynane2 }
        };
        S_ImageSearching guanYu = new S_ImageSearching
        {
            name = "GuanYu",
            tolerance = 10,
            regionBegin = new Point(160, 250),
            regionEnd = new Point(400, 400),
            imagesToFind = new Bitmap[] { Resource1.Guanyu }
        };


        #endregion

        #region Main Menu UI

        #region ArmiesButton
        S_ImageSearching notSelectedArmiesButton = new S_ImageSearching
        {
            name = "Not Selected Armies Button",
            tolerance = 30,
            regionBegin = new Point(0, 0),
            regionEnd = new Point(250, 90),
            imagesToFind = new Bitmap[] { Resource1.ArmiesButtonNotSelected }
        };
        S_ImageSearching selectedArmiesButton = new S_ImageSearching
        {
            name = "Selected Armies Button",
            tolerance = 30,
            regionBegin = new Point(0, 0),
            regionEnd = new Point(250, 90),
            imagesToFind = new Bitmap[] { Resource1.ArmiesButtonSelected }
        };
        #endregion

        #region Commander Button
        S_ImageSearching selectedCommanderButton = new S_ImageSearching
        {
            name = "Selected Armies Button",
            tolerance = 30,
            regionBegin = new Point(0, 0),
            regionEnd = new Point(270, 100),
            imagesToFind = new Bitmap[] { Resource1.selectedCommanderButton }
        };
        S_ImageSearching notSelectedCommanderButton = new S_ImageSearching
        {
            name = "Selected Armies Button",
            tolerance = 30,
            regionBegin = new Point(0, 0),
            regionEnd = new Point(270, 100),
            imagesToFind = new Bitmap[] { Resource1.notSelectedCommanderButton }
        };

        #endregion

        #region Factions

        #region Roman
        S_ImageSearching notSelectedRoman = new S_ImageSearching
        {
            name = "Not Selected Roman Button",
            tolerance = 30,
            regionBegin = new Point(40, 140),
            regionEnd = new Point(515, 245),
            imagesToFind = new Bitmap[] { Resource1.romanNotSelected }
        };
        S_ImageSearching selectedRoman = new S_ImageSearching
        {
            name = " Selected Roman Button",
            tolerance = 30,
            regionBegin = new Point(40, 140),
            regionEnd = new Point(515, 245),
            imagesToFind = new Bitmap[] { Resource1.romanSelected }
        };
        #endregion
        #region Grec
        S_ImageSearching notSelectedGrec = new S_ImageSearching
        {
            name = " Not Selected Grec Button",
            tolerance = 30,
            regionBegin = new Point(40, 140),
            regionEnd = new Point(515, 245),
            imagesToFind = new Bitmap[] { Resource1.grecNotSelected }
        };
        S_ImageSearching selectedGrec = new S_ImageSearching
        {
            name = " Selected Grec Button",
            tolerance = 30,
            regionBegin = new Point(40, 140),
            regionEnd = new Point(515, 245),
            imagesToFind = new Bitmap[] { Resource1.grecSelected }
        };
        #endregion 

        #endregion

        S_ImageSearching playButton = new S_ImageSearching
        {
            name = "PlayButton",
            tolerance = 30,
            regionBegin = new Point(1180, 0),
            regionEnd = new Point(1370, 50),
            imagesToFind = new Bitmap[] { Resource1.PlayButton0, Resource1.PlayButton1 }
        };
        S_ImageSearching cancelButton = new S_ImageSearching
        {
            name = "CancelButton",
            tolerance = 30,
            regionBegin = new Point(1180, 110),
            regionEnd = new Point(1370, 140),
            imagesToFind = new Bitmap[] { Resource1.cancel0 }
        };
        S_ImageSearching continueButton = new S_ImageSearching
        {
            name = "ContinueButton",
            tolerance = 30,
            regionBegin = new Point(1100, 1370),
            regionEnd = new Point(1450, 1440),
            imagesToFind = new Bitmap[] { Resource1.continueButton }
        };
        S_ImageSearching closeButton = new S_ImageSearching
        {
            name = "CloseButton",
            tolerance = 30,
            regionBegin = new Point(1100, 830),
            regionEnd = new Point(1620, 1440),
            imagesToFind = new Bitmap[] { Resource1.close, Resource1.close2 }
        };
        S_ImageSearching acceptAllButton = new S_ImageSearching
        {
            name = "AcceptAllButton",
            tolerance = 30,
            regionBegin = new Point(1270, 940),
            regionEnd = new Point(1560, 1000),
            imagesToFind = new Bitmap[] { Resource1.accept }
        };

        #endregion

        #region InGame

        S_ImageSearching enemyBase = new S_ImageSearching
        {
            name = "EnemyBase",
            tolerance = 100,
            regionBegin = new Point(2280, 1160),
            regionEnd = new Point(2560, 1440),
            imagesToFind = new Bitmap[] { Resource1.pointC,Resource1.enemybasecamp0, Resource1.enemybasecamp1,
                Resource1.enemybasecamp8,Resource1.enemybasecamp10, Resource1.enemyBase12,Resource1.enemyBase13,
                Resource1.enemyBase14,Resource1.enemyBase15,Resource1.enemyBase16,Resource1.enemyBase17,Resource1.enemyBase18,
                Resource1.enemyBase19,Resource1.enemyBase20 }
        };
        S_ImageSearching isInGameIcon = new S_ImageSearching
        {
            name = "IsInGame",
            tolerance = 50,
            regionBegin = new Point(860, 1155),
            regionEnd = new Point(2560, 1440),
            imagesToFind = new Bitmap[] { Resource1.isIngame4, Resource1.isInGame8 }
        };
        S_ImageSearching respawnPanel = new S_ImageSearching
        {
            name = "RespawnPanel",
            tolerance = 30,
            regionBegin = new Point(1500, 370),
            regionEnd = new Point(1560, 430),
            imagesToFind = new Bitmap[] { Resource1.respawnpanel }
        };
        S_ImageSearching respawnButton = new S_ImageSearching
        {
            name = "RespawnButton",
            tolerance = 100,
            regionBegin = new Point(1007, 507),
            regionEnd = new Point(1560, 1060),
            imagesToFind = new Bitmap[] { Resource1.respawn1,Resource1.respawn2,Resource1.respawn3,  Resource1.respawn5,
                Resource1.respawn6, Resource1.respawn7,Resource1.respawn8,Resource1.respawn9,Resource1.respawn10,Resource1.respawn11 }
        };
        S_ImageSearching antiAfk = new S_ImageSearching
        {
            name = "AntiAfk",
            tolerance = 50,
            regionBegin = new Point(1160, 800),
            regionEnd = new Point(1400, 860),
            imagesToFind = new Bitmap[] { Resource1.antiAfk0 }
        };

        static S_ImageSearching meleeIconUnit1 = new S_ImageSearching
        {
            name = "Unit 1 MeleIcon",
            tolerance = 120,
            regionBegin = new Point(1010, 1160),
            regionEnd = new Point(1230, 1260),
            imagesToFind = new Bitmap[] { Resource1.melee, Resource1.melee1, Resource1.melee2 }
        };
        static S_ImageSearching meleeIconUnit2 = new S_ImageSearching
        {
            name = "Unit 2 MeleIcon",
            tolerance = 120,
            regionBegin = new Point(1230, 1160),
            regionEnd = new Point(1450, 1260),
            imagesToFind = new Bitmap[] { Resource1.melee, Resource1.melee1, Resource1.melee2 }
        };
        static S_ImageSearching meleeIconUnit3 = new S_ImageSearching
        {
            name = "Unit 3 MeleIcon",
            tolerance = 120,
            regionBegin = new Point(1450, 1160),
            regionEnd = new Point(1670, 1260),
            imagesToFind = new Bitmap[] { Resource1.melee, Resource1.melee1, Resource1.melee2 }
        };

        S_ImageSearching[] meleesIconsUnits = { meleeIconUnit1, meleeIconUnit2, meleeIconUnit3 };


        private bool debug = false;

        #endregion

       
        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            gameHandle = bot.GetGameHandle();
           // CheckFaction();

        }

        #region Testing
        private void Test()
        {
            //bot.SetForgroundWindow(gameHandle);
            TestWorker.RunWorkerAsync();
        }
        private void TestingWorker(object sender, DoWorkEventArgs e)
        {
            delegateUpdateRichTextBox DelUpdateUiTextBox = new delegateUpdateRichTextBox(SetConsoleText);
            // MultiSearchImageInRegion(meleeIconUnit1);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //  backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
            SetCommandersDesirability();

            process = true;
            if (bot.SetForgroundWindow(gameHandle))
            {
                SetConsoleText("************START*************", richTextBox, Color.Green);
                Thread.Sleep(500);
                timer1.Enabled = true;
                timer1.Start();

                CheckFaction();

                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                SetConsoleText("Game Not Detected", richTextBox, Color.Red);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            richTextBox.Clear();
            process = false;
            backgroundWorker.CancelAsync();
            backgroundWorker.Dispose();

            button1.Enabled = true;
            SetConsoleText("Stop", richTextBox, Color.Black);

            isArmiesButtonSelected = false;
            isCommanderButtonSelected = false;

            isPartyLaunching = false;
            isInGame = false;


        }
        public void PrintToConsole(string text)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, text, richTextBox, Color.Black);
        }
        public void PrintToConsoleWithColor(string text, Color color)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, text, richTextBox, color);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            
            delegateUpdateRichTextBox DelUpdateUiTextBox = new delegateUpdateRichTextBox(SetConsoleText);
            delegateUpdateLabelBox DelUpdateLabelBox = new delegateUpdateLabelBox(SetLabelText);

            while (!backgroundWorker.CancellationPending && process)
            {

                if (!isInGame)
                {
                    if (!isArmiesButtonSelected)
                    {
                        if (MultiSearchAndClickInRegion(notSelectedArmiesButton))
                            isArmiesButtonSelected = true;

                        else if (MultiSearchAndClickInRegion(selectedArmiesButton))
                            isArmiesButtonSelected = true;

                        else
                            isArmiesButtonSelected = false;
                    }

                    if (!isCommanderButtonSelected)
                    {
                        if (MultiSearchAndClickInRegion(notSelectedCommanderButton))
                            isCommanderButtonSelected = true;

                        else if (MultiSearchAndClickInRegion(selectedCommanderButton))
                            isCommanderButtonSelected = true;

                        else
                            isCommanderButtonSelected = false;
                    }

                    if (isArmiesButtonSelected && isCommanderButtonSelected && !isPartyLaunching)
                    {
                        if (currentSelectedCommander == Commanders.NoSelected)
                        {
                            switch (factions)
                            {
                                case Factions.Roman:

                                    if (isGermanicus_Desired && ((currentDeadCommander & Commanders.Germanicus) != Commanders.Germanicus))
                                    {
                                        if (MultiSearchAndClickInRegion(germanicus))
                                        {
                                            currentSelectedCommander = Commanders.Germanicus | Commanders.Selected;

                                            Commanders commander = currentSelectedCommander;
                                            commander &= ~Commanders.Selected;
                                            string t = commander.ToString();
                                            richTextBox.BeginInvoke(DelUpdateUiTextBox, "CommanderClicked = " + t, richTextBox, Color.Black);

                                            break;

                                        }

                                    }
                                    break;

                                case Factions.Greece:

                                    if (!MultiSearchAndClickInRegion(selectedGrec))
                                    {
                                        MultiSearchAndClickInRegion(notSelectedGrec);
                                    }
                                  

                                    if (isCynane_Desired && ((currentDeadCommander & Commanders.Cynane) != Commanders.Cynane))
                                    {
                                        if (MultiSearchAndClickInRegion(cynane))
                                        {
                                            currentSelectedCommander = Commanders.Cynane | Commanders.Selected;

                                            Commanders commander = currentSelectedCommander;
                                            commander &= ~Commanders.Selected;
                                            string t = commander.ToString();
                                            richTextBox.BeginInvoke(DelUpdateUiTextBox, "CommanderClicked = " + t, richTextBox, Color.Black);

                                            break;

                                        }

                                    }
                                    break;

                                case Factions.Carthage:
                                    break;

                                case Factions.Barbarian:
                                    break;

                                default:
                                    factions = Factions.Roman;
                                    break;
                            }

                            //if ((currentSelectedCommander & Commanders.Selected) != Commanders.Selected) // HERO IS NOT SELECTED
                            //{
                            //    ScrollInLateralMenu();
                            //}
                        }

                        if ((currentSelectedCommander & Commanders.Selected) == Commanders.Selected) // HERO IS SELECTED
                        {
                            Thread.Sleep(500);
                            if (MultiSearchAndClickInRegion(playButton))
                            {
                                numberOfPlayedGame += 1;
                                Thread.Sleep(2500);

                                if (MultiSearchImageInRegion(cancelButton))
                                {
                                    isPartyLaunching = true;
                                    isCancelButtonFound = true;
                                    PrintToConsoleWithColor("PartyLaunching = " + isPartyLaunching.ToString(), Color.Purple);

                                    Commanders commander = currentSelectedCommander;
                                    commander &= ~Commanders.Selected;
                                    currentCommanderInGame = commander;

                                    //string t = commander.ToString();
                                    //richTextBox.BeginInvoke(DelUpdateUiTextBox, "CommanderReadyToBattle = " + t, richTextBox, Color.Blue);
                                    //richTextBox.BeginInvoke(DelUpdateUiTextBox, "currentSelectedCommander_Flags = " + currentSelectedCommander.ToString(), richTextBox, Color.Black);

                                }
                            }
                            else
                            {
                                isPartyLaunching = false;

                                currentSelectedCommander = Commanders.NoSelected;
                                richTextBox.BeginInvoke(DelUpdateUiTextBox, "currentSelectedCommander = " + currentSelectedCommander.ToString(), richTextBox, Color.Black);

                            }
                        }
                    }

                    if (!isArmiesButtonSelected && !isCommanderButtonSelected && !isPartyLaunching)
                    {
                        if (MultiSearchAndClickInRegion(closeButton))
                        {
                            EndOfGame();
                        }

                        if (MultiSearchAndClickInRegion(acceptAllButton))
                        {
                            EndOfGame();
                        }
                    }

                    if (isPartyLaunching)
                    {
                        if (isCancelButtonFound)
                        {
                            if (MultiSearchImageInRegion(cancelButton))
                            {
                                isCancelButtonFound = true;
                                Thread.Sleep(10000);
                            }
                            else
                                isCancelButtonFound = false;
                        }

                        if (!isCancelButtonFound)
                        {
                            if (MultiSearchImageInRegion(isInGameIcon))
                            {
                                isArmiesButtonSelected = false;
                                isCommanderButtonSelected = false;
                                isPartyLaunching = false;

                                isInGame = true;

                                PrintToConsoleWithColor("IsInGame  = " + isInGame.ToString(), Color.Purple);


                            }
                        }
                    }
                }

                ///IS IN GAME///
                else
                {
                    currentDeadCommander = Commanders.NoSelected;
                    currentSelectedCommander = Commanders.NoSelected;

                    if (enemyBaseLocation == Point.Empty)
                    {
                        Point enemyBaselocalLocation;
                        if (MultiSearchImageInRegion(enemyBase, out enemyBaseLocation, out enemyBaselocalLocation))
                        {
                            selfBaseLocation = CalculateSelfBaseLocation(enemyBase, enemyBaselocalLocation);
                        }
                    }


                    if (enemyBaseLocation != Point.Empty && selfBaseLocation != Point.Empty)
                    {
                        autoAttackCounter += 1;

                        //if (autoAttackCounter % 2 == 0 )
                            //AutoAttackEnemyBase(enemyBaseLocation);

                        switch (currentCommanderInGame)
                        {
                            case Commanders.Germanicus:

                                for (int i = 0; i < meleesIconsUnits.Length; i++)
                                {
                                    SelectUnit(i);
                                    SelectedUnitAttackEnemyBase(enemyBaseLocation);

                                    if (IsUnitInMelee(meleesIconsUnits[i], IsUnitsInMelee, i, "Unit " + (i + 1)))
                                    {
                                        Vengeance(i);
                                        Stab(i);
                                    }
                                   
                                }

                                break;

                            case Commanders.Cynane:

                                for (int i = 0; i < meleesIconsUnits.Length; i++)
                                {
                                    SelectUnit(i);

                                    if (IsUnitInMelee(meleesIconsUnits[i], IsUnitsInMelee, i, "Unit " + (i + 1)))
                                    {
                                        BackToBase(selfBaseLocation);
                                        Dash(i);
                                    }
                                    else
                                    {
                                        SelectedUnitAttackEnemyBase(enemyBaseLocation);
                                    }
                                }

                                break;
                            default:
                                break;
                        }


                        if (MultiSearchImageInRegion(respawnPanel))
                            ClickOnTheGrid(respawnButton);

                        MultiSearchAndClickInRegion(antiAfk);

                        if (MultiSearchAndClickInRegion(continueButton))
                            EndOfGame();

                    }
                    Thread.Sleep(2000);
                }
            }
        }
        private Point CalculateSelfBaseLocation(S_ImageSearching enemyBase, Point enemyBaseLocalLocation)
        {
            Point baseLocation = Point.Empty;

            int distanceX = (enemyBase.regionEnd.X - enemyBase.regionBegin.X) - enemyBaseLocalLocation.X;
            baseLocation.X = enemyBase.regionBegin.X + distanceX;

            int distanceY = (enemyBase.regionEnd.Y - enemyBase.regionBegin.Y) - enemyBaseLocalLocation.Y;
            baseLocation.Y = enemyBase.regionBegin.Y + distanceY;

            return baseLocation;
        }
        private void BackToBase(Point location)
        {
            bot.moveMouse(location, false);
            Thread.Sleep(200);
            bot.rightClick();
            Thread.Sleep(200);
        }
        private void SelectUnit(int i)
        {
            if (i == 0)
            {
                bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_1);
            }
            if (i == 1)
            {
                bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_2);
            }
            if (i == 2)
            {
                bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_3);
            }
        }
        private bool IsUnitInMelee(S_ImageSearching unitRegion, bool[] isInMelee, int unitIndex, string consoleLog)
        {
            if (MultiSearchAndClickInRegion(unitRegion))
            {
                if (!isInMelee[unitIndex])
                {
                    isInMelee[unitIndex] = true;
                    PrintToConsoleWithColor(consoleLog + " MELEE ON", Color.Purple);

                }
                return true;
            }
            else
            {
                if (isInMelee[unitIndex])
                {
                    isInMelee[unitIndex] = false;
                    PrintToConsoleWithColor(consoleLog + "MELLE OFF", Color.Cyan);
                }
                return false;
            }

        }
        private void ClickOnTheGrid(S_ImageSearching searchUi)
        {

            int cellSize = 23;
            int numberOfCellsX = (searchUi.regionEnd.X - searchUi.regionBegin.X) / cellSize;
            int numberOfCellsY = (searchUi.regionEnd.Y - searchUi.regionBegin.Y) / cellSize;

            Point firstCellLocation = new Point(searchUi.regionBegin.X + cellSize / 2, searchUi.regionBegin.Y + cellSize / 2);

            for (int i = 0; i < numberOfCellsX; i++)
            {
                for (int y = 0; y < numberOfCellsY; y++)
                {
                    Point newPos = new Point(firstCellLocation.X + cellSize * i, firstCellLocation.Y + cellSize * y);
                    bot.moveMouse(newPos, false);
                    Thread.Sleep(20);
                    bot.leftClick();

                }



            }

        }
        private void EndOfGame()
        {
            isInGame = false;
            enemyBaseLocation = Point.Empty;

            currentDeadCommander = currentCommanderInGame;
            currentCommanderInGame = Commanders.NoSelected;



            GamePlayed.BeginInvoke(DelegateUpdateLabelBox, numberOfPlayedGame.ToString(), GamePlayed);
        }
        private void AutoAttackEnemyBase(Point p_location)
        {


            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "AutoAttacking", richTextBox, Color.Black);

            SquadMoveToEnemyBase(BotUtilityNative.ScanCodeShort.KEY_1, p_location);
            Thread.Sleep(500);
            SquadMoveToEnemyBase(BotUtilityNative.ScanCodeShort.KEY_2, p_location);
            Thread.Sleep(500);
            SquadMoveToEnemyBase(BotUtilityNative.ScanCodeShort.KEY_3, p_location);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_1);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_1);

            Thread.Sleep(500);
        }
        private void SquadMoveToEnemyBase(BotUtilityNative.ScanCodeShort key, Point location)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "AutoAttacking", richTextBox, Color.Black);

            bot.SendInputKeyPress(key);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_W);
            //Thread.Sleep(500);
            //bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_Z);
            Thread.Sleep(500);
            bot.moveMouse(location, false);
            Thread.Sleep(550);
            bot.rightClick();
        }
        private void SelectedUnitAttackEnemyBase(Point location)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "AutoAttacking", richTextBox, Color.Black);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_W);
            Thread.Sleep(200);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_Z);
            Thread.Sleep(200);
            bot.moveMouse(location, false);
            Thread.Sleep(200);
            bot.rightClick();
        }
        private void Dash(int index)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Unit " + (index + 1) + " Dash", richTextBox, Color.Black);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_T);
            Thread.Sleep(100);
        }
        private void Vengeance(int index)
        {
            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Unit " + (index + 1) + " Vengeance", richTextBox, Color.Black);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_H);
            Thread.Sleep(100);
        }
        private void Whip()
        {

            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Whip", richTextBox, Color.Black);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_1);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_G);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_2);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_G);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_3);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_G);
            Thread.Sleep(500);

        }
        private void Stab(int index)
        {

            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Unit " + (index + 1) + " Stab", richTextBox, Color.Black);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_R);
            Thread.Sleep(100);

        }
        private void ToggleFormedCombat()
        {

            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "FormationToggle", richTextBox, Color.Black);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_1);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_Y);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_2);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_Y);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_3);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_Y);
            Thread.Sleep(500);

            //  isInFormation = !isInFormation;

        }
        private void ToggleFortify()
        {

            richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Fortify", richTextBox, Color.Black);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_1);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_F);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_2);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_F);
            Thread.Sleep(500);

            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_3);
            Thread.Sleep(500);
            bot.SendInputKeyPress(BotUtilityNative.ScanCodeShort.KEY_F);
            Thread.Sleep(500);

            // isInFormation = !isInFormation;

        }
        public static void SetConsoleText(string t, RichTextBox richbox, Color color)
        {
            richbox.SelectionColor = color;
            richbox.AppendText("\n" + t);
            richbox.ScrollToCaret();
        }
        public static void SetLabelText(string t, Label label)
        {
            label.Text = t;
        }
        public bool MultiSearchAndClickInRegion(S_ImageSearching searchUi)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {

                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out location, searchUi.tolerance))
                {
                    location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(location.X + searchUi.regionBegin.X, location.Y + searchUi.regionBegin.Y);
                    bot.moveMouse(newPos, false);
                    Thread.Sleep(500);
                    bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);
                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);
                }
            }
            return false;
        }
        public bool MultiSearchAndClickInRegion(S_ImageSearching searchUi, out Point location)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);

            Point temp_location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {

                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out temp_location, searchUi.tolerance))
                {
                    temp_location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(temp_location.X + searchUi.regionBegin.X, temp_location.Y + searchUi.regionBegin.Y);
                    bot.moveMouse(newPos, false);
                    Thread.Sleep(500);
                    bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);
                    location = newPos;
                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);

                }


            }

            location = Point.Empty;
            return false;



        }
        public bool MultiSearchImageInRegion(S_ImageSearching searchUi)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point temp_location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {
                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out temp_location, searchUi.tolerance))
                {
                    temp_location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(temp_location.X + searchUi.regionBegin.X, temp_location.Y + searchUi.regionBegin.Y);
                    bot.moveMouse(newPos, false);
                    //Thread.Sleep(500);
                    //bot.leftClick();


                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);

                    return true;
                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);
                }


            }


            return false;
        }
        public bool MultiSearchImageInRegion(S_ImageSearching searchUi, out Point globalLocation, out Point localLocation)
        {

            Thread.Sleep(100);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindowRegion(bot.GetGameHandle(), searchUi.regionBegin, searchUi.regionEnd);
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point temp_location;


            PrintToConsole("Searching for " + searchUi.name);

            for (int i = 0; i < searchUi.imagesToFind.Length; i++)
            {
                Bitmap find = searchUi.imagesToFind[i];

                if (debug)
                    PrintToConsole("Searching for " + searchUi.name + " " + i);

                if (bot.findImage(find, screenshot, out temp_location, searchUi.tolerance))
                {
                    temp_location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    Point newPos = new Point(temp_location.X + searchUi.regionBegin.X, temp_location.Y + searchUi.regionBegin.Y);
                    Point localPos = new Point(temp_location.X, temp_location.Y);

                    //bot.moveMouse(newPos, false);
                    //Thread.Sleep(500);
                    //bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, searchUi.name + " " + i + " Found", richTextBox, Color.Green);
                    globalLocation = newPos;
                    localLocation = localPos;
                    return true;
                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + searchUi.name + " " + i + " not Found", richTextBox, Color.Red);

                }
            }

            globalLocation = Point.Empty;
            localLocation = Point.Empty;
            return false;
        }
        public bool MultiSearchAndClickAllScreen(Bitmap[] imagesToFind, int tolerance, string arrayName)
        {

            Thread.Sleep(500);
            Bitmap screenshot = BotUtilityNative.getScreenshotOfWindow(bot.GetGameHandle());
            //Bitmap screenshot = BotUtilityNative.getScreenshot();
            Point location;

            for (int i = 0; i < imagesToFind.Length; i++)
            {

                Bitmap find = imagesToFind[i];

                PrintToConsole("Searching for " + arrayName + " " + i);

                if (bot.findImage(find, screenshot, out location, tolerance))
                {
                    location.Offset(bot.GetWindowsUpperLetftCorner(bot.GetGameHandle()));
                    bot.moveMouse(location, false);
                    Thread.Sleep(500);
                    bot.leftClick();
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, arrayName + " " + i + " Found", richTextBox, Color.Green);
                    return true;
                }
                else
                {
                    if (debug)
                    {
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image " + arrayName + " " + i + " not Found", richTextBox, Color.Red);

                    }

                }
            }
            return false;
        }
        public bool MultiSearchImageAllScreen(Bitmap[] imagesToFind, int tolerance, string ArrayName)
        {
            Thread.Sleep(500);
            Point location;

            for (int i = 0; i < imagesToFind.Length; i++)
            {
                Bitmap find = imagesToFind[i];
                Bitmap screenshot = BotUtilityNative.getScreenshotOfWindow(gameHandle);


                if (bot.findImage(find, screenshot, out location, tolerance))
                {
                    location.Offset(bot.GetWindowsUpperLetftCorner(gameHandle));
                    // bot.moveMouse(location, false);
                    Thread.Sleep(500);
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image" + ArrayName + " " + i + " Found", richTextBox, Color.Green);

                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, "Image" + ArrayName + " " + i + " not Found", richTextBox, Color.Red);

                }


            }
            return false;



        }
        public bool MultiSearchImageAllScreen(Bitmap[] imagesToFind, int tolerance, out Point location, string ArrayName)
        {
            Thread.Sleep(500);
            Point templocation;

            for (int i = 0; i < imagesToFind.Length; i++)
            {
                Bitmap find = imagesToFind[i];
                Bitmap screenshot = BotUtilityNative.getScreenshotOfWindow(gameHandle);
                PrintToConsole("Searching for " + ArrayName + " " + i);

                if (bot.findImage(find, screenshot, out templocation, tolerance))
                {
                    templocation.Offset(bot.GetWindowsUpperLetftCorner(gameHandle));
                    bot.moveMouse(templocation, false);
                    Thread.Sleep(500);
                    location = templocation;
                    richTextBox.BeginInvoke(DelegateUpdateUiTextBox, " Image" + ArrayName + " " + i + " Found ! ", richTextBox, Color.Green);

                    return true;

                }
                else
                {
                    if (debug)
                        richTextBox.BeginInvoke(DelegateUpdateUiTextBox, " Image" + ArrayName + " " + i + " not Found ! ", richTextBox, Color.Red);


                }


            }
            location = Point.Empty;
            return false;



        }
        void SetCommandersDesirability()
        {
            //ROMAN
            if (GermanicusChekBox.Checked)
            {
                isGermanicus_Desired = true;
            }
            else
            {
                isGermanicus_Desired = false;
            }

            if (SullaChekBox.Checked)
            {
                IsSulla_Desired = true;
            }
            else
            {
                IsSulla_Desired = false;
            }

            if (CaesarCheckBox.Checked)
            {
                isCaesarDesired = true;
            }
            else
            {
                isCaesarDesired = false;
            }

            if (ScipioChekbox.Checked)
            {
                isScipioDesired = true;
            }
            else
            {
                isScipioDesired = false;
            }

            //GRECE
            if (CynaneChekBox.Checked)
            {
                isCynane_Desired = true;
            }
            else
            {
                isScipioDesired = false;
            }

            //BARBARIAN



            //CARTHAGE
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            ss += 1;

            if (ss >= 60)
            {
                ss = 0;
                mm += 1;
            }
            if (mm >= 60)
            {
                mm = 0;
                hh += 1;
            }
            if (hh >= 24)
            {
                hh = 0;
            }

            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }



            ElapsedTime.Text = time;




        }
        private void showStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aZERTYToolStripMenuItem.CheckOnClick = true;
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CheckFaction()
        {
            string faction = FactionComboBox.Text;

            if (faction == Factions.Roman.ToString())
            {
                SetFaction(Factions.Roman);
            }
            if (faction == Factions.Greece.ToString())
            {
                SetFaction(Factions.Greece);
            }
            if (faction == Factions.Barbarian.ToString())
            {
                SetFaction(Factions.Barbarian);
            }
            if (faction == Factions.Carthage.ToString())
            {
                SetFaction(Factions.Carthage);
            }
        }
        private void SetFaction(Factions p_faction)
        {
            if (p_faction == Factions.Roman)
            {
                RomanPanel.Visible = true;
            }
            else
            {
                RomanPanel.Visible = false;
            }

            if (p_faction == Factions.Greece)
            {
                GreecePanel.Visible = true;
                factions = Factions.Greece;
            }
            else
            {
                GreecePanel.Visible = false;
            }

            if (p_faction == Factions.Barbarian)
            {
                BarbarianPanel.Visible = true;
            }
            else
            {
                BarbarianPanel.Visible = false;
            }

            if (p_faction == Factions.Carthage)
            {
                CarthagePanel.Visible = true;
            }
            else
            {
                CarthagePanel.Visible = false;
            }
        }
        private void FactionComboBox_DropDownClosed(object sender, EventArgs e)
        {
            CheckFaction();
        }
        private void FactionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFaction();
        }
        private void aZERTYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (aZERTYToolStripMenuItem.Checked)
            {
                is_azerty = true;
                is_qwerty = false;
                qWERTYToolStripMenuItem.Checked = false;
            }
            else
            {
                is_azerty = false;
                is_qwerty = true;
                qWERTYToolStripMenuItem.Checked = true;
            }

        }
        private void qWERTYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (qWERTYToolStripMenuItem.Checked)
            {
                is_qwerty = true;
                is_azerty = false;
                aZERTYToolStripMenuItem.Checked = false;
            }
            else
            {
                is_qwerty = false;
                is_azerty = true;
                aZERTYToolStripMenuItem.Checked = true;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void ScrollInLateralMenu()
        //{
        //    MultiSearchImage(ScrollButton, 20, out Point ScrollPoint, "ScrollButton");

        //    Point DownPoint = new Point(ScrollPoint.X, ScrollPoint.Y + 200);
        //    Point UpPoint = new Point(ScrollPoint.X, ScrollPoint.Y - 200);
        //    Size winsize = bot.GetWindowSize(gameHandle);

        //    float PositionOnScreenRatio = ((float)ScrollPoint.Y / (float)winsize.Height);

        //    if (PositionOnScreenRatio > 0.6)
        //    {
        //        bot.dragMouse(ScrollPoint, UpPoint, true);
        //    }

        //    if (PositionOnScreenRatio < 0.6)
        //    {
        //        bot.dragMouse(ScrollPoint, DownPoint, true);
        //    }
        //}


    }
}
