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
            aqua.aquaModels.Clear();
            ModelSet set = new ModelSet();
            set.models.Add(BluePointConvert.ReadCMSH(file, out AquaNode aqn));
            if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
            {
                aqua.aquaModels.Add(set);
                aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                set.models[0].ConvertToLegacyTypes();
                set.models[0].CreateTrueVertWeights();

                FbxExporter.ExportToFile(aqua.aquaModels[0].models[0], aqn, new List<AquaMotion>(), Path.ChangeExtension(file, ".fbx"), new List<string>(), new List<System.Numerics.Matrix4x4>(), false);
            }
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
