using System;

namespace laboratory_1 {
     class BinarySearchTree {
        private Node _root;
        private const int COLUMN_WIDTH = 8;
        enum NumberOfChidren {
            NO_CHILDREN,
            ONE_CHILD,
            TWO_CHILDREN
        }

        public BinarySearchTree() {
            _root = null;
        }

        public void InsertNode(int value) {
            _root = InsertNode(_root, value);
        }

        private Node InsertNode(Node node, int value) {

            if (node == null) {
                node = new Node();
                node.value = value;
            } else if (value < node.value) {
                node.left = InsertNode(node.left, value);
            } else {
                node.right = InsertNode(node.right, value);
            }
            return node;
        }

        public bool FindNode(int value) {
            Node node = _root;

            while (node != null) {

                if (value < node.value) {
                    node = node.left;
                } else if (value > node.value) {
                    node = node.right;
                } else {
                    return true;
                }
            }

            return false;
        }

        private Node MinNode(Node node) {
            while (node.left != null) {
                node = node.left;
            }
            return node;
        }

        public void DeleteNode(int value) {
            DeleteNode(_root, value);
        }

        private Node DeleteNode(Node node, int value) {

            if (node == null) {
                return node;
            }

            if (value < node.value) {
                node.left = DeleteNode(node.left, value);
            } else if (value > node.value) {
                node.right = DeleteNode(node.right, value);
            } else {

                switch (node.NumberOfChildren()) {
                    case (int)NumberOfChidren.NO_CHILDREN:

                        if (node == _root) {
                            _root = null;
                        } else {
                            node = null;
                        }
                        break;
                    case (int)NumberOfChidren.ONE_CHILD:
                        Node childNode = node.left ?? node.right;

                        if (node == _root) {
                            _root = childNode;
                        } else {
                            node = childNode;
                        }
                        break;
                    case (int)NumberOfChidren.TWO_CHILDREN:
                        Node minNode = MinNode(node.right);
                        node.value = minNode.value;
                        node.right = DeleteNode(node.right, minNode.value);
                        break;
                }

            }
            return node;
        }

        public void Order(Node node) {

            if (node != null) {
                Order(node.left);
                Order(node.right);                
            }
        }

        public int GetHeight() {
            return GetHeight(_root);
        }

        private int GetHeight(Node node) {
            if (node == null) {
                return 0;
            }

            int leftHeight = GetHeight(node.left);
            int rightHeight = GetHeight(node.right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public void Print() {
            Print(_root, 0);
        }

        private void Print(Node node, int space) {
            while (true) {
                if (node == null) {
                    return;
                }

                space += COLUMN_WIDTH;
                Print(node.right, space);
                Console.WriteLine();

                for (int i = COLUMN_WIDTH; i < space; i++) {
                    Console.Write(" ");
                }

                Console.WriteLine(node);
                node = node.left;
            }
        }       

    }   

}
