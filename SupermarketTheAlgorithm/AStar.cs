using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketTheAlgorithm
{
    public class AStar
    {
        public static MyLinkedList<Node> AstarAlgorithm(Node start, Node goal)
        {
            MyLinkedList<Node> denLukkedeListe = new MyLinkedList<Node>();
            MyLinkedList<Node> denÅbneListe = new MyLinkedList<Node>();

            denLukkedeListe.Add(start); //Tilføjer current node til den lukkede liste            

            //Tilføj alle omkringliggende noder til den åbne liste 
            //og sæt current node som parent til dem.
            foreach (Edge item in start.Edges)
            {
                if (item.EndNode.isWalkable)
                {
                    denÅbneListe.Add(item.EndNode);
                    item.EndNode.Parent = start; //Tilføjer parent til hver node

                    //HScore
                    item.EndNode.HScore = Math.Abs(item.EndNode.XPos - goal.XPos) + Math.Abs(item.EndNode.YPos - goal.YPos) ; //Tilføjer H-scoren ved at kigge på positionen for denne node i arrayet i forhold til goal noden.
                    
                    //GScore
                    if (start.XPos != item.EndNode.XPos && start.YPos != item.EndNode.YPos) // Hvis både x og y på EndNode er forskellig fra start's x og y vil den altid være skrå
                    {
                        item.EndNode.GScore = 14;
                    }
                    else //ellers vil den altid være lige
                    {
                        item.EndNode.GScore = 10;
                    }
                    
                    //FScore
                    item.EndNode.FScore = item.EndNode.GScore + item.EndNode.HScore; //Fscore sættes
                }
            }

            //Søger efter den node med laveste F-score fra den åbne liste 
            //indtil den åbne liste er tom eller goal er i den lukkede liste.
            while (denLukkedeListe.First.Value != goal && denLukkedeListe.Last.Value != goal && denÅbneListe.Count > 0)
            {
                Node currentNode = null;
                foreach (Node item in denÅbneListe)//Kører igennem for at finde den med laveste F-score
                {
                    if (currentNode == null)
                    {
                        currentNode = item;
                    }
                    else if (item.FScore < currentNode.FScore)
                    {
                        currentNode = item;

                    }
                }

                denLukkedeListe.Add(currentNode);
                denÅbneListe.Remove(currentNode);

                if (currentNode == null) // hvis den åbne liste er tom er algoritmen færdig og kunne ikke finde en rute
                {
                    return null;
                }


                MyLinkedList<Node> tmpList = denÅbneListe;
                foreach (Edge item in currentNode.Edges)//Løber begge lister igennem for at se om de allerede er tilføjet
                {
                    bool openContains = false;
                    bool closedContains = false;
                    foreach (Node otherItem in tmpList)
                    {
                        if (item.EndNode == otherItem)
                        {
                            openContains = true;
                            //Ny-GScore
                            if (otherItem.XPos != item.EndNode.XPos && otherItem.YPos != item.EndNode.YPos) // Hvis både x og y på EndNode er forskellig fra start's x og y vil den altid være skrå
                            {
                                item.EndNode.NyGScore = 14 + currentNode.GScore;
                            }
                            else //ellers vil den altid være lige
                            {
                                item.EndNode.NyGScore = 10 + currentNode.GScore;
                            }
                            if (item.EndNode.NyGScore + item.EndNode.HScore < item.EndNode.FScore)
                            {
                                item.EndNode.GScore = item.EndNode.NyGScore;
                                item.EndNode.FScore = item.EndNode.GScore + item.EndNode.HScore;
                                item.EndNode.Parent = currentNode;
                            }
                        }
                    }

                    foreach (Node dobbeltTjek in denLukkedeListe)
                    {
                        if (item.EndNode == dobbeltTjek)
                        {
                            closedContains = true;
                        }
                    }

                    if (openContains == false && closedContains == false)
                    {
                        if (item.EndNode == goal)
                        {
                            denLukkedeListe.Add(item.EndNode);
                            MyLinkedList<Node> rute = new MyLinkedList<Node>();
                            item.EndNode.Parent = currentNode;
                            Node tmpNode = item.EndNode;
                            for (int i = 0; i < denLukkedeListe.Count; i++)
                            {
                                rute.AddFirst(tmpNode);

                                if (tmpNode == start)
                                {
                                    break;
                                }

                                tmpNode = tmpNode.Parent;
                            }
                            return rute;
                        }
                        else
                        {
                            //HScore
                            item.EndNode.HScore = Math.Abs(item.EndNode.XPos - goal.XPos) + Math.Abs(item.EndNode.YPos - goal.YPos); //Tilføjer H-scoren ved at kigge på positionen for denne node i arrayet i forhold til goal noden.

                            //GScore
                            if (start.XPos != item.EndNode.XPos && start.YPos != item.EndNode.YPos) // Hvis både x og y på EndNode er forskellig fra start's x og y vil den altid være skrå
                            {
                                item.EndNode.GScore = 14;
                            }
                            else //ellers vil den altid være lige
                            {
                                item.EndNode.GScore = 10;
                            }

                            //FScore
                            item.EndNode.FScore = item.EndNode.GScore + item.EndNode.HScore; //Fscore sættes
                            if (item.EndNode.isWalkable) // hvis noden er walkable tilføj til den åbne liste
                            {
                                denÅbneListe.Add(item.EndNode);
                            }
                            
                        }
                        
                        item.EndNode.Parent = currentNode;

                    }
                }
            }
            return null; // hvis den ikke kan finde vej
        }
    }
}