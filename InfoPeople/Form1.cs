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

            var records = RecordsXML.Get().PeopleList;
            uint peopleSum = 0;
            int peopleCount = 0;

            foreach (var rec in records)
            {

                if (rec.city == comboBox1.GetItemText(comboBox1.SelectedItem)) // не видит значения
                {
                    peopleSum += rec.age;
                    peopleCount++;
                }
            }

            var peopleAvg = peopleSum / peopleCount;

            label1.Text = peopleAvg.ToString() + "лет";
        }

        public static long[] GetAvg()
        {
            var records = RecordsXML.Get().PeopleList;
            uint peopleSum = 0;
            int peopleCount = 0;

            foreach (var rec in records)
            {
                peopleSum += rec.age;
                peopleCount++;
            }

            var peopleAvg = peopleSum / peopleCount;

            var result = new long[] { peopleAvg };
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            RecordsXML.Generate(100);           
            dataGridView1.DataSource = RecordsXML.Get().PeopleList;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
