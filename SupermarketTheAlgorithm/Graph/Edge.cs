using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class Edge<T>
    {
        public Node<T> SourceNode { get; set; }
        public Node<T> EndNode { get; set; }
        public string Name { get; set; }

        public Edge(Node<T> sourceNode, Node<T> endNode)
        {
            SourceNode = sourceNode;
            EndNode = endNode;
            Name = sourceNode.Name + "-" + endNode.Name;
        }
    }
}
