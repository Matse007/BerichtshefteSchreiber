using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace Berichtsheft
{
    public partial class Form2 : Form
    {
        public List<string> bmlist = new List<string>(); 
        public string bmnummer { get; set; }
        public string bmweekstart { get; set; }
        public string bmweekend { get; set;}
        public string bmjahr { get; set; }
        
        

        public int usageint { get; set; }

        
        
        public Form2(List<string> bms, int usage)
        {
            InitializeComponent();
            
            bmlist = null;
            bmlist = bms;
            usageint = usage;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            foreach (string bm in bmlist)
            {

                listBox1.Items.Add(bm);
                listBox2.Items.Add(bm);
                listBox3.Items.Add(bm);
                listBox4.Items.Add(bm);
            }
            //Defaulting to the first bookmark so you have a bookmark selected
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            listBox3.SelectedIndex = 0;
            listBox4.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            switch (usageint)
            {
                case 0:
                    this.bmnummer = listBox1.SelectedItem.ToString();
                    bmlist.Remove(listBox1.SelectedItem.ToString());
                   
                    break;
                case 1:
                    this.bmweekstart = listBox1.SelectedItem.ToString();
                    bmlist.Remove(listBox1.SelectedItem.ToString());
                    break;
                case 2:
                    this.bmweekend = listBox1.SelectedItem.ToString();
                    bmlist.Remove(listBox1.SelectedItem.ToString());

                    break;
                case 3:
                    this.bmjahr = listBox1.SelectedItem.ToString();
                    bmlist.Remove(listBox1.SelectedItem.ToString());
                    break;
                case 4:
                    MessageBox.Show("We had a hardcoded error prior, still same shit");
                    break;
                default:
                    MessageBox.Show("button click broke switch case is not working sadge");
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
