using System;
using System.Linq;
using System.IO;

namespace laboratory_1 {
    class Check {
        public int GetInt() {
            int num;

            while (true) {

                if (int.TryParse(Console.ReadLine(), out num)) {
                    break;
                }

                Console.WriteLine("Input Error. Try again.");
            }

            return num;
        }


        public string RemovingExtraSymbols(string str, int k = 1) {
            char[] charNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };

            for (int i = 0; i < str.Length; i++) {

                if (!charNumbers.Contains(str[i])) {
                    str = str.Remove(i, 1);
                    i--;
                }
            }

            char space = ' ';
            str = str.Trim();

            while (k != (str.Length + 1)) {

                if (k >= str.Length) {

                    if (str[k - 1] == space) {
                        str = str.Remove(k - 1, 1);
                    }
                    return str;

                } else {

                    if ((str[k - 1] == space) && (str[k] == space)) {
                        str = str.Remove(k - 1, 1);
                    } else {
                        k++;
                    }
                }
            }
            return str;
        }

        public string OpenFileOutput() {
            const int FILE_HAS_DATA = 0;
            const int OVERWRITE_FILE = 1;
            const int OVERWRITE_PATH = 2;    
            int userChoice;
            bool isCorrectPath;
            string path;

            do {

                Console.Write("Input the path to the file: ");
                path = Console.ReadLine();

                try {
                    using (FileStream file = new FileStream(path, FileMode.OpenOrCreate)) {
                        isCorrectPath = true;
                    }
                } catch (Exception) {
                    Console.WriteLine("Opening error! Try again.");
                    isCorrectPath = false;
                }

                if (isCorrectPath == true) {
                    string[] generalString = File.ReadAllLines(path);


                    if (generalString.Length != FILE_HAS_DATA) {
                        Console.WriteLine("This file has some data. Do you want to overwrite the file?");
                        Console.WriteLine("Press 1 if you want to overwrite this file");
                        Console.WriteLine("Press 2 if you DON'T want to overwrite this file");
                    }

                    userChoice = GetInt();

                    while (userChoice != OVERWRITE_PATH && userChoice != OVERWRITE_FILE) {
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine("Press 1 if you want to overwrite this file");
                        Console.WriteLine("Press 2 if you DON'T want to overwrite this file");
                        userChoice = GetInt();
                    }

                    if (userChoice == OVERWRITE_PATH) {
                        isCorrectPath = false;
                    }

                    if (userChoice == OVERWRITE_FILE) {
                        isCorrectPath = true;
                    }
                }

            } while (isCorrectPath == false);

            return path;
        }

        public string OpenFileInput() {
            string path;
            bool isCorrectPath;
            const int FILE_HAS_DATA = 0;

            do {
                Console.Write("Input the path to the file: ");
                path = Console.ReadLine();

                try {
                    using (FileStream file = new FileStream(path, FileMode.OpenOrCreate)) {
                        isCorrectPath = true;
                    }
                } catch (Exception) {
                    Console.WriteLine("Opening error! Try again.");
                    isCorrectPath = false;
                }

                string[] generalString = File.ReadAllLines(path);

                if (generalString.Length == FILE_HAS_DATA) {
                    Console.WriteLine("The file is empty. Try again.");
                    isCorrectPath = false;
                }
                
            } while (isCorrectPath == false);

            return path;
        }
    }

}
