using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace API
{
    public class Currency
    {
        //wszystko co jest w tej klasie jest spisane z neta, bo to już był szczyt moich możliwości wczoraj.
        //Nawet nie do końca wiem jak to działa XD
        private readonly String BASE_URI = "https://free.currconv.com/";
        private readonly String API_VERSION = "v7";

        public Decimal GetCurrencyExchange(String localCurrency, String foreignCurrency)
        {
            var code = $"{localCurrency}_{foreignCurrency}";
            var newRate = FetchSerializedData(code);
            return newRate;
        }

        public Decimal FetchSerializedData(String code)
        {
            var url = $"{BASE_URI}/api/{API_VERSION}/convert?q={code}&compact=y";
            var webClient = new WebClient();
            var jsonData = String.Empty;

            var conversionRate = 1.0m;
            try
            {
                jsonData = webClient.DownloadString(url);
                var jsonObject = new JavaScriptSerializer().Deserialize<Dictionary<string, Dictionary<string, decimal>>>(jsonData);
                var result = jsonObject[code];
                conversionRate = result["val"];

            }
            catch (Exception) { }

            return conversionRate;
        }
    }
}
