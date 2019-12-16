﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    class Egde<T>
    {
        public Node<T> SourceNode { get; set; }
        public Node<T> EndNode { get; set; }
        public string Name { get; set; }

        public Egde(Node<T> sourceNode, Node<T> endNode)
        {
            SourceNode = sourceNode;
            EndNode = endNode;
            Name = sourceNode.Name + "-" + endNode.Name;
        }
    }
}
