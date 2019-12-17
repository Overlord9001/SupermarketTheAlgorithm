using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    class AStar<T>
    {
        public void AstarAlgorithm(Node<T> start, Node<T> goal, int h)
        {
            MyLinkedList<Node<T>> denLukkedeListe = new MyLinkedList<Node<T>>();
            MyLinkedList<Node<T>> denÅbneListe = new MyLinkedList<Node<T>>();
            denLukkedeListe.Add(start); //Tilføjer current node til den åbne liste            

            //Tilføj alle omkringliggende noder til den åbne liste 
            //og sæt current node som parent til dem.
            foreach (Edge<T> item in start.Edges)
            {
                if (item.EndNode.isWalkable)
                {
                    denÅbneListe.Add(item.EndNode);
                    item.EndNode.Parent = start;
                }
            }


            while (true)
            {

            }
        }
    }
}
