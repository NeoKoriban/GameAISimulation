using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /**
     * Klasa odpowiedzialna za przygotowanie zestawu danych do zapisu do pliku
     * 
     * */
    public class Stats
    {
        //Liczba żołnierzy wystawionych do walki
        private int SoldierFight;
        //Liczba ocalałych żołnierzy 
        private int SoldierSurvive;
        //Liczba czołgów wystawionych do walki
        private int TankFight;
        //Liczba ocalałych czołgów 
        private int TankSurvive;
        //Liczba samolotów wystawionych do walki
        private int AircraftFight;
        //Liczba ocalałych samolotów 
        private int AircraftSurvive;

        /**
         * Konstruktor argumentowy przyjmujący jako argumenty wartości wystawionych jednostek do walki.
         * Argumenty:
         * int SolFight - liczba piechoty
         * int TanFight - liczba czołgów
         * int ArcFight - liczba samolotów
         * */
        public Stats(int SolFight, int TanFight, int ArcFight)
        {
            SoldierFight = SolFight;
            TankFight = TanFight;
            AircraftFight = ArcFight;

            SoldierSurvive = 0;
            TankSurvive = 0;
            AircraftSurvive = 0;
        }

        /**
         * Zwraca i przyjmuje wartośc ocalałych jednostek piechoty
         * */
        public int soldierSurvived
        {
            get
            {
                return SoldierSurvive;
            }
            set
            {
                SoldierSurvive = value;
            }
        }

        /**
         * Zwraca i przyjmuje wartość jednostek pancernych ocalałych
         * 
         * */
        public int tankSurvive
        {
            get
            {
                return TankSurvive;
            }
            set
            {
                TankSurvive = value;
            }
        }

        /**
         * Przyjmuje i zwraca wartość ocalałych jednostek lotniczych
         * 
         * */
        public int aircraftSurvive
        {
            get
            {
                return AircraftSurvive;
            }
            set
            {
                AircraftSurvive = value;
            }
        }

        //Zwraca wartość piechoty wystawionej do walki
        public int soldierFight()
        {
            return SoldierFight;
        }

        //Zwraca wartość pancernych jednostek wystawionych do walki
        public int tankFight()
        {
            return TankFight;
        }

        //Zwraca wartośc jednostek lotniczych wystawionych do walki
        public int aircraftFight()
        {
            return AircraftFight;
        }
    }
}
