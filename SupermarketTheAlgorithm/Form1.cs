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
        private int cellSize = 10; // must be 10
        public Node<int>[,] Nodes { get; set; }

        public Form1()
        {
            InitializeComponent();

            // setup
            //supermarketPictureBox.Size = new Size((int)(gridSize * 13.5), (int)(gridSize * 13.5));
            Bitmap DrawArea = new Bitmap(supermarketPictureBox.Size.Width, supermarketPictureBox.Size.Height);
            supermarketPictureBox.Image = DrawArea;
            supermarketPictureBoxPaintGrid();
            PlaceNodes();
        }

        private void supermarketPictureBoxPaintGrid()
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            //int numOfCells = 20;
            //int cellSize = 10;
            Pen p = new Pen(Color.Black);

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    g.DrawRectangle(Pens.Black, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }

            //for (int y = 0; y < gridSize; ++y)
            //{
            //    g.DrawLine(p, 0, y * cellSize, gridSize * cellSize, y * cellSize);
            //}

            //for (int x = 0; x < gridSize; ++x)
            //{
            //    g.DrawLine(p, x * cellSize, 0, x * cellSize, gridSize * cellSize);
            //}
        }

        private void supermarketPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            Pen p = new Pen(Color.Black);
            SolidBrush b;
            switch (selectedTextBox.Text)
            {
                case "Wall":
                    b = new SolidBrush(Color.Black);
                    break;
                case "Walkable":
                    b = new SolidBrush(Color.White);
                    break;
                default:
                    b = new SolidBrush(Color.Black);
                    break;
            }

            // rounds down the position to a 10 (53 -> 50) to draw on the grid
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
            
            g.FillRectangle(b, x, y, cellSize, cellSize);
            g.DrawRectangle(p, x, y, cellSize, cellSize);
            supermarketPictureBox.Refresh();
        }

        /// <summary>
        /// Place the nodes into the gridarray
        /// </summary>
        private void PlaceNodes()
        {
            Nodes = new Node<int>[gridSize, gridSize];
            for (int h = 0; h < gridSize; h++)
            {
                for (int v = 0; v < gridSize; v++)
                {
                    Nodes[h, v] = new Node<int>(h + "," + v);
                }
            }
            for (int h = 0; h < gridSize; h++)
            {
                for (int v = 0; v < gridSize; v++)
                {
                    CreateEdges(h, v);
                }
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
    }
}
