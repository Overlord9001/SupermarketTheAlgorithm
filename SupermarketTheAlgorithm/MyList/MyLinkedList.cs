using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class MyLinkedList<T> : IEnumerable
    {
        private bool empty = true;

        public MyLinkedListNode<T> First { get; set; }
        public MyLinkedListNode<T> Last { get; set; }

        public int Count { get; private set; } = 0;

        // used so that Foreach can be used on MyLinkedList
        public IEnumerator GetEnumerator()
        {
            MyLinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Adds a node to the end of the list
        /// </summary>
        /// <param name="value">the value of the new node</param>
        /// <returns></returns>
        public MyLinkedListNode<T> Add(T value)
        {
            // if the list is empty set the new node to both first and last
            if (empty == true)
            {
                MyLinkedListNode<T> newFirst = new MyLinkedListNode<T>(value);
                First = newFirst;
                Last = newFirst;
                empty = false;
                Count++;
                return newFirst;

            }

            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value)
            {
                Previous = Last, // the last node in the list is set to the new node's prevíous
                Next = null // the new node's next is null because it is last
            };

            Last.Next = newNode; // the old last's next is set to this new node
            Last = newNode; // the new node is added on the end of the list
            Count++;
            return newNode;
        }

        /// <summary>
        /// Remove the first instance of an object in the list, and returns true/false based on succes
        /// </summary>
        /// <param name="value">the obejct to remove</param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            MyLinkedListNode<T> toBeRemoved = null;
            MyLinkedListNode<T> tmp = First; 

            // runs through the list to find the obejct to remove
            for (int i = 0; i < Count; i++)
            {
                // compare two generic values
                if (EqualityComparer<T>.Default.Equals(tmp.Value, value))
                {
                    toBeRemoved = tmp; // if the values match set that node to be removed
                    break;
                }
                tmp = tmp.Next;
            }

            // if nothing was found return false
            if (toBeRemoved == null)
            {
                return false;
            }

            // try catch catches the exception that comes if the object is last/first in the list
            try
            {
                toBeRemoved.Previous.Next = toBeRemoved.Next; // sets the previous node's next to the removed node's next
                toBeRemoved.Next.Previous = toBeRemoved.Previous; // sets the next node's previous to the removed node's previous
            }
            catch (Exception) { }

            toBeRemoved = null;
            Count--;
            return true;
        }
    }
}
