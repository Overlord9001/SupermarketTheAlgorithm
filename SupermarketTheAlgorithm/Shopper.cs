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
        public bool finished = false;

        Color color;
        PictureBox supermarketPictureBox;
        Node goal;
        Graphics g;

        public Shopper(PictureBox supermarketPictureBox, Color color, Graphics g)
        {
            this.color = color;
            this.supermarketPictureBox = supermarketPictureBox;
            this.g = g;
        }

        public void Move()
        {
            Pen p = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.White);

            if (shoppingList.First != null)
                goal = shoppingList.First.Value;
            else
                goal = Form1.Checkout; // set goal to checkout if shoppinglist is empty

            Path = AStar.AstarAlgorithm(CurrentNode, goal); // brug astar til at finde rute
            if (Path == null) // if path can not be found, 
            {
                g.FillRectangle(Brushes.White, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
                g.DrawRectangle(Pens.Black, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
                supermarketPictureBox.Refresh();
                finished = true;
                Form1.failedShoppers.Text = "A shopper could not find a path";
                Form1.failedShoppers.Visible = true;
                return;
            }
            Path.Remove(Path.Last.Value); // remove the goal from the path so the shopper does not step into the goal

            CurrentNode = Path.First.Value;
            // paint the cell the shopper is standing on white
            g.FillRectangle(b, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            g.DrawRectangle(p, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            
            Path.Remove(Path.First.Value);
            CurrentNode = Path.First.Value;

            // paint the new position with the "shopper color"
            b = new SolidBrush(color);
            g.FillRectangle(b, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            g.DrawRectangle(p, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
            
            if (Path.Count == 1 && shoppingList.Count > 0) // if the shopper has reached its goal go to next item in shoppinglist
            {
                shoppingCart.Add(goal);
                shoppingList.Remove(goal);
            }
            else if (Path.Count == 1 && goal == Form1.Checkout) // else if reached goal and goal was checkout, finish
            {
                // remove the shopper from the picturebox and set the shopper as finished
                g.FillRectangle(Brushes.White, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
                g.DrawRectangle(Pens.Black, CurrentNode.XPos * 10, CurrentNode.YPos * 10, Form1.cellSize, Form1.cellSize);
                finished = true;
            }

            supermarketPictureBox.Refresh(); // refresh the picturebox to apply changes
        }

        public void GenerateShoppingList()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 5);
            switch (random)
            {
                case 1:
                    shoppingList.Add(Form1.Bread);
                    shoppingList.Add(Form1.Cheese);
                    break;
                case 2:
                    shoppingList.Add(Form1.Bread);
                    shoppingList.Add(Form1.Fruit);
                    break;
                case 3:
                    shoppingList.Add(Form1.Bread);
                    shoppingList.Add(Form1.Fruit);
                    shoppingList.Add(Form1.Cheese);
                    break;
                case 4:
                    shoppingList.Add(Form1.Bread);
                    shoppingList.Add(Form1.Fruit);
                    shoppingList.Add(Form1.Cheese);
                    shoppingList.Add(Form1.Meat);
                    break;
            }
        }
    }
}