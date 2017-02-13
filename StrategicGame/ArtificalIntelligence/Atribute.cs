using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    /**
     * Klasa tworząca atrybut dla drzewa decyzyjnego.
     * 
     * */
    public class Atribute<T> 
    {
        //Nazwa atrybutu
        private string attributeName;
        //Lista wartości atrybutu
        private List<T> valuesList;
        //Lista zysków informacji dla wartości atrybutu
        private List<double> valueGain;
        //Lista nazw klas dla atrybutów
        private List<string> className;
        //Zysk informacji dla całego atrybutu
        private double attributeGain = 0.0;

        /**
         * Konstruktor argumentowy tworzący obiekt atrybutu.
         * Argumenty:
         * List<T> values - lista wartości
         * string name - nazwa atrybutu
         * List<string> classN - lista nazw klas
         * */
        public Atribute(List<T> values, string name, List<string> classN)
        {
            valuesList = values;
            attributeName = name;
            className = classN;
        }
        public int uniqueClassCount()
        {
            int uClassCount = 0;
            List<string> uniqueClass = new List<string>();
            for (int i = 0; i < className.Count; i++)
            {
                if (!uniqueClass.Contains(className[i]))
                {
                    uniqueClass.Add(className[i]);
                    uClassCount++;
                }
            }
            return uClassCount;
        }
        /**
         * Zwraca element listy dla danego atrybutu który ma największy zysk informacji.
         * */
        public T returnMaxGainValue()
        {
            List<T> tmpValue = valuesList;
            tmpValue.Sort();
            int indexMedianValue = Convert.ToInt32(tmpValue.Count / 2);

            if (!(tmpValue.Count % 2).Equals(0))
            { //  return tmpValue[indexMedianValue];
            }
            else
            {
                // return (T)(object)Convert.ToInt32((Int32.Parse(tmpValue[indexMedianValue].ToString()) + Int32.Parse(tmpValue[indexMedianValue].ToString())) / 2);


            }
             return valuesList[valueGain.IndexOf(valueGain.Min())];
        }

        /**
         * Zwraca nazwę klasy dla wartości atrybutu o największym zysku informacji.
         * */
        public string returnMaxGainClass()
        {
            return className[valueGain.IndexOf(valueGain.Min())];
        }

        /**
         * Zwraca nazwę atrybutu
         * 
         * */
        public string returnNameAttribute()
        {
            return attributeName;
        }

        
        /**
         * Funkcja obliczająca zysk informacji dla atrybutu.
         * Argumenty:
         * double entropy - entropia zbioru wartości
         * List<string> classList - lista klas
         * 
         * */
        public double atributeGain(double entropy, List<string> classList)
        {
            valueGain = new List<double>();
            List<double> valueGainArchive = new List<double>(); 
            double entropyAttribute = 0.0;
            List<T> valueArchive = new List<T>();


            for (int i = 0; i < valuesList.Count; i++)
            {
                valueGain.Add(0.0);
            }

            
            for (int i = 0; i < valuesList.Count; i++)
            {
                if (!valueArchive.Contains(valuesList[i]))
                {

                    valueArchive.Add(valuesList[i]);

                    List<string> valueClassDetection = new List<string>();
                    for (int j = 0; j < valuesList.Count; j++)
                    {
                        if (valuesList[j].Equals(valuesList[i]))
                        {
                            valueClassDetection.Add(className[j]);

                        }
                    }

                    List<string> aiClassDetection = new List<string>();
                    List<int> aiClassDetectionCount = new List<int>();

                    for (int j = 0; j < valueClassDetection.Count; j++)
                    {
                        if (aiClassDetection.Contains(valueClassDetection[j]))
                            aiClassDetectionCount[aiClassDetection.IndexOf(valueClassDetection[j])]++;
                        else
                        {
                            aiClassDetection.Add(valueClassDetection[j]);
                            aiClassDetectionCount.Add(1);
                        }
                    }
                    Calculations calc = new Calculations();
                    entropyAttribute += calc.makeEntropy(aiClassDetectionCount) * (Convert.ToDouble(aiClassDetectionCount.Sum()) / Convert.ToDouble(valuesList.Count));


                    valueGainArchive.Add(calc.makeEntropy(aiClassDetectionCount) * (Convert.ToDouble(aiClassDetectionCount.Sum()) / Convert.ToDouble(valuesList.Count)));
                    
                    
                }                

            }

            for (int i = 0; i < valuesList.Count; i++)
            {
                valueGain[i] = valueGainArchive[valueArchive.IndexOf(valuesList[i])];
            }
            attributeGain = entropy - entropyAttribute;
            return attributeGain;
        }

        /**
         * Metoda obliczająca podział zbioru wartości dla danego atrybutu i
         * zwracająca tą wartość.
         * 
         * Argumenty:
         * List<string> classList - przyjmuje jako argument listę klas.
         * 
         * */
        public double atributeSplit(List<string> classList)
        {
            double splitAttribute = 0.0;
            List<T> valueDetection = new List<T>();
            List<int> valueDetectionCount = new List<int>();
            for (int i = 0; i < valuesList.Count; i++)
            {
                if (valueDetection.Contains(valuesList[i]))
                    valueDetectionCount[valueDetection.IndexOf(valuesList[i])]++;
                else
                {
                    valueDetection.Add(valuesList[i]);
                    valueDetectionCount.Add(1);
                }
            }
            Calculations calc = new Calculations();
            splitAttribute = calc.makeEntropy(valueDetectionCount);

            return splitAttribute;
        }

        /**
         * Zwraca listę wartości atrybutu
         * */
        public List<T> atributeValueReturn()
        {
            return valuesList;
        }
    }
}
