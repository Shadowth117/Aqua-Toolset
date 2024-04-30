using AquaModelLibrary.Core.BluePoint;
using AquaModelLibrary.Core.FromSoft;
using AquaModelLibrary.Core.General;
using AquaModelLibrary.Core.ToolUX;
using System;
using System.IO;

namespace SoulsModelTool
{
    public static class FileHandler
    {
        public static void ConvertBluepointModel(string file)
        {
            BluePointConvert.ConvertCMDLCMSH(file);
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
            SoulsConvert.addRootNodeLikeBlenderSmdImport = smtSetting.addRootNodeLikeBlenderSmdImport;
            SoulsConvert.doNotAdjustRootRotation = smtSetting.doNotAdjustRootRotation;
        }

        public static void ApplyModelImporterSettings(MainSetting mainSetting)
        {
            if (Int32.TryParse(mainSetting.customScaleSelection, out int selection))
            {
                switch (selection)
                {
                    case 2:
                    case 1:
                    case 0:
                        AssimpModelImporter.scaleHandling = (AssimpModelImporter.ScaleHandling)selection;
                        break;
                    default:
                        AssimpModelImporter.scaleHandling = AssimpModelImporter.ScaleHandling.NoScaling;
                        break;
                }
            }
            if (Double.TryParse(mainSetting.customScaleValue, out double result))
            {
                AssimpModelImporter.customScale = result;
            }
            else
            {
                AssimpModelImporter.customScale = 1;
            }
        }
    }
}
