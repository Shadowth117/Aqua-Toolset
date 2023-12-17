using AquaModelLibrary;
using AquaModelLibrary.Extra;
using AquaModelLibrary.Extra.FromSoft;
using AquaModelLibrary.ToolUX;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Path = System.IO.Path;

namespace SoulsModelTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SoulsModelToolWindow : Window
    {
        public string settingsPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        public string settingsFile = "SoulsSettings.json";
        public string mainSettingsFile = "Settings.json";
        public SMTSetting smtSetting = new SMTSetting();
        public MainSetting mainSetting = new MainSetting();
        public AquaUtil aqua = new AquaUtil();
        JsonSerializerSettings jss = new JsonSerializerSettings() { Formatting = Formatting.Indented };
        public SoulsModelToolWindow(List<string> paths, SMTSetting _smtSetting, MainSetting _mainSetting)
        {
            smtSetting = _smtSetting;
            mainSetting = _mainSetting;
            InitializeComponent();
            useMetaDataCB.IsChecked = smtSetting.useMetaData;
            mirrorCB.IsChecked = smtSetting.mirrorMesh;
            matNamesToMeshCB.IsChecked = smtSetting.applyMaterialNamesToMesh;
            transformMeshCB.IsChecked = smtSetting.transformMesh;
            extractUnreferencedFilesCB.IsChecked = smtSetting.extractUnreferencedMapData;
            separateModelsCB.IsChecked = smtSetting.separateMSBDumpByModel;
            FileHandler.SetSMTSettings(smtSetting);
            FileHandler.ApplyModelImporterSettings(mainSetting);
            SetGameLabel();

            //Main settings
            scaleHandlingCB.Items.Add("No Import Scale");
            scaleHandlingCB.Items.Add("Use File Scale");
            scaleHandlingCB.Items.Add("Use Custom Scale");
            if (Int32.TryParse(mainSetting.customScaleSelection, out int selection))
            {
                switch (selection)
                {
                    case 2:
                    case 1:
                    case 0:
                        scaleHandlingCB.SelectedIndex = selection;
                        break;
                    default:
                        scaleHandlingCB.SelectedIndex = 0;
                        break;
                }
            }
            if (Double.TryParse(mainSetting.customScaleValue, out double result))
            {
                 scaleUD.Value = result;
            }
            else
            {
                 scaleUD.Value = 1;
            }
        }

        private void ConvertModelToFBX(object sender, RoutedEventArgs e)
        {
            FileHandler.ApplyModelImporterSettings(mainSetting);
            FileHandler.SetSMTSettings(smtSetting);

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select From Software flver, MDL4, TPF, BND or BluePoint CMDL or CMSH file(s)",
                Filter = "From Software flver, MDL4, or BND Files (*.flver, *.flv, *.mdl, *.*bnd, *.dcx, *.tpf, *.cmsh, *.cmdl)|*.flver;*.flv;*.mdl;*.*bnd;*.dcx;*.tpf;*.cmsh;*.cmdl|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                FileHandler.ConvertFileSMT(openFileDialog.FileNames);
            }
        }

        private void GenerateMCPMCG(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new()
            {
                IsFolderPicker = true,
                Multiselect = true,
                Title = "Select Demon's Souls m**_**_**_** folders for connected areas",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                AquaModelLibrary.Extra.FromSoft.SoulsMapMetadataGenerator.Generate(goodFolderDialog.FileNames.ToList(), out var mcCombo);
            }
        }

        private void ConvertFBXToDeSModel(object sender, RoutedEventArgs e)
        {
            FileHandler.ApplyModelImporterSettings(mainSetting);
            FileHandler.SetSMTSettings(smtSetting);

            using (var ctx = new Assimp.AssimpContext())
            {
                var formats = ctx.GetSupportedImportFormats().ToList();
                formats.Sort();

                OpenFileDialog openFileDialog = new()
                {
                    Title = "Import model file, fbx recommended (output .aqp and .aqn will write to import directory)",
                    Filter = ""
                };
                string tempFilter = "(*.fbx,*.dae,*.glb,*.gltf,*.pmx,*.smd)|*.fbx;*.dae;*.glb;*.gltf;*.pmx;*.smd";
                string tempFilter2 = "";
                openFileDialog.Filter = tempFilter + tempFilter2;

                if (openFileDialog.ShowDialog() == true)
                {
                    if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DeSMtdLayoutData.bin")))
                    {
                        MessageBox.Show("No DeSMtdLayoutData.bin detected! Please select a PS3 Demon's Souls game folder!");
                        var browseDialog = new CommonOpenFileDialog()
                        {
                            Title = "Open PS3 Demon's Souls root folder",
                            IsFolderPicker = true,
                        };

                        if (browseDialog.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            SoulsConvert.GetDeSLayoutMTDInfo(browseDialog.FileName);
                        }
                        else
                        {
                            MessageBox.Show("You MUST have an DeSMtdLayoutData.bin file to proceed!");
                            return;
                        }
                    }

                    AquaUtil aqua = new AquaUtil();
                    var ext = Path.GetExtension(openFileDialog.FileName);
                    var outStr = openFileDialog.FileName.Replace(ext, "_out.flver");
                    SoulsConvert.ConvertModelToFlverAndWrite(openFileDialog.FileName, outStr, 1, true, true, SoulsConvert.SoulsGame.DemonsSouls);
                }
            }
        }

        private void smtSettingSet(object sender = null, RoutedEventArgs e = null)
        {
            smtSetting.useMetaData = (bool)useMetaDataCB.IsChecked;
            smtSetting.mirrorMesh = (bool)mirrorCB.IsChecked;
            smtSetting.applyMaterialNamesToMesh = (bool)matNamesToMeshCB.IsChecked;
            smtSetting.transformMesh = (bool)transformMeshCB.IsChecked;
            smtSetting.soulsGame = SoulsConvert.game;
            smtSetting.extractUnreferencedMapData = (bool)extractUnreferencedFilesCB.IsChecked;
            smtSetting.separateMSBDumpByModel = (bool)separateModelsCB.IsChecked;
            string smtSettingText = JsonConvert.SerializeObject(smtSetting, jss);
            File.WriteAllText(settingsPath + settingsFile, smtSettingText);
        }

        private void MSBExtract(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select .msb file(s)",
                Filter = "Msb Files (*.msb, *.msb.dcx)|*.msb;*.msb.dcx",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                if (SoulsConvert.game == SoulsConvert.SoulsGame.None)
                {
                    SetGame();
                    if (SoulsConvert.game == SoulsConvert.SoulsGame.None)
                    {
                        //User already warned when setting game.
                        return;
                    }
                    smtSettingSet();
                }
                foreach (var file in openFileDialog.FileNames)
                {
                    MSBModelExtractor.ExtractMSBMapModels(file);
                }
            }
        }

        private void SetGame(object sender = null, RoutedEventArgs e = null)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select .exe, eboot file(s)",
                Filter = "Exe, Eboot Files (*.exe, eboot.bin)|*.exe;eboot.bin;",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var tempGame = SoulsConvert.GetGameEnum(openFileDialog.FileName);
                if (tempGame != SoulsConvert.SoulsGame.None)
                {
                    SoulsConvert.game = tempGame;
                }
                else
                {
                    MessageBox.Show("You must select a valid From Software title!\nCurrent valid titles are: Demon's Souls, Dark Souls: Prepare to Die Edition, Dark Souls Remastered, Dark Souls II: Scholar of the First Sin, Bloodborne, Dark Souls III, Sekiro, Elden Ring");
                }
                SetGameLabel();
            }
        }

        private void SetGameLabel()
        {
            SetGameOption.Header = $"Set Game (For MSB Extraction) | Current Game: {SoulsConvert.game}";
        }

        private void comboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (scaleHandlingCB.SelectedIndex == 2)
            {
                scaleUD.IsEnabled = true;
            }
            else
            {
                scaleUD.IsEnabled = false;
            }
        }
    }
}
