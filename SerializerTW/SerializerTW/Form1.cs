using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerializerTW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DirectoryInfo taskDirectory = new DirectoryInfo(@"C:\cica\");
            FileInfo[] taskFiles = taskDirectory.GetFiles("person*.dat");
            Person.IDCounter = taskFiles.Length;
            InitializeComponent();
            if (File.Exists(@"C:\cica\person0.dat"))
            {
                Person person = Person.DeSerialize(true);
                FillText(person);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Person person = new Person(textBox1.Text, textBox3.Text, textBox2.Text);
            MessageBox.Show("person saved");
            person.Serialize();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\cica\person0.dat"))
            {
                try
                {
                    Person person = Person.DeSerialize(true);
                    FillText(person);
                } catch (FileNotFoundException ex)
                {
                    MessageBox.Show("No more files");
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\cica\person0.dat"))
            {
                Person person = Person.DeSerialize(false);
                FillText(person);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\cica\person0.dat"))
            {
                Person person = Person.DeSerializeFirst();
                FillText(person);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\cica\person0.dat"))
            {
                Person person = Person.DeSerializeLast();
                FillText(person);
            }
        }

        private void FillText(Person person)
        {
            textBox1.Text = person.name;
            textBox2.Text = person.address;
            textBox3.Text = person.phone;
        }
    }
}
