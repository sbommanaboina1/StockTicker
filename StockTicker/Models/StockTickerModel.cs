using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTicker.Models
{
    public class StockTickerModel
    {

            public string Symbol { get; set; }

            public string Value { get; set; }

            public DateTime LastUpdated { get; set; }

            public string LastUpdatedDate { get; set; }

           public string LastUpdatedTime { get; set; }

           public string Change { get; set; }

    }
}