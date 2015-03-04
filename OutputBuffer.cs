using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEliteOCR {
    class OutputBuffer {
        public List<Market> Markets = new List<Market>();
        public int AcceptedCount { get { return Markets.Sum(m => m.Commodities.Count); } }
        public int IgnoredCount { get  { return Markets.Sum(m => m.Ignored.Count); } }


        public delegate void CountChangeCallback(object s, int acc, int ign);
        public event CountChangeCallback CountChanged;

        public void Add(Market m) {
            lock (Markets) {
                Markets.Add(m);
            }
            if (CountChanged != null) CountChanged(this, AcceptedCount, IgnoredCount);
        }

        public int Flush() {

            switch (Settings.Default.ExportType) {
                case "bpc":
                    return ToBpc();
                default:
                    return ToCsv();
            }
            
        }

        protected int ToCsv() {
            var sb = new StringBuilder();
            sb.AppendLine(Market.CsvHeader);

            int i = 0;
            lock (Markets) {
                foreach (var m in Markets) {
                    i += m.Commodities.Count;
                    sb.Append(m.ToCsv());
                }
                Markets.Clear();
            }

            string path = Settings.Default.CsvFolder + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

            if (i > 0) File.WriteAllText(path, sb.ToString());
            if (CountChanged != null) CountChanged(this, AcceptedCount, IgnoredCount);

            return i;
        }

        protected int ToBpc() {
            var sb = new StringBuilder();
            sb.AppendLine(Market.BpcHeader);

            int i = 0;
            lock (Markets) {
                foreach (var m in Markets) {
                    i += m.Commodities.Count;
                    sb.Append(m.ToBpc());
                }
                Markets.Clear();
            }

            string path = Settings.Default.CsvFolder + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bpc";

            if (i > 0) File.WriteAllText(path, sb.ToString());
            if (CountChanged != null) CountChanged(this, AcceptedCount, IgnoredCount);

            return i;
        }
    }
}
