using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace InfoPeople
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RecordsXML.Generate(100);
            label1.Text = Convert.ToString(Form1.GetAvg()) + "лет";

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            RecordsXML.Generate(100);

            List<People> oblst = new List<People>();
            var list = new BindingList<People>();
             dataGridView1.DataSource = list;
            
            dataGridView1.AutoGenerateColumns = true;

            // Set up the data source.
           // bindingSource1.DataSource = GetData("Select * From Products");


        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* comboBox1.Items.Add("Кемерово");
            comboBox1.Items.Add("Новосибирск");
            comboBox1.Items.Add("Москва");
            comboBox1.Items.Add("Новокузнецк");
            comboBox1.Items.Add("Омск");
            comboBox1.Items.Add("Томск");
            comboBox1.Items.Add("Нижний Новгород");
            comboBox1.Items.Add("СПБ");
            comboBox1.Items.Add("Калининград");
            */
        }

        public static long[] GetAvg()
        {
            var records = RecordsXML.Get().PeopleList;
            uint peopleSum = 0;
            int peopleCount = 0;

            Form1 f = new Form1();
            
            Object selectedItem = f.comboBox1.SelectedItem;
            MessageBox.Show("Selected Item Text: " + selectedItem.ToString());

            foreach (var rec in records)
            {
                
                if (rec.city == f.comboBox1.GetItemText(f.comboBox1.SelectedItem)) // не видит значения
                {
                    peopleSum += rec.age;
                    peopleCount++;
                }
            }

            var peopleAvg = peopleSum / peopleCount;


            var result = new long[] { peopleAvg };
            return result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
