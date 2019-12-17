using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Graph
    {
        public MyLinkedList<Node> Nodes { get; set; } = new MyLinkedList<Node>();

        public Graph()
        {

        }

        public Node AddNode(string nodeName)
        {
            Node node = new Node(nodeName);
            Nodes.Add(node);
            return node;
        }
    }
}
