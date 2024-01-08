using AquaModelLibrary.Core.LegacyObjPort;
using AquaModelLibrary.Data.PSO2.Aqua;

namespace AquaAutoRig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                DisplayUsage();
            }
            else
            {
                foreach (var arg in args)
                {
                    switch (Path.GetExtension(arg))
                    {
                        case ".aqp":
                        case ".aqo":
                        case ".trp":
                        case ".tro":
                            string backup = Path.ChangeExtension(arg, ".org.aqp");
                            if (File.Exists(backup))
                            {
                                File.Delete(backup);
                            }
                            File.Copy(arg, backup);
                            var aqpName = arg;
                            var aqp = new AquaPackage(File.ReadAllBytes(aqpName));
                            LegacyObjIO.ExportObj(Path.ChangeExtension(aqpName, ".obj"), aqp.models[0]);
                            break;
                        case ".obj":
                            var outAqp = new AquaPackage(File.ReadAllBytes(Path.ChangeExtension(arg, ".org.aqp")));
                            var model = LegacyObjIO.ImportObj(arg, outAqp.models[0]);
                            string outName = Path.ChangeExtension(arg, ".aqp");
                            File.WriteAllBytes(outName, new AquaPackage(model).GetPackageBytes(outName));
                            break;
                        default:
                            DisplayUsage();
                            break;
                    }
                }
            }
        }

        private static void DisplayUsage()
        {
            Console.WriteLine("usage: " +
                "\nAquaAutoRig.exe model.aqp" +
                "\nAquaAutoRig.exe model.obj" +
                "\nFeeding the program an aqp will create an .obj, .mtl, and .org.aqp of the same name as the given file." +
                "\nFeeding the program an .obj will have it use the .org.aqp of the same name as a base." +
                "\nProps to the anonymous creator of aqp2obj for the original program. ありがとうございます。" +
                "\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}
