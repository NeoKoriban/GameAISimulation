using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /**
     * Klasa odpowiadająca za listę obiektów biorących udział w bitwie.
     * 
     * */
    public class BattleSources
    {
        //Lista obiektów do walki
        private List<BattleObject> fighterList;
        
        /**
         * Konstruktor argumentowy tworzący obiekty do walki.
         * Argumenty:
         * 
         * int soldierCount - liczba piechoty wystawiona do walki
         * int tanksCount - liczba czołgów wystatwionych do walki
         * int aircraftCount - liczba samolotów wystawionych do walki
         * 
         */
        public BattleSources(int soldierCount, int tanksCount, int aircraftCount)
        {
            fighterList = new List<BattleObject>();
            for (int i = 0; i < soldierCount; i++)
            {
                fighterList.Add(new BattleObject(1, 2, "soldier"));
            }    
            for (int i = 0; i < tanksCount; i++)
            {
                fighterList.Add(new BattleObject(4, 5, "tank"));
            }
            for (int i = 0; i < aircraftCount; i++)
            {
                fighterList.Add(new BattleObject(10, 20, "aircraft"));
            }
        }       
        
        //Zwraca liczbę jednostek o danej nazwie
        public int armyUnitCount(string name)
        {
            int counterFighter = 0;
            for(int i = 0; i < fighterList.Count(); i++)
            {
                if (fighterList[i].identityValue.Equals(name))
                    counterFighter++;
            }
            return counterFighter;
        }

        /**
         * Zwracanie listy obiektów
         * 
         * */
        public List<BattleObject> returnList
        {
            set
            {
                fighterList = value;
            }
            get
            {
                return fighterList;
            }
        }

        /**
         * Zwrot wartości siły rażenia
         * */
        public int returnFire ()
        {
            int summaryFire = 0;
            for (int i = 0; i < fighterList.Count; i++)
            {
                summaryFire += fighterList[i].fireValue;
            }
            return summaryFire;
        }

       
    }
}
