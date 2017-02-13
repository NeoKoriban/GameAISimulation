using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /**
     * 
     * Klasa odpowiedzialna za system walki
     * 
     * */
    public class FightSystem
    {
        //Lista jednostek AI
        private List<BattleObject> enemyList;

        //Lista jednostek Gracza
        private List<BattleObject> playerList;

        /**
         * Konstruktor bezargumentowy tworzący system walki.
         * 
         * */
        public FightSystem()
        {
            enemyList = new List<BattleObject>();
            playerList = new List<BattleObject>();
        }

        /**
         * Konstruktor argumentowy tworzący system walki.
         * 
         * Argumenty:
         * 
         * List<BattleObject> pList - lista obiektów gracza
         * List<BattleObject> eList - lista obiektów wroga
         * */
        public FightSystem(List<BattleObject> pList, List<BattleObject> eList)
        {
            playerList = pList;
            enemyList = eList;
        }

        /**
         * Funkcja odpowiedzialna za atak.
         * Argumenty:
         * List<BattleObject> attacked - lista obiektów atakowanych
         * List<BattleObject> attacking - lista obiektów atakujących
         * */
        private void attack(List<BattleObject> attacked, List<BattleObject> attacking)
        {
            int attackingFire = 0;

            if (attacking.Count != 0)
                attackingFire = attacking[0].fireValue;

            if (attacked.Count() != 0)
            {
                attacked[0].lifeValue -= attackingFire;
                if (attacked[0].lifeValue < 0)
                {
                    attacked.RemoveAt(0);
                }
            }
        }

        //Funkcja odpowiedzialna za walkę
        public void fight()
        {
            int enemyFire = 0;
            int playerFire = 0;

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyFire += enemyList[i].fireValue;
            }
            for (int i = 0; i < playerList.Count; i++)
            {
                playerFire += playerList[i].fireValue;
            }

            while (enemyList.Count() != 0 && playerList.Count() != 0)
            {
            
                if(playerFire >= enemyFire)
                {
                    attack(enemyList, playerList);
                    attack(playerList, enemyList);
                }
                else
                {
                    attack(playerList, enemyList);
                    attack(enemyList, playerList);
                }

            }
        }

        
    }
}
