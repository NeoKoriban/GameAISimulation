using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic
{
    /**
     * Klasa operacji logiki rozmytej
     * 
     * */
    public class Operations
    {
        //liczba piechoty
        private int soldierCount;
        //liczba czołgów
        private int tankCount;
        //liczba samolotów
        private int aircraftCount;
        //siła rażenia
        private int fireCount;
        //lista wartości przynależności do zbioru
        private List<List<double>> listValues;
        //lista wartości rozmywania dla każdej klasy
        private List<double> fuzzyClassValue;
        //lista nazw wyników
        private List<string> nameResult;

        /**
         * Konstruktor argumentowy.
         * Argumenty:
         * int solCount - liczba piechoty
         * int tanCount - liczba czołgów
         * int arcCount - liczba samolotów
         * int fCount - siła rażenia
         * */
        public Operations(int solCount, int tanCount, int arcCount, int fCount)
        {
            soldierCount = solCount;
            tankCount = tanCount;
            aircraftCount = arcCount;
            fireCount = fCount;
        }

        /**
         * Funkcja odpowiedzialna za rozmywanie.
         * 
         * Argumenty:
         * List<List<int>> attributesList - lista atrybutów dla których będzie badana przynależność do zbioru
         * List<List<double>> listVal - lista wartości przynależności do zbioru każdej wartości
         * */
        public void fuzzyfication(List<List<int>> attributesList, List<List<double>> listVal)
        {
            listValues = listVal;
            double valueToFuzzy = 0.0;

            for (int i = 0; i < attributesList[0].Count; i++)
            {
                for (int j = 0; j < attributesList.Count; j++)
                {
                    switch (j)
                    {
                        case 0: valueToFuzzy = Convert.ToDouble(soldierCount); break;
                        case 1: valueToFuzzy = Convert.ToDouble(tankCount); break;
                        case 2: valueToFuzzy = Convert.ToDouble(aircraftCount); break;
                        case 3: valueToFuzzy = Convert.ToDouble(fireCount); break;
                        case 4: valueToFuzzy = Convert.ToDouble(attributesList[j].Max()); break;
                        case 5: valueToFuzzy = Convert.ToDouble(attributesList[j].Max()); break;
                        case 6: valueToFuzzy = Convert.ToDouble(attributesList[j].Max()); break;
                    }

                    if (Convert.ToDouble(attributesList[j][i]) >= valueToFuzzy)
                        listValues[j][i] = 1.0;
                    else if (Convert.ToDouble(attributesList[j][i]) < Convert.ToDouble(attributesList[j].Min()))
                        listValues[j][i] = 0.0;
                    else
                    listValues[j][i] = (Convert.ToDouble(attributesList[j][i]) - Convert.ToDouble(attributesList[j].Min()))
                            / (valueToFuzzy - Convert.ToDouble(attributesList[j].Min()));
                   
                        
                }
            }
        }

        /**
         * Funkcja odpowiedzialna za wnioskowanie.
         * 
         * Argumenty:
         * 
         * List<double> fuzzyClassVal - lista wartości przynależności do zbioru rozwiązań dla każdej klasy.
         * */
        public void interferention(List<double> fuzzyClassVal)
        {
            fuzzyClassValue = fuzzyClassVal;

            for (int i = 0; i < listValues[0].Count; i++)
            {
                List<double> tmpListValues = new List<double>();
                double tmpMaxValue = 0.0;
                for (int j = 0; j < listValues.Count; j++)
                {

                    if (j > 3)
                    {
                        if (listValues[j][i] > tmpMaxValue)
                            tmpMaxValue = listValues[j][i];
                        if (j.Equals(6))
                        {
                            tmpListValues.Add(tmpMaxValue);
                            tmpMaxValue = 0.0;
                        }
                    }
                    else if (j < 3)
                    {
                        if (listValues[j][i] > tmpMaxValue)
                            tmpMaxValue = listValues[j][i];
                        if (j.Equals(2))
                        {
                            tmpListValues.Add(tmpMaxValue);
                            tmpMaxValue = 0.0;
                        }
                    }
                    else
                        tmpListValues.Add(listValues[j][i]);

                }
                fuzzyClassValue.Add(tmpListValues.Min());
            }
        }

        /**
        * Funkcja odpowiedzialna za wyostrzanie. Zwraca nazwę klasy, która ma największą przynależność do zbioru rozwiązań.
        * 
        * Argumenty:
        * List<string> nameRes - nazwa klas.
        * */
        public string defuzzyfication(List<string> nameRes, bool firstMax)
        {
            if (firstMax.Equals(true))
            {
                nameResult = nameRes;
                return nameResult[fuzzyClassValue.IndexOf(fuzzyClassValue.Max())];
            }
            else
            {
                nameResult = nameRes;
                int lastMaxIndex = 0;
                
                for(int i = 0; i < fuzzyClassValue.Count; i++)
                {
                    if(fuzzyClassValue[i] >= fuzzyClassValue[lastMaxIndex])
                    {
                        lastMaxIndex = i;
                    }                    
                }
                return nameResult[lastMaxIndex];
            }
        }
    }
}
