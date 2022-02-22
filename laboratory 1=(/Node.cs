namespace laboratory_1 {
    public class Node {
        private int _value;
        private Node _left;
        private Node _right;

        public int Value {
            get {
                return _value;
            }

            set {
                _value = value;
            }
        }

        public Node Left {
            get {
                return _left;
            }

            set {
                _left = value;
            }
        }

        public Node Right {
            get {
                return _right;
            }

            set {
                _right = value;
            }
        }

        public int NumberOfChildren() {
            int numberOfChildren = 0;

            if (Left != null) {
                numberOfChildren++;
            }

            if (Right != null) {
                numberOfChildren++;
            }

            return numberOfChildren;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }

}