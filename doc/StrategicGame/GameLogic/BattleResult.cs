using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GameLogic
{
    /**
     * Klasa odpowiedzialna za zapis do pliku wyników gry.
     * */
    public class BattleResult
    {
        // wynik bitwy
        private string result;
        //saldo jednostek wystawionych i jednostek ocalałych Gracza
        private Stats playerStats;
        //saldo jednostek wystawionych i jednostek ocalałych AI
        private Stats aiStats;
      
        /**
         * Konstruktor argumentowych tworzący obiekt wyniku gry, który zostanie zapisany do pliku.
         * Argumenty:
         * Stats pStats - statystyki Gracza po bitwie
         * Stats aStats - statystyki AI po bitwie
         * */
        public BattleResult(Stats pStats, Stats aStats)
        {
            result = "";
            playerStats = pStats;
            aiStats = aStats;
        }
     
        /**
         * Funkcja zapisująca wynik do pliku
         * Argumenty:
         * string timeName - nazwa folderu do zapisu.
         * 
         * */   
        public void saveToFileResult(string timeName)
        {
            if (playerStats.soldierSurvived.Equals(0) &&
               playerStats.tankSurvive.Equals(0) &&
               playerStats.aircraftSurvive.Equals(0))
                result = "AI";
            else
                result = "Player";

            if(Directory.Exists(timeName))
            {
                int size = Directory.GetFiles(timeName).Length + 1;
                string pathString = System.IO.Path.Combine(timeName, "result"+size+".txt");
                using (StreamWriter streamWriter =File.CreateText(pathString))
                {
                    streamWriter.WriteLine(result);

                    streamWriter.WriteLine(playerStats.soldierFight());
                    streamWriter.WriteLine(playerStats.tankFight());
                    streamWriter.WriteLine(playerStats.aircraftFight());

                    streamWriter.WriteLine(playerStats.soldierSurvived);
                    streamWriter.WriteLine(playerStats.tankSurvive);
                    streamWriter.WriteLine(playerStats.aircraftSurvive);

                    streamWriter.WriteLine(playerStats.soldierFight() * 2 + playerStats.tankFight() * 5 + playerStats.aircraftFight() * 20);

                    streamWriter.WriteLine(aiStats.soldierFight());
                    streamWriter.WriteLine(aiStats.tankFight());
                    streamWriter.WriteLine(aiStats.aircraftFight());

                    streamWriter.WriteLine(aiStats.soldierSurvived);
                    streamWriter.WriteLine(aiStats.tankSurvive);
                    streamWriter.WriteLine(aiStats.aircraftSurvive);
                    streamWriter.WriteLine(aiStats.soldierFight() * 2 + aiStats.tankFight() * 5 + aiStats.aircraftFight() * 20);

                }
            }
            else
            {
                Directory.CreateDirectory(timeName);
                string pathString = System.IO.Path.Combine(timeName, "result1.txt");
                using (StreamWriter streamWriter = File.CreateText(pathString))
                {
                    streamWriter.WriteLine(result);

                    streamWriter.WriteLine(playerStats.soldierFight());
                    streamWriter.WriteLine(playerStats.tankFight());
                    streamWriter.WriteLine(playerStats.aircraftFight());

                    streamWriter.WriteLine(playerStats.soldierSurvived);
                    streamWriter.WriteLine(playerStats.tankSurvive);
                    streamWriter.WriteLine(playerStats.aircraftSurvive);
                    streamWriter.WriteLine(playerStats.soldierFight() * 2 + playerStats.tankFight() * 5 + playerStats.aircraftFight() * 20);

                    streamWriter.WriteLine(aiStats.soldierFight());
                    streamWriter.WriteLine(aiStats.tankFight());
                    streamWriter.WriteLine(aiStats.aircraftFight());

                    streamWriter.WriteLine(aiStats.soldierSurvived);
                    streamWriter.WriteLine(aiStats.tankSurvive);
                    streamWriter.WriteLine(aiStats.aircraftSurvive);
                    streamWriter.WriteLine(aiStats.soldierFight() * 2 + aiStats.tankFight() * 5 + aiStats.aircraftFight() * 20);

                }
            }
        }
    }
}
