using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StockTicker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StockTicker.Controllers
{
    public class StockTickerController : Controller
    {
        // GET: StockTicker
        public ActionResult Index()
        {
            ViewBag.Title = "Stock Ticker";

            return View();
        }

        public string GetStocks(string stockUrl)
        {
            if (string.IsNullOrEmpty(stockUrl)) stockUrl = "MCI+DIS+COKE+PEP&f=sl1d1t1c1";
            List<StockTickerModel> result = GetFewStocks(stockUrl);
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(result, Formatting.None, settings); 
        }

        private List<StockTickerModel> GetFewStocks(string stockUrl)
        {
            List<StockTickerModel> stockInfoModel = new List<StockTickerModel>();
                 string base_url =  "http://download.finance.yahoo.com/d/quotes.csv?s=" + stockUrl;
                try
                { 
                    return GetWebResponse(base_url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Read Error");
                }
            return stockInfoModel;
        }
        // Get a web response.
        protected List<StockTickerModel> GetWebResponse(string url)
        {
            // Make a WebClient.
            WebClient web_client = new WebClient();
            // Get the indicated URL.
            Stream response = web_client.OpenRead(url);
            List<string[]> _tempList = new List<string[]>();
            // Read the result.
            using (StreamReader stream_reader = new StreamReader(response))
            {
                string currentLine;
                while ((currentLine = stream_reader.ReadLine()) != null)
                {
                    string[] temp = currentLine.Split(new char[] { ',' }, StringSplitOptions.None).Select(x => x.Replace(@"""", "")).ToArray();
                    _tempList.Add(temp);
                }
                stream_reader.Close();
                var stocks = _tempList.Select(stock => new StockTickerModel { Symbol = stock.ElementAt(0).ToString(), Value = stock.ElementAt(1).ToString(), LastUpdatedDate = stock.ElementAt(2).ToString(), LastUpdatedTime = stock.ElementAt(3).ToString(), Change = stock.ElementAt(4).ToString() });
                return stocks.ToList();
            }
        }
    }
}