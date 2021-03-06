using System;

namespace laboratory_1 {
    class Program {
        enum EndOfProgram {
            QUIT = 1,
            CONTINUE
        };

        public static void Main(string[] args) { 
            Menu menu = new Menu();
            menu.Greeting();
            int userChoice;
            Check inputChecks = new Check();
            ActionsWithTheTree filling = new ActionsWithTheTree();

            do {
                
                do {
                    filling.FillingTheTree();
                    Console.WriteLine("Press 1 to finish");
                    Console.WriteLine("Press 2 to continue");
                    userChoice = inputChecks.GetInt();

                    if (userChoice != (int)EndOfProgram.QUIT && userChoice != (int)EndOfProgram.CONTINUE) {
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                    }

                } while (userChoice != (int)EndOfProgram.QUIT && userChoice != (int)EndOfProgram.CONTINUE);

            } while (userChoice != (int)EndOfProgram.QUIT);

        }

    }
}
