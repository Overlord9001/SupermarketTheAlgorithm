using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    class AStar
    {
        public void AstarAlgorithm(Node start, Node goal, int h)
        {
            MyLinkedList<Node> denLukkedeListe = new MyLinkedList<Node>();
            MyLinkedList<Node> denÅbneListe = new MyLinkedList<Node>();
            denLukkedeListe.Add(start); //Tilføjer current node til den åbne liste            

            //Tilføj alle omkringliggende noder til den åbne liste 
            //og sæt current node som parent til dem.
            foreach (Edge item in start.Edges)
            {
                if (item.EndNode.isWalkable)
                {
                    denÅbneListe.Add(item.EndNode);
                    item.EndNode.Parent = start;
                }
            }


            while (denLukkedeListe.First.Value != goal)
            {

            }
        }
    }
}
