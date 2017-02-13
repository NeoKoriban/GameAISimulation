using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    /**
     * Klasa tworząca element listy wyników
     * 
     * */
    public class ResultListItem
    {
        //Liczba jednostek piechoty
        private int soldierCount;
        //Liczba jednostek czołgów
        private int tankCount;
        //Liczba jednostek samolotów
        private int aircraftCount;

        //Liczba jednostek piechoty
        private int soldierSurvive;
        //Liczba jednostek czołgów
        private int tankSurvive;
        //Liczba jednostek samolotów
        private int aircraftSurvive;
        //Siła ognia
        private int fireSummary;

        //Liczba jednostek SI
        private string artificalIntelligenceCount;

        /**
         * Konstruktor klasy przyjmujący za argumenty liczby jednostek.
         * int solCount - liczba piechoty
         * int tanCount - liczba czołgów
         * int arcCount - liczba samolotów
         * string aiCount - liczba jednostek SI
         * */
        public ResultListItem(int solCount, int tanCount, int arcCount, int solSurvive, int tanSurvive, int arcSurvive, int fSummary, string aiCount)
        {
            soldierCount = solCount;
            tankCount = tanCount;
            aircraftCount = arcCount;
            soldierSurvive = solSurvive;
            tankSurvive = tanSurvive;
            aircraftSurvive = arcSurvive;
            fireSummary = fSummary;
            artificalIntelligenceCount = aiCount;
        }
        public ResultListItem(int solCount, int tanCount, int arcCount, int solSurvive, int tanSurvive, int arcSurvive, string aiCount)
        {
            soldierCount = solCount;
            tankCount = tanCount;
            aircraftCount = arcCount;
            soldierSurvive = solSurvive;
            tankSurvive = tanSurvive;
            aircraftSurvive = arcSurvive;
;
            artificalIntelligenceCount = aiCount;
        }
        //Zwraca liczbę jednostek piechoty
        public int solider()
        {
            return soldierCount;
        }

        //Zwraca liczbę jednostek czołgów
        public int tank()
        {
            return tankCount;
        }

        //Zwraca liczbę jednostek samolotów
        public int aircraft()
        {
            return aircraftCount;
        }

        //Zwraca liczbę jednostek ocalałych
        public int soliderSurvived()
        {
            return soldierSurvive;
        }

        //Zwraca liczbę jednostek czołgów
        public int tankSurvived()
        {
            return tankSurvive;
        }

        //Zwraca liczbę jednostek samolotów
        public int aircraftSurvived()
        {
            return aircraftSurvive;
        }

        //Zwraca siłę ognia
        public int fireSummaryReturn()
        {
            return fireSummary;
        }

        //Zwraca liczbę jednostek SI
        public string ai()
        {
            return artificalIntelligenceCount;
        }
    }
}
