using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchDojo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("sonka");
            listBox1.Items.Add("répa mogyoró saláta");
            listBox1.Items.Add("A róka szereti a fókát");
            listBox1.Items.Add("Fikusz Kukisz");
            listBox1.Items.Add("Ki tudja merre jár a kerge marha?");
            listBox1.Items.Add("Oo oo, livin on a prayer!");
            listBox1.Items.Add("Take my hand, we'll make it I swear");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            String pattern = textBox1.Text;
            foreach(String line in listBox1.Items)
            {
                if (Regex.IsMatch(line, pattern)) listBox2.Items.Add(line);
            }
        }
    }
}
