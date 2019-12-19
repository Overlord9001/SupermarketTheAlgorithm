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
        public static Label failedShoppers;

        public bool RunSimulation { get; set; } = false;
        public Node[,] Nodes { get; set; }
        public MyLinkedList<Shopper> shoppers = new MyLinkedList<Shopper>();
        public static MyLinkedList<Shopper> checkoutList = new MyLinkedList<Shopper>();
        public static Node Meat { get; set; }
        public static Node Fruit { get; set; }
        public static Node Cheese { get; set; }
        public static Node Bread { get; set; }
        public static Node Checkout { get; set; }

        Graphics g;
        SolidBrush b;


        public Form1()
        {
            InitializeComponent();

            // setup
            Bitmap DrawArea = new Bitmap(supermarketPictureBox.Size.Width, supermarketPictureBox.Size.Height);
            supermarketPictureBox.Image = DrawArea;
            supermarketPictureBoxPaintGrid();
            PlaceNodes(gridSize);
            fruitPictureBox.BackColor = Color.ForestGreen;
            meatPictureBox.BackColor = Color.DarkRed;
            checkoutPictureBox.BackColor = Color.Gray;
            shopperPictureBox.BackColor = Color.HotPink;
            wallPictureBox.BackColor = Color.Black;
            breadPictureBox.BackColor = Color.SandyBrown;
            cheesePictureBox.BackColor = Color.Yellow;

            failedShoppers = shoppersFailedLabel;
            g = Graphics.FromImage(supermarketPictureBox.Image);
            b = new SolidBrush(Color.White);
        }

        /// <summary>
        /// Paint the grid on the supermarket picturebox
        /// </summary>
        private void supermarketPictureBoxPaintGrid()
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            Pen p = new Pen(Color.Black);
            g.FillRectangle(Brushes.White, 0, 0, supermarketPictureBox.Width, supermarketPictureBox.Height);

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
            if (RunSimulation) // return if the simulation is running
            {
                return;
            }
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
                        UnassignNode(Nodes[x / 10, y / 10]);
                        break;
                    case "Walkable":
                        b = new SolidBrush(Color.White);
                        Nodes[x / 10, y / 10].isWalkable = true;
                        UnassignNode(Nodes[x / 10, y / 10]);
                        break;
                    case "Shopper":
                        b = new SolidBrush(shopperPictureBox.BackColor);
                        Nodes[x / 10, y / 10].isWalkable = true;
                        if (Nodes[x / 10, y / 10].Shopper == null) // if a shopper already exists dont add another
                        {
                            Nodes[x / 10, y / 10].Shopper = shoppers.Add(new Shopper(supermarketPictureBox, shopperPictureBox.BackColor, g)
                            {
                                CurrentNode = Nodes[x / 10, y / 10]
                            });
                        }
                        break;
                    case "Checkout":
                        b = new SolidBrush(checkoutPictureBox.BackColor);
                        UnassignNode(Nodes[x / 10, y / 10]);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        if (Checkout != null) // if a checkout already exists draw old posision white
                        {
                            Checkout.isWalkable = true;
                            g.FillRectangle(Brushes.White, Checkout.XPos * 10, Checkout.YPos * 10, cellSize, cellSize);
                            g.DrawRectangle(Pens.Black, Checkout.XPos * 10, Checkout.YPos * 10, cellSize, cellSize);
                        }
                        Checkout = Nodes[x / 10, y / 10];
                        break;
                    case "Fruit":
                        b = new SolidBrush(fruitPictureBox.BackColor);
                        UnassignNode(Nodes[x / 10, y / 10]);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        if (Fruit != null)
                        {
                            Fruit.isWalkable = true;
                            g.FillRectangle(Brushes.White, Fruit.XPos * 10, Fruit.YPos * 10, cellSize, cellSize);
                            g.DrawRectangle(Pens.Black, Fruit.XPos * 10, Fruit.YPos * 10, cellSize, cellSize);
                        }
                        Fruit = Nodes[x / 10, y / 10];
                        break;
                    case "Meat":
                        b = new SolidBrush(meatPictureBox.BackColor);
                        UnassignNode(Nodes[x / 10, y / 10]);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        if (Meat != null)
                        {
                            Meat.isWalkable = true;
                            g.FillRectangle(Brushes.White, Meat.XPos * 10, Meat.YPos * 10, cellSize, cellSize);
                            g.DrawRectangle(Pens.Black, Meat.XPos * 10, Meat.YPos * 10, cellSize, cellSize);
                        }
                        Meat = Nodes[x / 10, y / 10];
                        break;
                    case "Bread":
                        b = new SolidBrush(breadPictureBox.BackColor);
                        UnassignNode(Nodes[x / 10, y / 10]);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        if (Bread != null)
                        {
                            Bread.isWalkable = true;
                            g.FillRectangle(Brushes.White, Bread.XPos * 10, Bread.YPos * 10, cellSize, cellSize);
                            g.DrawRectangle(Pens.Black, Bread.XPos * 10, Bread.YPos * 10, cellSize, cellSize);
                        }
                        Bread = Nodes[x / 10, y / 10];
                        break;
                    case "Cheese":
                        b = new SolidBrush(cheesePictureBox.BackColor);
                        UnassignNode(Nodes[x / 10, y / 10]);
                        Nodes[x / 10, y / 10].isWalkable = false;
                        if (Cheese != null)
                        {
                            Cheese.isWalkable = true;
                            g.FillRectangle(Brushes.White, Cheese.XPos * 10, Cheese.YPos * 10, cellSize, cellSize);
                            g.DrawRectangle(Pens.Black, Cheese.XPos * 10, Cheese.YPos * 10, cellSize, cellSize);
                        }
                        Cheese = Nodes[x / 10, y / 10];
                        break;
                }

                // if a shopper is on the place clicked, remove that shopper
                if (Nodes[x / 10, y / 10].Shopper != null && b.Color != shopperPictureBox.BackColor)
                {
                    shoppers.Remove(Nodes[x / 10, y / 10].Shopper);
                }
            }
            catch (Exception)
            {
                return;
            }
            
            g.FillRectangle(b, x, y, cellSize, cellSize);
            g.DrawRectangle(p, x, y, cellSize, cellSize);
            supermarketPictureBox.Refresh();
            CheckAndActivateBeginButton(); // check if the begin button should activate
        }

        /// <summary>
        /// Place the nodes into the gridarray
        /// </summary>
        public void PlaceNodes(int gridSize)
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

        /// <summary>
        /// Updates the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSimulation(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
            int finishedShoppers = 0;
            int checkoutShoppers = 0;
            foreach (Shopper shopper in shoppers)
            {
                if (!shopper.finished && !shopper.inCheckout)
                {
                    shopper.Move();
                }
                else if (shopper.finished)
                {
                    finishedShoppers++;
                    statusLabel.Text = $"{finishedShoppers} shopper(s) finished";
                }
                else if (shopper.inCheckout)
                {
                    if (shopper.checkoutTimer >= 5)
                    {
                        shopper.finished = true;
                        checkoutLabel.Text = $"{checkoutShoppers} shopper(s) in queue";
                    }
                    else
                    {
                        shopper.checkoutTimer++;
                        checkoutShoppers++;
                        checkoutLabel.Text = $"{checkoutShoppers} shopper(s) in queue";
                    }
                    
                }
            }

            myTimer.Enabled = true;

            // if all shoppers are finished stop the simulation
            if (finishedShoppers == shoppers.Count)
            {
                foreach (Shopper item in shoppers) // draw all shoppers white on reset
                {
                    g.FillRectangle(b, item.CurrentNode.XPos * 10, item.CurrentNode.YPos * 10, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, item.CurrentNode.XPos * 10, item.CurrentNode.YPos * 10, cellSize, cellSize);
                }
                supermarketPictureBox.Refresh();
                
                myTimer.Stop();
                RunSimulation = false;
                beginButton.Enabled = true;
                shoppers = new MyLinkedList<Shopper>();
                foreach (Node item in Nodes) // resets shoppers so that they can be placed on the same spots again after reset
                {
                    item.Shopper = null;
                }
            }

            
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (RunSimulation == false)
            {
                foreach (Shopper shopper in shoppers) // generate a shoppinglist for all shoppers when starting
                {
                    shopper.GenerateShoppingList();
                }
                // create a timer that updates the simulation
                myTimer = new Timer();
                myTimer.Interval = Convert.ToInt32(speedTextBox.Text);
                myTimer.Tick += new EventHandler(UpdateSimulation);
                myTimer.Start();
                RunSimulation = true;
                beginButton.Enabled = false;
                statusLabel.Text = "Simulation running";
                failedShoppers.Visible = false;
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

        #region clickEvents
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
        #endregion

        /// <summary>
        /// Check if all requirements for beginning the simulation is met
        /// </summary>
        private void CheckAndActivateBeginButton()
        {
            if (Fruit != null && Meat != null && Bread != null && Cheese != null && Checkout != null && shoppers.Count > 0)
            {
                beginButton.Enabled = true;
            }
            else
            {
                beginButton.Enabled = false;
            }
        }

        private void UnassignNode(Node node)
        {
            if (Meat == node)
                Meat = null;
            if (Fruit == node)
                Fruit = null;
            if (Bread == node)
                Bread = null;
            if (Cheese == node)
                Cheese = null;
        }
    }
}
