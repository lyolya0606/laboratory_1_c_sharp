using System;

namespace laboratory_1 {
    class Menu {
        public void Greeting() {
            Console.WriteLine("Laboratory work 1, variant 1");
            Console.WriteLine("Need to implement a binary search tree, demonstrate characteristic features,");
            Console.WriteLine("implement the ability to add and remove elements, visualize a tree");
            Console.WriteLine("Student of group number 403, Bezdudnaya Olga. 2022 year");
            Console.WriteLine();
        }

        public void MenuWork() {
            Console.WriteLine("Press 1 to enter numbers from the keyboard");
            Console.WriteLine("Press 2 to enter numbers randomly");
            Console.WriteLine("Press 3 to enter numbers from the file");
        }

        public void MenuForWorkingWithTheTree() {
            Console.WriteLine();
            Console.WriteLine("Press 1 if you want to insert a node");
            Console.WriteLine("Press 2 if you want to delete a node");
            Console.WriteLine("Press 3 if you DON'T want to work with the tree");
        }
    }
}
