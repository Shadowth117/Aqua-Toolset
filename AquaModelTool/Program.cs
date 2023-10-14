using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaModelTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
      {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AquaModelTool aquaModelTool = new AquaModelTool();
            Application.Run(aquaModelTool);
            if (args.Length > 0)
            {
                aquaModelTool.AquaUIOpenFile(args[0]);
            }
        }
    }
}
