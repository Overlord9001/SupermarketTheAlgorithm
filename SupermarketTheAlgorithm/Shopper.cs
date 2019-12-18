using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketTheAlgorithm
{
    public class Shopper
    {
        MyLinkedList<Node> shoppingList { get; set; } = new MyLinkedList<Node>(); 
        MyLinkedList<Node> shoppingCart { get; set; } = new MyLinkedList<Node>();
        public Node CurrentNode { get; set; }
        MyLinkedList<Node> Path { get; set; } = new MyLinkedList<Node>();

        Color color;
        PictureBox supermarketPictureBox;
        Node goal;
        Graphics g;

        public Shopper(PictureBox supermarketPictureBox, Color color, Graphics g)
        {
            this.color = color;
            this.supermarketPictureBox = supermarketPictureBox;
            GenerateShoppingList();
            this.g = g;
        }

        public void Move()
        {
            //Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            Pen p = new Pen(Color.Orange);
            SolidBrush b = new SolidBrush(Color.White);

            if (shoppingList.Count > 0)
                goal = shoppingList.First.Value;
            //else
            //do something
            if (Path.Count == 0)
            {
                Path = AStar.AstarAlgorithm(CurrentNode, goal); // brug astar til at finde rute
                if (Path == null)
                {
                    return;
                }
            }

            CurrentNode = Path.First.Value;
            // paint the cell the shopper is standing on white
            g.FillRectangle(b, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            g.DrawRectangle(p, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            
            Path.Remove(Path.First.Value);
            CurrentNode = Path.First.Value;

            b = new SolidBrush(color);
            g.FillRectangle(b, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            g.DrawRectangle(p, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);

            supermarketPictureBox.Refresh();

            //if (Path.Count == 0 && shoppingList.First != null)
            //{
            //    goal = shoppingList.First.Value;
            //}
        }

        private void GenerateShoppingList()
        {
            shoppingList.Add(Form1.Meat);
            //shoppingList.Add(Form1.Bread);
            //shoppingList.Add(Form1.Cheese);
        }
    }
}
