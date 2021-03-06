using System;
using System.Collections.Generic;

namespace laboratory_1 {
    class ActionsWithTheTree {
        enum ChoiceOfInput {
            KEYBOARD_INPUT = 1,
            RANDOM_INPUT,
            FILE_INPUT
        }
        enum WorkingWithTheTree {
            INSERT = 1,
            DELETE,
            NO_WORK
        };


        public void FillingTheTree() {
            Menu menu = new Menu();
            BinarySearchTree bst = new BinarySearchTree();
            Check check = new Check();
            Input input = new Input();
            SavingFiles savingFiles = new SavingFiles();
            bool stop;          
            int userChoice;
            string[] stringInputArray;
            string stringInput = " ";

            do {
                menu.MenuWork();
                userChoice = check.GetInt();
                switch (userChoice) {
                    case (int)ChoiceOfInput.KEYBOARD_INPUT:
                        stringInput = input.KeyboardInput();
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.RANDOM_INPUT:
                        stringInput = input.RandomInput();                   
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.FILE_INPUT:
                        stringInput = input.FileInput();
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }

                
            } while (stop == false);

            stringInputArray = stringInput.Split(' ');

            List<int> intInputList = new List<int>();

            foreach(string i in stringInputArray) {
                intInputList.Add(int.Parse(i));
            }

            for (int i = 0; i < intInputList.Count; i++) {
                for (int j = i + 1; j < intInputList.Count; j++) {
                    if (intInputList[i] == intInputList[j]) {
                        intInputList.RemoveAt(j);
                        j--;
                    }
                }
            }

            Console.Write("Node sizes: ");
            foreach (int i in intInputList) {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach (int i in intInputList) {
                bst.InsertNode(i);
            }

            Console.WriteLine("Your tree: ");
            bst.VisualizeTree(bst);         

            do {
                do {
                    menu.MenuForWorkingWithTheTree();
                    userChoice = check.GetInt();

                    switch (userChoice) {
                        case (int)WorkingWithTheTree.INSERT:
                            Console.Write("Enter the node you want to insert: ");
                            userChoice = check.GetInt();

                            if (!bst.FindNode(userChoice)) {
                                bst.InsertNode(userChoice);
                                Console.WriteLine("Your tree: ");
                                bst.VisualizeTree(bst);
                                stop = true;
                            } else {
                                Console.WriteLine("This node already exists");
                                stop = false;
                            }
                            
                            break;
                        case (int)WorkingWithTheTree.DELETE:
                            Console.Write("Enter the node you want to delete: ");
                            userChoice = check.GetInt();

                            if (bst.FindNode(userChoice)) {
                                bst.DeleteNode(userChoice);

                                if (bst.GetHeight() == 0) {
                                    Console.WriteLine("The tree is empty");

                                } else {
                                    Console.WriteLine("Your tree: ");
                                    bst.VisualizeTree(bst);
                                }
                                stop = true;
                            } else {
                                Console.WriteLine("There is no such node");
                                stop = false;
                            }

                            break;
                        case (int)WorkingWithTheTree.NO_WORK:
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("There is no such choice!");
                            Console.WriteLine();
                            stop = false;
                            break;
                    }
                } while (stop == false);
            } while (userChoice != (int)WorkingWithTheTree.NO_WORK);

            char[][] console = bst.VisualizeTreeForFile(bst);
            savingFiles.SavingInput(intInputList);
            savingFiles.SavingTheResult(console);
        }
    }
}
