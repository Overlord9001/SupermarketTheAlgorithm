using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Node
    {
        public Graph Graph { get; private set; } //måske slettes

        public MyLinkedList<Edge> Edges { get; set; } = new MyLinkedList<Edge>();

        public Node Parent { get; set; }

        public string Name { get; private set; }

        public bool isWalkable { get; set; } = true;

        public int HScore { get; set; }
        public int GScore { get; set; }
        public int FScore { get; set; }

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
