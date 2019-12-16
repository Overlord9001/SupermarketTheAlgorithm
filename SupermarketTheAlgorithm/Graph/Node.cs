using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    class Node<T>
    {
        public Graph<T> Graph { get; private set; }
        public List<Egde<T>> Egdes { get; set; } = new List<Egde<T>>();
        public T Value { get; private set; }
        public string Name { get; private set; }
        public Node<T> Parent { get; set; }
        public bool isWalkable { get; set; }

        public Node(T value, string nodeName, Graph<T> graph)
        {
            Name = nodeName;
            Value = value;
            Graph = graph;
        }
    }
}
