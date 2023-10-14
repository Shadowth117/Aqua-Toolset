using AquaModelLibrary;
using AquaModelLibrary.Extra;
using AquaModelLibrary.Native.Fbx;
using AquaModelLibrary.ToolUX;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AquaModelLibrary.Utility.AquaUtilData;

namespace SoulsModelTool
{
    public static class FileHandler
    {
        public static AquaUtil aqua = new AquaUtil();

        public static void ConvertBluepointModel(string file)
        {
            BluePointConvert.ReadCMDL(file);
        }

        public static void ConvertFileSMT(string[] FileNames)
        {
            foreach (var file in FileNames)
            {
                string ext = Path.GetExtension(file);
                if (ext == ".cmsh" || ext == ".cmdl")
                {
                    ConvertBluepointModel(file);
                }
                else
                {
                    SoulsConvert.ConvertFile(file);
                }
            }
        }

        public static void SetSMTSettings(SMTSetting smtSetting)
        {
            SoulsConvert.useMetaData = smtSetting.useMetaData;
            SoulsConvert.mirrorMesh = smtSetting.mirrorMesh;
            SoulsConvert.applyMaterialNamesToMesh = smtSetting.applyMaterialNamesToMesh;
            SoulsConvert.transformMesh = smtSetting.transformMesh;
            SoulsConvert.extractUnreferencedMapData = smtSetting.extractUnreferencedMapData;
            SoulsConvert.game = smtSetting.soulsGame;
            SoulsConvert.separateMSBDumpByModel = smtSetting.separateMSBDumpByModel;
        }
    }
}
