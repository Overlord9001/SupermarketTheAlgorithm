using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

        public Graph()
        {

        }

        public Node<T> AddNode(T value, string nodeName)
        {
            Node<T> node = new Node<T>(value, nodeName, this);
            Nodes.Add(node);
            return node;
        }
    }
}
