using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketTheAlgorithm;

namespace UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AStarTest
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Form1 form = new Form1();
            form.PlaceNodes(5);
            Node start = form.Nodes[0, 0];
            Node goal = form.Nodes[0, 4];
            for (int i = 0; i < 4; i++)
            {
                form.Nodes[i, 2].isWalkable = false;
            }
            MyLinkedList<Node> result = new MyLinkedList<Node>();
            MyLinkedList<Node> expected = new MyLinkedList<Node>();
            //act
            result = AStar.AstarAlgorithm(start, goal);
            //assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
