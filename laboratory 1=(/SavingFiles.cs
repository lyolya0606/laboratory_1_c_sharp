using System;
using System.IO;

namespace laboratory_1 {
    class SavingFiles {

        public void SavingInput(string stringInput) {
            Check check = new Check();
            const int SAVING = 1;
            const int NOT_SAVING = 2;

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
                FileStream file = new FileStream($"{path}.txt", FileMode.Open);
                StreamWriter fileWriter = new StreamWriter(file);
                fileWriter.Write(stringInput);
                Console.WriteLine("Your input is successfully saved!");
                fileWriter.Close();
            }
        }

        public void SavingTheResult() {
            Check check = new Check();
            const int SAVING = 1;
            const int NOT_SAVING = 2;

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
                FileStream file = new FileStream(path, FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(file);
                //fileWriter.Write(arrayOfNodes);
                //fileWriter.Close();
                Console.WriteLine("Your result is successfully saved!");
            }
        }
    }
}
