using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //backgroundWorker1.WorkerReportsProgress = true;
        }
        int procent;
        int maxValue = 0;
        public int Fibonacci_Count(int counter, int last, int i)
        {
           procent = Convert.ToInt32((double)(((i - 1) - maxValue) * -1) / (double)maxValue * 100);
           this.Invoke(new ThreadStart(delegate { progressBar1.Value = procent; }));
            if (i == 0)
                return counter;
            else if( i == 1)
                return counter;
            else
                return Fibonacci_Count(counter + last, counter, i - 1);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void begin_Click(object sender, EventArgs e)
        {
            //Thread inprocess = new Thread(progressChange);
            maxValue = (int)textBox1.Value;
            begin.Enabled = false;
            textBox1.Enabled = false;
            //inprocess.Start();
            textBox2.Text = Convert.ToString(Fibonacci_Count(1, 0, maxValue));
            maxValue = 0;
            begin.Enabled = true;
            textBox1.Enabled = true;
        }

        void progressChange()
        {
            progressBar1.Value = procent;
        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {

        }

        private void begin2_Click(object sender, EventArgs e)
        {
            maxValue = (int)numericUpDown1.Value;
            begin2.Enabled = false;
            numericUpDown1.Enabled = false;
            //inprocess.Start();
            textBox3.Text = Convert.ToString(Factorial_Count(1, maxValue));
            maxValue = 0;
            begin2.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        public int Factorial_Count(int counter, int i)
        {
            procent = Convert.ToInt32((double)(((i - 1) - maxValue) * -1) / (double)maxValue * 100);
            this.Invoke(new ThreadStart(delegate { progressBar2.Value = procent; }));
            if (i == 1)
                return counter;
            else
                return Factorial_Count(counter * i, i - 1);
        }

        private void begin3_Click(object sender, EventArgs e)
        {
            maxValue = (int)numericUpDown3.Value;
            begin3.Enabled = false;
            numericUpDown2.Enabled = false;
            //inprocess.Start();
            textBox4.Text = Convert.ToString(Sqrt_Count((int)numericUpDown2.Value, maxValue));
            maxValue = 0;
            begin3.Enabled = true;
            numericUpDown2.Enabled = true;
        }
        public int Sqrt_Count(int counter, int i)
        {
            procent = Convert.ToInt32((double)(((i - 1) - maxValue) * -1) / (double)maxValue * 100);
            this.Invoke(new ThreadStart(delegate { progressBar3.Value = procent; }));
            if (i == 1)
                return counter;
            else
                return Sqrt_Count(counter * (int)numericUpDown2.Value, i - 1);
        }
    }
}
