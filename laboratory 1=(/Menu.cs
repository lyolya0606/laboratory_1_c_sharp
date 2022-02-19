using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_1 {
    class Menu {
        public void Greeting() {
            Console.WriteLine("Laboratory work 1, variant 1");
            Console.WriteLine("Задание.................................................");
            Console.WriteLine("Student of group number 403, Bezdudnaya Olga. 2022 year.");
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
