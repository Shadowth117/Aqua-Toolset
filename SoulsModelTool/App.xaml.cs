﻿using AquaModelLibrary.Core.FromSoft;
using AquaModelLibrary.Core.ToolUX;
using AquaModelLibrary.Data.FromSoft;
using AquaModelLibrary.Data.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace SoulsModelTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string settingsPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        public string settingsFile = "SoulsSettings.json";
        public string mainSettingsFile = "Settings.json";
        public enum SoulsModelAction
        {
            none = 0,
            toFBX = 1,
            toFlver = 2,
            toFlverDes = 3,
            toCMDL = 4, //lol
            toObj = 5,
            mcgMCP = 6,
            toSMD = 7,
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //CRITICAL, without this, shift jis handling in SoulsFormats will break and kill the application
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            MainSetting mainSetting = new MainSetting();
            var finalMainSettingsPath = Path.Combine(settingsPath, mainSettingsFile);
            var mainSettingText = File.Exists(finalMainSettingsPath) ? File.ReadAllText(finalMainSettingsPath) : null;
            if (mainSettingText != null)
            {
                mainSetting = JsonConvert.DeserializeObject<MainSetting>(mainSettingText);
            }
            FileHandler.ApplyModelImporterSettings(mainSetting);

            SMTSetting smtSetting = new SMTSetting();
            var finalSettingsPath = Path.Combine(settingsPath, settingsFile);
            var settingText = File.Exists(finalSettingsPath) ? File.ReadAllText(finalSettingsPath) : null;
            if (settingText != null)
            {
                smtSetting = JsonConvert.DeserializeObject<SMTSetting>(settingText);
            }
            FileHandler.SetSMTSettings(smtSetting);

            InitializeComponent();
            bool launchUi = true;
            List<string> filePaths = new List<string>();
            if (e.Args.Length > 0)
            {
                var action = SoulsModelAction.toFBX;
                launchUi = false;

                foreach (var arg in e.Args)
                {
                    var argProcessed = arg.ToLower();
                    switch (argProcessed)
                    {
                        case "-tofbx":
                            smtSetting.exportFormat = ExportFormat.Fbx;
                            action = SoulsModelAction.toFBX;
                            break;
                        case "-tosmd":
                            smtSetting.exportFormat = ExportFormat.Smd;
                            action = SoulsModelAction.toSMD;
                            break;
                        case "-toflver":
                            action = SoulsModelAction.toFlver;
                            Trace.WriteLine("toFlver not implemented. Did you mean toFlverDes?");
                            break;
                        case "-toflverdes":
                            action = SoulsModelAction.toFlverDes;
                            break;
                        case "-tocmdl":
                        case "-tocmsh":
                            action = SoulsModelAction.toCMDL;
                            Trace.WriteLine("toCMDL not implemented.");
                            break;
                        case "-mcgmcp":
                            action = SoulsModelAction.mcgMCP;
                            break;
                        case "-toobj":
                            action = SoulsModelAction.toObj;
                            break;
                        //Old behavior, applies an automatic rotation to the model in fbx
                        case "-coordoldaqua":
                        case "-coordopengl":
                        case "-y_up":
                            smtSetting.coordSystem = CoordSystem.OpenGL;
                            break;
                        case "-coordbbtool":
                        case "-coordmax":
                        case "-z_up":
                            smtSetting.coordSystem = CoordSystem.Max;
                            break;
                        //Removes from soft mirroring
                        case "-mirrorz":
                        case "-nomirror":
                            smtSetting.mirrorType = AquaModelLibrary.Data.Utility.MirrorType.Z;
                            break;
                        case "-mirrory":
                            smtSetting.mirrorType = AquaModelLibrary.Data.Utility.MirrorType.Y;
                            break;
                        case "-mirrorx":
                            smtSetting.mirrorType = AquaModelLibrary.Data.Utility.MirrorType.X;
                            break;
                        //Leave from soft mirroring, ie don't touch mirroring
                        case "-fromsoftmirror":
                        case "-mirror":
                            smtSetting.mirrorType = MirrorType.None;
                            break;
                        case "-dontdumpmetadata":
                            smtSetting.useMetaData = false;
                            break;
                        case "-dumpmetadata":
                            smtSetting.useMetaData = true;
                            break;
                        case "-meshnameismatname":
                            smtSetting.applyMaterialNamesToMesh = true;
                            break;
                        case "-meshnameisdefault":
                            smtSetting.applyMaterialNamesToMesh = false;
                            break;
                        case "-transformmesh":
                            smtSetting.transformMesh = true;
                            break;
                        case "-donttransformmesh":
                            smtSetting.transformMesh = false;
                            break;
                        case "-launch":
                            launchUi = true;
                            break;
                        case "-addrootnode":
                            smtSetting.addFBXRootNode = true;
                            break;
                        case "-dontaddrootnode":
                            smtSetting.addFBXRootNode = false;
                            break;
                        case "-addflverdummies":
                            smtSetting.addFlverDummies = true;
                            break;
                        case "-dontaddflverdummies":
                            smtSetting.addFlverDummies = false;
                            break;
                        case "-parentdummiestoattach":
                            smtSetting.parentDummiesToAttachNodes = true;
                            break;
                        case "-dontparentdummiestoattach":
                            smtSetting.parentDummiesToAttachNodes = false;
                            break;
                        case "-includetangentdata":
                            smtSetting.addTangentData = true;
                            break;
                        case "-dontincludetangentdata":
                            smtSetting.addTangentData = false;
                            break;
                        default:
                            filePaths.Add(arg);
                            break;
                    }
                }
                FileHandler.SetSMTSettings(smtSetting);

                switch (action)
                {
                    case SoulsModelAction.toFBX:
                    case SoulsModelAction.toSMD:
                        FileHandler.ConvertFileSMT(filePaths.ToArray());
                        break;
                    case SoulsModelAction.toObj:
                        break;
                    case SoulsModelAction.toFlverDes:
                        foreach (var file in filePaths)
                        {
                            var ext = Path.GetExtension(file);
                            var outStr = file.Replace(ext, "_out.flver");
                            SoulsConvert.ConvertModelToFlverAndWrite(file, outStr, 1, true, true, SoulsGame.DemonsSouls);
                        }
                        break;
                    case SoulsModelAction.mcgMCP:
                        SoulsMapMetadataGenerator.Generate(filePaths, out var mcCombo);
                        break;
                    case SoulsModelAction.toFlver:
                    case SoulsModelAction.toCMDL:
                    case SoulsModelAction.none:
                    default:
                        break;
                }
            }

            if (launchUi)
            {
                SoulsModelToolWindow wnd = new SoulsModelToolWindow(filePaths, smtSetting, mainSetting);
                wnd.Show();
            }
            else
            {
                Current.Shutdown();
            }

        }
    }
}
