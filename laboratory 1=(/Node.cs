using System;

namespace laboratory_1 {
    class Node {
        public int value;
        public Node left;
        public Node right;   
        
        public int NumberOfChildren() {
            int numberOfChildren = 0;

            if (left != null) {
                numberOfChildren++;
            }

            if (right != null) {
                numberOfChildren++;
            }

            return numberOfChildren;
        }

        public override string ToString() {
            return value.ToString();
        }
    }

}