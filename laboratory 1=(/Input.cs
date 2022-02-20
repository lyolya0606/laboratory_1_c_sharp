using System;
using System.IO;

namespace laboratory_1 {
    class Input {

        public string KeyboardInput() {
            Check inputChecks = new Check();
            bool emptyString = true;
            const int EMPTY_STRING = 0;
            string stringInput;

            do {
                Console.Write("Enter the node's values seperated by a space: ");
                stringInput = inputChecks.RemovingExtraSymbols(Console.ReadLine());

                if (stringInput.Length == EMPTY_STRING) {
                    emptyString = false;
                    Console.WriteLine("You didn't enter the numbers. Try again");
                } 

            } while (emptyString == false);
            return stringInput;
        }

        public string RandomInput() {
            const int LEFT_BOARD = 0;
            const int RIGHT_BOARD = 100;
            string stringInput = "";

            Check inputChecks = new Check();
            Console.Write("Enter the number of nodes: ");
            int numberOfNodes = inputChecks.GetInt();

            Random rand = new Random();
            int[] nodeData = new int[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++) {
                nodeData[i] = rand.Next(LEFT_BOARD, RIGHT_BOARD);
                stringInput += $"{nodeData[i]} ";
            }

            stringInput = stringInput.Trim();
            return stringInput;
        }

        public string FileInput() {
            Check check = new Check();
            const int EMPTY_STRING = 0;
            string path = check.OpenFileInput();
            string stringInput = File.ReadAllText($"{path}.txt");

            for (int i = 0; i < stringInput.Length; i++) {
                if (stringInput[i] == '\r') {
                    stringInput = stringInput.Replace(stringInput[i], ' ');
                }
            }

            stringInput = check.RemovingExtraSymbols(stringInput);

            if (stringInput.Length == EMPTY_STRING) {
                Console.WriteLine("Incorrect data in the file! Try again.");
            } 

            return stringInput;
        }       
    }
}
