using AquaModelLibrary.Core.FromSoft;
using AquaModelLibrary.Core.ToolUX;
using AquaModelLibrary.Data.FromSoft;
using AquaModelLibrary.Data.Utility;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string settingsPath =
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";

        public string settingsFile = "SoulsSettings.json";
        public string mainSettingsFile = "Settings.json";
        public DateTime buildDate = GetBuildDate();
        public SMTSetting smtSetting = new SMTSetting();
        public MainSetting mainSetting = new MainSetting();
        public string[] importFormats;
        public string[] convertFormats;

        JsonSerializerSettings jss = new JsonSerializerSettings() { Formatting = Formatting.Indented };
        public string GetTitleString()
        {
            return $"Souls Model Tool {buildDate.ToString("yyyy-MM-dd h:mm tt")}";
        }
        private static DateTime GetBuildDate()
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            const string BuildVersionMetadataPrefix = "+build";

            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null)
            {
                var value = attribute.InformationalVersion;
                var index = value.IndexOf(BuildVersionMetadataPrefix);
                if (index > 0)
                {
                    value = value.Substring(index + BuildVersionMetadataPrefix.Length);
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                    {
                        return result;
                    }
                }
            }

            return default;
        }

        public SoulsModelToolWindow(List<string> paths, SMTSetting _smtSetting, MainSetting _mainSetting)
        {
            smtSetting = _smtSetting;
            mainSetting = _mainSetting;
            InitializeComponent();
            useMetaDataCB.IsChecked = smtSetting.useMetaData;
            matNamesToMeshCB.IsChecked = smtSetting.applyMaterialNamesToMesh;
            transformMeshCB.IsChecked = smtSetting.transformMesh;
            extractUnreferencedFilesCB.IsChecked = smtSetting.extractUnreferencedMapData;
            separateModelsCB.IsChecked = smtSetting.separateMSBDumpByModel;
            exportFormatCB.Items.Add("Fbx (Default)");
            exportFormatCB.Items.Add("Smd (Not recommended)");
            exportFormatCB.ToolTip = "Smd export will not contain vertex colors, more than one uv channel, detailed material names, mesh names, etc. Not recommended, but you can use it!";
            mirrorTypeCB.Items.Add("No Mirroring");
            mirrorTypeCB.Items.Add("Mirror Z (Default)");
            mirrorTypeCB.Items.Add("Mirror Y");
            mirrorTypeCB.Items.Add("Mirror X");
            mirrorTypeCB.Items.Add("HavokMax YZ Swap (Overrides Coordinate System)");
            coordSystemCB.Items.Add("OpenGL Y Up (Classic, adds 90 degrees)");
            coordSystemCB.Items.Add("BB Tool Z Up (Default)");
            exportFormatCB.SelectedIndex = (int)smtSetting.exportFormat;
            mirrorTypeCB.SelectedIndex = (int)smtSetting.mirrorType;
            coordSystemCB.SelectedIndex = (int)smtSetting.coordSystem;
            addFBXRootNodeCB.IsChecked = smtSetting.addFBXRootNode;
            addDummyNodeCB.IsChecked = smtSetting.addFlverDummies;
            parentDummyToAttachCB.IsChecked = smtSetting.parentDummiesToAttachNodes;
            includeTangentDataCB.IsChecked = smtSetting.addTangentData;

            importFormats = new[]
            {
                ".fbx",
                ".dae",
                ".glb",
                ".gltf",
                ".pmx",
                ".smd"
            };

            convertFormats = new[]
            {
                ".flver",
                ".flv",
                ".mdl",
                ".bnd",
                ".dcx",
                ".tpf",
                ".cmsh",
                ".cmdl"
            };

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
            this.Title = GetTitleString();
        }

        private void smtSettingSet(object sender = null, RoutedEventArgs e = null)
        {
            smtSetting.useMetaData = (bool)useMetaDataCB.IsChecked;
            smtSetting.applyMaterialNamesToMesh = (bool)matNamesToMeshCB.IsChecked;
            smtSetting.transformMesh = (bool)transformMeshCB.IsChecked;
            smtSetting.soulsGame = SoulsConvert.game;
            smtSetting.extractUnreferencedMapData = (bool)extractUnreferencedFilesCB.IsChecked;
            smtSetting.separateMSBDumpByModel = (bool)separateModelsCB.IsChecked;
            smtSetting.exportFormat = (ExportFormat)exportFormatCB.SelectedIndex;
            smtSetting.coordSystem = (CoordSystem)coordSystemCB.SelectedIndex;
            smtSetting.mirrorType = (MirrorType)mirrorTypeCB.SelectedIndex;
            smtSetting.addFBXRootNode = (bool)addFBXRootNodeCB.IsChecked;
            smtSetting.addFlverDummies = (bool)addDummyNodeCB.IsChecked;
            smtSetting.parentDummiesToAttachNodes = (bool)parentDummyToAttachCB.IsChecked;
            smtSetting.addTangentData = (bool)includeTangentDataCB.IsChecked;
            SMTSettingSave();
        }

        private void SMTSettingSave()
        {
            string smtSettingText = JsonConvert.SerializeObject(smtSetting, jss);
            File.WriteAllText(settingsPath + settingsFile, smtSettingText);
        }

        private void ConvertModelToFBX(object sender, RoutedEventArgs e)
        {
            FileHandler.ApplyModelImporterSettings(mainSetting);
            FileHandler.SetSMTSettings(smtSetting);

            string[] transformedFilters = convertFormats.Select(ext => $"*{ext}").ToArray();
            string filterNames = string.Join(", ", transformedFilters);
            string actualFilter = string.Join(";", transformedFilters);
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select From Software flver, MDL4, TPF, BND or BluePoint CMDL, CMSH, or CTXR file(s)",
                Filter =
                    $"From Software flver, MDL4, or BND Files ({filterNames})|{actualFilter}|All Files (*.*)|*",
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
                SoulsMapMetadataGenerator.Generate(goodFolderDialog.FileNames.ToList(), out var mcCombo);
            }
        }

        private void ConvertFBXToDeSModel(object sender, RoutedEventArgs e)
        {
            FileHandler.ApplyModelImporterSettings(mainSetting);
            FileHandler.SetSMTSettings(smtSetting);


            OpenFileDialog openFileDialog = new()
            {
                Title = "Import model file, fbx recommended (output .aqp and .aqn will write to import directory)",
                Filter = ""
            };
            string[] transformedFilters = importFormats.Select(ext => $"*{ext}").ToArray();
            string filterNames = string.Join(", ", transformedFilters);
            string actualFilter = string.Join(";", transformedFilters);
            string combinedFilter = $"Model files ({filterNames})|{actualFilter}|All Files (*.*)|*";
            openFileDialog.Filter = combinedFilter;

            if (openFileDialog.ShowDialog() == true && LayoutDataSet())
            {
                ConvertFBXToDeSModelCallback(openFileDialog.FileName);
            }
        }

        private bool LayoutDataSet()
        {
            if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "DeSMtdLayoutData.bin")))
            {
                MessageBox.Show(
                    "No DeSMtdLayoutData.bin detected! Please select a PS3 Demon's Souls game folder!");
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
                    return false;
                }
            }

            return true;
        }

        private void ConvertFBXToDeSModelCallback(string path)
        {
            var ext = Path.GetExtension(path);
            var outStr = path.Replace(ext, "_out.flver");
            SoulsConvert.ConvertModelToFlverAndWrite(path, outStr, 1, true, true,
                SoulsGame.DemonsSouls);
        }

        private bool MSBGameSet()
        {
            if (SoulsConvert.game == SoulsGame.None)
            {
                SetGame();
                if (SoulsConvert.game == SoulsGame.None)
                {
                    //User already warned when setting game.
                    return false;
                }

                smtSettingSet();
            }

            return true;
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
                if (!MSBGameSet()) return;

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
                if (tempGame != SoulsGame.None)
                {
                    SoulsConvert.game = tempGame;
                }
                else
                {
                    MessageBox.Show(
                        "You must select a valid From Software title!\nCurrent valid titles are: Demon's Souls, Dark Souls: Prepare to Die Edition, Dark Souls Remastered, Dark Souls II: Scholar of the First Sin, Bloodborne, Dark Souls III, Sekiro, Elden Ring");
                }

                SetGameLabel();
            }
        }

        private void SetGameLabel()
        {
            SetGameOption.Header = $"Set Game (For MSB Extraction) | Current Game: {SoulsConvert.game}";
        }

        private void scaleCBSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (scaleHandlingCB.SelectedIndex == 2)
            {
                scaleUD.IsEnabled = true;
            }
            else
            {
                scaleUD.IsEnabled = false;
            }
            SMTSettingSave();
        }

        private void scaleUDChanged(object sender, RoutedPropertyChangedEventArgs<object> routedEvent)
        {
            mainSetting.customScaleValue = scaleUD.Value.ToString();
            SMTSettingSave();
        }

        private void exportFormatCBChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            smtSetting.exportFormat = (ExportFormat)exportFormatCB.SelectedIndex;
            SMTSettingSave();
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            var files = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (files == null || files.Length <= 0) return;

            string[] msbExtensions = { ".msb", ".msb.dcx" };
            string[] msbs = files.Where(f => msbExtensions.Contains(Path.GetExtension(f))).ToArray();
            string[] fbxs = files.Where(f => importFormats.Contains(Path.GetExtension(f))).ToArray();
            string[] folders = files.Where(f => Directory.Exists(f)).ToArray();
            string[] convert = files.Where(f => convertFormats.Contains(Path.GetExtension(f))).ToArray();

            FileHandler.ApplyModelImporterSettings(mainSetting);
            FileHandler.SetSMTSettings(smtSetting);

            if (convert.Any())
                FileHandler.ConvertFileSMT(convert);

            if (fbxs.Any() && LayoutDataSet())
            {
                foreach (string fbx in fbxs)
                {
                    ConvertFBXToDeSModelCallback(fbx);
                }
            }

            if (folders.Any())
                SoulsMapMetadataGenerator.Generate(folders.ToList(), out var mcCombo);

            if (msbs.Any() && MSBGameSet())
            {
                foreach (string msb in msbs)
                {
                    MSBModelExtractor.ExtractMSBMapModels(msb);
                }
            }
        }

        private void mirrorTypeCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            smtSetting.mirrorType = (MirrorType)mirrorTypeCB.SelectedIndex;
            SMTSettingSave();
        }

        private void mirrorTypeCB_DropDownClosed(object sender, EventArgs e)
        {
            smtSetting.mirrorType = (MirrorType)mirrorTypeCB.SelectedIndex;
            SMTSettingSave();
        }


        private void coordSystemCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            smtSetting.coordSystem = (CoordSystem)coordSystemCB.SelectedIndex;
            SMTSettingSave();
        }

        private void exportFormatCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            smtSetting.exportFormat = (ExportFormat)exportFormatCB.SelectedIndex;
            SMTSettingSave();
        }
    }
}