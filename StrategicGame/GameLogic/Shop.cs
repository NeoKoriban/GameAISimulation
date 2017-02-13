using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /**
     * Klasa odpowiedzialna za obsługę sklepu
     * */ 
    public class Shop
    {
        //stan konta
        private int wallet;

        //liczba żołnierzy do kupienia
        private int sdBuy;

        //liczba czołgów do kupienia
        private int tkBuy;

        //liczba samolotów do kupienia
        private int acBuy;
        
        /**
         * Konstruktor tworzący portfel dla sklepu
        */
        public Shop()
        {
            wallet = 0;
            sdBuy = 0;
            tkBuy = 0;
            acBuy = 0;
        }

        /**
         * Dodawanie losowo pieniędzy do portfela podczas
         * trwania tury.
         * */
        public void addMoney()
        {
            Random random = new Random();
            int countMoney = random.Next(1, 9) * 10;
            wallet += countMoney;
        }

        /**
         * Kupowanie jednostek do walki. Sprawdzanie rodzaju
         * jednostki i liczby jednostek.
         * 
         * Parametry:
         * string item - nazwa jednostki
         * int count - liczba jednostek do zakupu
         * 
         * */
        public bool buyWallet(string item)
        {
            switch (item)
            {
                case "soldier":
                    if (buyCheck(50, sdBuy).Equals(true))
                    {
                        wallet -= 50 * sdBuy;
                        sdBuy = 0;
                        return true;
                    }
                    return false;
                case "tanks":
                    if (buyCheck(200, tkBuy).Equals(true))
                    { 
                        wallet -= 200 * tkBuy;
                        tkBuy = 0;
                        return true;
                    }
                    return false;
        
                case "aircraft":
                    if (buyCheck(1000, acBuy).Equals(true))
                    {
                        wallet -= 1000 * acBuy;
                        acBuy = 0;
                        return true;
                    }
                    return false;
            }
            return false;
        }

        /**
         * Sprawdzanie stanu konta przy liczbie jednostek i ich cenie
         * 
         * Parametry:
         * int value - wartość jednostki
         * int count - liczba jednostek
         * 
         * Zwraca:
         * bool - Czy gracz ma odpowiednią ilość pieniędzy by zakupić jednostki
         * */
        private bool buyCheck(int value, int count)
        {
            if (wallet >= count * value)
                return true;
            return false;
        }

        /**
         * Funkcja wysyłająca aktualną wartość posiadanych pieniędzy
         * do wyświetlenia.
         * */
        public int printWallet()
        {
            return wallet;
        }
        
        /**
         * Przekazanie do wyświetlenia wartości aktualnej liczby
         * jednostek żołnierzy do kupienia 
         * */
        public int printSoldierBuy()
        {
            return sdBuy;
        }
       
        /**
         * Przekazanie do wyświetlenia wartości aktualnej liczby
         * jednostek czołgów do kupienia 
         * */
        public int printTanksBuy()
        {
            return tkBuy;
        }
        
        /**
         * Przekazanie do wyświetlenia wartości aktualnej liczby
         * jednostek samolotów do kupienia.
         * */
        public int printAircraftBuy()
        {
            return acBuy;
        }

        /**
         * Ustawienie wartości przy starcie sklepu w grze.
         * */
        public void startShop()
        {
            resetShop();
            wallet = 500;
        }

        /**
         * Ustawienie wartości przy resecie gry.
         * */
        public void resetShop()
        {
            acBuy = 0;
            tkBuy = 0;
            sdBuy = 0;
            wallet = 0;
          
        }
       
        /**
         * Dodanie zawartości do koszyka.
         * Argument:
         * string addItem - nazwa rodzaju wojska.
         * Zwraca:
         * int - aktualna ilość produktów w koszyku.
         * */
        public int addBuy(string addItem)
        {
            switch (addItem)
            {
                case "soldier":
                    sdBuy++;
                    return sdBuy;
                case "tanks":
                    tkBuy++;
                    return tkBuy;

                case "aircraft":
                    acBuy++;
                    return acBuy;
                default:
                    return 0;
            }
            
        }

        /**
       * Usuwanie zawartości z koszyka.
       * Argument:
       * string addItem - nazwa rodzaju wojska.
       * Zwraca:
       * int - aktualna ilość produktów w koszyku.
       * */
        public int deleteBuy(string delItem)
        {
            switch (delItem)
            {
                case "soldier":
                    if(sdBuy > 0)
                        sdBuy--;
                    return sdBuy;
                case "tanks":
                    if(tkBuy > 0)
                        tkBuy--;
                    return tkBuy;

                case "aircraft":
                    if(acBuy > 0)
                    acBuy--;
                    return acBuy;
                default:
                    return 0;
            }

        }

    }
}
