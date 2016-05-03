using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTicker.Controllers;
using System.Web.Mvc;


namespace StockTicker.Tests.Controllers
{
    [TestClass]
    public class StockTickerControllerTest
    {
        [TestMethod]
        public void IsStockTickerControllerRunning()
        {
            StockTickerController controller = new StockTickerController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Stock Ticker", result.ViewBag.Title);

        }

        [TestMethod]
        public void IsStockApiWorking()
        {
            StockTickerController controller = new StockTickerController();
            string stockUrl = "s=MSFT+GOOG+FB+ORCL&f=sl1d1t1c1";
            string result = controller.GetStocks(stockUrl);
            Assert.IsNotNull(result);
        }
    }
}
