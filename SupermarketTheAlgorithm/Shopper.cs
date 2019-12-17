using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Shopper
    {
        MyLinkedList<string> shoppingList { get; set; } = new MyLinkedList<string>();
        MyLinkedList<string> shoppingCart { get; set; } = new MyLinkedList<string>();
        public Node CurrentNode { get; set; }
        MyLinkedList<string> Path { get; set; } = new MyLinkedList<string>();

        public Shopper()
        {

        }

        public void Move()
        {

        }
    }
}
