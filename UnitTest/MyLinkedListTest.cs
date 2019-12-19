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
        public void Add()
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
        public void AddToEmpty()
        {
            // arrange
            MyLinkedList<int> result = new MyLinkedList<int>();
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1 };

            // act
            result.Add(1);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddFirst()
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
        public void Remove()
        {
            // arrange
            MyLinkedList<int> result = new MyLinkedList<int>() { 1, 2, 3 , 4 };
            MyLinkedList<int> expected = new MyLinkedList<int>() { 1, 2, 4 };

            // act
            result.Remove(3);

            // assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveFailed()
        {
            // arrange
            MyLinkedList<int> testList = new MyLinkedList<int>() { 1, 2, 3, 4 };
            bool result;

            // act
            result = testList.Remove(9);

            // assert
            Assert.IsFalse(result);
        }
    }
}
