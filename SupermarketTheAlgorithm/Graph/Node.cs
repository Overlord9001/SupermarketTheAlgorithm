using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Node<T>
    {
        public Graph<T> Graph { get; private set; }
        public MyLinkedList<Edge<T>> Edges { get; set; } = new MyLinkedList<Edge<T>>();
        public T Value { get; private set; }
        public string Name { get; private set; }
        public Node<T> Parent { get; set; }
        public bool isWalkable { get; set; } = true;

        public Node(string nodeName)
        {
            Name = nodeName;
            //Value = value;
            //Graph = graph;
        }

        /// <summary>
        /// Adds an egde from this node to endNode
        /// </summary>
        /// <param name="endNode"></param>
        /// <returns></returns>
        public Edge<T> AddEgde(Node<T> endNode)
        {
            Edge<T> egde = new Edge<T>(this, endNode);
            Edges.Add(egde);
            return egde;
        }
    }
}
