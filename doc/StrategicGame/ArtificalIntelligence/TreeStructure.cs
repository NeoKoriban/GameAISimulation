using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    /**
     * Klasa odpowiedzialna za budowę drzewa decyzyjnego i przeszukiwanie go.
     * 
     * */
    public class TreeStructure<T>
    {
        //Korzeń drzewa decyzyjnego
        private TreeNode<T> root;

        //Konstruktor bezarugmentowy
        public TreeStructure()
        {
            root = null;
        }

        /**
         * Konstruktor argumentowy drzewa decyzyjnego.
         * 
         * Argumenty:
         * Atribute<T> atributesList - lista atrybutów
         * List<string> classNames - lista klas
         * 
         * */
        public TreeStructure(Atribute<T>[] atributesList, List<string> classNames)
        {
            root = new TreeNode<T>(atributesList, classNames);
            
        }

        //Funkcja zwracająca korzeń drzewa
        public TreeNode<T> returnRootNode()
        {
            return root;
        }

        /**
         * Funkcja budująca drzewo decyzyjne i zwracająca je po utworzeniu.
         * 
         * Argumenty:
         * TreeNode<T> node - aktualny węzeł drzewa.
         * 
         * */
        public TreeNode<T> buildTree(TreeNode<T> node)
        {
            if (node.atributesReturn()[0].uniqueClassCount() > 1)
            {
                double entropy = 0.0;

                List<string> aiClass = new List<string>();
                List<int> aiClassDetection = new List<int>();

                for (int i = 0; i < node.classNamesReturn().Count(); i++)
                {
                    if (aiClass.Contains(node.classNamesReturn()[i]))
                        aiClassDetection[aiClass.IndexOf(node.classNamesReturn()[i])]++;
                    else
                    {
                        aiClass.Add(node.classNamesReturn()[i]);
                        aiClassDetection.Add(1);
                    }
                }

                Calculations calc = new Calculations();
                entropy = calc.makeEntropy(aiClassDetection);

                double maxValue = 0.0;
                double prevMaxValue = 0.0;
                int indexMaxValue = 0;

                //Wyznaczanie atrybutu o największym zysku informacji
                for (int i = 0; i < node.atributesReturn().Count(); i++)
                {
                    double splitVal = node.atributesReturn()[i].atributeGain(entropy, aiClass);// / node.atributesReturn()[i].atributeSplit(aiClass);
                    prevMaxValue = maxValue;
                    maxValue = Math.Max(maxValue, splitVal);

                    if (!maxValue.Equals(prevMaxValue))
                        indexMaxValue = i;
                }

                //Wartość atrybutu o najwięszym zysku informacji
                T nameMax = node.atributesReturn()[indexMaxValue].returnMaxGainValue();

                node.valueDividedReturn = nameMax;
                node.attributeDividedReturn = indexMaxValue;

                Atribute<T>[] leftAttributes = new Atribute<T>[node.atributesReturn().Count()];
                Atribute<T>[] rightAttributes = new Atribute<T>[node.atributesReturn().Count()];
                List<string> leftClass = new List<string>();
                List<string> rightClass = new List<string>();
                List<T>[] leftList = new List<T>[node.atributesReturn().Count()];
                List<T>[] rightList = new List<T>[node.atributesReturn().Count()];

                for (int i = 0; i < node.atributesReturn().Count(); i++)
                {
                    leftList[i] = new List<T>();
                    rightList[i] = new List<T>();
                }


                for (int i = 0; i < node.classNamesReturn().Count; i++)
                {
                    if (Convert.ToInt32(nameMax) >= Convert.ToInt32(node.atributesReturn()[indexMaxValue].atributeValueReturn()[i]))
                    {
                        for (int j = 0; j < node.atributesReturn().Count(); j++)
                        {
                            leftList[j].Add(node.atributesReturn()[j].atributeValueReturn()[i]);
                        }
                        leftClass.Add(node.classNamesReturn()[i]);
                    }
                    else
                    {

                        for (int j = 0; j < node.atributesReturn().Count(); j++)
                        {
                            rightList[j].Add(node.atributesReturn()[j].atributeValueReturn()[i]);
                        }
                        rightClass.Add(node.classNamesReturn()[i]);
                    }

                }
                if (leftClass.Count.Equals(0) || rightClass.Count.Equals(0))
                {
                    if(leftClass.Count.Equals(0))
                    {
                        rightClass.Sort();            
                        for (int i = 0; i < rightClass.Count-1; i++)
                        {
                            rightClass.RemoveAt(i);
                        }
                    }
                    else
                    {
                        leftClass.Sort();
                        for (int i = 0; i < leftClass.Count - 1; i++)
                        {
                            leftClass.RemoveAt(i);
                        }
                    }
                    return node;
                }
                else
                {
                    for (int j = 0; j < node.atributesReturn().Length; j++)
                    {
                        leftAttributes[j] = new Atribute<T>(leftList[j], node.atributesReturn()[j].returnNameAttribute(), leftClass);
                        rightAttributes[j] = new Atribute<T>(rightList[j], node.atributesReturn()[j].returnNameAttribute(), rightClass);
                    }


                    node.left = new TreeNode<T>(leftAttributes, leftClass);
                    node.right = new TreeNode<T>(rightAttributes, rightClass);

                    buildTree(node.left);
                    buildTree(node.right);
                }
            }

            return node;
        }

        /**
         * Funkcja szukająca decyzji w utworzonym wcześniej drzewie i zwracająca decyzję.
         * 
         * Argumenty:
         * List<T> playerResources - zasoby gracza
         * TreeNode<T> node - węzeł drzewa
         * */
        public string searchTree(List<T> playerResources, TreeNode <T> node)
        {
            string nameClassReturned = "";

            if (node.atributesReturn()[0].uniqueClassCount() > 1)
            {
                if (node.left != null)
                {
                    if (Convert.ToInt32(node.valueDividedReturn) >= Convert.ToInt32(playerResources[node.attributeDividedReturn]))
                    {
                        nameClassReturned = searchTree(playerResources, node.left);
                    }
                    else
                    {
                        nameClassReturned = searchTree(playerResources, node.right);
                    }
                }
                else
                    nameClassReturned = node.classNamesReturn()[0];
            }
            else
                nameClassReturned = node.classNamesReturn()[0];

            return nameClassReturned;
              
        }

    }
}
