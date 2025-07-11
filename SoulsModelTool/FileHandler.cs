﻿using AquaModelLibrary.Core.BluePoint;
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
                switch(ext.ToLower())
                {
                    case ".cmsh":
                    case ".cmdl":
                        ConvertBluepointModel(file);
                        break;
                    case ".ctxr":
                        BluePointConvert.ConvertCTXR(file);
                        break;
                    default:
                        SoulsConvert.ConvertFile(file);
                        break;
                }
            }
        }

        public static void SetSMTSettings(SMTSetting smtSetting)
        {
            SoulsConvert.useMetaData = smtSetting.useMetaData;
            SoulsConvert.mirrorType = smtSetting.mirrorType;
            SoulsConvert.applyMaterialNamesToMesh = smtSetting.applyMaterialNamesToMesh;
            SoulsConvert.transformMesh = smtSetting.transformMesh;
            SoulsConvert.extractUnreferencedMapData = smtSetting.extractUnreferencedMapData;
            SoulsConvert.game = smtSetting.soulsGame;
            SoulsConvert.separateMSBDumpByModel = smtSetting.separateMSBDumpByModel;
            SoulsConvert.addFBXRootNode = smtSetting.addFBXRootNode;
            SoulsConvert.exportFormat = smtSetting.exportFormat;
            SoulsConvert.coordSystem = smtSetting.coordSystem;
            SoulsConvert.addFlverDummies = smtSetting.addFlverDummies;
            SoulsConvert.parentDummiesToAttachNodes = smtSetting.parentDummiesToAttachNodes;
            SoulsConvert.addTangentData = smtSetting.addTangentData;
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
