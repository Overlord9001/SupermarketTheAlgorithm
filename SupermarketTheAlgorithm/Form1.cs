using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SupermarketTheAlgorithm
{
    public partial class Form1 : Form
    {
        private int gridSize = 20;
        public static int cellSize = 10; // must be 10
        private Timer myTimer;

        public bool RunSimulation { get; set; } = false;
        public Node[,] Nodes { get; set; }
        public MyLinkedList<Shopper> shoppers = new MyLinkedList<Shopper>();
        public Node Meat { get; set; }
        public Node Fruit { get; set; }
        public Node Cheese { get; set; }
        public Node Bread { get; set; }


        public Form1()
        {
            InitializeComponent();

            // setup
            Bitmap DrawArea = new Bitmap(supermarketPictureBox.Size.Width, supermarketPictureBox.Size.Height);
            supermarketPictureBox.Image = DrawArea;
            supermarketPictureBoxPaintGrid();
            PlaceNodes();
            fruitPictureBox.BackColor = Color.ForestGreen;
            meatPictureBox.BackColor = Color.DarkRed;
            checkoutPictureBox.BackColor = Color.Gray;
            shopperPictureBox.BackColor = Color.HotPink;
            wallPictureBox.BackColor = Color.Black;
            breadPictureBox.BackColor = Color.SandyBrown;
            cheesePictureBox.BackColor = Color.Yellow;
        }

        /// <summary>
        /// Paint the grid on the supermarket picturebox
        /// </summary>
        private void supermarketPictureBoxPaintGrid()
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            Pen p = new Pen(Color.Black);

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    g.DrawRectangle(Pens.Black, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }
        }

        private void supermarketPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            Pen p = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);
            
            // rounds down the mouseposition to a 10 (53 -> 50) to draw on the grid
            string xString = e.X.ToString();
            string yString = e.Y.ToString();
            if (xString.Length > 1)
            {
                xString = xString.Remove(xString.Length - 1);
                xString += "0";
            }
            else
                xString = "0";
            if (yString.Length > 1)
            {
                yString = yString.Remove(yString.Length - 1);
                yString += "0";
            }
            else
                yString = "0";
            int x = Convert.ToInt32(xString);
            int y = Convert.ToInt32(yString);

            try // in case the picturebox is clicked outside of the grid
            {
                switch (selectedTextBox.Text)
                {
                    case "Wall":
                        b = new SolidBrush(wallPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false; // divide by 10 to get position in array
                        break;
                    case "Walkable":
                        b = new SolidBrush(Color.White);
                        Nodes[x / 10, y / 10].isWalkable = true;
                        break;
                    case "Shopper":
                        b = new SolidBrush(shopperPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false; // can shoppers collide?
                        shoppers.Add(new Shopper(supermarketPictureBox, shopperPictureBox.BackColor)
                        {
                            CurrentNode = Nodes[x / 10, y / 10]
                        });
                        break;
                    case "Checkout":
                        b = new SolidBrush(checkoutPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        break;
                    case "Fruit":
                        b = new SolidBrush(fruitPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        Fruit = Nodes[x / 10, y / 10];
                        break;
                    case "Meat":
                        b = new SolidBrush(meatPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        Meat = Nodes[x / 10, y / 10];
                        break;
                    case "Bread":
                        b = new SolidBrush(breadPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        Bread = Nodes[x / 10, y / 10];
                        break;
                    case "Cheese":
                        b = new SolidBrush(cheesePictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        Cheese = Nodes[x / 10, y / 10];
                        break;
                }
            }
            catch (Exception)
            {
                return;
            }
            
            g.FillRectangle(b, x, y, cellSize, cellSize);
            g.DrawRectangle(p, x, y, cellSize, cellSize);
            supermarketPictureBox.Refresh();
        }

        /// <summary>
        /// Place the nodes into the gridarray
        /// </summary>
        private void PlaceNodes()
        {
            Nodes = new Node[gridSize, gridSize];
            for (int h = 0; h < gridSize; h++)
            {
                for (int v = 0; v < gridSize; v++)
                {
                    Nodes[h, v] = new Node(h + "," + v)
                    {
                        YPos = v,
                        XPos = h
                    };
                }
            }

            // creates edges for all nodes
            for (int h = 0; h < gridSize; h++)
            {
                for (int v = 0; v < gridSize; v++)
                {
                    CreateEdges(h, v);
                }
            }
        }

        private void UpdateSimulation(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
            speedTextBox.Text += "1";

            foreach (Shopper shopper in shoppers)
            {
                shopper.Move();
            }

            myTimer.Enabled = true;
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (RunSimulation == false)
            {
                myTimer = new Timer();
                myTimer.Interval = Convert.ToInt32(speedTextBox.Text);
                myTimer.Tick += new EventHandler(UpdateSimulation);
                myTimer.Start();
                RunSimulation = true;
                beginButton.Text = "Simulation running";
            }

        }

        /// <summary>
        /// Creates edges between all the nodes
        /// </summary>
        /// <param name="h">horizontal place in the gridarray</param>
        /// <param name="v">vertical place in the gridarray</param>
        private void CreateEdges(int h, int v)
        {
            if (h != gridSize - 1)
            Nodes[h, v].AddEgde(Nodes[h + 1, v]); // højre
            if (h != 0)
            Nodes[h, v].AddEgde(Nodes[h - 1, v]); // venstre
            if (v != gridSize - 1)
            Nodes[h, v].AddEgde(Nodes[h, v + 1]); // ned
            if (v != 0)
            Nodes[h, v].AddEgde(Nodes[h, v - 1]); // op

            if (h != gridSize - 1 && v != gridSize - 1)
            Nodes[h, v].AddEgde(Nodes[h + 1, v + 1]); // skrå ned højre
            if (h != gridSize - 1 && v != 0)
            Nodes[h, v].AddEgde(Nodes[h + 1, v - 1]); // skrå op højre
            if (h != 0 && v != gridSize - 1)
            Nodes[h, v].AddEgde(Nodes[h - 1, v + 1]); // skrå ned venstre
            if (h != 0 && v != 0)
            Nodes[h, v].AddEgde(Nodes[h - 1, v - 1]); // skrå op venstre
        }

        private void wallButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Wall";
        }

        private void walkableButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Walkable";
        }

        private void fruitButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Fruit";
        }

        private void meatButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Meat";
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Checkout";
        }

        private void shopperButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Shopper";
        }

        private void breadButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Bread";
        }

        private void cheeseButton_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text = "Cheese";
        }
    }
}
