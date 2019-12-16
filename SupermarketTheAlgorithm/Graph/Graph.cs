using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Graph<T>
    {
        public MyLinkedList<Node<T>> Nodes { get; set; } = new MyLinkedList<Node<T>>();

        public Graph()
        {

        }

        public Node<T> AddNode(T value, string nodeName)
        {
            Node<T> node = new Node<T>(nodeName);
            Nodes.Add(node);
            return node;
        }
    }
}
