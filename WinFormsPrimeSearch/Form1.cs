using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompulsoryAssignmentPP;

namespace WinFormsPrimeSearch
{
    public partial class Form1 : Form
    {
        private long lowInput;
        private long highInput;
        private PrimeGenerator pg;
        public Form1()
        {
            InitializeComponent();
            // Set the ListBox to display items in multiple columns.
            listBox1.MultiColumn = true;
            // Set the selection mode to multiple and extended.
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            pg = new PrimeGenerator();
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
            if (!CheckIfValidInput())
                return;
            var uictx = TaskScheduler.FromCurrentSynchronizationContext();


            Task.Factory.StartNew(() =>
            {
                var list = pg.GetPrimesSequential(lowInput, highInput);
                return list;
            }).ContinueWith((result) =>
            {
                listBox1.BeginUpdate();
                listBox1.DataSource = result.Result;
                listBox1.EndUpdate();
            }, uictx);
        }

        //Parallel
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckIfValidInput())
                return;
            var uictx = TaskScheduler.FromCurrentSynchronizationContext();


            Task.Factory.StartNew(() =>
            {
                var list = pg.GetPrimesParallel(lowInput, highInput);
                return list;
            }).ContinueWith((result) =>
            {
                listBox1.BeginUpdate();
                listBox1.DataSource = result.Result;
                listBox1.EndUpdate();
            }, uictx);
        }
    }
}
