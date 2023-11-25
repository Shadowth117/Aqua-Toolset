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
    public static class BODYStructHandler
    {
        //Converts a body struct's accessible contents to text
        //Currently strings and such are left alone, though that could be changed in the future
        //Some things like the main id really shouldn't be changed and so are intentionally excluded
        public static StringBuilder ConvertToString(BODYObject body, string type, bool includeComments = true)
        {
            StringBuilder outText = new StringBuilder();

            outText.AppendLine(type + " : " + body.body.id.ToString(new CultureInfo("en-US")));

            outText.AppendLine("int_20 = " + body.body.int_20.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_24_0x9_0x9 = " + body.body2.int_24_0x9_0x9.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_28 = " + body.body2.int_28.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_2C = " + body.body2.int_2C.ToString(new CultureInfo("en-US")));

            outText.AppendLine("costumeSoundId = " + body.body2.costumeSoundId.ToString(new CultureInfo("en-US")));
            outText.AppendLine("headId = " + body.body2.headId.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_38 = " + body.body2.int_38.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_3C = " + body.body2.int_3C.ToString(new CultureInfo("en-US")));

            outText.AppendLine("linkedInnerId = " + body.body2.linkedInnerId.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_44 = " + body.body2.int_44.ToString(new CultureInfo("en-US")));
            outText.AppendLine("legLength = " + body.body2.legLength.ToString(new CultureInfo("en-US")));
            outText.AppendLine("float_4C_0xB = " + body.body2.float_4C_0xB.ToString(new CultureInfo("en-US")));

            outText.AppendLine("float_50 = " + body.body2.float_50.ToString(new CultureInfo("en-US")));
            outText.AppendLine("float_54 = " + body.body2.float_54.ToString(new CultureInfo("en-US")));
            outText.AppendLine("float_58 = " + body.body2.float_58.ToString(new CultureInfo("en-US")));
            outText.AppendLine("float_5C = " + body.body2.float_5C.ToString(new CultureInfo("en-US")));

            outText.AppendLine("float_60 = " + body.body2.float_60.ToString(new CultureInfo("en-US")));
            outText.AppendLine("int_64 = " + body.body2.int_64.ToString(new CultureInfo("en-US")));
            outText.AppendLine("Red Mask Mapping = " + ((int)body.bodyMaskColorMapping.redIndex).ToString(new CultureInfo("en-US")));
            outText.AppendLine("Green Mask Mapping = " + ((int)body.bodyMaskColorMapping.greenIndex).ToString(new CultureInfo("en-US")));
            outText.AppendLine("Blue Mask Mapping = " + ((int)body.bodyMaskColorMapping.blueIndex).ToString(new CultureInfo("en-US")));
            outText.AppendLine("Alpha Mask Mapping = " + ((int)body.bodyMaskColorMapping.alphaIndex).ToString(new CultureInfo("en-US")));

            if(includeComments)
            {
                outText.AppendLine("\n//Mask Mapping options. The _m texture for outfits maps character data color slots to its red, green, blue and alpha color channels. Alpha may be unusable and not all outfits may support this.\r\n" +
                                    "//PrimaryOuterWear = 1\r\n" +
                                    "//SecondaryOuterWear = 2\r\n" +
                                    "//PrimaryBaseWear = 3\r\n" +
                                    "//SecondaryBaseWear = 4\r\n" +
                                    "//PrimaryInnerWear = 5\r\n" +
                                    "//SecondaryInnerWear = 6\r\n" +
                                    "//CastColor1 = 7\r\n" +
                                    "//CastColor2 = 8\r\n" +
                                    "//CastColor3 = 9\r\n" +
                                    "//CastColor4 = 10\r\n" +
                                    "//MainSkin = 11\r\n" +
                                    "//SubSkin = 12\r\n" +
                                    "//RightEye = 13\r\n" +
                                    "//LeftEye = 14\r\n" +
                                    "//EyebrowColor = 15\r\n" +
                                    "//EyelashColor = 16\r\n" +
                                    "//HairColor = 17");
            }

            return outText;
        }
        
        //Takes an existing bodyObject class and applies the data from the user text into it
        //Expects data to be pruned a little beforehand
        public static void PatchBody(BODYObject body, List<string> bodyData)
        {
            foreach(var line in bodyData)
            {
                var contents = line.Replace(" = ", "=").Split("=");

                switch(contents[0])
                {
                    case "int_20":
                        body.body.int_20 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_24_0x9_0x9":
                        body.body2.int_24_0x9_0x9 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_28":
                        body.body2.int_28 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_2C":
                        body.body2.int_2C = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "costumeSoundId":
                        body.body2.costumeSoundId = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "reference_id":
                    case "headId":
                        body.body2.headId = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_38":
                        body.body2.int_38 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_3C":
                        body.body2.int_3C = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "int_40":
                    case "linkedInnerId":
                        body.body2.linkedInnerId = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_44":
                        body.body2.int_44 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "legLength":
                        body.body2.legLength = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "float_4C_0xB":
                        body.body2.float_4C_0xB = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "float_50":
                        body.body2.float_50 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "float_54":
                        body.body2.float_54 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "float_58":
                        body.body2.float_58 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "float_5C":
                        body.body2.float_5C = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;

                    case "float_60":
                        body.body2.float_60 = Single.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "int_64":
                        body.body2.int_64 = Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "Red Mask Mapping":
                        body.bodyMaskColorMapping.redIndex = (CharColorMapping)Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "Green Mask Mapping":
                        body.bodyMaskColorMapping.greenIndex = (CharColorMapping)Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "Blue Mask Mapping":
                        body.bodyMaskColorMapping.blueIndex = (CharColorMapping)Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    case "Alpha Mask Mapping":
                        body.bodyMaskColorMapping.alphaIndex = (CharColorMapping)Int32.Parse(contents[1], new CultureInfo("en-US"));
                        break;
                    default:
                        break;
                }
            }
        }

        public static byte[] GetBODYAsBytes(BODYObject body, bool postRetem = true)
        {
            List<byte> bodyBytes = new List<byte>();
            bodyBytes.AddRange(AquaGeneralMethods.ConvertStruct(body.body));
            if(postRetem)
            {
                bodyBytes.AddRange(AquaGeneralMethods.ConvertStruct(body.bodyMaskColorMapping));
            }
            bodyBytes.AddRange(AquaGeneralMethods.ConvertStruct(body.body2));

            return bodyBytes.ToArray();
        }
    }
}
