namespace laboratory_1 {
    public class Node {
        private int _value;
        private Node _left;
        private Node _right;

        public int value {
            get {
                return _value;
            }

            set {
                _value = value;
            }
        }

        public Node left {
            get {
                return _left;
            }

            set {
                _left = value;
            }
        }

        public Node right {
            get {
                return _right;
            }

            set {
                _right = value;
            }
        }

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