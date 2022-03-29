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
using System.Net.Http;
using Newtonsoft.Json;

namespace API
{
    public partial class Form1 : Form
    {
        public List<Student> students;
        //public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.TextBox textBox1;
        public string date, end;
        public Form1()
        {
            InitializeComponent();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar(); 
            students = new List<Student>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*string json = File.ReadAllText("student.json");
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
            listBox1.Items.Clear();
            foreach (Student student in students)
                listBox1.Items.Add(student.ToString());*/
        }

        public void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            getResponseAsync();
            foreach (Student student in students)
                listBox1.Items.Add(student.ToString());
        }
        public async Task<string> getResponseAsync()
        {
            HttpClient client = new HttpClient();
            string call = "http://radoslaw.idzikowski.staff.iiar.pwr.wroc.pl/instruction/students.json";
            string response = await client.GetStringAsync(call);
            students = JsonConvert.DeserializeObject<List<Student>>(response);
            return response;
        }
        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.ShowToday = false;
            monthCalendar1.ShowTodayCircle = false;
            date = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            end = monthCalendar1.SelectionEnd.ToString("yyyy-MM-dd");
            MessageBox.Show("DateSelected: " + date);
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = date;
        }
    }
}
