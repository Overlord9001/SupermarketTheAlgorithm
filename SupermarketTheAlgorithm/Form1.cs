using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupermarketTheAlgorithm.MyList;


namespace SupermarketTheAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
    }
}
