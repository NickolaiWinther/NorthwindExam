using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindExam.WebService
{
    public class RatesWebService
    {
        //private readonly string accessKey = "313cb2de1aad4ad8914c1dbfc82f30c2";

        public (Rates rates, bool isValid)GetRates(string accessKey = "313cb2de1aad4ad8914c1dbfc82f30c2")
        {
            string url = $"https://openexchangerates.org/api/latest.json?app_id={accessKey}";

            Task<string> resultTask = CallWebApi(url);
            try
            {
            return (UnpackFrom(resultTask.Result), true);
            }
            catch (Exception)
            {
                return (new Rates(), false);
                throw;
            }
        }


        private async Task<string> CallWebApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url).ConfigureAwait(false);
            }
        }
        private Rates UnpackFrom(string json)
        {
            RatesExchange ratesExchange = JsonConvert.DeserializeObject<RatesExchange>(json);
            return ratesExchange.Rates;
        }
    }
}
