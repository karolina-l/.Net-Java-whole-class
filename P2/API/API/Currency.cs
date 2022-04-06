using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace API
{
    public class Currency
    {
        public int Id { get; set; }
        public string base_currency_ { get; set; }
        public string final_currency_ { get; set; }
        public string date_ { get; set; }
        public decimal rate_ { get; set; }

        /*public Currency()
        {
            base_currency_ = "0";
            final_currency_ = "0";
            date_ = "0";
            rate_ = 0;
        }
        public Currency( string bc, string fc, string d, decimal r)
        {
            base_currency_ = bc;
            final_currency_ = fc;
            date_ = d;
            rate_ = r;
        }*/

        public override string ToString()
        {
            return Id.ToString() + ", " + base_currency_ + "_" + final_currency_ + ", " + rate_.ToString();
        }
    }  
}
