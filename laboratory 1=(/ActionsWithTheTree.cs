using System;

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
            bool stop;
            Menu menu = new Menu();
            BinarySearchTree bst = new BinarySearchTree();
            Check check = new Check();
            Input input = new Input();
            SavingFiles savingFiles = new SavingFiles();
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
            int[] intInputArray = new int[stringInputArray.Length];

            for (int i = 0; i < stringInputArray.Length; i++) {
                intInputArray[i] = int.Parse(stringInputArray[i]);
            }

            foreach (int i in intInputArray) {
                bst.InsertNode(i);
            }

            bst.Print();

            do {
                do {
                    menu.MenuForWorkingWithTheTree();
                    userChoice = check.GetInt();

                    switch (userChoice) {
                        case (int)WorkingWithTheTree.INSERT:
                            Console.Write("Enter the node you want to insert: ");
                            userChoice = check.GetInt();

                            if (!bst.FindNode(userChoice)) {
                                bst.InsertNode(check.GetInt());
                                bst.Print();
                            } else {
                                Console.WriteLine("This node already exists");
                            }
                            
                            stop = true;
                            break;
                        case (int)WorkingWithTheTree.DELETE:
                            Console.Write("Enter the node you want to delete: ");
                            userChoice = check.GetInt();

                            if (bst.FindNode(userChoice)) {
                                bst.DeletingNode(userChoice);
                                bst.Print();
                            } else {
                                Console.WriteLine("There is no such node");
                            }

                            stop = true;
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

            savingFiles.SavingInput(stringInput);
            savingFiles.SavingTheResult();

        }
    }
}
