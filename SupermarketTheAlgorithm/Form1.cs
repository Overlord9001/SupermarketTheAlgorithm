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
        private int gridSize = 10;
        public Node[,] Nodes { get; set; }

        public Form1()
        {
            InitializeComponent();

            Bitmap DrawArea = new Bitmap(supermarketPictureBox.Size.Width, supermarketPictureBox.Size.Height);
            supermarketPictureBox.Image = DrawArea;
            supermarketPictureBoxPaintGrid();

            PlaceNodes();

            // old testing code
            //MyList.MyLinkedList<int> list = new MyList.MyLinkedList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);

            //list.Remove(3);

            //string tmp = "";
            //foreach (var item in list)
            //{
            //    tmp = tmp + item.ToString() + " ";
            //}
            //testTextBox.Text = tmp;
        }

        private void supermarketPictureBoxPaintGrid()
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            //int numOfCells = 20;
            int cellSize = 10;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < gridSize; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, gridSize * cellSize, y * cellSize);
            }

            for (int x = 0; x < gridSize; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, gridSize * cellSize);
            }
        }

        private void supermarketPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(supermarketPictureBox.Image);
            SolidBrush b = new SolidBrush(Color.Blue);
            if (true)
            {

            }
            g.FillRectangle(b, e.X, e.Y, 10, 10);
            supermarketPictureBox.Refresh();
        }

        private void PlaceNodes()
        {
            Nodes = new Node[gridSize, gridSize];
            for (int h = 0; h < gridSize; h++)
            {
                for (int v = 0; v < gridSize; v++)
                {
                    Nodes[h, v] = new Node(h + "," + v);
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
    }
}
