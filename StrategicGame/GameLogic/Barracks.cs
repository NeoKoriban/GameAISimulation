using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /**
     * Klasa zajmująca się obsługą koszar.
     * */
    public class Barracks
    {
        //Ilość żołnierzy w koszarach
        private int soldiersCount;
        //Ilość czołgów w koszarach
        private int tanksCount;
        //Ilość samolotów w koszarach
        private int aircraftCount;

        //Ilość wystawionych do walki żołnierzy
        private int soldiersToFight;
        //Ilość wystawionych do walki czołgów
        private int tanksToFight;
        //Ilość wystawionych do walki samolotów
        private int aircraftToFight;

        /**
         * Konstruktor bezargumentowy przypisujacy
         * domyślne wartości.
         * */
        public Barracks()
        {
            soldiersCount = 0;
            tanksCount = 0;
            aircraftCount = 0;

            soldiersToFight = 0;
            tanksToFight = 0;
            aircraftToFight = 0;
        }

        /**
        * Dodawanie do koszar nowozakupionych jednostek.
        * Argumenty:
        * string addItem - nazwa rodzaju wojska
        * int count - liczba jednostek 
        * */
        public void addToBarracks(string addItem, int count)
        {
            switch (addItem)
            {
                case "soldier":
                    soldiersCount += count;
                    break;
                case "tanks":
                    tanksCount += count;
                    break;

                case "aircraft":
                    aircraftCount += count;
                    break;
                default:
                    break;
            }
        }

        /**
         * Dodanie do walki jednostek
         * Argumenty:
         * string addItem - nazwa rodzaju jednostki
         * */
        public void addToFight(string addItem)
        {
            switch (addItem)
            {
                case "soldier":
                    if (soldiersCount > 0)
                    {
                        soldiersToFight++;
                        soldiersCount--;
                    }
                    break;
                case "tanks":
                    if (tanksCount > 0)
                    {
                        tanksToFight++;
                        tanksCount--;
                    }
                    break;
                case "aircraft":
                    if (aircraftCount > 0)
                    {
                        aircraftToFight++;
                        aircraftCount--;
                    }
                    break;
                default:
                    break;
            }
        }

        /**
         * Usuwanie jednostek wyznaczonych do walki.
         * Argumenty:
         * string addItem - nazwa rodzaju jednostki
         * */
        public void deleteToFight(string addItem)
        {
            switch (addItem)
            {
                case "soldier":
                    if (soldiersToFight > 0)
                    {
                        soldiersToFight--;
                        soldiersCount++;
                    }
                    break;
                case "tanks":
                    if (tanksToFight > 0)
                    {
                        tanksToFight--;
                        tanksCount++;
                    }
                    break;
                case "aircraft":
                    if (aircraftToFight > 0)
                    {
                        aircraftToFight--;
                        aircraftCount++;
                    }
                    break;
                default:
                    break;
            }
        }

        /**
         * Zwraca ilość żołnierzy w koszarach
         * */
        public int printSolidersCount()
        {
            return soldiersCount;
        }

        /**
         * Zwraca ilość czołgów w koszarach
         * */
        public int printTanksCount()
        {
            return tanksCount;
        }

        /**
         * Zwraca ilość samolotów w koszarach
         * */
        public int printAircraftCount()
        {
            return aircraftCount;
        }

        /**
         * Zwraca ilość żołnierzy wystawionych do walki
         * */
        public int printSolidersFight()
        {
            return soldiersToFight;
        }

        /**
         * Zwraca ilość czołgów wystawionych do walki
         * */
        public int printTanksFight()
        {
            return tanksToFight;
        }
        
        /**
         * Zwraca ilość samolotów wystawionych do walki 
         * */
        public int printAircraftFight()
        {
            return aircraftToFight;
        }

        /**
         * Reset wartości w koszarach
         * */
        public void resetBarracks()
        {
            soldiersCount = 0;
            tanksCount = 0;
            aircraftCount = 0;

            soldiersToFight = 0;
            tanksToFight = 0;
            aircraftToFight = 0;
        }
    }
}
