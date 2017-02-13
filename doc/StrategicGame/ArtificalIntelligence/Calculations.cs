using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    /**
     * Klasa odpowiedzialna za obliczenia w drzewie decyzyjnym.
     * 
     * */
    public class Calculations
    {
        private double entropy = 0.0;

        /**
         * Funkcja licząca entropię dla danego zbioru.
         * Przyjmuje listę klas jako argument. Zwraca entropię.
         * 
         * Argumenty: 
         * List<int> aiClassDetection - lista klas
         * */
        public double makeEntropy(List<int> aiClassDetection)
        {
            for (int i = 0; i < aiClassDetection.Count; i++)
            {
                double probability = Convert.ToDouble(aiClassDetection[i]) / Convert.ToDouble(aiClassDetection.Sum());
                entropy -= probability * (Math.Log(probability, 2.0));
            }
            return entropy;
        }
    }
}
