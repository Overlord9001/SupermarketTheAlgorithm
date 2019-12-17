using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Node
    {
        public Graph Graph { get; private set; }
        public MyLinkedList<Edge> Edges { get; set; } = new MyLinkedList<Edge>();
        public string Name { get; private set; }
        public Node Parent { get; set; }
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
        public Edge AddEgde(Node endNode)
        {
            Edge egde = new Edge(this, endNode);
            Edges.Add(egde);
            return egde;
        }
    }
}
