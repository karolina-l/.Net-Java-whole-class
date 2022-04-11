using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class CurrencyDraw
    {
        private decimal rate { get; set; }
        private DateTime date { get; set; }
        public decimal Rate   // property
        {
            get { return rate; }   // get method
            set { rate = value; }  // set method
        }
        public DateTime Date   // property
        {
            get { return date; }   // get method
            set { date = value; }  // set method
        }
    }
}
