using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;
using DecisionTree;
using FuzzyLogic;
using System.Diagnostics;

namespace StrategicGame
{
    public partial class StrategicGame : Form
    {
        public StrategicGame()
        {
            InitializeComponent();
        
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private int minutes;
        private int second;
        private string saveTime;
        private Shop shop;
        private Barracks barracks;
        private DecisionTree.DecisionTree decisionTree;
        private FuzzyLogic.FuzzyLogic fuzzyLogic;

        private void resetSettings()
        {
            barrackGroup.Enabled = false;
            barracks.resetBarracks();
            tanksTextbox.Text = shop.printTanksBuy().ToString();
            soldiersTextbox.Text = shop.printTanksBuy().ToString();
            aircraftTextbox.Text = shop.printAircraftBuy().ToString();

            soldiersCountTextBox.Text = barracks.printSolidersCount().ToString();
            tanksCountTextBox.Text = barracks.printTanksCount().ToString();
            aircraftCountTextBox.Text = barracks.printAircraftCount().ToString();

            fightSolCountTextBox.Text = barracks.printSolidersFight().ToString();
            fightTanCountTextBox.Text = barracks.printTanksFight().ToString();
            fightArcCountTextBox.Text = barracks.printAircraftFight().ToString();

            soldierPlayerTextbox.ResetText();
            tanksPlayerTextbox.ResetText();
            aircraftPlayerTextbox.ResetText();

            TimeLabel.Text = "00:00";
            startButton.Enabled = false;
            shopGroup.Enabled = false;
            shop.resetShop();

            moneyLabel.Text = shop.printWallet().ToString() + " $";
        }

        private void threeMinutesItem_Click(object sender, EventArgs e)
        {
            TimeLabel.Text = "03:00";
            saveTime = "3minutes";
            startButton.Enabled = true;
        }
        private void fiveMinutesItem_Click(object sender, EventArgs e)
        {
            TimeLabel.Text = "05:00";
            saveTime = "5minutes";
            startButton.Enabled = true;
        }

        private void tenMinutesItem_Click(object sender, EventArgs e)
        {
            TimeLabel.Text = "10:00";
            saveTime = "10minutes";
            startButton.Enabled = true;
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {

            second = second - 1;
            if (second.Equals(-1))
            {
                minutes--;
                second = 59;
            }
            if (minutes.Equals(0) && second.Equals(0))
            {
                startButton.Enabled = false;
                shopGroup.Enabled = false;
                barrackGroup.Enabled = true;
                MoneyTimer.Stop();
                GameTimer.Stop();
            }
            TimeLabel.Text = minutes.ToString("00") + ":" + second.ToString("00");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string[] time = TimeLabel.Text.Split(':');
            minutes = Convert.ToInt32(time[0]);
            second = Convert.ToInt32(time[1]);

            shop = new Shop();
            shop.startShop();
            barracks = new Barracks();
            ResetButton.Enabled = true;
            resetSettings();
            shopGroup.Enabled = true;
            moneyLabel.Text = shop.printWallet() + "$";
            GameTimer.Start();
            MoneyTimer.Start();
        }

        private void ssplusbutton_Click(object sender, EventArgs e)
        {
            soldiersTextbox.Text = shop.addBuy("soldier").ToString();
        }

        private void ssminusbutton_Click(object sender, EventArgs e)
        {
            soldiersTextbox.Text = shop.deleteBuy("soldier").ToString();
        }

        private void tsplusbutton_Click(object sender, EventArgs e)
        {
            tanksTextbox.Text = shop.addBuy("tanks").ToString();
        }

        private void tsminusbutton_Click(object sender, EventArgs e)
        {
            tanksTextbox.Text = shop.deleteBuy("tanks").ToString();
        }

        private void acplusbutton_Click(object sender, EventArgs e)
        {
            aircraftTextbox.Text = shop.addBuy("aircraft").ToString();
        }

        private void acminusbutton_Click(object sender, EventArgs e)
        {
            aircraftTextbox.Text = shop.deleteBuy("aircraft").ToString();
        }

        private void MoneyTimer_Tick(object sender, EventArgs e)
        {
            shop.addMoney();
            moneyLabel.Text = shop.printWallet() + "$";
        }

        private void buySoldierButton_Click(object sender, EventArgs e)
        {

            if (shop.buyWallet("soldier").Equals(true))
            {
                moneyLabel.Text = shop.printWallet() + "$";
                barracks.addToBarracks("soldier", Convert.ToInt32(soldiersTextbox.Text.ToString()));
                soldiersCountTextBox.Text = barracks.printSolidersCount().ToString();
                soldiersTextbox.Text = shop.printSoldierBuy().ToString();
            }
        }

        private void buyTanksButton_Click(object sender, EventArgs e)
        {
            if (shop.buyWallet("tanks").Equals(true))
            {
                moneyLabel.Text = shop.printWallet() + "$";
                barracks.addToBarracks("tanks", Convert.ToInt32(tanksTextbox.Text.ToString()));
                tanksCountTextBox.Text = barracks.printTanksCount().ToString();
                tanksTextbox.Text = shop.printTanksBuy().ToString();
            }
        }

        private void buyAircraftButton_Click(object sender, EventArgs e)
        {
            if (shop.buyWallet("aircraft").Equals(true))
            {
                moneyLabel.Text = shop.printWallet() + "$";
                barracks.addToBarracks("aircraft", Convert.ToInt32(aircraftTextbox.Text.ToString()));
                aircraftCountTextBox.Text = barracks.printAircraftCount().ToString();
                aircraftTextbox.Text = shop.printAircraftBuy().ToString();
            }
        }

        private void plusFightSolButton_Click(object sender, EventArgs e)
        {
            barracks.addToFight("soldier");
            soldiersCountTextBox.Text = barracks.printSolidersCount().ToString();
            fightSolCountTextBox.Text = barracks.printSolidersFight().ToString();
        }

        private void minusFightSolButton_Click(object sender, EventArgs e)
        {
            barracks.deleteToFight("soldier");
            soldiersCountTextBox.Text = barracks.printSolidersCount().ToString();
            fightSolCountTextBox.Text = barracks.printSolidersFight().ToString();
        }

        private void plusFightTanButton_Click(object sender, EventArgs e)
        {
            barracks.addToFight("tanks");
            tanksCountTextBox.Text = barracks.printTanksCount().ToString();
            fightTanCountTextBox.Text = barracks.printTanksFight().ToString();

        }

        private void minusFightTanButton_Click(object sender, EventArgs e)
        {
            barracks.deleteToFight("tanks");
            tanksCountTextBox.Text = barracks.printTanksCount().ToString();
            fightTanCountTextBox.Text = barracks.printTanksFight().ToString();

        }

        private void plusFightArcButton_Click(object sender, EventArgs e)
        {
            barracks.addToFight("aircraft");
            aircraftCountTextBox.Text = barracks.printAircraftCount().ToString();
            fightArcCountTextBox.Text = barracks.printAircraftFight().ToString();

        }

        private void minusFightArcButton_Click(object sender, EventArgs e)
        {
            barracks.deleteToFight("aircraft");
            aircraftCountTextBox.Text = barracks.printAircraftCount().ToString();
            fightArcCountTextBox.Text = barracks.printAircraftFight().ToString();

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            MoneyTimer.Stop();
            resetSettings();
        }

        private void FightButton_Click(object sender, EventArgs e)
        {
            BattleSources battleSourcesPlayer = new BattleSources(barracks.printSolidersFight(), barracks.printTanksFight(), barracks.printAircraftFight());
            soldierPlayerTextbox.Text = barracks.printSolidersFight().ToString() + " / " + battleSourcesPlayer.armyUnitCount("soldier").ToString();
            tanksPlayerTextbox.Text = barracks.printTanksFight().ToString() + " / " + battleSourcesPlayer.armyUnitCount("tank").ToString();
            aircraftPlayerTextbox.Text = barracks.printAircraftFight().ToString() + " / " + battleSourcesPlayer.armyUnitCount("aircraft").ToString();
            Stats playerStats = new Stats(barracks.printSolidersFight(), barracks.printTanksFight(), barracks.printAircraftFight());

            Random randomSoldier = new Random();
            Random randomTank = new Random();
            Random randomAircraft = new Random();
            int randomSoldierCount = 0;
            int randomTanksCount = 0;
            int randomAircraftCount = 0;
            bool ifDo = false;
            decisionAlgorithmResult.Text = "Użyty algorytm: ";
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (initNumber.Equals(2) || initNumber.Equals(3))
            {
                decisionTree = new DecisionTree.DecisionTree();
                ifDo = decisionTree.readFiles(saveTime.ToString());
                decisionAlgorithmResult.Text += "Drzewo decyzyjne \n ";
            }
            else
            {
                fuzzyLogic = new FuzzyLogic.FuzzyLogic(barracks.printSolidersFight(), barracks.printTanksFight(), barracks.printAircraftFight(), battleSourcesPlayer.returnFire());
                ifDo = fuzzyLogic.readFromFile(saveTime.ToString());
                decisionAlgorithmResult.Text += "Logika rozmyta \n";
            }

            if (ifDo.Equals(false))
            {
                randomSoldierCount = randomSoldier.Next(Convert.ToInt32(0.75 * barracks.printSolidersFight()), Convert.ToInt32(1.25 * barracks.printSolidersFight()));
                randomTanksCount = randomSoldier.Next(Convert.ToInt32(0.75 * barracks.printTanksFight()), Convert.ToInt32(1.25 * barracks.printTanksFight()));
                randomAircraftCount = randomAircraft.Next(Convert.ToInt32(0.75 * barracks.printAircraftFight()), Convert.ToInt32(1.25 * barracks.printAircraftFight()));
            }
            else
            {
                
                string decisionString = "";
                if (initNumber.Equals(2))
                {
                    decisionString = decisionTree.doC4_5(barracks.printSolidersFight(), barracks.printTanksFight(), barracks.printAircraftFight(), true);
                    treeDecisionView.Visible = true;
                    treeDecisionView = decisionTree.returnDecisionTree(treeDecisionView);

                }
                else if (initNumber.Equals(3))
                {
                    decisionString = decisionTree.doC4_5(barracks.printSolidersFight(), barracks.printTanksFight(), barracks.printAircraftFight(), false);
                    treeDecisionView.Visible = true;
                    treeDecisionView = decisionTree.returnDecisionTree(treeDecisionView);

                }
                else if(initNumber.Equals(4))
                {
                    treeDecisionView.Visible = false;

                    decisionString = fuzzyLogic.doFuzzyLogic(false);
                    decisionAlgorithmResult.Text += fuzzyLogic.attributeListReturn();
                }
                else
                {
                    treeDecisionView.Visible = false;

                    decisionString = fuzzyLogic.doFuzzyLogic(true);
                    decisionAlgorithmResult.Text += fuzzyLogic.attributeListReturn();
                }
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                
                string elapsedTime = ts.Milliseconds.ToString() + " ms";
                decisionAlgorithmResult.Text += "Czas wykonania:" + elapsedTime;

                decisionLabel.Text = decisionString;
                if (decisionString.Equals("Soldier"))
                {
                    randomSoldierCount = randomSoldier.Next(Convert.ToInt32(0.75 * barracks.printSolidersFight()), Convert.ToInt32(1.25 * barracks.printSolidersFight())) + 1;
                }
                else if (decisionString.Equals("Tank"))
                {
                    randomTanksCount = randomSoldier.Next(Convert.ToInt32(0.75 * barracks.printTanksFight()), Convert.ToInt32(1.25 * barracks.printTanksFight())) + 1;
                }
                else if (decisionString.Equals("Aircraft"))
                {
                    randomAircraftCount = randomAircraft.Next(Convert.ToInt32(0.75 * barracks.printAircraftFight()), Convert.ToInt32(1.25 * barracks.printAircraftFight())) + 1;
                }
                else if (decisionString.Equals("SoldierTank"))
                {
                        randomSoldierCount = randomSoldier.Next(barracks.printSolidersFight(), 
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printSolidersFight()))) + 1;
                        randomTanksCount = randomTank.Next(barracks.printTanksFight(), 
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printTanksFight()))) + 1;                                      
                }
                else if (decisionString.Equals("SoldierAircraft"))
                {                   
                        randomSoldierCount = randomSoldier.Next(barracks.printSolidersFight(),
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printSolidersFight()))) + 1;
                        randomAircraftCount = randomAircraft.Next(barracks.printAircraftFight(),
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printAircraftFight()))) + 1;                    
                }
                else if (decisionString.Equals("TankAircraft"))
                {                 
                        randomTanksCount = randomTank.Next(barracks.printTanksFight(),
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printTanksFight()))) + 1;
                        randomAircraftCount = randomAircraft.Next(barracks.printAircraftFight(),
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printAircraftFight()))) + 1;                                  
                }
                else
                {
                    
                        randomSoldierCount = randomSoldier.Next(barracks.printSolidersFight(),
                               Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printSolidersFight()))) + 1;
                        randomTanksCount = randomTank.Next(barracks.printTanksFight(),
                          Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printTanksFight()))) + 1;
                        randomAircraftCount = randomAircraft.Next(barracks.printAircraftFight(),
                            Convert.ToInt32(1.25 * Convert.ToDouble(barracks.printAircraftFight()))) + 1;

                    
                }
            }
         
            
            BattleSources battleSourcesAI = new BattleSources(randomSoldierCount, randomTanksCount, randomAircraftCount);
            Stats aiStats = new Stats(randomSoldierCount, randomTanksCount, randomAircraftCount);



            soldierAITextbox.Text = randomSoldierCount.ToString() + " / " + battleSourcesAI.armyUnitCount("soldier").ToString();
            tanksAITextbox.Text = randomTanksCount.ToString() + " / " + battleSourcesAI.armyUnitCount("tank").ToString();
            aircraftAITextbox.Text = randomAircraftCount.ToString() + " / " + battleSourcesAI.armyUnitCount("aircraft").ToString();


            List<BattleObject> enemyList = battleSourcesAI.returnList;
            List<BattleObject> playerList = battleSourcesPlayer.returnList;

            FightSystem fightSystem = new FightSystem(playerList, enemyList);
            fightSystem.fight();

            battleSourcesPlayer.returnList = playerList;
            battleSourcesAI.returnList = enemyList;
            soldierPlayerTextbox.Text = barracks.printSolidersFight().ToString() + " / " + battleSourcesPlayer.armyUnitCount("soldier").ToString();
            tanksPlayerTextbox.Text = barracks.printTanksFight().ToString() + " / " + battleSourcesPlayer.armyUnitCount("tank").ToString();
            aircraftPlayerTextbox.Text = barracks.printAircraftFight().ToString() + " / " + battleSourcesPlayer.armyUnitCount("aircraft").ToString();

            playerStats.soldierSurvived = battleSourcesPlayer.armyUnitCount("soldier");
            playerStats.tankSurvive = battleSourcesPlayer.armyUnitCount("tank");
            playerStats.aircraftSurvive = battleSourcesPlayer.armyUnitCount("aircraft");

            soldierAITextbox.Text = randomSoldierCount.ToString() + " / " + battleSourcesAI.armyUnitCount("soldier").ToString();
            tanksAITextbox.Text = randomTanksCount.ToString() + " / " + battleSourcesAI.armyUnitCount("tank").ToString();
            aircraftAITextbox.Text = randomAircraftCount.ToString() + " / " + battleSourcesAI.armyUnitCount("aircraft").ToString();

            aiStats.soldierSurvived = battleSourcesAI.armyUnitCount("soldier");
            aiStats.tankSurvive = battleSourcesAI.armyUnitCount("tank");
            aiStats.aircraftSurvive = battleSourcesAI.armyUnitCount("aircraft");


            if (aiStats.soldierSurvived.Equals(0) && aiStats.tankSurvive.Equals(0) && aiStats.aircraftSurvive.Equals(0))
                decisionLabel.Text = "Wygrana";
            else
                decisionLabel.Text = "Przegrana";

            BattleResult resultSave = new BattleResult(playerStats, aiStats);
            resultSave.saveToFileResult(saveTime);
        }
        int initNumber = 0;
        private void logikaRozmytaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNumber = 1;
        }

        private void drzewoDecyzyjneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNumber = 2;

        }

        private void drzewoDecyzyjneBezSiłyOgniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNumber = 3;
        }

        private void drzewoDecyzyjneBezAtrybutówNumerycznychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNumber = 3;

        }

        private void logikaRozmytaOstatnieMaksimumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNumber = 4;
        }
    }
}
