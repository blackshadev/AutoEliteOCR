using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoEliteOCR {
    static class Program {
        internal static AutoEliteOCR AutoEliteOcr;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Directory.CreateDirectory("./tmp");
            AutoEliteOcr = new AutoEliteOCR();
            Application.Run(AutoEliteOcr);
        }

    }
}
