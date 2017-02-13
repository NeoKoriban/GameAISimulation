using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DecisionTree
{
    /**
     * Klasa tworząca drzewo decyzyjne.
     * 
     * */
    public class DecisionTree
    {
        //Lista wyników poprzednich bitew
        private List<ResultListItem> resultList;

        private TreeStructure<int> tree;
        private TreeNode<int> treeRootNode;
        /**
         * Konstruktor bezargumentowy inicjalizujący pustą listę wyników poprzednich gier
         * 
         * */
        public DecisionTree()
        {
            resultList = new List<ResultListItem>();
        }

        /**
         * Odczytywanie wyników bitew z folderu.
         * 
         * Argumenty:
         * string resultDirectory - nazwa folderu z rezultatami.
         * 
         */
        public bool readFiles(string resultDirectory)
        {
            string[] filesName = Directory.GetFiles(resultDirectory);
            if (!filesName.Length.Equals(0))
            {
                for (int i = 0; i < filesName.Length; i++)
                {
                    using (StreamReader streamReader = File.OpenText(filesName[i]))
                    {
                        if (streamReader.ReadLine().Equals("AI")) // gdy AI wygrywa z graczem
                        {
                            int soldierPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy Gracza
                            int tankPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów Gracza
                            int aircraftPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów Gracza
                            if (soldierPlayerCount > 0)
                                soldierPlayerCount = 1;                            
                            if (tankPlayerCount > 0)
                                tankPlayerCount = 1;
                            if (aircraftPlayerCount > 0)
                                aircraftPlayerCount = 1;

                            streamReader.ReadLine(); // Liczba żołnierzy Gracza które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba czołgów Gracza które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba samolotów Gracza które przetrwały (jeśli przegrał to 0)
                            int firePlayerSummary = Convert.ToInt32(streamReader.ReadLine()); // Wartość siły ognia całej armii Gracza

                            int soldierAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy AI
                            int tankAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów AI
                            int aircraftAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów AI
                            int soldierAIKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy którzy polegli
                            int tankAIKilled =  Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów które zniszczono
                            int aircraftAIKilled =  Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów które zniszczono
                            streamReader.ReadLine();  // Wartość siły ognia całej armii AI                       

                            string aiCount = "";
                            if (soldierAICount > 0)
                                aiCount += "Soldier";
                            if (tankAICount > 0)
                                aiCount += "Tank";
                            if (aircraftAICount > 0)
                                aiCount += "Aircraft";

                            ResultListItem item = new ResultListItem(soldierPlayerCount, tankPlayerCount, aircraftPlayerCount, soldierAIKilled, tankAIKilled, aircraftAIKilled, firePlayerSummary, aiCount);
                            resultList.Add(item);
                        }
                        else
                        {
                            int soldierPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy Gracza
                            int tankPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów Gracza
                            int aircraftPlayerCount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów Gracza
                            int soldierPlayerKilled =  Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy którzy polegli
                            int tankPlayerKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów które zniszczono
                            int aircraftPlayerKilled = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów które zniszczono
                            int firePlayer = Convert.ToInt32(streamReader.ReadLine());  // Wartość siły ognia całej armii Gracza                      

                            int soldierAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba żołnierzy AI
                            int tankAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba czołgów AI
                            int aircraftAICount = Convert.ToInt32(streamReader.ReadLine()); // Liczba samolotów AI

                            if (soldierAICount > 0)
                                soldierAICount = 1;
                            if (tankAICount > 0)
                                tankAICount = 1;
                            if (aircraftAICount > 0)
                                aircraftAICount = 1;

                            streamReader.ReadLine(); // Liczba żołnierzy AI które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba czołgów AI które przetrwały (jeśli przegrał to 0)
                            streamReader.ReadLine(); // Liczba samolotów AI które przetrwały (jeśli przegrał to 0)
                            int fireAISummary = Convert.ToInt32(streamReader.ReadLine()); // Wartość siły ognia całej armii AI

                            string aiCount = "";
                            if (soldierPlayerCount > 0)
                                aiCount += "Soldier";
                            if (tankPlayerCount > 0)
                                aiCount += "Tank";
                            if (aircraftPlayerCount > 0)
                                aiCount += "Aircraft";

                            ResultListItem item = new ResultListItem(soldierAICount, tankAICount, aircraftAICount, soldierPlayerKilled, tankPlayerKilled, aircraftPlayerKilled, fireAISummary, aiCount);
                            resultList.Add(item);
                            if (soldierPlayerCount > 0)
                                soldierPlayerCount = 1;
                            if (tankPlayerCount > 0)
                                tankPlayerCount = 1;
                            if (aircraftPlayerCount > 0)
                                aircraftPlayerCount = 1;
                           // ResultListItem item2 = new ResultListItem(soldierPlayerCount, tankPlayerCount, aircraftPlayerCount, 0, 0, 0, firePlayer, aiCount);
                           // resultList.Add(item2);
                        }
                    }
                }

                using (StreamWriter streamWriter = File.CreateText("resultList.arff"))
                {
                    streamWriter.WriteLine("@relation Fight");
                    streamWriter.WriteLine("@attribute soldier numeric");
                    streamWriter.WriteLine("@attribute tank numeric");
                    streamWriter.WriteLine("@attribute aircraft numeric");
                    streamWriter.WriteLine("@attribute soldierSurvive numeric");
                    streamWriter.WriteLine("@attribute tankSurvive numeric");
                    streamWriter.WriteLine("@attribute aircraftSurvive numeric");
                    streamWriter.WriteLine("@attribute fireSummary numeric");
                    string ai = "@attribute ai {";

                    for (int i = 0; i < resultList.Count; i++)
                    {
                        int copy = 0;
                        for (int j = 0; j < i; j++)
                        {

                            if (resultList[i].ai() == resultList[j].ai())
                                copy++;
                        }
                        if (copy == 0)
                            ai += "'" + resultList[i].ai() + "'" + ", ";

                    }
                    ai += "}";
                    streamWriter.WriteLine(ai);
                    streamWriter.WriteLine("@data");

                    for (int i = 0; i < resultList.Count; i++)
                    {
                        string record = resultList[i].solider() + ","
                            + resultList[i].tank() + "," +
                            resultList[i].aircraft() + "," +
                            resultList[i].soliderSurvived() + ","
                            + resultList[i].tankSurvived() + "," +
                            resultList[i].aircraftSurvived() + "," +
                                 resultList[i].fireSummaryReturn() + ",'" +
                            resultList[i].ai() + "',?";
                        streamWriter.WriteLine(record);
                    }
                }
                return true;
            }
            else
                return false;
        }

        /**
         * Funkcja odpowiedzialna za inicjowanie tworzenia i podejmowanie decyzji w oparciu o dane wejściowe. 
         * Zwraca nazwę decyzji.
         * 
         * Argumenty:
         * int soldierPlayerCount - liczba żołnierzy gracza
         * int tankPlayerCount - liczba czołgów gracza
         * int aircraftPlayerCount - liczba samolotów gracza
         * 
         * */
        public string doC4_5(int soldierPlayerCount, int tankPlayerCount, int aircraftPlayerCount, bool fireEnabled)
        {
            string[] AttributesName;
          
            AttributesName = new string[] { "soldier", "tank", "aircraft", "soldierSurvive", "tankSurvive", "aircraftSurvive", "fireSummary" };
          

            Atribute<int>[] attributes = new Atribute<int>[AttributesName.Length];

            for (int i = 0; i < AttributesName.Length; i++)
            {
                List<int> valueList = new List<int>();
                List<string> classNames = new List<string>();

                for (int j = 0; j < resultList.Count; j++)
                {
                    switch (i)
                    {
                        case 0: valueList.Add(resultList[j].solider()); break;
                        case 1: valueList.Add(resultList[j].tank()); break;
                        case 2: valueList.Add(resultList[j].aircraft()); break;
                        case 3: valueList.Add(resultList[j].soliderSurvived()); break;
                        case 4: valueList.Add(resultList[j].tankSurvived()); break;
                        case 5: valueList.Add(resultList[j].aircraftSurvived()); break;
                        case 6: valueList.Add(resultList[j].fireSummaryReturn()); break;

                    }
                    classNames.Add(resultList[j].ai());
                    
                }
                if (fireEnabled.Equals(false))
                {

                    if (i.Equals(6))
                    {
                        for(int j = 0; j < valueList.Count; j++)
                        {
                            if(valueList[j] >= Convert.ToInt32(Convert.ToDouble( valueList.Max()) * 0.75))
                            {
                                valueList[j] = 2;
                            }
                            else if (valueList[j] >= Convert.ToInt32(Convert.ToDouble(valueList.Max()) * 0.25))
                            {
                                valueList[j] = 1;

                            }
                            else
                            {
                                valueList[j] = 0;
                            }

                        }

                    }
                }
                attributes[i] = new Atribute<int>(valueList, AttributesName[i], classNames);
            }

         
            List<string> classNameList = new List<string>();
            for (int i = 0; i < resultList.Count; i++)
            {
                classNameList.Add((resultList[i].ai()));
            }

            List<int> lista = new List<int>();
            lista.Add(soldierPlayerCount);
            lista.Add(tankPlayerCount);
            lista.Add(aircraftPlayerCount);
            lista.Add(attributes[3].atributeValueReturn().Max());
            lista.Add(attributes[4].atributeValueReturn().Max());
            lista.Add(attributes[5].atributeValueReturn().Max());       
            lista.Add(soldierPlayerCount * 2 + tankPlayerCount * 5 + aircraftPlayerCount * 20);
            tree = new TreeStructure<int>(attributes, classNameList);
            treeRootNode = tree.buildTree(tree.returnRootNode());
            return tree.searchTree(lista, treeRootNode);
            
        }  

        private void printTree(TreeNode<int> node, TreeNode tn)
        {            
            if (node.atributesReturn()[0].uniqueClassCount() > 1 )
            {
                if (node.left != null)
                {
                    TreeNode newNode = new TreeNode(node.atributesReturn()[node.attributeDividedReturn].returnNameAttribute()
                        + " [ " + node.valueDividedReturn + " ] ");
                    tn.Nodes.Add(newNode);
                    printTree(node.left, newNode);
                    printTree(node.right, newNode);
                }
                else
                {
                    TreeNode newNode = new TreeNode(node.classNamesReturn()[0]);
                    tn.Nodes.Add(newNode);
                }
            }
            else
            {
                TreeNode newNode = new TreeNode (node.classNamesReturn()[0]);
                tn.Nodes.Add(newNode);    
            }
           
        }
        public TreeView returnDecisionTree(TreeView tv)
        {
            TreeNode tn = new TreeNode("Decision Tree");
            printTree(treeRootNode, tn);
            tv.Nodes.Add(tn);
            return tv;
        }
    }
}
