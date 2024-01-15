using System.Text;

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
            //CRITICAL, without this, shift jis handling will break and kill the application
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
