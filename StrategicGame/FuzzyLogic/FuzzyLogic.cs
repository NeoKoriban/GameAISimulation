using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic
{
    /**
     * Klasa odpowiedzialna za logikę rozmytą.
     * 
     * */
    public class FuzzyLogic
    {
        //Lista atrybutów zawierająca listę wartości dla atrybutu
        private List<List<int>> attributesList;
        //Lista nazw rozwiązań
        private List<string> nameResult;
        //Liczba piechoty
        private int soldierCount;
        //Liczba czołgów
        private int tankCount;
        //Liczba samolotów
        private int aircraftCount;
        //Wartość siły ognia
        private int fireCount;
        //Lista list wartości przynależności do zbioru konkrentych wartości atrybutów
        private List<List<double>> listValues;
        //Lista wartości przynależności do zbioru dla wartości klas
        private List<double> fuzzyClassValue;

        public string attributeListReturn()
        {
            string attributesValues = "  SoliderCount\t  TankCount\t  AircraftCount\t  FireSummary\t  SoldierSurvive\t  TankSurvive\t  AircraftSurvive\t  DecisionClass\t\n";
           
            for (int i = 0; i < attributesList[0].Count; i++)
            {
                for (int j = 0; j < attributesList.Count; j++)
                {
                    attributesValues += String.Format("{0,-5}\t{1,5:N3}\t",attributesList[j][i].ToString() ,listValues[j][i]);
              
                }
                attributesValues += String.Format("{0,-20}\t{1,5:N3}\t",nameResult[i].ToString() , fuzzyClassValue[i]);

                attributesValues += "\n" ;
            }

            return attributesValues;
        }

        /**
         * Konstruktor argumentowy logiki rozmytej.
         * 
         * Argumenty:
         * int soldierValue - liczba piechoty
         * int tankValue - liczba czołgów
         * int aircraftValue - liczba samolotów
         * int fireValue - wartość siły ognia
         * 
         * */
        public FuzzyLogic(int soldierValue, int tankValue, int aircraftValue, int fireValue)
        {
            soldierCount = soldierValue;
            tankCount = tankValue;
            aircraftCount = aircraftValue;
            fireCount = fireValue;
            attributesList = new List<List<int>>();
            nameResult = new List<string>();
            listValues = new List<List<double>>();
            fuzzyClassValue = new List<double>();
        }

        /**
         * Odczytywanie wartości z plików.
         * 
         * Argumenty:
         * string directoryName - nazwa folderu, gdzie są zapisane wyniki
         * */
        public bool readFromFile(string directoryName)
        {
            for (int i = 0; i < 7; i++)
            {
                List<int> newListAttributes = new List<int>();
                attributesList.Add(newListAttributes);
                List<double> newListValues = new List<double>();
                listValues.Add(newListValues);
            }

            string[] filesName = Directory.GetFiles(directoryName);
            if (!filesName.Length.Equals(0))
            {
                for (int i = 0; i < filesName.Length; i++)
                {
                    using (StreamReader streamReader = File.OpenText(filesName[i]))
                    {
                        if (streamReader.ReadLine().Equals("AI")) // gdy AI wygrywa z graczem
                        {
                            int soldierPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy Gracza
                            int tankPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów Gracza
                            int aircraftPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów Gracza

                            streamReader.ReadLine(); // Liczba żołnierzy Gracza które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba czołgów Gracza które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba samolotów Gracza które przetrwały (jeśli przegrał to 0)
                            int firePlayerSummary = Convert.ToInt32(streamReader.ReadLine()); // Wartość siły ognia całej armii Gracza

                            int soldierAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy AI
                            int tankAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów AI
                            int aircraftAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów AI
                            int soldierAIKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy którzy polegli
                            int tankAIKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów które zniszczono
                            int aircraftAIKilled =  Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów które zniszczono
                            streamReader.ReadLine();  // Wartość siły ognia całej armii AI                       

                            string aiCount = "";
                            if (soldierAICount > 0)
                                aiCount += "Soldier";
                            if (tankAICount > 0)
                                aiCount += "Tank";
                            if (aircraftAICount > 0)
                                aiCount += "Aircraft";

                            attributesList[0].Add(soldierCount);
                            listValues[0].Add(0.0);
                            attributesList[1].Add(tankPlayerCount);
                            listValues[1].Add(0.0);
                            attributesList[2].Add(aircraftPlayerCount);
                            listValues[2].Add(0.0);
                            attributesList[3].Add(firePlayerSummary);
                            listValues[3].Add(0.0);
                            attributesList[4].Add(soldierAIKilled);
                            listValues[4].Add(0.0);
                            attributesList[5].Add(tankAIKilled);
                            listValues[5].Add(0.0);
                            attributesList[6].Add(aircraftAIKilled);
                            listValues[6].Add(0.0);
                            nameResult.Add(aiCount);
                        }
                        else
                        {
                            int soldierPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy Gracza
                            int tankPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów Gracza
                            int aircraftPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów Gracza
                            int soldierPlayerKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy którzy polegli
                            int tankPlayerKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów które zniszczono
                            int aircraftPlayerKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów które zniszczono
                            int firePlayer = Convert.ToInt32(streamReader.ReadLine());  // Wartość siły ognia całej armii Gracza                      

                            int soldierAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy AI
                            int tankAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów AI
                            int aircraftAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów AI

                            streamReader.ReadLine(); // Liczba żołnierzy AI które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba czołgów AI które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba samolotów AI które przetrwały (jeśli przegrał to 0)
                            int fireAISummary = Convert.ToInt32(streamReader.ReadLine()); // Wartość siły ognia całej armii AI

                            string aiCount = "";
                            if (soldierPlayerCount > 0)
                                aiCount += "Soldier";
                            if (tankPlayerCount > 0)
                                aiCount += "Tank";
                            if (aircraftPlayerCount > 0)
                                aiCount += "Aircraft";

                            attributesList[0].Add(soldierAICount);
                            listValues[0].Add(0.0);
                            attributesList[1].Add(tankAICount);
                            listValues[1].Add(0.0);
                            attributesList[2].Add(aircraftAICount);
                            listValues[2].Add(0.0);
                            attributesList[3].Add(fireAISummary);
                            listValues[3].Add(0.0);
                            attributesList[4].Add(soldierPlayerKilled);
                            listValues[4].Add(0.0);
                            attributesList[5].Add(tankPlayerKilled);
                            listValues[5].Add(0.0);
                            attributesList[6].Add(aircraftPlayerKilled);
                            listValues[6].Add(0.0);
                            nameResult.Add(aiCount);
                        }
                    }
                }

                return true;
            }
            else
                return false;

        }
   
        
        /**
         * Funkcja inicjująca operacje logiki rozmytej zwracająca decyzję.
         * 
         * */
        public string doFuzzyLogic(bool firstMax)
        {
            Operations operations = new Operations(soldierCount, tankCount, aircraftCount, fireCount);
            operations.fuzzyfication(attributesList,listValues);
            operations.interferention(fuzzyClassValue);
            return operations.defuzzyfication(nameResult,firstMax);
        }

    }
}
