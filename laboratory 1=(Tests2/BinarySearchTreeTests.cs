using Microsoft.VisualStudio.TestTools.UnitTesting;
using laboratory_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_1.Tests {
    [TestClass()]
    public class BinarySearchTreeTests {
        [TestMethod()]
        public void InsertNodeTest1() {
            int[] valueOfNodes = { 8, 6, 2, 7, 10, 15, 13 };
            List<int> expectedOrder = new List<int>() { 2, 6, 7, 8, 10, 13, 15 };
            BinarySearchTree bst = new BinarySearchTree();

            foreach (int i in valueOfNodes) {
                bst.InsertNode(i);
            }

            List<int> resultOrder = bst.Order();
            CollectionAssert.AreEqual(expectedOrder, resultOrder);
        }

        [TestMethod()]
        public void DeleteNodeTest1() {
            int[] valueOfNodes = { 8, 6, 2, 7, 10, 15, 13 };
            List<int> expectedOrder = new List<int>() { 2, 6, 7, 10, 13, 15 };
            int nodeForDeleting = 8;
            BinarySearchTree bst = new BinarySearchTree();

            foreach (int i in valueOfNodes) {
                bst.InsertNode(i);
            }

            bst.DeleteNode(nodeForDeleting);

            List<int> resultOrder = bst.Order();
            CollectionAssert.AreEqual(expectedOrder, resultOrder);
        }

        [TestMethod()]
        public void InsertNodeTest2() {
            int[] valueOfNodes = { 25, 16, 0, 37, 89, -6 };
            List<int> expectedOrder = new List<int>() { -6, 0, 16, 25, 37, 89 };
            BinarySearchTree bst = new BinarySearchTree();

            foreach (int i in valueOfNodes) {
                bst.InsertNode(i);
            }

            List<int> resultOrder = bst.Order();
            CollectionAssert.AreEqual(expectedOrder, resultOrder);
        }

        [TestMethod()]
        public void DeleteNodeTest2() {
            int[] valueOfNodes = { 25, 16, 0, 37, 89, -6 };
            List<int> expectedOrder = new List<int>() { -6, 16, 25, 37, 89 };
            int nodeForDeleting = 0;
            BinarySearchTree bst = new BinarySearchTree();

            foreach (int i in valueOfNodes) {
                bst.InsertNode(i);
            }

            bst.DeleteNode(nodeForDeleting);

            List<int> resultOrder = bst.Order();
            CollectionAssert.AreEqual(expectedOrder, resultOrder);
        }
    }
}