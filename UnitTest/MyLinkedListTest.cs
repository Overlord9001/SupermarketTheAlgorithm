using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketTheAlgorithm;

namespace UnitTest
{
    [TestClass]
    public class MyLinkedListTest
    {
        [TestMethod]
        public void AddTest()
        {
            // arrange
            MyLinkedList<int> result = new MyLinkedList<int>() { 1, 2, 3};
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // act
            result.Add(4);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddFirstTest()
        {
            // arrange
            MyLinkedList<int> result = new MyLinkedList<int>() { 2, 3, 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 3, 4 };

            // act
            result.AddFirst(1);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveTest()
        {
            // arrange
            MyLinkedList<int> result = new MyLinkedList<int>() { 1, 2, 3 , 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 4 };

            // act
            result.Remove(3);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
