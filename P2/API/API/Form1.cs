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
using System.Web.Script.Serialization;
using System.Net;

namespace API
{
    public partial class Form1 : Form
    {
        public string date, base_currency, final_currency, amt;
        public double amount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            date = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            final_currency = textBox3.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            date = DateTime.Now.ToString("yyyy-MM-dd");
            textBox2.Text = date;
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            amt = textBox4.Text;
            amount = Convert.ToDouble(amt);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            base_currency = textBox1.Text;
        }

        public async void button1_Click(object sender, EventArgs e)
        {



            var dat = getValue();
            var d = Convert.ToDouble(dat);
            var conversionRate = 1.0m;
            var result = d * amount;
            textBox6.Text = result.ToString();
            //listBox1.Items.Clear();
            //listBox1.Items.Add(dat.ToString());
        }

        public decimal getValue()
        {
            var code = $"{base_currency}_{final_currency}";
            var conversionRate = 4.0m;

            //łączenie z api
            var json = String.Empty;
            var webClient = new WebClient();
            string call = "https://free.currconv.com/api/v7/convert?q=" + base_currency + "_" + final_currency + "," + final_currency + "_" + base_currency + "&compact=ultra&date=" + date + "&apiKey=6e518d133c379bc395df";
            json = webClient.DownloadString(call);

            //testy na pliku
            //string json = File.ReadAllText("student.json");
            
            textBox5.Text = json;
            var jsonObject = new JavaScriptSerializer().Deserialize<Dictionary<string, Dictionary<string, decimal>>>(json);
            var result = jsonObject[code];
            conversionRate = result[date];

            return conversionRate;
        }
    }
}
