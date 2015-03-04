using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace AutoEliteOCR {
    public class ParseException : Exception {
        public ParseException(string msg) : base(msg) { }
    }

    public class ConfidenceException : Exception {
         public ConfidenceException(string msg) : base(msg) { }
    }

    public class Market {
        public const string CsvHeader = "System;Station;Commodity;Sell;Buy;Demand;;Supply;;Date;";
        public const string BpcHeader = "userID;System;Station;Commodity;Sell;Buy;Demand;;Supply;;Date;";

        private const string DateFormat = "yyyy-MM-ddTHH:mm:sszzz";
        public const float MinConfidence = 0.8f;

        public Exception Error; 

        public string SystemName;
        public string StationName;
        public DateTime Date;

        public List<Commodity> Commodities = new List<Commodity>();
        public List<Commodity> Ignored     = new List<Commodity>();


        public string ToCsv() {
            var sb = new StringBuilder();

            foreach (var str in Commodities.Select(c => String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};",
                SystemName, StationName, c.Name, c.Sell, c.Buy,
                c.Demand, c.DemandLevel, c.Supply, c.SupplyLevel,
                Date.ToString(DateFormat)))
            ) {
                sb.AppendLine(str);
            }

            return sb.ToString();
        }

        public string ToBpc() {
            var sb = new StringBuilder();

            foreach (var str in Commodities.Select(c => String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};",
                Settings.Default.UserId, SystemName, StationName, 
                c.Name, c.Sell, c.Buy,
                c.Demand, c.DemandLevel, c.Supply, c.SupplyLevel,
                Date.ToString(DateFormat)))
            ) {
                sb.AppendLine(str);
            }

            return sb.ToString();
        }

        public static Market FromXml(XmlDocument doc) {
            var market = new Market();
            var res = doc.SelectNodes("/ocrresult");
            if (res == null || res.Count < 1) throw new Exception("Invalid XML");
            var xml_setup = res[0]["setup"];
            var xml_loc = res[0]["location"];
            var xml_market = res[0]["market"];
            if(xml_setup == null || xml_loc == null || xml_market == null) throw new ParseException("Invalid XML");
            
            if (xml_setup["filetimestamp"] == null || xml_setup["ocrtime"] == null) 
                throw new ParseException("No file and parse timestamps found");
            var a = Convert.ToDateTime(xml_setup["filetimestamp"].InnerText);
            var b = Convert.ToDateTime(xml_setup["ocrtime"].InnerText);
            
            market.Date = a > b ? a : b;

            if(xml_loc["system"] == null) throw new ParseException("No system name found, make sure eliteOCR works properly");
            if (xml_loc["station"] == null) throw new ParseException("No station name found, invalid xml.");

            market.SystemName = xml_loc["system"].InnerText;
            market.StationName = xml_loc["station"].InnerText;

            var conf = Convert.ToDouble(xml_loc["station"].Attributes["conf"].InnerText);
            if(conf < Market.MinConfidence) throw new ConfidenceException("Confidence of system name is to low");

            foreach (XmlElement entry in xml_market.ChildNodes) {
                var c = Commodity.FromXmlEntry(entry);
                if (c.Confidence >= Market.MinConfidence)
                    market.Commodities.Add(c);
                else
                    market.Ignored.Add(c);
            }
            

            return market;
        }

    }

    public class Commodity {
        public float Confidence = 1.0f;
        public string Name = null;
        public int? Sell = null;
        public int? Buy = null;
        public int? Demand = null;
        public string DemandLevel = null;
        public int? Supply = null;
        public string SupplyLevel = null;

        public static readonly Dictionary<string, string> XmlLookup = new Dictionary<string, string> {
            { "Name", "commodity" },
            { "Sell", "sell" },
            { "Buy", "buy" },
            { "Demand", "demand" },
            { "DemandLevel", "demandlevel" },
            { "Supply", "supply" },
            { "SupplyLevel", "supplylevel" }
        }; 
        public static Commodity FromXmlEntry(XmlElement entry) {
            var c = new Commodity();

            float conf = 1.0f;
            XmlElement el;
            FieldInfo prop;

            foreach (var kvp in XmlLookup) {
                prop = c.GetType().GetField(kvp.Key);
                el = entry[kvp.Value];
                // null set continue
                if (el == null || el.InnerText == String.Empty) continue;
                
                // set confidence to minimum found
                conf = Math.Min(conf, float.Parse(el.GetAttribute("conf")));
                
                if (conf < Market.MinConfidence) continue;

                // Convert the value type and set the value
                Type t = Nullable.GetUnderlyingType(prop.FieldType) ?? prop.FieldType;
                prop.SetValue(c, Convert.ChangeType(el.InnerText, t));
                
            }

            c.Confidence = conf;

            return c;
        }
    }
}
