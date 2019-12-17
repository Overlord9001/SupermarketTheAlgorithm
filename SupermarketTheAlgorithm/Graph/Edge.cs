using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Edge
    {
        public Node SourceNode { get; set; }
        public Node EndNode { get; set; }
        public string Name { get; set; }

        public Edge(Node sourceNode, Node endNode)
        {
            SourceNode = sourceNode;
            EndNode = endNode;
            Name = sourceNode.Name + "-" + endNode.Name;
        }
    }
}
