using AquaModelLibrary;
using AquaModelLibrary.AquaMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AquaModelLibrary.CharacterMakingIndex;
namespace CMXPatcher
{
    public static class HAIRStructHandler
    {
        //Converts a body struct's accessible contents to text
        //Currently strings and such are left alone, though that could be changed in the future
        //Some things like the main id really shouldn't be changed and so are intentionally excluded
        public static StringBuilder ConvertToString(HAIRObject hair, string type)
        {
            StringBuilder outText = new StringBuilder();

            outText.AppendLine(type + " : " + hair.hair.id.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkIntB1 = " + hair.hair.unkIntB1.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt1 = " + hair.hair.unkInt1.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt2 = " + hair.hair.unkInt2.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkFloat0 = " + hair.hair.unkFloat0.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat1 = " + hair.hair.unkFloat1.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat2 = " + hair.hair.unkFloat2.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat3 = " + hair.hair.unkFloat3.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkInt3 = " + hair.hair.unkInt3.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt4 = " + hair.hair.unkInt4.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt5 = " + hair.hair.unkInt5.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt6 = " + hair.hair.unkInt6.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkInt7 = " + hair.hair.unkInt7.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt8 = " + hair.hair.unkInt8.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat4 = " + hair.hair.unkFloat4.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat5 = " + hair.hair.unkFloat5.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkFloat6 = " + hair.hair.unkFloat6.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt9 = " + hair.hair.unkInt9.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt10 = " + hair.hair.unkInt10.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt11 = " + hair.hair.unkInt11.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkInt12 = " + hair.hair.unkInt12.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt13 = " + hair.hair.unkInt13.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt14 = " + hair.hair.unkInt14.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat7 = " + hair.hair.unkFloat7.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkFloat8 = " + hair.hair.unkFloat8.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkFloat9 = " + hair.hair.unkFloat9.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt15 = " + hair.hair.unkInt15.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt16 = " + hair.hair.unkInt16.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkInt17 = " + hair.hair.unkInt17.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt18 = " + hair.hair.unkInt18.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt19 = " + hair.hair.unkInt19.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkInt20 = " + hair.hair.unkInt20.ToString(new CultureInfo("en-US")));

            outText.AppendLine("unkShortB1 = " + hair.hair.unkShortB1.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkShortB2 = " + hair.hair.unkShortB2.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkShortB3 = " + hair.hair.unkShortB3.ToString(new CultureInfo("en-US")));
            outText.AppendLine("unkShort0 = " + hair.hair.unkShort0.ToString(new CultureInfo("en-US")));

            return outText;
        }
        
        //Takes an existing HAIRObject class and applies the data from the user text into it
        //Expects data to be pruned a little beforehand
        public static void PatchBody(HAIRObject hair, List<string> hairData)
        {
            
            foreach(var line in hairData)
            {
                var contents = line.Replace(" = ", "=").Split("=");

                switch(contents[0])
                {
                    case "unkIntB1":
                        hair.hair.unkIntB1 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt1":
                        hair.hair.unkIntB1 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt2":
                        hair.hair.unkIntB1 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;


                    case "unkFloat0":
                        hair.hair.unkFloat0 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat1":
                        hair.hair.unkFloat1 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat2":
                        hair.hair.unkFloat2 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat3":
                        hair.hair.unkFloat3 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkInt3":
                        hair.hair.unkInt3 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt4":
                        hair.hair.unkInt4 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt5":
                        hair.hair.unkInt5 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt6":
                        hair.hair.unkInt6 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkInt7":
                        hair.hair.unkInt7 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt8":
                        hair.hair.unkInt8 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat4":
                        hair.hair.unkFloat4 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat5":
                        hair.hair.unkFloat5 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkFloat6":
                        hair.hair.unkFloat6 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt9":
                        hair.hair.unkInt9 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt10":
                        hair.hair.unkInt10 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt11":
                        hair.hair.unkInt11 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkInt12":
                        hair.hair.unkInt12 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt13":
                        hair.hair.unkInt13 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt14":
                        hair.hair.unkInt14 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat7":
                        hair.hair.unkFloat7 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkFloat8":
                        hair.hair.unkFloat8 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkFloat9":
                        hair.hair.unkFloat9 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt15":
                        hair.hair.unkInt15 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt16":
                        hair.hair.unkInt16 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkInt17":
                        hair.hair.unkInt17 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt18":
                        hair.hair.unkInt18 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt19":
                        hair.hair.unkInt19 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkInt20":
                        hair.hair.unkInt20 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "unkShortB1":
                        hair.hair.unkShortB1 = Int16.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkShortB2":
                        hair.hair.unkShortB2 = Int16.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkShortB3":
                        hair.hair.unkShortB3 = Int16.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "unkShort0":
                        hair.hair.unkShort0 = Int16.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    default:
                        break;
                }
            }
        }

        public static byte[] GetHAIRAsBytes(HAIRObject hair)
        {
            List<byte> hairBytes = new List<byte>();
            hairBytes.AddRange(AquaGeneralMethods.ConvertStruct(hair.hair));

            return hairBytes.ToArray();
        }
    }
}
