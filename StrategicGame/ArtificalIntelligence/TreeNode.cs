using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    /**
     * Klasa tworząca węzeł drzewa decyzyjnego.
     * 
     * 
     * */
    public class TreeNode<T>
    {
        //Lista atrybutów
        private Atribute<T>[] attributes;
        
        //Lista nazw klas
        private List<string> className;
        
        //atrubut dzielący listę wartości
        private int attributeDivided;
        
        //wartość dzieląca listę wartości
        private T valueDivided;

        //lewe dziecko drzewa
        public TreeNode<T> left;

        //prawe dziecko drzewa
        public TreeNode<T> right;

        /**
         * Konstruktor argumentowy tworzący węzeł drzewa decyzyjnego.
         * 
         * Argumenty:
         * Atribute<T> [] listOfAttributes - lista atrybutów
         * List<string> - lista nazw klas         
         * */
        public TreeNode(Atribute<T>[] listOfAttributes, List<string> classNames)
        {
            attributes = listOfAttributes;
            className = classNames;
        }
       
        /**
         * Zwrot listy atrybutów
         * 
         * */
        public Atribute<T>[] atributesReturn()
        {
            return attributes;
        }

        /**
         * Zwrot listy klas
         * 
         * */
        public List<string> classNamesReturn()
        {
            return className;
        }

        /**
         * Zwrot wartości dzielącej wartości w drzewie
         * 
         * */
        public T valueDividedReturn
        {
            set
            {
                valueDivided = value;
            }
            get
            {
                return valueDivided;
            }
        }

        /**
         * Zwrot atrybutu dzielącego drzewo o największym zysku informacji
         * 
         * */
        public int attributeDividedReturn
        {
            set
            {
                attributeDivided = value;
            }
            get
            {
                return attributeDivided;
            }
        }
    }
}
