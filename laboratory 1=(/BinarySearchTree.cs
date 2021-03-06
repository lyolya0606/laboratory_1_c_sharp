using System;
using System.Collections.Generic;

namespace laboratory_1 {
     public class BinarySearchTree {
        private Node _root;
        private const int COLUMN_WIDTH = 5;
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
                node.Value = value;
            } else if (value < node.Value) {
                node.Left = InsertNode(node.Left, value);
            } else {
                node.Right = InsertNode(node.Right, value);
            }
            return node;
        }

        public bool FindNode(int value) {
            Node node = _root;

            while (node != null) {

                if (value < node.Value) {
                    node = node.Left;
                } else if (value > node.Value) {
                    node = node.Right;
                } else {
                    return true;
                }
            }

            return false;
        }

        private Node MinNode(Node node) {
            while (node.Left != null) {
                node = node.Left;
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

            if (value < node.Value) {
                node.Left = DeleteNode(node.Left, value);
            } else if (value > node.Value) {
                node.Right = DeleteNode(node.Right, value);
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
                        Node childNode = node.Left ?? node.Right;

                        if (node == _root) {
                            _root = childNode;
                        } else {
                            node = childNode;
                        }
                        break;
                    case (int)NumberOfChidren.TWO_CHILDREN:
                        Node minNode = MinNode(node.Right);
                        node.Value = minNode.Value;
                        node.Right = DeleteNode(node.Right, minNode.Value);
                        break;
                }

            }
            return node;
        }

        public List<int> Order() {
            List<int> valuesOfNode = new List<int>();
            return Order(_root, valuesOfNode);
        }


        private List<int> Order(Node node, List<int> valuesOfNodes) {

            if (node != null) {
                Order(node.Left, valuesOfNodes);
                valuesOfNodes.Add(node.Value);
                Order(node.Right, valuesOfNodes);                
            }

            return valuesOfNodes;
        }

        public int GetHeight() {
            return GetHeight(_root);
        }

        private int GetHeight(Node node) {
            if (node == null) {
                return 0;
            }

            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        private int GetHeightNode(Node node) {
            return 1 + GetHeight(_root) - GetHeight(node);
        }
        
        private void DrawLeft(Node node, int row, int column, char[][] console, int columnDelta) {
            if (node.Left != null) {
                int startColumnIndex = COLUMN_WIDTH * (column - columnDelta) + 2;
                int endColumnIndex = COLUMN_WIDTH * column + 2;
                for (int i = startColumnIndex; i < endColumnIndex; i++) {
                    console[row + 1][i] = '-';
                }

                console[row + 1][startColumnIndex] = '\u250c';
                console[row + 1][endColumnIndex] = '+';
            }
        }

        private void DrawRight(Node node, int row, int column, char[][] console, int columnDelta) {
            if (node.Right != null) {
                int startColumnIndex = COLUMN_WIDTH * column + 2;
                int endColumnIndex = COLUMN_WIDTH * (column + columnDelta) + 2;
                for (int i = startColumnIndex + 1; i < endColumnIndex; i++) {
                    console[row + 1][i] = '-';
                }

                console[row + 1][startColumnIndex] = '+';
                console[row + 1][endColumnIndex] = '\u2510';
            }
        }

        private void VisualizeNode(Node node, int row, int column, char[][] console, int width) {
            if (node != null) {
                char[] chars = node.Value.ToString().ToCharArray();
                int margin = (COLUMN_WIDTH - chars.Length) / 2;
                for (int i = 0; i < chars.Length; i++) {
                    console[row][COLUMN_WIDTH * column + i + margin] = chars[i];
                }

                int columnDelta = (width + 1) / (int)Math.Pow(2, GetHeightNode(node) + 1);
                VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
                VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
                DrawLeft(node, row, column, console, columnDelta);
                DrawRight(node, row, column, console, columnDelta);
            }
        }

        private char[][] InitializeVisualization(BinarySearchTree bst, out int width) {
            int height = bst.GetHeight(bst._root);
            width = (int)Math.Pow(2, height) - 1;
            char[][] console = new char[height * 2][];
            for (int i = 0; i < 2 * height; i++) {
                console[i] = new char[COLUMN_WIDTH * width];
                for (int j = 0; j < console[i].Length; j++) {
                    console[i][j] = ' ';
                }
            }

            return console;
        }

        public void VisualizeTree(BinarySearchTree bst) {
            char[][] console = InitializeVisualization(bst, out int width);
            VisualizeNode(bst._root, 0, width / 2, console, width);
            foreach (char[] row in console) {
                Console.WriteLine(row);
            }
        }

        public char[][] VisualizeTreeForFile(BinarySearchTree bst) {
            char[][] console = InitializeVisualization(bst, out int width);
            VisualizeNode(bst._root, 0, width / 2, console, width);           
            return console;
        }

    }   

}
