using AquaModelLibrary;
using AquaModelLibrary.Extra;
using AquaModelLibrary.ToolUX;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    switch(argProcessed)
                    {
                        case "-tofbx":
                            action = SoulsModelAction.toFBX;
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
                        case "-nomirror":
                            smtSetting.mirrorMesh = true;
                            break;
                        case "-dontdumpmetadata":
                            smtSetting.useMetaData = true;
                            break;
                        case "-meshnameismatname":
                            smtSetting.applyMaterialNamesToMesh = true;
                            break;
                        case "-transformMesh":
                            smtSetting.transformMesh = true;
                            break;
                        case "-launch":
                            launchUi = true;
                            break;
                        default:
                            filePaths.Add(arg);
                            break;
                    }
                }

                switch (action)
                {
                    case SoulsModelAction.toFBX:
                        FileHandler.ConvertFileSMT(filePaths.ToArray());
                        break;
                    case SoulsModelAction.toObj:
                        break;
                    case SoulsModelAction.toFlverDes:
                        foreach (var file in filePaths)
                        {
                            AquaUtil aqua = new AquaUtil();
                            var ext = Path.GetExtension(file);
                            var outStr = file.Replace(ext, "_out.flver");
                            SoulsConvert.ConvertModelToFlverAndWrite(file, outStr, 1, true, true, SoulsConvert.SoulsGame.DemonsSouls);
                        }
                        break;
                    case SoulsModelAction.mcgMCP:
                        AquaModelLibrary.Extra.FromSoft.SoulsMapMetadataGenerator.Generate(filePaths, out var mcCombo);
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
            } else
            {
                Current.Shutdown();
            }

        }
    }
}
