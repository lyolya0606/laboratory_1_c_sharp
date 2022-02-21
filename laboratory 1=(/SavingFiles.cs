using System;
using System.IO;
using System.Collections.Generic;

namespace laboratory_1 {
    class SavingFiles {
        private const int SAVING = 1;
        private const int NOT_SAVING = 2;

        public void SavingInput(List<int> intInputList) {
            Check check = new Check();

            Console.WriteLine("Press 1 if you want to save your input in the file");
            Console.WriteLine("Press 2 if you DON'T want to save your input in the file");
            int userChoice = check.GetInt();

            while (userChoice != SAVING && userChoice != NOT_SAVING) {
                Console.WriteLine("There is no such choice!");
                Console.WriteLine("Press 1 if you want to save your input in the file");
                Console.WriteLine("Press 2 if you DON'T want to save your input in the file");

                userChoice = check.GetInt();
            }

            if (userChoice == SAVING) {
                string path = check.OpenFileOutput();
                FileStream file = new FileStream($"{path}.txt", FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(file);

                foreach (int i in intInputList) {
                    fileWriter.Write($"{i} ");
                }
                Console.WriteLine("Your input is successfully saved!");
                fileWriter.Close();
            }
        }

        public void SavingTheResult(char[][] console) {
            Check check = new Check();

            Console.WriteLine("Press 1 if you want to save your result in the file");
            Console.WriteLine("Press 2 if you DON'T want to save your result in the file");
            int userChoice = check.GetInt();

            while (userChoice != SAVING && userChoice != NOT_SAVING) {
                Console.WriteLine("There is no such choice!");
                Console.WriteLine("Press 1 if you want to save your result in the file");
                Console.WriteLine("Press 2 if you DON'T want to save your result in the file");

                userChoice = check.GetInt();
            }

            if (userChoice == SAVING) {
                string path = check.OpenFileOutput();
                FileStream file = new FileStream($"{path}.txt", FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(file);

                foreach (char[] row in console) {
                    fileWriter.WriteLine(row);
                }
                fileWriter.Close();
                Console.WriteLine("Your result is successfully saved!");
            }
        }
    }
}
