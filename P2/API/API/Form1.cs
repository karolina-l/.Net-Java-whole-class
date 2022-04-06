using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;
using System.Data.Entity;
using System.Net;

namespace API
{
    public partial class Form1 : Form
    {
        public string date, base_currency, final_currency, amt;
        public double amount;
        Currency test = new Currency();

        public Bank bank;

        public Form1()
        {
            InitializeComponent();
            bank = new Bank();
            //bank.SaveChanges();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(var c in bank.Currencies)
            {
                bank.Currencies.Remove(c);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            base_currency = textBox1.Text;
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            amount = Convert.ToDouble(amt);

            test.base_currency_ = base_currency;
            test.final_currency_ = final_currency;
            test.date_ = date;
            test.rate_ = getRate(date);

            bank.Currencies.Add(test);
            bank.SaveChanges();
            //textBox5.Text = bank.Currencies.ToString();
            foreach (var c in bank.Currencies)
            {
                listBox1.Items.Add(c.ToString());
            }

            var d = Convert.ToDouble(test.rate_);
            var result = d * amount;
            textBox6.Text = result.ToString();
            //listBox1.Items.Clear();
            //listBox1.Items.Add(dat.ToString());
        }

        public decimal getRate(string dd)
        {
            var code = $"{base_currency}_{final_currency}";
            var conversionRate = 4.0m;

            //łączenie z api
            /*var json = String.Empty;
            var webClient = new WebClient();
            string call = "https://free.currconv.com/api/v7/convert?q=" + base_currency + "_" + final_currency + "," + final_currency + "_" + base_currency + "&compact=ultra&date=" + dd + "&apiKey=6e518d133c379bc395df";
            json = webClient.DownloadString(call);*/

            //testy na pliku
            string json = File.ReadAllText("student.json");
            
            //textBox5.Text = json;
            var jsonObject = new JavaScriptSerializer().Deserialize<Dictionary<string, Dictionary<string, decimal>>>(json);
            var result = jsonObject[code];
            conversionRate = result[date];

            return conversionRate;
        }

        /*public Dictionary<string, decimal> getOlderRates()
        {
            Dictionary<string, decimal> olderRates = new Dictionary<string, decimal>();
            DateTime nowDate = Convert.ToDateTime(date);
            decimal olderRate;
            DateTime oldDate = nowDate.AddDays(-1);
            textBox5.Text = oldDate.ToString();
            olderRates.Add(oldDate.ToString(), 3.0m);
            olderRates.Add(date.ToString(), 2.0m);
            for(int i = 0; i < 5; i++)
            {
                DateTime oldDate = nowDate.AddDays(-1);
                string od = oldDate.ToString();
                textBox5.Text = od;
                olderRate = getRate(od);
            }

            return olderRates;
        }*/
    }
}
