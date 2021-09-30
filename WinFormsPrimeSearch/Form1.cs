using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsPrimeSearch
{
    public partial class Form1 : Form
    {
        long lowInput;
        long highInput;
        public Form1()
        {
            InitializeComponent();
            // Set the ListBox to display items in multiple columns.
            listBox1.MultiColumn = true;
            // Set the selection mode to multiple and extended.
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        private bool CheckIfValidInput()
        {
            
            try
            {
                lowInput = long.Parse(textBox1.Text);
                highInput = long.Parse(textBox2.Text);
            }
            catch (Exception e)
            {
                return false;
            }

            return lowInput < highInput;
        }

        //Sequential
        private void button1_Click(object sender, EventArgs e)
        {
            if(!CheckIfValidInput())
                return;

            listBox1.BeginUpdate();
            //add The stuff here
            listBox1.EndUpdate();
        }

        //Parallel
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckIfValidInput())
                return;

            listBox1.BeginUpdate();
            //add The stuff here
            listBox1.EndUpdate();
        }
    }
}
