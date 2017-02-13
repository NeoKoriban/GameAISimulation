using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /**
     * Klasa tworząca obiekt jednostki do walki.
     * 
     * */
    public class BattleObject
    {
        // rodzaj jednostki
        private string identity;
        // punkty wytrzymałości
        private int life;
        // punkty ognia
        private int fire;

        /**
         * Konstruktor argumentowy tworzący obiekt.
         * 
         * Argumenty:
         * int lifeObj - liczba punktów życia
         * int fireObj - liczba punktów siły ognia
         * string name - nazwa obiektu
         * 
         * */
        public BattleObject(int lifeObj, int fireObj, string name)
        {
            life = lifeObj;
            fire = fireObj;
            identity = name;
        }

        /**
         * Zwraca wartość lub przyjmuje wartość jednostki.
         * */
        public string identityValue
        {
            set
            {
                identity = value;
            }
            get
            {
                return identity;
            }
        }

        /**
         * Przyjmuje lub zwraca wartość punktów życia
         * */
        public int lifeValue
        {
            set
            {
                life = value;
            }
            get
            {
                return life;
            }
        }

        /**
         * Przyjmuje lub zwraca wartość punktów ognia
         * */
        public int fireValue
        {
            set
            {
                fire = value;
            }
            get
            {
                return fire;
            }
        }


    }

}
