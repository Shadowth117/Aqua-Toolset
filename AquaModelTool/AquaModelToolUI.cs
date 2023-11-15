using AquaModelLibrary;
using AquaModelLibrary.AquaMethods;
using AquaModelLibrary.AquaStructs;
using AquaModelLibrary.BluePoint.CAWS;
using AquaModelLibrary.BluePoint.CMDL;
using AquaModelLibrary.Extra;
using AquaModelLibrary.Extra.AM2;
using AquaModelLibrary.Extra.FromSoft;
using AquaModelLibrary.Extra.FromSoft.MetalWolfChaos;
using AquaModelLibrary.Extra.Ninja;
using AquaModelLibrary.Extra.Ninja.BillyHatcher;
using AquaModelLibrary.Native.Fbx;
using AquaModelLibrary.NNStructs;
using AquaModelLibrary.Nova;
using AquaModelLibrary.ToolUX;
using AquaModelLibrary.ToolUX.CommonForms;
using AquaModelLibrary.Zero;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Reloaded.Memory.Streams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zamboni;
using Zamboni.IceFileFormats;
using static AquaExtras.FilenameConstants;
using static AquaModelLibrary.AquaMethods.AquaGeneralMethods;
using static AquaModelLibrary.AquaStructs.ShaderPresetDefaults;
using static AquaModelLibrary.Utility.AquaUtilData;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using Path = System.IO.Path;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace AquaModelTool
{
    public partial class AquaModelTool : Form
    {
        public AquaUICommon aquaUI = new AquaUICommon();
        public List<string> modelExtensions = new List<string>() { ".aqp", ".aqo", ".trp", ".tro" };
        public List<string> simpleModelExtensions = new List<string>() { ".prm", ".prx" };
        public List<string> effectExtensions = new List<string>() { ".aqe" };
        public List<string> motionConfigExtensions = new List<string>() { ".bti" };
        public List<string> motionExtensions = new List<string>() { ".aqm", ".aqv", ".aqc", ".aqw", ".trm", ".trv", ".trw" };
        public DateTime buildDate = GetLinkerTime(System.Reflection.Assembly.GetExecutingAssembly(), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        public string mainSettingsPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        public string mainSettingsFile = "Settings.json";
        public string soulsSettingsFile = "SoulsSettings.json";
        public string borderBreakPS4BonePath = "";
        JsonSerializerSettings jss = new JsonSerializerSettings() { Formatting = Formatting.Indented };
        public string currentFile;
        public bool isNIFL = false;

        public AquaModelTool()
        {
            MainSetting mainSetting = new MainSetting();
            var finalMainSettingsPath = Path.Combine(mainSettingsPath, mainSettingsFile);
            var mainSettingText = File.Exists(finalMainSettingsPath) ? File.ReadAllText(finalMainSettingsPath) : null;
            if (mainSettingText != null)
            {
                mainSetting = JsonConvert.DeserializeObject<MainSetting>(mainSettingText);
            }

            SMTSetting smtSetting = new SMTSetting();
            var finalSMTSettingsPath = Path.Combine(mainSettingsPath, soulsSettingsFile);
            var SMTSettingText = File.Exists(finalSMTSettingsPath) ? File.ReadAllText(finalSMTSettingsPath) : null;
            if (SMTSettingText != null)
            {
                smtSetting = JsonConvert.DeserializeObject<SMTSetting>(SMTSettingText);
            }

            InitializeComponent();
            this.DragEnter += new DragEventHandler(AquaUI_DragEnter);
            this.DragDrop += new DragEventHandler(AquaUI_DragDrop);
#if !DEBUG
            debugToolStripMenuItem.Visible = false;        
            debug2ToolStripMenuItem.Visible = false;
            debug3ToolStripMenuItem.Visible = false;        
#endif
            filenameButton.Enabled = false;
            this.Text = GetTitleString();

            //Border Break PS4 Settings
            borderBreakPS4BonePath = mainSetting.BBPS4BonePath;

            //Souls Settings
            exportWithMetadataToolStripMenuItem.Checked = smtSetting.useMetaData;
            fixFromSoftMeshMirroringToolStripMenuItem.Checked = smtSetting.mirrorMesh;
            applyMaterialNamesToMeshToolStripMenuItem.Checked = smtSetting.applyMaterialNamesToMesh;
            transformMeshToolStripMenuItem.Checked = smtSetting.transformMesh;
            mSBExtractionExtractUnreferencedModelsAndTexturesToolStripMenuItem.Checked = smtSetting.extractUnreferencedMapData;
            mSBExtractionSeparateExtractionByModelToolStripMenuItem.Checked = smtSetting.separateMSBDumpByModel;
            SoulsConvert.game = smtSetting.soulsGame;
            SetSoulsGameToolStripText();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AquaUIOpenFile();
        }
        private void AquaUI_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void AquaUI_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AquaUIOpenFile(files[0]);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(currentFile);
            SaveFileDialog saveFileDialog;
            //Model saving
            if (modelExtensions.Contains(ext))
            {
                saveFileDialog = new SaveFileDialog()
                {
                    Title = "Save model file",
                    Filter = "PSO2 VTBF Model (*.aqp)|*.aqp|PSO2 VTBF Terrain (*.trp)|*.trp|PSO2 NIFL Model (*.aqp)|*.aqp|PSO2 NIFL Terrain (*.trp)|*.trp"
                };
                switch (ext)
                {
                    case ".aqp":
                    case ".aqo":
                        saveFileDialog.FilterIndex = 1;
                        break;
                    case ".trp":
                    case ".tro":
                        saveFileDialog.FilterIndex = 2;
                        break;
                    default:
                        saveFileDialog.FilterIndex = 1;
                        return;
                }
                if (isNIFL)
                {
                    saveFileDialog.FilterIndex += 2;
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    aquaUI.setAllTransparent(((ModelEditor)filePanel.Controls[0]).GetAllTransparentChecked());
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                        case 2:
                            aquaUI.toVTBFModel(saveFileDialog.FileName);
                            break;
                        case 3:
                        case 4:
                            aquaUI.toNIFLModel(saveFileDialog.FileName);
                            break;
                    }
                    currentFile = saveFileDialog.FileName;
                    AquaUIOpenFile(saveFileDialog.FileName);
                    this.Text = GetTitleString();
                }

            }
            //Anim Saving
            else if (motionExtensions.Contains(ext))
            {
                saveFileDialog = new SaveFileDialog()
                {
                    Title = "Save model file",
                    Filter = $"PSO2 VTBF Motion (*{ext})|*{ext}|PSO2 NIFL Motion (*{ext})|*{ext}"
                };
                if (isNIFL)
                {
                    saveFileDialog.FilterIndex += 1;
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            aquaUI.aqua.WriteVTBFMotion(saveFileDialog.FileName);
                            break;
                        case 2:
                            aquaUI.aqua.WriteNIFLMotion(saveFileDialog.FileName);
                            break;
                    }
                    currentFile = saveFileDialog.FileName;
                    AquaUIOpenFile(saveFileDialog.FileName);
                    this.Text = GetTitleString();
                }

            }
            else if (effectExtensions.Contains(ext))
            {
                saveFileDialog = new SaveFileDialog()
                {
                    Title = "Save EFfect file",
                    Filter = $"PSO2 Classic NIFL Effect (*{ext})|*{ext}"
                };
                /*
                if (isNIFL)
                {
                    saveFileDialog.FilterIndex += 1;
                }*/
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            aquaUI.aqua.WriteClassicNIFLEffect(saveFileDialog.FileName);
                            break;
                    }
                    currentFile = saveFileDialog.FileName;
                    AquaUIOpenFile(saveFileDialog.FileName);
                    this.Text = GetTitleString();
                }
            }
            else if (motionConfigExtensions.Contains(ext))
            {
                saveFileDialog = new SaveFileDialog()
                {
                    Title = "Save motion config file",
                    Filter = $"PSO2 Motion Config (*{ext})|*{ext}"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            AquaUtil.WriteBTI(aquaUI.aqua.aquaMotionConfigs[0], saveFileDialog.FileName);
                            break;
                    }
                    currentFile = saveFileDialog.FileName;
                    AquaUIOpenFile(saveFileDialog.FileName);
                    this.Text = GetTitleString();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile != null)
            {
                string ext = Path.GetExtension(currentFile);

                //Model saving
                if (modelExtensions.Contains(ext))
                {
                    aquaUI.setAllTransparent(((ModelEditor)filePanel.Controls[0]).GetAllTransparentChecked());
                    switch (isNIFL)
                    {
                        case true:
                            aquaUI.toNIFLModel(currentFile);
                            break;
                        case false:
                            aquaUI.toVTBFModel(currentFile);
                            break;
                    }
                    AquaUIOpenFile(currentFile);
                    this.Text = GetTitleString();
                }
                else if (motionExtensions.Contains(ext))
                {
                    switch (isNIFL)
                    {
                        case true:
                            aquaUI.aqua.WriteNIFLMotion(currentFile);
                            break;
                        case false:
                            aquaUI.aqua.WriteVTBFMotion(currentFile);
                            break;
                    }
                    AquaUIOpenFile(currentFile);
                    this.Text = GetTitleString();
                }
                else if (effectExtensions.Contains(ext))
                {
                    aquaUI.aqua.WriteClassicNIFLEffect(currentFile);
                    AquaUIOpenFile(currentFile);
                    this.Text = GetTitleString();
                }
                else if (motionConfigExtensions.Contains(ext))
                {
                    AquaUtil.WriteBTI(aquaUI.aqua.aquaMotionConfigs[0], currentFile);
                    AquaUIOpenFile(currentFile);
                    this.Text = GetTitleString();
                }
            }
        }

        public bool AquaUIOpenFile(string str = null)
        {
            string file = aquaUI.confirmFile(str);
            if (file != null)
            {
                UserControl control;
                currentFile = file;
                this.Text = GetTitleString();

                foreach (var ctrl in filePanel.Controls)
                {
                    if (ctrl is ModelEditor)
                    {
                        ((ModelEditor)ctrl).CloseControlWindows();
                    }
                }
                filePanel.Controls.Clear();
                switch (Path.GetExtension(file))
                {
                    case ".aqp":
                    case ".aqo":
                    case ".trp":
                    case ".tro":
                        ClearData();
                        aquaUI.aqua.ReadModel(file, true);
#if DEBUG
                        var test = aquaUI.aqua.aquaModels[0].models[0];
#endif
                        control = new ModelEditor(aquaUI.aqua.aquaModels[0]);
                        if (aquaUI.aqua.aquaModels[0].models[0].nifl.magic != 0)
                        {
                            isNIFL = true;
                        }
                        else
                        {
                            isNIFL = false;
                        }
                        this.Size = new Size(400, 360);
                        setModelOptions(true);
                        break;
                    case ".aqm":
                    case ".aqv":
                    case ".aqc":
                    case ".aqw":
                    case ".trm":
                    case ".trv":
                    case ".trw":
                        ClearData();
                        aquaUI.aqua.ReadMotion(file);
#if DEBUG
                        var test2 = aquaUI.aqua.aquaMotions[0].anims[0];
                        test2 = aquaUI.aqua.aquaMotions[0].anims[0];
#endif
                        this.Size = new Size(400, 320);
                        control = SetMotion();
                        break;
                    case ".aqe":
                        ClearData();
                        aquaUI.aqua.ReadEffect(file);
#if DEBUG
                        var test3 = aquaUI.aqua.aquaEffect[0];
                        test3 = aquaUI.aqua.aquaEffect[0];
#endif
                        if (aquaUI.aqua.aquaEffect[0].nifl.magic != 0)
                        {
                            isNIFL = true;
                        }
                        else
                        {
                            isNIFL = false;
                        }
                        control = new EffectEditor(aquaUI.aqua.aquaEffect[0]);
                        this.Size = new Size(800, 660);
                        setModelOptions(false);
                        break;
                    case ".bti":
                        ClearData();
                        aquaUI.aqua.ReadBTI(file);
                        control = new BTIEditor(aquaUI.aqua.aquaMotionConfigs[0]);
                        this.Size = new Size(600, 460);
                        setModelOptions(false);
                        break;
                    default:
                        MessageBox.Show("Invalid File");
                        return false;
                }
                filePanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                control.BringToFront();
            }

            return true;
        }

        private void ClearData()
        {
            aquaUI.aqua.aquaModels.Clear();
            aquaUI.aqua.aquaMotions.Clear();
            aquaUI.aqua.aquaEffect.Clear();
            aquaUI.aqua.aquaMotionConfigs.Clear();
        }

        private UserControl SetMotion()
        {
            UserControl control = new AnimationEditor(aquaUI.aqua.aquaMotions[0]);
            if (aquaUI.aqua.aquaMotions[0].anims[0].nifl.magic != 0)
            {
                isNIFL = true;
            }
            else
            {
                isNIFL = false;
            }
            setModelOptions(false);
            return control;
        }

        private void setModelOptions(bool setting)
        {
            averageNormalsOnSharedPositionVerticesToolStripMenuItem.Enabled = setting;
        }

        private void averageNormalsOnSharedPositionVerticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aquaUI.averageNormals();
            MessageBox.Show("Normal averaging complete!");
        }

        private void parseVTBFToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select a VTBF PSO2 file",
                Filter = "All Files|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    AquaModelLibrary.AquaUtil.AnalyzeVTBF(file);
                }
            }

        }

        private void parsePSO2TextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select a pso2 .text file",
                Filter = "PSO2 Text (*.text) Files|*.text",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DumpTextFiles(openFileDialog.FileNames);
            }
        }

        private void DumpTextFiles(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var text = AquaMiscMethods.ReadPSO2Text(fileName);

                StringBuilder output = new StringBuilder();
                output.AppendLine(Path.GetFileName(fileName) + " was created: " + File.GetCreationTime(fileName).ToString());
                output.AppendLine("Filesize is: " + new FileInfo(fileName).Length.ToString() + " bytes");
                output.AppendLine();
                for (int i = 0; i < text.text.Count; i++)
                {
                    output.AppendLine(text.categoryNames[i]);

                    for (int j = 0; j < text.text[i].Count; j++)
                    {
                        output.AppendLine($"Group {j}");

                        for (int k = 0; k < text.text[i][j].Count; k++)
                        {
                            var pair = text.text[i][j][k];
                            output.AppendLine($"{pair.name} - {pair.str}");
                        }
                        output.AppendLine();
                    }
                    output.AppendLine();
                }

                File.WriteAllText(fileName + ".txt", output.ToString());
            }
        }

        private void convertTxtToPSO2TextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select a .txt file (Must follow parsed pso2 .text formatting)",
                Filter = "txt (*.txt) Files|*.txt",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConvertTxtFiles(openFileDialog.FileNames);
            }
        }

        private void ConvertTxtFiles(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                AquaUtil.ConvertPSO2Text(fileName.Split('.')[0] + ".text", fileName);
            }
        }
        private void parsePSO2TextFolderSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select pso2 .text folder",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DumpTextFiles(Directory.GetFiles(goodFolderDialog.FileName, "*.text"));
            }
        }
        private void convertTxtToPSO2TextFolderSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select .txt folder",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ConvertTxtFiles(Directory.GetFiles(goodFolderDialog.FileName, "*.txt"));
            }
        }

        private void readBonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 Bones",
                Filter = "PSO2 Bones (*.aqn, *.trn)|*.aqn;*.trn"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                aquaUI.aqua.ReadBones(openFileDialog.FileName);
#if DEBUG
                for (int i = 0; i < aquaUI.aqua.aquaBones[0].nodeList.Count; i++)
                {
                    var bone = aquaUI.aqua.aquaBones[0].nodeList[i];
                    Console.WriteLine($"{bone.boneName.GetString()} {bone.boneShort1.ToString("X")} {bone.boneShort2.ToString("X")}  {bone.eulRot.X.ToString()} {bone.eulRot.Y.ToString()} {bone.eulRot.Z.ToString()} ");
                    Console.WriteLine((bone.parentId == -1) + "");
                }
#endif
            }
        }

        private void updateClassicPlayerAnimToNGSAnimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select NGS PSO2 Bones",
                Filter = "PSO2 Bones (*.aqn)|*.aqn"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                aquaUI.aqua.aquaBones.Clear();
                aquaUI.aqua.ReadBones(openFileDialog.FileName);
                if (aquaUI.aqua.aquaBones[0].nodeList.Count < 171)
                {
                    aquaUI.aqua.aquaBones.Clear();
                    MessageBox.Show("Not an NGS PSO2 .aqn");
                    return;
                }
                var data = new AquaModelLibrary.NGSAnimUpdater();
                data.GetDefaultTransformsFromBones(aquaUI.aqua.aquaBones[0]);

                openFileDialog = new OpenFileDialog()
                {
                    Title = "Select Classic PSO2 Player Animation",
                    Filter = "PSO2 Player Animation (*.aqm)|*.aqm",
                    FileName = ""
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    aquaUI.aqua.aquaBones.Clear();
                    aquaUI.aqua.aquaMotions.Clear();
                    aquaUI.aqua.ReadMotion(openFileDialog.FileName);
                    data.UpdateToNGSPlayerMotion(aquaUI.aqua.aquaMotions[0].anims[0]);

                    currentFile = openFileDialog.FileName;
                    this.Text = GetTitleString();

                    filePanel.Controls.Clear();
                    var control = SetMotion();
                    filePanel.Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                    control.BringToFront();
                }
            }
        }

        private void generateFileReferenceSheetsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                goodFolderDialog.Title = "Select output directory";
                var pso2_binDir = goodFolderDialog.FileName;

                if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var outfolder = goodFolderDialog.FileName;

                    aquaUI.aqua.pso2_binDir = pso2_binDir;
                    aquaUI.aqua.GenerateFileReferenceSheets(pso2_binDir, outfolder);
                }
            }

        }

        private void batchParsePSO2SetToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select a folder containing pso2 .sets",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                List<string> files = new List<string>();
                string[] extensions = new string[] { "*.set" };
                foreach (string s in extensions)
                {
                    files.AddRange(Directory.GetFiles(goodFolderDialog.FileName, s));
                }

                //Go through models we gathered
                foreach (string file in files)
                {
                    aquaUI.aqua.ReadSet(file);
                }

                //Gather from .set files. This is subject to change because I'm really just checking things for now.
                StringBuilder allSetOutput = new StringBuilder();
                StringBuilder objSetOutput = new StringBuilder();
                for (int i = 0; i < aquaUI.aqua.aquaSets.Count; i++)
                {
                    StringBuilder setString = new StringBuilder();

                    var set = aquaUI.aqua.aquaSets[i];
                    setString.AppendLine(set.fileName);

                    //Strings
                    foreach (var entityString in set.entityStrings)
                    {
                        for (int sub = 0; sub < entityString.subStrings.Count; sub++)
                        {
                            var subStr = entityString.subStrings[sub];
                            setString.Append(subStr);
                            if (sub != (entityString.subStrings.Count - 1))
                            {
                                setString.Append(",");
                            }
                        }
                        setString.AppendLine();
                    }

                    //Objects
                    foreach (var obj in set.setEntities)
                    {
                        if (obj.variables.ContainsKey("object_name"))
                        {
                            StringBuilder objString = new StringBuilder();
                            objString.AppendLine(obj.entity_variant_string0.GetString());
                            objString.AppendLine(obj.entity_variant_string1);
                            objString.AppendLine(obj.entity_variant_stringJP);
                            foreach (var variable in obj.variables)
                            {
                                objString.AppendLine(variable.Key + " - " + variable.Value.ToString());
                            }
                            setString.Append(objString);

                            objSetOutput.AppendLine(set.fileName);
                            objSetOutput.Append(objString);
                        }
                    }

                    allSetOutput.Append(setString);
                    allSetOutput.AppendLine();
                }

                File.WriteAllText(goodFolderDialog.FileName + "\\" + "allSetOutput.txt", allSetOutput.ToString());
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "objects.txt", objSetOutput.ToString());

                aquaUI.aqua.aquaSets.Clear();
            }
        }

        private void checkAllShaderExtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select a folder containing pso2 models/ice files (PRM has no shader and will not be read). This shit can take a longass time",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Dictionary<string, List<string>> shaderCombinationsTexSheet = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderModelFilesTexSheet = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderTexListCode = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderTexDataCode = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderUnk0 = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderCombinations = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderModelFiles = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderDetails = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> shaderExtras = new Dictionary<string, List<string>>();
                List<string> files = new List<string>();
                string[] extensions = new string[] { ".aqp", ".aqo", ".trp", ".tro" };
                files.AddRange(Directory.GetFiles(goodFolderDialog.FileName, "*", SearchOption.AllDirectories));

                //Go through models we gathered
                foreach (string file in files)
                {
                    if (extensions.Contains(Path.GetExtension(file)))
                    {
                        try
                        {
                            aquaUI.aqua.ReadModel(file);
                        }
                        catch
                        {
                            Console.WriteLine("Could not read file: " + file);
                            continue;
                        }

                        ParseModelShaderInfo(shaderUnk0, shaderCombinations, shaderModelFiles, shaderDetails, shaderExtras, file);
                        GetTexSheetData(shaderCombinationsTexSheet, shaderModelFilesTexSheet, shaderTexListCode, shaderTexDataCode, file);
                    }
                    else
                    {
                        var fileBytes = File.ReadAllBytes(file);
                        if (fileBytes.Length > 0)
                        {
                            var magic = BitConverter.ToInt32(fileBytes, 0);
                            if (magic == 0x454349)
                            {
                                var strm = new MemoryStream(fileBytes);
                                IceFile fVarIce;
                                try
                                {
                                    fVarIce = IceFile.LoadIceFile(strm);

                                    List<byte[]> iceFiles = (new List<byte[]>(fVarIce.groupOneFiles));
                                    iceFiles.AddRange(fVarIce.groupTwoFiles);

                                    //Loop through files to get what we need
                                    foreach (byte[] iceFileBytes in iceFiles)
                                    {
                                        var name = IceFile.getFileName(iceFileBytes).ToLower();
                                        var nameExtension = Path.GetExtension(name);
                                        if (extensions.Contains(nameExtension))
                                        {
                                            try
                                            {
                                                aquaUI.aqua.aquaModels.Clear();
                                                aquaUI.aqua.ReadModel(iceFileBytes);
                                                ParseModelShaderInfo(shaderUnk0, shaderCombinations, shaderModelFiles, shaderDetails, shaderExtras, name);
                                                GetTexSheetData(shaderCombinationsTexSheet, shaderModelFilesTexSheet, shaderTexListCode, shaderTexDataCode, name);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Could not read file: " + name + " in " + file);
                                                continue;
                                            }
                                        }
                                    }

                                    fVarIce = null;
                                }
                                catch
                                {
                                }
                                strm.Dispose();
                            }
                        }

                        fileBytes = null;
                    }
                    aquaUI.aqua.aquaModels.Clear();
                }

                //Sort the list so we don't get a mess
                var keys = shaderCombinations.Keys.ToList();
                keys.Sort();

                StringBuilder simpleOutput = new StringBuilder();
                StringBuilder advancedOutput = new StringBuilder();
                StringBuilder detailDictOutput = new StringBuilder();
                StringBuilder extraDictOutput = new StringBuilder();
                StringBuilder unk0DictOutput = new StringBuilder();
                detailDictOutput.Append("using System.Collections.Generic;\n" +
                    "using static AquaModelLibrary.NGSAquaObject;\n\n" +
                    "namespace AquaModelLibrary.AquaStructs.NGSShaderPresets\n" +
                    "{\n" +
                    "    //Autogenerated presets from existing models\n" +
                    "    public static class NGSShaderDetail\n" +
                    "    {\n");
                extraDictOutput.Append("using System.Collections.Generic;\n" +
                    "using System.Numerics;\n" +
                    "using static AquaModelLibrary.NGSAquaObject;\n\n" +
                    "namespace AquaModelLibrary.AquaStructs.NGSShaderDetailPresets\n" +
                    "{\n" +
                    "    //Autogenerated presets from existing models\n" +
                    "    public static class NGSShaderExtraPresets\n" +
                    "    {\n");
                unk0DictOutput.Append("using System.Collections.Generic;\n" +
                    "namespace AquaModelLibrary.AquaStructs.NGSShaderPresets\n" +
                    "{\n" +
                    "    //Autogenerated presets from existing models\n" +
                    "    public static class NGSShaderUnk0ValuesPresets\n" +
                    "    {\n");
                detailDictOutput.Append("        public static Dictionary<string, SHADDetail> NGSShaderDetail = new Dictionary<string, SHADDetail>(){\n");
                extraDictOutput.Append("        public static Dictionary<string, List<SHADExtraEntry>> NGSShaderExtra = new Dictionary<string, List<SHADExtraEntry>>(){\n");
                unk0DictOutput.Append("        public static Dictionary<string, int> ShaderUnk0Values = new Dictionary<string, int>(){\n");
                foreach (var key in keys)
                {
                    simpleOutput.Append("\n" + key + "\n" + shaderCombinations[key][0]);
                    if (shaderDetails[key][0] != null && shaderDetails[key][0] != "")
                    {
                        detailDictOutput.Append("            " + shaderDetails[key][0]);
                    }
                    if (shaderExtras[key][0] != null && shaderExtras[key][0] != "")
                    {
                        extraDictOutput.Append("            " + shaderExtras[key][0]);
                    }
                    if (shaderUnk0[key][0] != null && shaderUnk0[key][0] != "")
                    {
                        unk0DictOutput.Append("            " + shaderUnk0[key][0]);
                    }
                    advancedOutput.Append("\n" + key + "\n" + shaderCombinations[key][0] + "," + shaderModelFiles[key][0]);
                    for (int i = 1; i < shaderCombinations[key].Count; i++)
                    {
                        advancedOutput.AppendLine("," + shaderCombinations[key][i] + "," + shaderModelFiles[key][i] + "," + shaderUnk0[key][i]);
                        advancedOutput.AppendLine();
                    }
                    advancedOutput.AppendLine();
                }
                detailDictOutput.Append("        };\n\n    }\n}");
                extraDictOutput.Append("        };\n\n    }\n}");
                unk0DictOutput.Append("        };\n\n    }\n}");

                //Sort the tex sheet list so we don't get a mess
                var keysTexSheet = shaderCombinationsTexSheet.Keys.ToList();
                keysTexSheet.Sort();

                StringBuilder simpleOutputTexSheet = new StringBuilder();
                StringBuilder advancedOutputTexSheet = new StringBuilder();
                StringBuilder presetTexList = new StringBuilder();
                StringBuilder tstaDict = new StringBuilder();

                presetTexList.Append("using System.Collections.Generic;\n" +
                    "namespace AquaModelLibrary.AquaStructs.NGSShaderPresets\n" +
                    "{\n" +
                    "    //Autogenerated presets from existing models\n" +
                    "    public static class PSO2ShaderTexSetPresets\n" +
                    "    {\n");
                tstaDict.Append("using System.Collections.Generic;\n" +
                    "using System.Numerics;\n" +
                    "using static AquaModelLibrary.AquaObject;\n\n" +
                    "namespace AquaModelLibrary.AquaStructs.NGSShaderPresets\n" +
                    "{\n" +
                    "    //Autogenerated presets from existing models\n" +
                    "    public static class PSO2ShaderTexInfoPresets\n" +
                    "    {\n");
                presetTexList.Append("        public static Dictionary<string, List<string>> shaderTexSet = new Dictionary<string, List<string>>(){\n");
                tstaDict.Append("        public static Dictionary<string, Dictionary<string, AquaObject.TSTA>> tstaTexSet = new Dictionary<string, Dictionary<string, AquaObject.TSTA>>(){\n");
                foreach (var key in keysTexSheet)
                {
                    simpleOutputTexSheet.AppendLine(key + "," + shaderCombinationsTexSheet[key][0]);
                    presetTexList.Append("            " + shaderTexListCode[key][0]);

                    string texDataStr = "";
                    //We want the largest one since in most cases it should contain the most definitions for textures (NGS shaders do NOT need all textures and instead have textures allocated based on other values)
                    for (int i = 0; i < shaderTexDataCode[key].Count; i++)
                    {
                        if (shaderTexDataCode[key][i].Length > texDataStr.Length)
                        {
                            texDataStr = shaderTexDataCode[key][i];
                        }
                    }
                    tstaDict.Append("            " + texDataStr);
                    advancedOutputTexSheet.AppendLine(key + "," + shaderCombinationsTexSheet[key][0] + "," + shaderModelFilesTexSheet[key][0]);
                    for (int i = 1; i < shaderCombinationsTexSheet[key].Count; i++)
                    {
                        advancedOutputTexSheet.AppendLine("," + shaderCombinationsTexSheet[key][i] + "," + shaderModelFilesTexSheet[key][i]);
                    }
                    advancedOutputTexSheet.AppendLine();
                }
                presetTexList.Append("        };\n\n    }\n}");
                tstaDict.Append("        };\n\n    }\n}");
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "simpleNGSOutput.csv", simpleOutput.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "detailedNGSOutput.csv", advancedOutput.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "simpleOutputTexSheets.csv", simpleOutputTexSheet.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "detailedOutputTexSheets.csv", advancedOutputTexSheet.ToString(), Encoding.UTF8);

                //Terrible chonks of code for the greater good
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "NGSShaderDetailPresets.cs", detailDictOutput.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "NGSShaderExtraPresets.cs", extraDictOutput.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "NGSShaderUnk0ValuesPresets.cs", unk0DictOutput.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "NGSShaderTexInfoPresets.cs", presetTexList.ToString(), Encoding.UTF8);
                File.WriteAllText(goodFolderDialog.FileName + "\\" + "NGSShaderTexSetPresets.cs", tstaDict.ToString(), Encoding.UTF8);
            }

            aquaUI.aqua.aquaModels.Clear();
        }

        private void ParseModelShaderInfo(Dictionary<string, List<string>> shaderUnk0, Dictionary<string, List<string>> shaderCombinations, Dictionary<string, List<string>> shaderModelFiles, Dictionary<string, List<string>> shaderDetails, Dictionary<string, List<string>> shaderExtras, string file)
        {
            string filestring = file;
            //Add them to the list
            if (filestring.Contains(":"))
            {
                filestring = Path.GetFileName(filestring);
            }
            var model = aquaUI.aqua.aquaModels[0].models[0];

            //Go through all meshes in each model
            foreach (var shad in model.shadList)
            {
                string key = shad.pixelShader.GetString() + " " + shad.vertexShader.GetString();
                string shad0Line = "{" + $"\"{key}\", " + shad.unk0.ToString() + " },\n";

                if (shad.isNGS && (shad.shadDetailOffset != 0 || shad.shadExtraOffset != 0))
                {
                    AquaObject.SHAD ngsShad = shad;

                    string data = "";
                    string detData = "";
                    string extData = "";
                    if (ngsShad.shadDetailOffset != 0)
                    {
                        data = $"Detail : \n unk0:{ngsShad.shadDetail.unk0} Extra Count:{ngsShad.shadDetail.shadExtraCount} unk1:{ngsShad.shadDetail.unk1} unkCount0:{ngsShad.shadDetail.unkCount0}\n" +
                            $" unk2:{ngsShad.shadDetail.unk2} unkCount1:{ngsShad.shadDetail.unkCount1} unk3:{ngsShad.shadDetail.unk3} unk4:{ngsShad.shadDetail.unk4}\n";
                        detData = "{" + $"\"{key}\", CreateDetail({ngsShad.shadDetail.unk0}, {ngsShad.shadDetail.shadExtraCount}, {ngsShad.shadDetail.unk1}, " +
                            $"{ngsShad.shadDetail.unkCount0}, {ngsShad.shadDetail.unk2}, {ngsShad.shadDetail.unkCount1}, {ngsShad.shadDetail.unk3}, " +
                            $"{ngsShad.shadDetail.unk4})" + "},\n";
                    }
                    if (ngsShad.shadExtraOffset != 0)
                    {
                        data += "Extra :\n";
                        extData = "{" + $"\"{key}\", new List<SHADExtraEntry>()" + "{";
                        foreach (var extra in ngsShad.shadExtra)
                        {
                            data += $"{extra.entryString.GetString()} {extra.entryFlag0} {extra.entryFlag1} {extra.entryFlag2}\n" +
                                $"{extra.entryFloats.X} {extra.entryFloats.Y} {extra.entryFloats.Z} {extra.entryFloats.W}\n";
                            extData += " CreateExtra(" + $"{extra.entryFlag0}, \"{extra.entryString.GetString()}\",";
                            extData += $" {extra.entryFlag1}, {extra.entryFlag2}";
                            if (extra.entryFloats != Vector4.Zero)
                            {
                                extData += $", new Vector4({extra.entryFloats.X}f, {extra.entryFloats.Y}f, {extra.entryFloats.Z}f, {extra.entryFloats.W}f)";
                            }
                            extData += "),";
                        }
                        extData += "}},\n";
                    }

                    if (!shaderCombinations.ContainsKey(key))
                    {
                        shaderUnk0[key] = new List<string>() { shad0Line };
                        shaderCombinations[key] = new List<string>() { data };
                        shaderModelFiles[key] = new List<string>() { filestring };
                        shaderDetails[key] = new List<string>() { detData };
                        shaderExtras[key] = new List<string>() { extData };
                    }
                    else
                    {
                        shaderUnk0[key].Add(shad0Line);
                        shaderCombinations[key].Add(data);
                        shaderModelFiles[key].Add(filestring);
                        shaderDetails[key].Add(detData);
                        shaderExtras[key].Add(extData);
                    }
                }
                else if (shad.unk0 != 0)
                {
                    if (!shaderCombinations.ContainsKey(key))
                    {
                        shaderUnk0[key] = new List<string>() { shad0Line };
                        shaderCombinations[key] = new List<string>() { "" };
                        shaderModelFiles[key] = new List<string>() { filestring };
                        shaderDetails[key] = new List<string>() { "" };
                        shaderExtras[key] = new List<string>() { "" };
                    }
                    else
                    {
                        shaderUnk0[key].Add(shad0Line);
                        shaderCombinations[key].Add("");
                        shaderModelFiles[key].Add(filestring);
                        shaderDetails[key].Add("");
                        shaderExtras[key].Add("");
                    }
                }
                else
                {
                    continue;
                }
            }


            model = null;
        }

        private void GetTexSheetData(Dictionary<string, List<string>> shaderCombinationsTexSheet, Dictionary<string, List<string>> shaderModelFilesTexSheet, Dictionary<string, List<string>> shaderTexListCode,
            Dictionary<string, List<string>> shaderTexDataCode, string file)
        {
            var model = aquaUI.aqua.aquaModels[0].models[0];

            //Go through all meshes in each model
            foreach (var mesh in model.meshList)
            {
                var shad = model.shadList[mesh.shadIndex];
                string key = shad.pixelShader.GetString() + " " + shad.vertexShader.GetString();
                var textures = AquaObjectMethods.GetTexListTSTAs(model, mesh.tsetIndex);

                if (textures.Count == 0 || textures == null)
                {
                    continue;
                }
                Dictionary<string, int> usedTextures = new Dictionary<string, int>();

                string combination = "";
                string combination2 = "{" + $"\"{key}\", new List<string>() " + "{ ";
                string combination3 = "{" + $"\"{key}\", new Dictionary<string, AquaObject.TSTA>() " + "{ ";
                foreach (var tex in textures)
                {
                    string texString = "";
                    foreach (var ptn in texNamePresetPatterns.Keys)
                    {
                        if (tex.texName.GetString().Contains(ptn))
                        {
                            texString = texNamePresetPatterns[ptn];
                            combination += texString;
                            combination2 += "\"" + texString + "\"" + ", ";
                            break;
                        }
                    }

                    if (combination == "") //Add the full name if we absolutely cannot figure this out from these
                    {
                        texString = tex.texName.GetString();
                        combination += texString;
                        combination2 += "\"" + texString + "\"" + ", ";
                    }

                    if (!usedTextures.ContainsKey(texString))
                    {
                        usedTextures[texString] = 0;
                    }
                    else
                    {
                        usedTextures[texString] += 1;
                    }

                    combination3 += "{\"" + texString + usedTextures[texString] + "\", new AquaObject.TSTA() {";
                    if (tex.tag != 0)
                    {
                        combination3 += $"tag = {tex.tag},";
                    }
                    if (tex.texUsageOrder != 0)
                    {
                        combination3 += $"texUsageOrder = {tex.texUsageOrder},";
                    }
                    if (tex.modelUVSet != 0)
                    {
                        combination3 += $"modelUVSet = {tex.modelUVSet},";
                    }
                    if (tex.unkVector0 != Vector3.Zero)
                    {
                        combination3 += $"unkVector0 = new Vector3({tex.unkVector0.X}f, {tex.unkVector0.Y}f, {tex.unkVector0.Z}f),";
                    }
                    if (tex.unkFloat2 != 0)
                    {
                        combination3 += $"unkFloat2 = {tex.unkFloat2}f,";
                    }
                    if (tex.unkFloat3 != 0)
                    {
                        combination3 += $"unkFloat3 = {tex.unkFloat3}f,";
                    }
                    if (tex.unkFloat4 != 0)
                    {
                        combination3 += $"unkFloat4 = {tex.unkFloat4}f,";
                    }
                    if (tex.unkInt3 != 0)
                    {
                        combination3 += $"unkInt3 = {tex.unkInt3},";
                    }
                    if (tex.unkInt4 != 0)
                    {
                        combination3 += $"unkInt4 = {tex.unkInt4},";
                    }
                    if (tex.unkInt5 != 0)
                    {
                        combination3 += $"unkInt5 = {tex.unkInt5},";
                    }
                    if (tex.unkFloat0 != 0)
                    {
                        combination3 += $"unkFloat0 = {tex.unkFloat0}f";
                    }
                    combination3 += "}}, ";
                    combination += " ";
                }
                combination2 += "}},\n";
                combination3 += "}},\n";

                //Add them to the list
                if (!shaderCombinationsTexSheet.ContainsKey(key))
                {
                    shaderTexListCode[key] = new List<string>() { combination2 };
                    shaderTexDataCode[key] = new List<string>() { combination3 };
                    shaderCombinationsTexSheet[key] = new List<string>() { combination };
                    shaderModelFilesTexSheet[key] = new List<string>() { Path.GetFileName(file) };
                }
                else
                {
                    shaderTexListCode[key].Add(combination2);
                    shaderTexDataCode[key].Add(combination3);
                    shaderCombinationsTexSheet[key].Add(combination);
                    shaderModelFilesTexSheet[key].Add(Path.GetFileName(file));
                }
            }
            model = null;
        }

        private void computeTangentSpaceTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AquaObjectMethods.ComputeTangentSpace(aquaUI.aqua.aquaModels[0].models[0], false, true);
        }

        private void cloneBoneTransformsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aquaUI.aqua.aquaBones.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 Bones",
                Filter = "PSO2 Bones (*.aqn, *.trn)|*.aqn;*.trn"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select PSO2 Bones",
                    Filter = "PSO2 Bones (*.aqn, *.trn)|*.aqn;*.trn"
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    aquaUI.aqua.ReadBones(openFileDialog.FileName);
                    aquaUI.aqua.ReadBones(openFileDialog2.FileName);

                    var bone1 = aquaUI.aqua.aquaBones[0];
                    var bone2 = aquaUI.aqua.aquaBones[1];
                    for (int i = 0; i < bone1.nodeList.Count; i++)
                    {
                        var bone = bone1.nodeList[i];
                        //bone.firstChild = bone2.nodeList[i].firstChild;
                        bone.eulRot = bone2.nodeList[i].eulRot;
                        /*
                        bone.nextSibling = bone2.nodeList[i].nextSibling;
                        bone.ngsSibling = bone2.nodeList[i].ngsSibling;
                        bone.pos = bone2.nodeList[i].pos;
                        bone.scale = bone2.nodeList[i].scale;
                        bone.m1 = bone2.nodeList[i].m1;
                        bone.m2 = bone2.nodeList[i].m2;
                        bone.m3 = bone2.nodeList[i].m3;
                        bone.m4 = bone2.nodeList[i].m4;*/
                        bone1.nodeList[i] = bone;
                    }

                    AquaUtil.WriteBones(openFileDialog.FileName + "_out", bone1);
                }
            }
        }

        private void legacyAqp2objObjExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aquaUI.aqua.aquaModels.Count > 0)
            {
                var exportDialog = new SaveFileDialog()
                {
                    Title = "Export obj file for basic editing",
                    Filter = "Object model (*.obj)|*.obj"
                };
                if (exportDialog.ShowDialog() == DialogResult.OK)
                {
                    LegacyObj.LegacyObjIO.ExportObj(exportDialog.FileName, aquaUI.aqua.aquaModels[0].models[0]);
                }
            }
        }

        private void legacyAqp2objObjImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Import obj geometry to current file. Make sure to remove LOD models.
            if (aquaUI.aqua.aquaModels.Count > 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Title = "Select PSO2 .obj",
                    Filter = "PSO2 .obj (*.obj)|*.obj"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var newObj = LegacyObj.LegacyObjIO.ImportObj(openFileDialog.FileName, aquaUI.aqua.aquaModels[0].models[0]);
                    aquaUI.aqua.aquaModels[0].models.Clear();
                    aquaUI.aqua.aquaModels[0].models.Add(newObj);
                    ((ModelEditor)filePanel.Controls[0]).PopulateModelDropdown();
                }

            }
        }

        private void testVTXEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = aquaUI.aqua.aquaModels[0].models[0];
            for (int i = 0; i < model.vtxlList.Count; i++)
            {
                model.vtxeList[i] = AquaObjectMethods.ConstructClassicVTXE(model.vtxlList[i], out int vertSize);
            }
        }

        private void exportModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool includeMetadata = includeMetadataToolStripMenuItem.Checked;
            string ext = Path.GetExtension(currentFile);
            //Model saving
            if (modelExtensions.Contains(ext))
            {
                SaveFileDialog saveFileDialog;
                saveFileDialog = new SaveFileDialog()
                {
                    Title = "Export fbx model file",
                    Filter = "Filmbox files (*.fbx)|*.fbx",
                    FileName = Path.ChangeExtension(Path.GetFileName(currentFile), ".fbx")
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get bone ext
                    string boneExt = "";
                    switch (ext)
                    {
                        case ".aqo":
                        case ".aqp":
                            boneExt = ".aqn";
                            break;
                        case ".tro":
                        case ".trp":
                            boneExt = ".trn";
                            break;
                        default:
                            break;
                    }

                    var bonePath = currentFile.Replace(ext, boneExt);
                    aquaUI.aqua.aquaBones.Clear();
                    if (!File.Exists(bonePath))
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog()
                        {
                            Title = "Select PSO2 bones",
                            Filter = "PSO2 Bones (*.aqn,*.trn)|*.aqn;*.trn"
                        };
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            bonePath = openFileDialog.FileName;
                            aquaUI.aqua.ReadBones(bonePath);
                        }
                        else
                        {
                            MessageBox.Show("Must be able to read bones to export properly! Defaulting to single node placeholder.");
                            aquaUI.aqua.aquaBones.Add(AquaNode.GenerateBasicAQN());
                        }
                    }
                    else
                    {
                        aquaUI.aqua.ReadBones(bonePath);
                    }
                    OpenFileDialog aqmOpenFileDialog = new OpenFileDialog()
                    {
                        Title = "**!Optional!**  Select PSO2 skeletal animations",
                        Filter = "PSO2 skeletal Animations (*.aqm,*.trm)|*.aqm;*.trm",
                        Multiselect = true,
                    };
                    List<AquaMotion> aqms = new List<AquaMotion>();
                    List<string> aqmFileNames = new List<string>();
                    if (aqmOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        AquaUtil aqmUt = new AquaUtil();

                        foreach (var fname in aqmOpenFileDialog.FileNames)
                        {
                            aqmUt.aquaMotions.Clear();
                            aqmUt.ReadMotion(fname);
                            aqms.Add(aqmUt.aquaMotions[0].anims[0]);
                            aqmFileNames.Add(Path.GetFileName(fname));
                        }
                    }

                    var modelCount = exportLODModelsIfInSameaqpToolStripMenuItem.Checked ? aquaUI.aqua.aquaModels[0].models.Count : 1;

                    for (int i = 0; i < aquaUI.aqua.aquaModels[0].models.Count && i < modelCount; i++)
                    {
                        var model = aquaUI.aqua.aquaModels[0].models[i];
                        if (model.objc.type > 0xC32)
                        {
                            model.splitVSETPerMesh();
                        }
                        model.FixHollowMatNaming();

                        var name = saveFileDialog.FileName;
                        if (modelCount > 1)
                        {
                            name = Path.Combine(Path.GetDirectoryName(name), Path.GetFileNameWithoutExtension(name) + $"_{i}.fbx");
                        }
                        FbxExporter.ExportToFile(model, aquaUI.aqua.aquaBones[0], aqms, name, aqmFileNames, new List<Matrix4x4>(), includeMetadata);
                    }
                }
            }
        }

        private void dumpNOF0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 NIFL file",
                Filter = "PSO2 NIFL File (*)|*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaModelLibrary.AquaMethods.AquaGeneralMethods.DumpNOF0(openFileDialog.FileName);
            }
        }

        private void readBTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 NIFL file",
                Filter = "PSO2 NIFL File (*.bti)|*.bti"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                aquaUI.aqua.ReadBTI(openFileDialog.FileName);
            }
        }

        private void prmEffectModelExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 prm file",
                Filter = "PSO2 Effect Model File (*.prm, *.prx)|*.prm;*.prx",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read prms
                foreach (var file in openFileDialog.FileNames)
                {
                    aquaUI.aqua.LoadPRM(file);
                }

                //Set up export
                using (var ctx = new Assimp.AssimpContext())
                {
                    var formats = ctx.GetSupportedExportFormats();
                    List<(string ext, string desc)> filterKeys = new List<(string ext, string desc)>();
                    foreach (var format in formats)
                    {
                        filterKeys.Add((format.FileExtension, format.Description));
                    }
                    filterKeys.Sort();

                    SaveFileDialog saveFileDialog;
                    saveFileDialog = new SaveFileDialog()
                    {
                        Title = "Export model file",
                        Filter = ""
                    };
                    string tempFilter = "";
                    foreach (var fileExt in filterKeys)
                    {
                        tempFilter += $"{fileExt.desc} (*.{fileExt.ext})|*.{fileExt.ext}|";
                    }
                    tempFilter = tempFilter.Remove(tempFilter.Length - 1, 1);
                    saveFileDialog.Filter = tempFilter;
                    saveFileDialog.FileName = Path.GetFileName(Path.ChangeExtension(openFileDialog.FileName, "." + filterKeys[0].ext));

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var id = saveFileDialog.FilterIndex - 1;

                        Assimp.ExportFormatDescription exportFormat = null;
                        for (int i = 0; i < formats.Length; i++)
                        {
                            if (formats[i].Description == filterKeys[id].desc && formats[i].FileExtension == filterKeys[id].ext)
                            {
                                exportFormat = formats[i];
                                break;
                            }
                        }
                        if (exportFormat == null)
                        {
                            return;
                        }

                        //Iterate through each selected model and use the selected type.
                        var finalExtension = Path.GetExtension(saveFileDialog.FileName);
                        for (int i = 0; i < aquaUI.aqua.prmModels.Count; i++)
                        {
                            string finalName;
                            if (i == 0)
                            {
                                finalName = saveFileDialog.FileName;
                            }
                            else
                            {
                                finalName = Path.ChangeExtension(openFileDialog.FileNames[i], finalExtension);
                            }

                            var scene = ModelExporter.AssimpPRMExport(finalName, aquaUI.aqua.prmModels[i]);

                            try
                            {
                                ctx.ExportFile(scene, finalName, exportFormat.FormatId, Assimp.PostProcessSteps.FlipUVs);
                            }
                            catch (Win32Exception w)
                            {
                                MessageBox.Show($"Exception encountered: {w.Message}");
                            }
                        }


                    }
                }
                aquaUI.aqua.prmModels.Clear();
            }
        }

        private void prmEffectFromModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select Model file",
                Filter = "Assimp Model Files (*.*)|*.*"
            };
            List<string> filters = new List<string>();
            using (var ctx = new Assimp.AssimpContext())
            {
                foreach (var format in ctx.GetSupportedExportFormats())
                {
                    if (!filters.Contains(format.FileExtension))
                    {
                        filters.Add(format.FileExtension);
                    }
                }
            }
            filters.Sort();

            StringBuilder filterString = new StringBuilder("Assimp Model Files(");
            StringBuilder filterStringTypes = new StringBuilder("|");
            StringBuilder filterStringSections = new StringBuilder();
            foreach (var filter in filters)
            {
                filterString.Append($"*.{filter},");
                filterStringTypes.Append($"*.{filter};");
                filterStringSections.Append($"|{filter} Files ({filter})|*.{filter}");
            }

            //Get rid of comma, add parenthesis 
            filterString.Remove(filterString.Length - 1, 1);
            filterString.Append(")");

            //Get rid of unneeded semicolon
            filterStringTypes.Remove(filterStringTypes.Length - 1, 1);
            filterString.Append(filterStringTypes);

            //Add final section
            filterString.Append(filterStringSections);

            openFileDialog.Filter = filterString.ToString();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelImporter.AssimpPRMConvert(openFileDialog.FileName, Path.ChangeExtension(openFileDialog.FileName, ".prm"));
            }
        }

        private void readMagIndicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 MGX file",
                Filter = "PSO2 MGX File (*.mgx)|*.mgx"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> magIds = AquaMiscMethods.ReadMGX(openFileDialog.FileName);
            }
        }

        private void readCMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 CMO file",
                Filter = "PSO2 MGX File (*.cmo)|*.cmo"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var cmo = AquaUtil.LoadCMO(openFileDialog.FileName);
            }
        }

        private void legacyAqp2objBatchExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 model file",
                Filter = "PSO2 Model Files (*.aqp, *.aqo, *.trp, *.tro)|*.aqp;*.aqo;*.trp;*.tro",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read models
                AquaUtil aqua = new AquaUtil(); //We want to leave the currently loaded model alone.
                foreach (var file in openFileDialog.FileNames)
                {
                    aqua.aquaModels.Clear();
                    aqua.ReadModel(file);
                    LegacyObj.LegacyObjIO.ExportObj(file + ".obj", aqua.aquaModels[0].models[0]);
                }
            }
        }

        private void dumpFigEffectTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 FIG file",
                Filter = "PSO2 FIG Files (*.fig)|*.fig",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read figs
                StringBuilder sb = new StringBuilder();
                List<int> ints = new List<int>();
                foreach (var file in openFileDialog.FileNames)
                {
                    sb.Append(AquaModelLibrary.AquaMethods.AquaFigMethods.CheckFigEffectMaps(file, ints));
                }
                ints.Sort();
                sb.AppendLine("All types:");
                foreach (var num in ints)
                {
                    sb.AppendLine(num.ToString() + " " + num.ToString("X"));
                }
                File.WriteAllText(Path.GetDirectoryName(openFileDialog.FileNames[0]) + "\\" + "figEffectTypes.txt", sb.ToString());
            }
        }

        private void readCMXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var pso2_binDir = goodFolderDialog.FileName;

                aquaUI.aqua.pso2_binDir = pso2_binDir;
                var aquaCMX = new CharacterMakingIndex();

                aquaCMX = CharacterMakingIndexMethods.ExtractCMX(pso2_binDir, aquaCMX);
            }
        }

        private void readFIGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 FIG file",
                Filter = "PSO2 FIG Files (*.fig)|*.fig",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read figs
                foreach (var file in openFileDialog.FileNames)
                {
                    aquaUI.aqua.ReadFig(file);
                }
            }
        }

        private void dumpFigShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 FIG file",
                Filter = "PSO2 FIG Files (*.fig)|*.fig",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read figs
                StringBuilder sb = new StringBuilder();
                List<int> uniqueShapes = new List<int>();
                foreach (var file in openFileDialog.FileNames)
                {
                    aquaUI.aqua.aquaFigures.Clear();
                    aquaUI.aqua.ReadFig(file);

                    sb.AppendLine(Path.GetFileName(file));
                    var fig = aquaUI.aqua.aquaFigures[0];
                    if (fig.stateStructs != null)
                    {
                        foreach (var state in fig.stateStructs)
                        {
                            sb.AppendLine();
                            sb.AppendLine(state.text);
                            if (state.collision != null)
                            {
                                if (state.collision.colliders != null)
                                {
                                    foreach (var col in state.collision.colliders)
                                    {
                                        int shape = col.colStruct.shape;
                                        sb.AppendLine(shape + " " + col.name + " " + col.text1);
                                        if (!uniqueShapes.Contains(shape))
                                        {
                                            uniqueShapes.Add(shape);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                uniqueShapes.Sort();
                sb.AppendLine();
                sb.AppendLine("Unique Shapes");
                foreach (int shape in uniqueShapes)
                {
                    sb.AppendLine(shape + "");
                }
                File.WriteAllText(Path.GetDirectoryName(openFileDialog.FileNames[0]) + "\\" + "figShapes.txt", sb.ToString());
            }
        }

        private void readRebootLacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 finger LAC file",
                Filter = "PSO2 finger LAC Files (*.lac)|*.lac",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read LACs
                foreach (var file in openFileDialog.FileNames)
                {
                    AquaMiscMethods.ReadRebootLAC(file);
                }
            }
        }

        private void readLacToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 LAC file",
                Filter = "PSO2 LAC Files (*.lac)|*.lac",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read LACs
                foreach (var file in openFileDialog.FileNames)
                {
                    AquaMiscMethods.ReadLAC(file);
                }
            }
        }

        private void readCMXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                Title = "Select CMX",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var aquaCMX = new CharacterMakingIndex();

                aquaCMX = CharacterMakingIndexMethods.ReadCMX(goodFolderDialog.FileName, aquaCMX);
            }
        }

        private void proportionAQMAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                Title = "Select proportion AQM",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                StringBuilder outStr = new StringBuilder();
                StringBuilder endStr = new StringBuilder();
                Dictionary<uint, List<uint>> timeSorted = new Dictionary<uint, List<uint>>();
                aquaUI.aqua.aquaMotions.Clear();
                aquaUI.aqua.ReadMotion(goodFolderDialog.FileName);

                //Go through keyframes for every node and note each bone that uses a specific frame
                foreach (var keySet in aquaUI.aqua.aquaMotions[0].anims[0].motionKeys)
                {
                    foreach (var data in keySet.keyData)
                    {
                        foreach (var time in data.frameTimings)
                        {
                            uint trueTime = (uint)(time / data.GetTimeMultiplier());
                            if (!timeSorted.ContainsKey(trueTime))
                            {
                                timeSorted[trueTime] = new List<uint>();
                            }
                            if (!timeSorted[trueTime].Contains((uint)keySet.mseg.nodeId))
                            {
                                timeSorted[trueTime].Add((uint)keySet.mseg.nodeId);
                            }
                        }
                    }
                }

                var timeSortedKeys = timeSorted.Keys.ToList();
                timeSortedKeys.Sort();
                foreach (var key in timeSortedKeys)
                {
                    timeSorted[key].Sort();
                    outStr.AppendLine("Frame Time: " + key);
                    foreach (var node in timeSorted[key])
                    {
                        outStr.AppendLine($"  {node} - {aquaUI.aqua.aquaMotions[0].anims[0].motionKeys[(int)node].mseg.nodeName.GetString()}");
                    }
                    endStr.AppendLine(key + "");
                    outStr.AppendLine();
                }
                outStr.Append(endStr);
                File.WriteAllText(goodFolderDialog.FileName + "_times.txt", outStr.ToString());
            }
        }

        private void proportionAQMTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                Title = "Select proportion AQM",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                int finalFrame = 1;
                //Get framecount
                aquaUI.aqua.ReadMotion(goodFolderDialog.FileName);
                finalFrame = aquaUI.aqua.aquaMotions[0].anims[0].moHeader.endFrame;
                aquaUI.aqua.aquaMotions.Clear();

                //Go through the motion, make edits to all keys at a specific frame time, save a copy, reset, and repeat with an incrmented frametime until the final frame
                for (int i = 0; i <= finalFrame; i++)
                {
                    aquaUI.aqua.ReadMotion(goodFolderDialog.FileName);

                    foreach (var keySet in aquaUI.aqua.aquaMotions[0].anims[0].motionKeys)
                    {
                        foreach (var data in keySet.keyData)
                        {
                            int frameIndex = -1;
                            for (int j = 0; j < data.frameTimings.Count; j++)
                            {
                                if (data.frameTimings[j] / data.GetTimeMultiplier() == i)
                                {
                                    frameIndex = j;
                                }
                            }

                            if (frameIndex != -1)
                            {
                                data.vector4Keys[frameIndex] = new System.Numerics.Vector4(5, 5, 5, 0);
                            }
                        }
                    }

                    aquaUI.aqua.WriteNIFLMotion(goodFolderDialog.FileName.Replace(".aqm", $"_{i}.aqm"));
                    aquaUI.aqua.aquaMotions.Clear();
                }



            }
        }

        private void importAAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PS Nova aai file(s)",
                Filter = "PS Nova aai Files (*.aai)|*.aai|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    AAIMethods.ReadAAI(file);
                }
            }
        }

        private void proportionAQMJankTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                Title = "Select proportion AQM ice",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                aquaUI.aqua.aquaMotions.Clear();
                var strm = new MemoryStream(File.ReadAllBytes(goodFolderDialog.FileName));
                var fVarIce = IceFile.LoadIceFile(strm);
                strm.Dispose();

                int frameToHit = 6;
                int tfmType = 3;
                //int tfmType2 = 2;
                var vec4 = new System.Numerics.Vector4(5, 5, 5, 0);
                var vec4_2 = new System.Numerics.Vector4(0.707f, 0, -0.707f, 0);

                //Loop through files to get what we need
                for (int i = 0; i < fVarIce.groupTwoFiles.Length; i++)
                {
                    List<byte> file;
                    var name = IceFile.getFileName(fVarIce.groupTwoFiles[i]).ToLower();
                    switch (name)
                    {
                        case "pl_cmakemot_b_fc.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        case "pl_cmakemot_b_fh.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        case "pl_cmakemot_b_fh_hand.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        case "pl_cmakemot_b_fh_rb.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        case "pl_cmakemot_b_fh_rb_oldface.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        default:
                            break;
                    }
                    aquaUI.aqua.aquaMotions.Clear();
                }

                byte[] rawData = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), fVarIce.groupOneFiles, fVarIce.groupTwoFiles).getRawData(false, false);
                File.WriteAllBytes(goodFolderDialog.FileName + $"_{frameToHit}.ice", rawData);

                rawData = null;
                fVarIce = null;
            }
        }

        private List<byte> AdjustNormalKeysMotion(IceFile fVarIce, int frameToHit, int i, string name, int tfmType, System.Numerics.Vector4 vec4, int node = -1)
        {
            List<byte> file;
            aquaUI.aqua.ReadMotion(fVarIce.groupTwoFiles[i]);
            SetNormalKeysToValue(frameToHit, tfmType, vec4, node);
            file = aquaUI.aqua.GetNiflMotionBytes(name);
            file.InsertRange(0, (new IceHeaderStructures.IceFileHeader(name, (uint)file.Count)).GetBytes());
            fVarIce.groupTwoFiles[i] = file.ToArray();
            return file;
        }

        private void SetNormalKeysToValue(int frame, int keyType, System.Numerics.Vector4 value, int node = -1)
        {
            //Go through the motion, make edits to all keys at a specific frame time, save a copy, reset, and repeat with an incrmented frametime until the final frame

            foreach (var keySet in aquaUI.aqua.aquaMotions[0].anims[0].motionKeys)
            {
                if (node == -1 || keySet.mseg.nodeId == node)
                {
                    foreach (var data in keySet.keyData)
                    {
                        if (data.keyType == keyType)
                        {
                            int frameIndex = -1;
                            for (int j = 0; j < data.frameTimings.Count; j++)
                            {
                                if (data.frameTimings[j] / data.GetTimeMultiplier() == frame)
                                {
                                    frameIndex = j;
                                }
                            }

                            if (frameIndex != -1)
                            {
                                data.vector4Keys[frameIndex] = value;
                            }
                        }
                    }
                }
            }
        }

        //Unused data???
        private void proportionAQMFaceTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                Title = "Select face proportion AQM ice",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                aquaUI.aqua.aquaMotions.Clear();
                var strm = new MemoryStream(File.ReadAllBytes(goodFolderDialog.FileName));
                var fVarIce = IceFile.LoadIceFile(strm);
                strm.Dispose();

                int frameToHit = 62;
                int tfmType = 3;
                //int tfmType2 = 2;
                var vec4 = new System.Numerics.Vector4(5, 5, 5, 0);
                var vec4_2 = new System.Numerics.Vector4(0.707f, 0, -0.707f, 0);

                //Loop through files to get what we need
                for (int i = 0; i < fVarIce.groupTwoFiles.Length; i++)
                {
                    List<byte> file;
                    var name = IceFile.getFileName(fVarIce.groupTwoFiles[i]).ToLower();
                    switch (name)
                    {
                        case "pl_cmakemot_f_fd.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        case "pl_cmakemot_f_fh.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        case "pl_cmakemot_f_fn.aqm":
                            file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4);
                            //file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2);
                            break;
                        default:
                            break;
                    }
                    aquaUI.aqua.aquaMotions.Clear();
                }

                byte[] rawData = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), fVarIce.groupOneFiles, fVarIce.groupTwoFiles).getRawData(false, false);
                File.WriteAllBytes(goodFolderDialog.FileName + $"_{frameToHit}.ice", rawData);

                rawData = null;
                fVarIce = null;
            }
        }

        private void proportionAQMNGSFaceTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                Title = "Select NGS Face proportion AQM ice",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                aquaUI.aqua.aquaMotions.Clear();
                var strm = new MemoryStream(File.ReadAllBytes(goodFolderDialog.FileName));
                var fVarIce = IceFile.LoadIceFile(strm);
                strm.Dispose();

                int frameToHit = 158;
                int tfmType = 3;
                int tfmType2 = 2;
                int tfmType3 = 1;
                var vec4 = new System.Numerics.Vector4(5, 5, 5, 0);
                var vec4_2 = new System.Numerics.Vector4(0.707f, 0, -0.707f, 0);
                var vec4_3 = new System.Numerics.Vector4(5, 5, 5, 0);
                var node = -1;

                //Loop through files to get what we need
                for (int i = 0; i < fVarIce.groupTwoFiles.Length; i++)
                {
                    List<byte> file;
                    var name = IceFile.getFileName(fVarIce.groupTwoFiles[i]).ToLower();
                    if (name.Contains(".aqm"))
                    {
                        file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType3, vec4_3, node); //pos
                        file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType, vec4, node); //scale
                        file = AdjustNormalKeysMotion(fVarIce, frameToHit, i, name, tfmType2, vec4_2, node); //rot
                    }
                    aquaUI.aqua.aquaMotions.Clear();
                }

                byte[] rawData = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), fVarIce.groupOneFiles, fVarIce.groupTwoFiles).getRawData(false, false);
                File.WriteAllBytes(goodFolderDialog.FileName + $"_{frameToHit}.ice", rawData);

                rawData = null;
                fVarIce = null;
            }
        }

        private void batchPSO2ToFBXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select a PSO2 file",
                Filter = "All Supported Files|*.aqp;*.aqo;*.trp;*.tro;*.axs;*.prm;*.prx",
                Multiselect = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil aqua = new AquaUtil();
                foreach (var filename in openFileDialog.FileNames)
                {
                    AquaObject model;
                    bool isPrm = false;
                    var ext = Path.GetExtension(filename);
                    if (simpleModelExtensions.Contains(ext))
                    {
                        aqua.LoadPRM(filename);
                        aqua.ConvertPRMToAquaObject();
                        isPrm = true;
                    }
                    else
                    {
                        if (modelExtensions.Contains(ext))
                        {
                            //Get bone ext
                            string boneExt = "";
                            switch (ext)
                            {
                                case ".aqo":
                                case ".aqp":
                                    boneExt = ".aqn";
                                    break;
                                case ".tro":
                                case ".trp":
                                    boneExt = ".trn";
                                    break;
                                default:
                                    break;
                            }
                            var bonePath = filename.Replace(ext, boneExt);
                            aqua.aquaBones.Clear();
                            if (!File.Exists(bonePath)) //We need bones for this
                            {
                                //Check group 1 if group 2 doesn't have them
                                bonePath = bonePath.Replace("group2", "group1");
                                if (!File.Exists(bonePath))
                                {
                                    bonePath = null;
                                }
                            }
                            if (bonePath != null)
                            {
                                aqua.ReadBones(bonePath);
                            }
                            else
                            {
                                //If we really can't find anything, make a placeholder
                                aqua.aquaBones.Add(AquaNode.GenerateBasicAQN());
                            }
                        }
                        aqua.ReadModel(filename);
                    }


                    var modelCount = !isPrm && exportLODModelsIfInSameaqpToolStripMenuItem.Checked ? aquaUI.aqua.aquaModels[0].models.Count : 1;

                    for (int i = 0; i < aqua.aquaModels[0].models.Count && i < modelCount; i++)
                    {
                        model = aqua.aquaModels[0].models[i];
                        if (!isPrm && model.objc.type > 0xC32)
                        {
                            model.splitVSETPerMesh();
                        }
                        model.FixHollowMatNaming();

                        var name = Path.ChangeExtension(filename, ".fbx");
                        if (modelCount > 1)
                        {
                            name = Path.Combine(Path.GetDirectoryName(name), Path.GetFileNameWithoutExtension(name) + $"_{i}.fbx");
                        }
                        FbxExporter.ExportToFile(model, aqua.aquaBones[0], new List<AquaMotion>(), name, new List<string>(), new List<Matrix4x4>(), includeMetadataToolStripMenuItem.Checked);
                    }
                    aqua.aquaBones.Clear();
                    aqua.aquaModels.Clear();
                }
            }

        }

        private void convertNATextToEnPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select NA pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var pso2_binDir = goodFolderDialog.FileName;
                goodFolderDialog.Title = "Select JP pso2_bin";
                if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var jpPso2_binDir = goodFolderDialog.FileName;
                    goodFolderDialog.Title = "Select output directory";
                    if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        var outfolder = goodFolderDialog.FileName;
                        string inWin32 = pso2_binDir + "\\data\\win32_na\\";
                        string inWin32Reboot = pso2_binDir + "\\data\\win32reboot_na\\";
                        string inWin32Jp = jpPso2_binDir + "\\data\\win32_na\\";
                        string inWin32RebootJp = jpPso2_binDir + "\\data\\win32reboot_na\\";
                        string outWin32 = outfolder + "\\win32\\";
                        string outWin32Reboot = outfolder + "\\win32reboot\\";

                        Directory.CreateDirectory(outWin32);
                        Directory.CreateDirectory(outWin32Reboot);

                        var win32NAFiles = Directory.GetFiles(inWin32);
                        var win32rebootNAFiles = Directory.GetFiles(inWin32Reboot, "*", SearchOption.AllDirectories);

                        Parallel.ForEach(win32rebootNAFiles, file =>
                        {
                            var jpRbtFilename = (file.Replace(inWin32Reboot, inWin32RebootJp)).Replace("_na", "");
                            if (!File.Exists(jpRbtFilename))
                            {
                                return;
                            }
                            var rbtFile = ConvertNATextIce(file, jpRbtFilename);
                            if (rbtFile != null)
                            {
                                var newPath = file.Replace(inWin32Reboot, outWin32Reboot);
                                if (newPath == file)
                                {
                                    throw new Exception("Path not corrected!");
                                }
                                var newParDirectory = Path.GetDirectoryName(newPath);
                                Directory.CreateDirectory(newParDirectory);
                                File.WriteAllBytes(newPath, rbtFile);
                            }
                            rbtFile = null;
                        });
                        Parallel.ForEach(win32NAFiles, file =>
                        {
                            var jpFilename = (file.Replace(inWin32, inWin32Jp)).Replace("_na", "");
                            if (!File.Exists(jpFilename))
                            {
                                return;
                            }
                            var win32File = ConvertNATextIce(file, jpFilename);
                            if (win32File != null)
                            {
                                var newPath = file.Replace(inWin32, outWin32);
                                if (newPath == file)
                                {
                                    throw new Exception("Path not corrected!");
                                }
                                File.WriteAllBytes(newPath, win32File);
                            }
                            win32File = null;
                        });
                    }
                }

            }
        }

        public static byte[] ConvertNATextIce(string str, string jpStr)
        {
            IceFile iceFile = null;
            IceFile jpIceFile = null;
            bool copy = false;
            using (Stream strm = new FileStream(str, FileMode.Open))
            using (Stream jpStrm = new FileStream(jpStr, FileMode.Open))
            {
                if (strm.Length <= 0 || jpStrm.Length <= 0)
                {
                    return null;
                }
                //Check if this is even an ICE file
                byte[] arr = new byte[4];
                strm.Read(arr, 0, 4);
                bool isIce = arr[0] == 0x49 && arr[1] == 0x43 && arr[2] == 0x45 && arr[3] == 0;
                if (isIce == false)
                {
                    return null;
                }

                try
                {
                    iceFile = IceFile.LoadIceFile(strm);
                    jpIceFile = IceFile.LoadIceFile(jpStrm);
                }
                catch
                {
                    return null;
                }

                List<string> jpGroupOneNames = new List<string>();
                List<string> jpGroupTwoNames = new List<string>();

                //Index JP filenames first for replacing
                for (int i = 0; i < jpIceFile.groupOneFiles.Length; i++)
                {
                    string name = null;
                    try
                    {
                        name = IceFile.getFileName(jpIceFile.groupOneFiles[i]);
                    }
                    catch
                    {
                        Trace.WriteLine($"Unable to get filename in group one at id {i} in ice {str}");
                    }

                    //Check if this is something we shouldn't move over
                    foreach (var check in NAConversionBlackList)
                    {
                        if (name.Contains(check))
                        {
                            return null;
                        }
                    }

                    jpGroupOneNames.Add(name);
                }
                for (int i = 0; i < jpIceFile.groupTwoFiles.Length; i++)
                {
                    string name = null;
                    try
                    {
                        name = IceFile.getFileName(jpIceFile.groupTwoFiles[i]);
                    }
                    catch
                    {
                        Trace.WriteLine($"Unable to get filename in group two at id {i} in ice {str}");
                    }
                    //Check if this is something we shouldn't move over
                    foreach (var check in NAConversionBlackList)
                    {
                        if (name == null || name.Contains(check))
                        {
                            return null;
                        }
                    }

                    jpGroupTwoNames.Add(name);
                }

                for (int i = 0; i < iceFile.groupOneFiles.Length; i++)
                {
                    var name = IceFile.getFileName(iceFile.groupOneFiles[i]);

                    //In theory, the NA files have to be in the same group
                    var jpId = jpGroupOneNames.IndexOf(name);

                    if (name.Contains(".usm"))
                    {
                        copy = true;
                        if (jpId != -1)
                        {
                            jpIceFile.groupOneFiles[jpId] = iceFile.groupOneFiles[i];
                        }
                    }
                    else if (name.Contains(".dds"))
                    {
                        copy = true;
                        if (jpId != -1)
                        {
                            jpIceFile.groupOneFiles[jpId] = iceFile.groupOneFiles[i];
                        }
                    }
                    else if (name.Contains(".text"))
                    {
                        copy = true;
                        if (jpId != -1)
                        {
                            var text = new List<byte>(AquaMiscMethods.GetEngToJPTextAsBytes(AquaMiscMethods.ReadPSO2Text(iceFile.groupOneFiles[i]), AquaMiscMethods.ReadPSO2Text(jpIceFile.groupOneFiles[jpId])));
                            text.InsertRange(0, (new IceHeaderStructures.IceFileHeader(name, (uint)text.Count)).GetBytes());
                            jpIceFile.groupOneFiles[jpId] = text.ToArray();
                        }
                    }
                }
                for (int i = 0; i < iceFile.groupTwoFiles.Length; i++)
                {
                    var name = IceFile.getFileName(iceFile.groupTwoFiles[i]);

                    //In theory, the NA files have to be in the same group
                    var jpId = jpGroupTwoNames.IndexOf(name);

                    if (name.Contains(".usm"))
                    {
                        copy = true;
                        if (jpId != -1)
                        {
                            jpIceFile.groupTwoFiles[jpId] = iceFile.groupTwoFiles[i];
                        }
                    }
                    else if (name.Contains(".dds"))
                    {
                        copy = true;
                        if (jpId != -1)
                        {
                            jpIceFile.groupTwoFiles[jpId] = iceFile.groupTwoFiles[i];
                        }
                    }
                    else if (name.Contains(".text"))
                    {
                        copy = true;
                        if (jpId != -1)
                        {
                            var text = new List<byte>(AquaMiscMethods.GetEngToJPTextAsBytes(AquaMiscMethods.ReadPSO2Text(iceFile.groupTwoFiles[i]), AquaMiscMethods.ReadPSO2Text(jpIceFile.groupTwoFiles[jpId])));
                            text.InsertRange(0, (new IceHeaderStructures.IceFileHeader(name, (uint)text.Count)).GetBytes());
                            jpIceFile.groupTwoFiles[jpId] = text.ToArray();
                        }
                    }
                }
            }

            if (copy)
            {
                return new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), jpIceFile.groupOneFiles, jpIceFile.groupTwoFiles).getRawData(false, false);
            }
            else
            {
                return null;
            }
        }

        //List of strings to check for and stop conversion if found
        public static List<string> NAConversionBlackList = new List<string>() {
            "ui_icon",
            "ui_vital",
            "ui_making",
            "ui_reb_title01",
            "ui_ending_common",
            "ui_system_01",
            "ui_rough",
            ".fon",
            ".ttf",
        };

        private void aQMOnToAQNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select player Aqn",
                Filter = "aqn|*.aqn",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog()
                {
                    Title = "Select player Aqm",
                    Filter = "aqm|*.aqm",
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    AquaUtil aqua = new AquaUtil();
                    aqua.ReadBones(openFileDialog.FileName);
                    aqua.ReadMotion(openFileDialog1.FileName);

                    var bn = aqua.aquaBones[0];
                    var mtn = aqua.aquaMotions[0].anims[0];
                    for (int i = 0; i < mtn.motionKeys.Count; i++)
                    {
                        if (bn.nodeList.Count > i)
                        {
                            var node = bn.nodeList[i];
                            var rawPos = mtn.motionKeys[i].keyData[0].vector4Keys[0];
                            var pos = new Vector3(rawPos.X, rawPos.Y, rawPos.Z);

                            var rawRot = mtn.motionKeys[i].keyData[1].vector4Keys[0];
                            var rot = new Quaternion(rawRot.X, rawRot.Y, rawRot.Z, rawRot.W);

                            var rawScale = mtn.motionKeys[i].keyData[2].vector4Keys[0];
                            var scale = new Vector3(rawScale.X, rawScale.Y, rawScale.Z);

                            Matrix4x4 mat = Matrix4x4.Identity;

                            mat *= Matrix4x4.CreateScale(scale);
                            mat *= Matrix4x4.CreateFromQuaternion(rot);
                            mat *= Matrix4x4.CreateTranslation(pos);

                            if (bn.nodeList[i].parentId != -1)
                            {
                                Matrix4x4.Invert(bn.nodeList[bn.nodeList[i].parentId].GetInverseBindPoseMatrix(), out var parMat);

                                mat *= parMat;
                            }
                            Matrix4x4.Invert(mat, out var invMat);

                            node.SetInverseBindPoseMatrix(invMat);
                            node.boneName.SetString(node.boneName.curString + "_test");
                            bn.nodeList[i] = node;
                        }
                        else
                        {
                            break;
                        }
                    }

                    AquaUtil.WriteBones(openFileDialog.FileName.Replace(".aqn", $"_{Path.GetFileNameWithoutExtension(openFileDialog1.FileName)}.aqn"), bn);
                }
            }
        }

        private void aqnLocalTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select player Aqn",
                Filter = "aqn|*.aqn",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil aqua = new AquaUtil();
                aqua.ReadBones(openFileDialog.FileName);

                var bn = aqua.aquaBones[0];
                List<Vector3> boneLocalRots = new List<Vector3>();
                List<Vector3> boneLocalPos = new List<Vector3>();
                List<Quaternion> boneLocalQuats = new List<Quaternion>();
                List<Vector3> boneWorldRots = new List<Vector3>();
                List<Quaternion> boneWorldQuats = new List<Quaternion>();
                List<Quaternion> boneWorldInvInvRots = new List<Quaternion>();
                List<Quaternion> boneLocalInvInvRots = new List<Quaternion>();
                List<Vector3> boneLocalInvInvPos = new List<Vector3>();
                for (int i = 0; i < bn.nodeList.Count; i++)
                {
                    var node = bn.nodeList[i];
                    var pos = bn.nodeList[i].pos;
                    var rot = bn.nodeList[i].eulRot;
                    var scale = bn.nodeList[i].scale;

                    boneLocalPos.Add(pos);

                    Matrix4x4.Invert(bn.nodeList[i].GetInverseBindPoseMatrix(), out var invInvMat);
                    Matrix4x4.Decompose(invInvMat, out var invInvScale, out var invInvRot, out var invInvPos);
                    boneWorldInvInvRots.Add(invInvRot);
                    //boneLocalInvInvPos.Add(invInvPos);
                    if (bn.nodeList[i].parentId != -1)
                    {
                        var invParMat = bn.nodeList[bn.nodeList[i].parentId].GetInverseBindPoseMatrix();
                        Matrix4x4.Invert(invParMat, out var parInvInvMat);
                        Matrix4x4.Decompose(parInvInvMat, out var parinvInvLocScale, out var parinvInvLocRot, out var parinvInvLocPos);
                        var localMat = invInvMat * invParMat;
                        Matrix4x4.Decompose(localMat, out var invInvLocScale, out var invInvLocRot, out var invInvLocPos);
                        boneLocalInvInvPos.Add(invInvLocPos);
                        boneLocalInvInvRots.Add(invInvRot * Quaternion.Inverse(boneWorldInvInvRots[bn.nodeList[i].parentId]));
                    }
                    else
                    {
                        boneLocalInvInvPos.Add(invInvPos);
                        boneLocalInvInvRots.Add(invInvRot);
                    }
                    boneLocalRots.Add(rot);
                    boneLocalQuats.Add(AquaModelLibrary.Extra.MathExtras.EulerToQuaternion(node.eulRot));
                    Matrix4x4 mat = Matrix4x4.Identity;

                    mat *= Matrix4x4.CreateScale(scale);
                    var rotation = Matrix4x4.CreateRotationX((float)(rot.X * Math.PI / 180)) *
                        Matrix4x4.CreateRotationY((float)(rot.Y * Math.PI / 180)) *
                        Matrix4x4.CreateRotationZ((float)(rot.Z * Math.PI / 180));

                    mat *= rotation;
                    mat *= Matrix4x4.CreateTranslation(pos);

                    if (bn.nodeList[i].parentId != -1)
                    {
                        var parBone = bn.nodeList[bn.nodeList[i].parentId];
                        Matrix4x4.Invert(parBone.GetInverseBindPoseMatrix(), out var parMat);

                        mat *= parMat;

                        while (parBone.parentId != -1) //Root is expected to be 0, 0, 0 for rot and so won't factor in it
                        {
                            rot += parBone.eulRot;
                            parBone = bn.nodeList[parBone.parentId];
                        }
                    }
                    boneWorldRots.Add(rot);
                    boneWorldQuats.Add(Quaternion.CreateFromYawPitchRoll((float)(rot.Y * Math.PI / 180), (float)(rot.X * Math.PI / 180), (float)(rot.Z * Math.PI / 180)));

                    Matrix4x4.Invert(mat, out var invMat);

                    node.SetInverseBindPoseMatrix(invMat);
                    node.boneName.SetString(node.boneName.curString + "_test");
                    bn.nodeList[i] = node;
                }

                AquaUtil.WriteBones(openFileDialog.FileName.Replace(".aqn", $"_local.aqn"), bn);
            }
        }

        private void aqnHighestXYZValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select player Aqn",
                Filter = "aqn|*.aqn",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil aqua = new AquaUtil();
                aqua.ReadBones(openFileDialog.FileName);

                var bn = aqua.aquaBones[0];
                Vector3 max = new Vector3();
                for (int i = 0; i < bn.nodeList.Count; i++)
                {
                    var nodeVec = bn.nodeList[i].eulRot;
                    if (Math.Abs(nodeVec.X) > Math.Abs(max.X))
                    {
                        max.X = nodeVec.X;
                    }
                    if (Math.Abs(nodeVec.Y) > Math.Abs(max.Y))
                    {
                        max.Y = nodeVec.Y;
                    }
                    if (Math.Abs(nodeVec.Z) > Math.Abs(max.Z))
                    {
                        max.Z = nodeVec.Z;
                    }
                }

                Trace.WriteLine($"{max.X}, {max.Y}, {max.Z}");
            }
        }

        private void aqnDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select player Aqn",
                Filter = "aqn|*.aqn",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil aqua = new AquaUtil();
                aqua.ReadBones(openFileDialog.FileName);

                StringBuilder sb = new StringBuilder();
                var bn = aqua.aquaBones[0];
                for (int i = 0; i < bn.nodeList.Count; i++)
                {
                    var node = bn.nodeList[i];
                    sb.AppendLine($"=== ({i}) {node.boneName.curString}:");
                    sb.AppendLine($"Bone Short 1 {node.boneShort1.ToString("X")} | Bone Short 2 {node.boneShort2.ToString("X")}");
                    sb.AppendLine($"Animated Flag {node.animatedFlag}");
                    sb.AppendLine($"First Child {node.firstChild} | Next Sibling {node.nextSibling} | NGS Sibling {node.bool_1C} | Unk Node {node.unkNode}");
                    if (i != 0)
                    {
                        sb.AppendLine($"Parent info - ({node.parentId}) {bn.nodeList[node.parentId].boneName.curString}");
                    }
                    sb.AppendLine($"Pos {node.pos.X} {node.pos.Y} {node.pos.Z}");
                    sb.AppendLine($"Euler Rot {node.eulRot.X} {node.eulRot.Y} {node.eulRot.Z}");
                    var quatXyz = MathExtras.EulerToQuaternionByOrder(node.eulRot, RotationOrder.XYZ);
                    var quatXzy = MathExtras.EulerToQuaternionByOrder(node.eulRot, RotationOrder.XZY);
                    var quatYzx = MathExtras.EulerToQuaternionByOrder(node.eulRot, RotationOrder.YZX);
                    var quatYxz = MathExtras.EulerToQuaternionByOrder(node.eulRot, RotationOrder.YXZ);
                    var quatZxy = MathExtras.EulerToQuaternionByOrder(node.eulRot, RotationOrder.ZXY);
                    var quatZyx = MathExtras.EulerToQuaternionByOrder(node.eulRot, RotationOrder.ZYX);
                    sb.AppendLine($"XYZ Euler Rot to Quat {quatXyz.X} {quatXyz.Y} {quatXyz.Z} {quatXyz.W}");
                    sb.AppendLine($"XZY Euler Rot to Quat {quatXzy.X} {quatXzy.Y} {quatXzy.Z} {quatXzy.W}");
                    sb.AppendLine($"YZX Euler Rot to Quat {quatYzx.X} {quatYzx.Y} {quatYzx.Z} {quatYzx.W}");
                    sb.AppendLine($"YXZ Euler Rot to Quat {quatYxz.X} {quatYxz.Y} {quatYxz.Z} {quatYxz.W}");
                    sb.AppendLine($"ZXY Euler Rot to Quat {quatZxy.X} {quatZxy.Y} {quatZxy.Z} {quatZxy.W}");
                    sb.AppendLine($"ZYX Euler Rot to Quat {quatZyx.X} {quatZyx.Y} {quatZyx.Z} {quatZyx.W}");
                    sb.AppendLine($"Scale {node.scale.X} {node.scale.Y} {node.scale.Z}");
                    sb.AppendLine($"");

                    Matrix4x4.Invert(node.GetInverseBindPoseMatrix(), out var mat);
                    Matrix4x4.Decompose(mat, out var scale, out var rotation, out var pos);
                    Vector3 localEulRotXyz;
                    Vector3 localEulRotXzy;
                    Vector3 localEulRotYzx;
                    Vector3 localEulRotYxz;
                    Vector3 localEulRotZxy;
                    Vector3 localEulRotZyx;
                    Vector3 worldEulRot = MathExtras.QuaternionToEuler(rotation);
                    Quaternion localQuat;
                    Quaternion invParentRot = new Quaternion(-1, -1, -1, -1);
                    if (i != 0)
                    {
                        Matrix4x4.Invert(bn.nodeList[node.parentId].GetInverseBindPoseMatrix(), out var parMat);
                        Matrix4x4.Decompose(parMat, out var parScale, out var parRot, out var parPos);
                        var invParRot = Quaternion.Inverse(parRot);
                        localQuat = rotation * invParRot;
                        localEulRotXyz = MathExtras.QuaternionToEulerByOrder(rotation * invParRot, RotationOrder.XYZ);
                        localEulRotXzy = MathExtras.QuaternionToEulerByOrder(rotation * invParRot, RotationOrder.XZY);
                        localEulRotYzx = MathExtras.QuaternionToEulerByOrder(rotation * invParRot, RotationOrder.YZX);
                        localEulRotYxz = MathExtras.QuaternionToEulerByOrder(rotation * invParRot, RotationOrder.YXZ);
                        localEulRotZxy = MathExtras.QuaternionToEulerByOrder(rotation * invParRot, RotationOrder.ZXY);
                        localEulRotZyx = MathExtras.QuaternionToEulerByOrder(rotation * invParRot, RotationOrder.ZYX);
                        invParentRot = invParRot;
                    }
                    else
                    {
                        localEulRotXyz = worldEulRot;
                        localEulRotXzy = MathExtras.QuaternionToEulerByOrder(rotation, RotationOrder.XZY);
                        localEulRotYzx = MathExtras.QuaternionToEulerByOrder(rotation, RotationOrder.YZX);
                        localEulRotYxz = MathExtras.QuaternionToEulerByOrder(rotation, RotationOrder.YXZ);
                        localEulRotZxy = MathExtras.QuaternionToEulerByOrder(rotation, RotationOrder.ZXY);
                        localEulRotZyx = MathExtras.QuaternionToEulerByOrder(rotation, RotationOrder.ZYX);
                        localQuat = rotation;
                    }
                    sb.AppendLine($"Inv Bind World Pos {pos.X} {pos.Y} {pos.Z}");
                    sb.AppendLine($"XYZ Inv Bind Local Euler Rot {localEulRotXyz.X} {localEulRotXyz.Y} {localEulRotXyz.Z}");
                    sb.AppendLine($"XZY Inv Bind Local Euler Rot {localEulRotXzy.X} {localEulRotXzy.Y} {localEulRotXzy.Z}");
                    sb.AppendLine($"YZX Inv Bind Local Euler Rot {localEulRotYzx.X} {localEulRotYzx.Y} {localEulRotYzx.Z}");
                    sb.AppendLine($"YXZ Inv Bind Local Euler Rot {localEulRotYxz.X} {localEulRotYxz.Y} {localEulRotYxz.Z}");
                    sb.AppendLine($"ZXY Inv Bind Local Euler Rot {localEulRotZxy.X} {localEulRotZxy.Y} {localEulRotZxy.Z}");
                    sb.AppendLine($"ZYX Inv Bind Local Euler Rot {localEulRotZyx.X} {localEulRotZyx.Y} {localEulRotZyx.Z}");
                    sb.AppendLine($"Inv Bind World Euler Rot {worldEulRot.X} {worldEulRot.Y} {worldEulRot.Z}");
                    sb.AppendLine($"Inv Bind Local Quat Rot {localQuat.X} {localQuat.Y} {localQuat.Z} {localQuat.W}");
                    sb.AppendLine($"Inv Bind World Quat Rot {rotation.X} {rotation.Y} {rotation.Z} {rotation.W}");
                    sb.AppendLine($"Inv Bind World Scale {scale.X} {scale.Y} {scale.Z}");
                    sb.AppendLine($"===");
                    sb.AppendLine($"");
                }
                File.WriteAllText($"C:\\{Path.GetFileName(openFileDialog.FileName)}.txt", sb.ToString());
            }
        }

        private void readFLTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 Physics file(s)",
                Filter = "PSO2 Physics Files (*.fltd)|*.fltd|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FLTDPhysicsMethods.LoadFLTD(openFileDialog.FileName);
            }
        }

        private void testCMXBuild_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var pso2_binDir = goodFolderDialog.FileName;

                aquaUI.aqua.pso2_binDir = pso2_binDir;
                var aquaCMX = new CharacterMakingIndex();

                aquaCMX = CharacterMakingIndexMethods.ExtractCMX(pso2_binDir, aquaCMX);
                CharacterMakingIndexMethods.WriteCMX("C://benchmarkCMX.cmx", aquaCMX, 0);
                CharacterMakingIndexMethods.WriteCMX("C://finalCMX.cmx", aquaCMX, 1);
            }
        }

        private void readTXLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 Texture List file(s)",
                Filter = "PSO2 Texture List Files (*.txl)|*.fltd|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil.LoadTXL(openFileDialog.FileName);
            }
        }

        private void assembleNGSMapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                CommonOpenFileDialog goodFolderDialog2 = new CommonOpenFileDialog()
                {
                    IsFolderPicker = true,
                    Title = "Select output folder",
                };
                if (goodFolderDialog2.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    int id = NumberPrompt.ShowDialog("map");
                    if (id >= 0)
                    {
                        PSO2MapHandler.pngMode = convertMapTexturesTopngToolStripMenuItem.Checked;
                        PSO2MapHandler.DumpMapData(goodFolderDialog.FileName, goodFolderDialog2.FileName, id);
                    }
                }
            }
        }

        private void readAOXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var pso2_binDir = goodFolderDialog.FileName;

                var filename = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, GetFileHash(unitIndexIce));
                var iceFile = IceFile.LoadIceFile(new MemoryStream(File.ReadAllBytes(filename)));
                List<byte[]> files = new List<byte[]>();
                files.AddRange(iceFile.groupOneFiles);
                files.AddRange(iceFile.groupTwoFiles);

                for (int i = 0; i < files.Count; i++)
                {
                    var name = IceFile.getFileName(files[i]);
                    if (name == unitIndexFilename)
                    {
                        AquaUtil.LoadAOX(files[i]);
                    }

                }
            }
        }

        private void readLPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 LPS file(s)",
                Filter = "PSO2 LPS Files (*.lps)|*.lps|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil.LoadLPS(openFileDialog.FileName);
            }
        }

        private void boneFlagTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 AQN file(s)",
                Filter = "PSO2 AQN Files (*.aqn)|*.aqn|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil aqu = new AquaUtil();
                aqu.ReadBones(openFileDialog.FileName);
                for (int i = 0; i < aqu.aquaBones[0].nodeList.Count; i++)
                {
                    var bone = aqu.aquaBones[0].nodeList[i];
                    bone.boneShort2 = 0xFFFF;

                    aqu.aquaBones[0].nodeList[i] = bone;
                }

                AquaUtil.WriteBones(openFileDialog.FileName, aqu.aquaBones[0]);
            }
        }

        private void importNGSShaderDetailsAndExtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 Aqua Model file(s)",
                Filter = "PSO2 Aqua Model Files (*.aqp,*.trp,*.aqo,*.tro)|*.aqp;*.trp;*.aqo;*.tro|All Files (*.*)|*",
                Multiselect = true
            };
            if (aquaUI.aqua.aquaModels.Count > 0 && openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AquaUtil aqu = new AquaUtil();
                Dictionary<string, AquaObject.SHAD> ngsShaders = new Dictionary<string, AquaObject.SHAD>();
                aqu.ReadModel(openFileDialog.FileName);

                for (int i = 0; i < aqu.aquaModels[0].models[0].shadList.Count; i++)
                {
                    var shad = aqu.aquaModels[0].models[0].shadList[i];
                    if (shad.isNGS)
                    {
                        ngsShaders.Add($"{shad.pixelShader.GetString()} {shad.vertexShader.GetString()}", shad);
                    }

                }
                foreach (var model in aquaUI.aqua.aquaModels[0].models)
                {
                    for (int s = 0; s < model.shadList.Count; s++)
                    {
                        var curShader = model.shadList[s];
                        string shadKey = $"{curShader.pixelShader.GetString()} {curShader.vertexShader.GetString()}";
                        if (ngsShaders.TryGetValue(shadKey, out var value))
                        {
                            AquaObject.SHAD ngsCurShad = curShader;
                            ngsCurShad.isNGS = true;
                            ngsCurShad.shadDetail = value.shadDetail;
                            ngsCurShad.shadDetailOffset = value.shadDetailOffset;
                            ngsCurShad.shadExtra = value.shadExtra;
                            ngsCurShad.shadExtraOffset = value.shadExtraOffset;
                            model.shadList[s] = ngsCurShad;
                        }
                    }
                }

            }
        }

        private void importModelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (var ctx = new Assimp.AssimpContext())
            {
                var formats = ctx.GetSupportedImportFormats().ToList();
                formats.Sort();

                OpenFileDialog openFileDialog;
                openFileDialog = new OpenFileDialog()
                {
                    Title = "Import model file, fbx recommended (output .aqp and .aqn will write to import directory)",
                    Filter = ""
                };
                string tempFilter = "(*.fbx,*.dae,*.glb,*.gltf,*.pmx,*.smd)|*.fbx;*.dae;*.glb;*.gltf;*.pmx;*.smd";
                string tempFilter2 = "";
                /*foreach (var str in formats)
                {
                    tempFilter += $"*{str};";
                    tempFilter2 += $"|(*{str})|*{str}";
                }*/
                openFileDialog.Filter = tempFilter + tempFilter2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AquaUtil aqua = new AquaUtil();
                    ModelSet modelSet = new ModelSet();
                    modelSet.models.Add(ModelImporter.AssimpAquaConvertFull(openFileDialog.FileName, 1, false, true, out AquaNode aqn));
                    aqua.aquaModels.Add(modelSet);
                    var ext = Path.GetExtension(openFileDialog.FileName);
                    var outStr = openFileDialog.FileName.Replace(ext, "_out.aqp");
                    aqua.WriteNGSNIFLModel(outStr, outStr);
                    AquaUtil.WriteBones(Path.ChangeExtension(outStr, ".aqn"), aqn);

                    aqua.aquaModels.Clear();
                    AquaUIOpenFile(outStr);
                }
            }
        }

        private void convertPSNovaaxsaifToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PS Nova axs/aif file(s)",
                Filter = "PS Nova model and texture Files (*.axs,*.aif)|*.axs;*.aif|PS Nova model files (*.axs)|*.axs|PS Nova Texture files (*.aif)|*.aif|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener("C:\\axsout.txt"));
                List<string> failedFiles = new List<string>();
                foreach (var file in openFileDialog.FileNames)
                {
                    try
                    {
                        aquaUI.aqua.aquaModels.Clear();
                        ModelSet set = new ModelSet();
                        set.models.Add(AXSMethods.ReadAXS(file, true, out AquaNode aqn));
                        if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                        {
                            aquaUI.aqua.aquaModels.Add(set);
                            aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false);

                            var outName = Path.ChangeExtension(file, ".aqp");
                            aquaUI.aqua.WriteNGSNIFLModel(outName, outName);
                            AquaUtil.WriteBones(Path.ChangeExtension(outName, ".aqn"), aqn);
                        }
                    }
                    catch (Exception exc)
                    {
                        failedFiles.Add(file);
                        failedFiles.Add(exc.Message);
                    }
                }

#if DEBUG
                File.WriteAllLines("C:\\failedFiiles.txt", failedFiles);
#endif
                System.Diagnostics.Debug.Unindent();
                System.Diagnostics.Debug.Flush();
            }
        }

        private void convertPSPortableunjToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PS Portable unj file(s)",
                Filter = "PS Portable unj Files (*.unj)|*.unj|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> failedFiles = new List<string>();
                foreach (var file in openFileDialog.FileNames)
                {
                    //try
                    //{
                    aquaUI.aqua.aquaModels.Clear();
                    ModelSet set = new ModelSet();
                    UNJObject unj = new UNJObject();
                    unj.ReadUNJ(file);
                    set.models.Add(unj.ConvertToBasicAquaobject(out var aqn));
                    if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false);

                        var outName = Path.ChangeExtension(file, ".aqp");
                        aquaUI.aqua.WriteNGSNIFLModel(outName, outName);
                        AquaUtil.WriteBones(Path.ChangeExtension(outName, ".aqn"), aqn);
                    }
                    /*}
                    catch (Exception exc)
                    {
                        failedFiles.Add(file);
                        failedFiles.Add(exc.Message);
                    }*/
                }

#if DEBUG
                File.WriteAllLines("C:\\failedFiiles.txt", failedFiles);
#endif
                System.Diagnostics.Debug.Unindent();
                System.Diagnostics.Debug.Flush();
            }
        }

        private void convertPSOnrelTotrpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO1 PC n.rel map file",
                Filter = "PSO1 PC Map|*n.rel",
                Multiselect = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in openFileDialog.FileNames)
                {
                    aquaUI.aqua.aquaModels.Clear();
                    bool useSubPath = true;
                    string subPath = "";
                    string fname = path;
                    string outFolder = null;
                    if (useSubPath == true)
                    {
                        subPath = Path.GetFileNameWithoutExtension(path) + "\\";
                        var info = Directory.CreateDirectory(Path.GetDirectoryName(path) + "\\" + subPath);
                        fname = info.FullName + Path.GetFileName(path);
                        outFolder = info.FullName;
                    }

                    var rel = new PSONRelConvert(File.ReadAllBytes(path), path, 0.1f, outFolder);
                    var aqua = new AquaUtil();
                    var set = new ModelSet();
                    set.models.Add(rel.aqObj);
                    aqua.aquaModels.Add(set);
                    aqua.ConvertToClassicPSO2Mesh(false, false, false, false, false, false, false);

                    if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                        set.models[0].ConvertToLegacyTypes();
                        set.models[0].CreateTrueVertWeights();

                        FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], rel.aqn, new List<AquaMotion>(), Path.ChangeExtension(fname, ".fbx"), new List<string>(), new List<Matrix4x4>(), false);
                    }
                }
            }
        }

        private void convertPSOxvrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO xvr file(s)",
                Filter = "PSO xvr Files (*.xvr)|*.xvr|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read Xvrs
                foreach (var file in openFileDialog.FileNames)
                {
                    PSOXVMConvert.ConvertLooseXVR(file);
                }
            }
        }

        private void dumpPSOxvmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO xvm file(s)",
                Filter = "PSO xvm Files (*.xvm)|*.xvm",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read Xvms
                foreach (var file in openFileDialog.FileNames)
                {
                    PSOXVMConvert.ExtractXVM(file);
                }
            }
        }

        private void cMTTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select CMT file",
                Filter = "PSO CMT Files (*.cmt)|*.cmt",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read CMT
                var cmt = CharacterMakingTemplateMethods.ReadCMT(openFileDialog.FileName);
                CharacterMakingTemplateMethods.ConvertToNGSBenchmark1(cmt);
                CharacterMakingTemplateMethods.SetNGSBenchmarkEnableFlag(cmt);
                File.WriteAllBytes("C:\\CMT.cmt", CharacterMakingTemplateMethods.CMTToBytes(cmt));
            }
        }

        private void pSZTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSZ text bin file",
                Filter = "PSZ text bin Files (*.bin)|*.bin",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read psz
                foreach (var filename in openFileDialog.FileNames)
                {
                    PSZTextBin.DumpNameBin(filename);
                }
            }
        }

        private void convertAnimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ctx = new Assimp.AssimpContext())
            {
                var formats = ctx.GetSupportedImportFormats().ToList();
                formats.Sort();

                OpenFileDialog openFileDialog;
                openFileDialog = new OpenFileDialog()
                {
                    Title = "Convert animation model file(s), fbx recommended (output .aqm(s) will be written to same directory)",
                    Filter = ""
                };
                string tempFilter = "(*.fbx,*.dae,*.glb,*.gltf,*.pmx,*.smd)|*.fbx;*.dae;*.glb;*.gltf;*.pmx;*.smd";
                string tempFilter2 = "";

                openFileDialog.Filter = tempFilter + tempFilter2;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    float scaleFactor = 1;

                    foreach (var file in openFileDialog.FileNames)
                    {
                        ModelImporter.AssimpAQMConvertAndWrite(file, forceNoCharacterMetadataCheckBox.Checked, true, scaleFactor);
                    }
                }
            }
        }

        private void pSZEnemyZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog()
            {
                Title = "Select enemy_zone_*.rel(s)",
                Filter = "(enemy_zone_*.rel)|enemy_zone_*.rel",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<int, string> itemNames = new Dictionary<int, string>();
                OpenFileDialog openFileDialog2;
                openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select ids file",
                    Filter = "(*.txt)|*.txt",
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    var txt = File.ReadAllLines(openFileDialog2.FileName);
                    for (int i = 0; i < txt.Length; i++)
                    {
                        var line = txt[i];

                        if (line == "")
                        {
                            continue;
                        }
                        if (line[0] < '0' || line[0] > '9')
                        {
                            continue;
                        }
                        var separatorArea = line.IndexOf(' ');
                        if (line.Length > separatorArea + 1)
                        {
                            string startNum = line.Substring(0, separatorArea);
                            string insertNumLate = separatorArea > 7 ? "" : "00";
                            int finalNum = Convert.ToInt32("0x" + startNum + insertNumLate, 16);

                            itemNames.Add(finalNum, line.Substring(separatorArea + 1, line.Length - separatorArea - 1));
                        }
                    }
                }

                foreach (var fname in openFileDialog.FileNames)
                {
                    var drops = new EnemyZoneDrops(File.ReadAllBytes(fname));
                    List<string> dropData = new List<string>();
                    dropData.Add("Item Name,Item Id,Rate");
                    for (int i = 0; i < drops.itemCount; i++)
                    {
                        string itemName;
                        itemNames.TryGetValue(drops.itemIds[i], out itemName);

                        dropData.Add($"{itemName},{drops.itemIds[i]:X8},1/{drops.rates[i]}");
                    }

                    File.WriteAllLines(fname + ".csv", dropData, Encoding.UTF8);
                }
            }
        }

        private void pSZObjZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog()
            {
                Title = "Select obj_zone_*.rel(s)",
                Filter = "(obj_zone_*.rel)|obj_zone_*.rel",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<int, string> itemNames = new Dictionary<int, string>();
                OpenFileDialog openFileDialog2;
                openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select ids file",
                    Filter = "(*.txt)|*.txt",
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    var txt = File.ReadAllLines(openFileDialog2.FileName);
                    for (int i = 0; i < txt.Length; i++)
                    {
                        var line = txt[i];

                        if (line == "")
                        {
                            continue;
                        }
                        if (line[0] < '0' || line[0] > '9')
                        {
                            continue;
                        }
                        var separatorArea = line.IndexOf(' ');
                        if (line.Length > separatorArea + 1)
                        {
                            string startNum = line.Substring(0, separatorArea);
                            string insertNumLate = separatorArea > 7 ? "" : "00";
                            int finalNum = Convert.ToInt32("0x" + startNum + insertNumLate, 16);

                            itemNames.Add(finalNum, line.Substring(separatorArea + 1, line.Length - separatorArea - 1));
                        }
                    }
                }

                foreach (var fname in openFileDialog.FileNames)
                {
                    var drops = new ObjZoneDrops(File.ReadAllBytes(fname));
                    List<string> dropData = new List<string>();
                    dropData.Add("Item Name,Item Id,Rate");
                    for (int i = 0; i < drops.itemCount; i++)
                    {
                        string itemName;
                        itemNames.TryGetValue(drops.itemIds[i], out itemName);

                        dropData.Add($"{itemName},{drops.itemIds[i]:X8},1/{drops.rates[i]}");
                    }

                    File.WriteAllLines(fname + ".csv", dropData, Encoding.UTF8);
                }
            }
        }

        private void pSZEnemyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;
            openFileDialog = new OpenFileDialog()
            {
                Title = "Select enemy_*.rel(s)",
                Filter = "(enemy_*.rel)|enemy_*.rel",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<int, string> itemNames = new Dictionary<int, string>();
                OpenFileDialog openFileDialog2;
                openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select ids file",
                    Filter = "(*.txt)|*.txt",
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    var txt = File.ReadAllLines(openFileDialog2.FileName);
                    for (int i = 0; i < txt.Length; i++)
                    {
                        var line = txt[i];

                        if (line == "")
                        {
                            continue;
                        }
                        if (line[0] < '0' || line[0] > '9')
                        {
                            continue;
                        }
                        var separatorArea = line.IndexOf(' ');
                        if (line.Length > separatorArea + 1)
                        {
                            string startNum = line.Substring(0, separatorArea);
                            string insertNumLate = separatorArea > 7 ? "" : "00";
                            int finalNum = Convert.ToInt32("0x" + startNum + insertNumLate, 16);

                            itemNames.Add(finalNum, line.Substring(separatorArea + 1, line.Length - separatorArea - 1));
                        }
                    }
                }

                foreach (var fname in openFileDialog.FileNames)
                {
                    var drops = new EnemyDrops(File.ReadAllBytes(fname));
                    List<string> dropData = new List<string>();
                    dropData.Add("Item0 Name,Item0 Id,Item1 Name,Item1 Id,Item2 Name,Item2 Id,Item3 Name,Item3 Id,Rate0,Rate1,Rate2,Rate3");
                    for (int i = 0; i < drops.enemyDropSets.Count; i++)
                    {
                        string item0Name;
                        itemNames.TryGetValue(drops.enemyDropSets[i].item0Id, out item0Name);
                        string item1Name;
                        itemNames.TryGetValue(drops.enemyDropSets[i].item1Id, out item1Name);
                        string item2Name;
                        itemNames.TryGetValue(drops.enemyDropSets[i].item2Id, out item2Name);
                        string item3Name;
                        itemNames.TryGetValue(drops.enemyDropSets[i].item3Id, out item3Name);

                        dropData.Add($"{item0Name},{drops.enemyDropSets[i].item0Id:X8},{item1Name},{drops.enemyDropSets[i].item1Id:X8},{item2Name},{drops.enemyDropSets[i].item2Id:X8},{item3Name},{drops.enemyDropSets[i].item3Id:X8}," +
                            $"1/{drops.enemyDropSets[i].item0Rate},1/{drops.enemyDropSets[i].item1Rate},1/{drops.enemyDropSets[i].item2Rate},1/{drops.enemyDropSets[i].item3Rate}");
                    }
                    dropData.Add("\nId,Item0 Name,Item0 Id,Item1 Name,Item1 Id,Item2 Name,Item2 Id,Item3 Name,Item3 Id,u16_14,u16_16,u16_18,u16_1A,u16_1C,u16_1E,u16_20,u16_22");
                    for (int i = 0; i < drops.enemyData.Count; i++)
                    {
                        string item0Name;
                        itemNames.TryGetValue(drops.enemyData[i].item0Id, out item0Name);
                        string item1Name;
                        itemNames.TryGetValue(drops.enemyData[i].item1Id, out item1Name);
                        string item2Name;
                        itemNames.TryGetValue(drops.enemyData[i].item2Id, out item2Name);
                        string item3Name;
                        itemNames.TryGetValue(drops.enemyData[i].item3Id, out item3Name);

                        dropData.Add($"{item0Name},{drops.enemyData[i].item0Id:X8},{item1Name},{drops.enemyData[i].item1Id:X8},{item2Name},{drops.enemyData[i].item2Id:X8},{item3Name},{drops.enemyData[i].item3Id:X8}," +
                            $"{drops.enemyData[i].u16_14},{drops.enemyData[i].u16_16},{drops.enemyData[i].u16_18},{drops.enemyData[i].u16_1A},{drops.enemyData[i].u16_1C},{drops.enemyData[i].u16_1E},{drops.enemyData[i].u16_20},{drops.enemyData[i].u16_22}");
                    }

                    File.WriteAllLines(fname + ".csv", dropData, Encoding.UTF8);
                }
            }
        }

        private void dumpAllTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select NA pso2_bin",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var pso2_binDir = goodFolderDialog.FileName;
                goodFolderDialog.Title = "Select jp pso2_bin";
                if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var jpPso2_binDir = goodFolderDialog.FileName;
                    goodFolderDialog.Title = "Select output directory";
                    if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        var outfolder = goodFolderDialog.FileName;
                        string inWin32 = pso2_binDir + "\\data\\win32_na\\";
                        string inWin32Reboot = pso2_binDir + "\\data\\win32reboot_na\\";
                        string inWin32Jp = jpPso2_binDir + "\\data\\win32\\";
                        string inWin32RebootJp = jpPso2_binDir + "\\data\\win32reboot\\";
                        string outWin32 = outfolder + "\\win32_jp\\";
                        string outWin32Reboot = outfolder + "\\win32reboot_jp\\";
                        string outWin32NA = outfolder + "\\win32_na\\";
                        string outWin32RebootNA = outfolder + "\\win32reboot_na\\";

                        var files = new List<string>(Directory.GetFiles(inWin32));
                        files.AddRange(Directory.GetFiles(inWin32Reboot, "*", SearchOption.AllDirectories));
                        files.AddRange(Directory.GetFiles(inWin32Jp));
                        files.AddRange(Directory.GetFiles(inWin32RebootJp, "*", SearchOption.AllDirectories));

                        Parallel.ForEach(files, file =>
                        {
                            long len;
                            IceFile iceFile = null;
                            using (Stream strm = new FileStream(file, FileMode.Open))
                            {
                                len = strm.Length;
                                if (len <= 0)
                                {
                                    return;
                                }

                                //Check if this is even an ICE file
                                byte[] arr = new byte[4];
                                strm.Read(arr, 0, 4);
                                bool isIce = arr[0] == 0x49 && arr[1] == 0x43 && arr[2] == 0x45 && arr[3] == 0;
                                if (isIce == false)
                                {
                                    return;
                                }

                                try
                                {
                                    iceFile = IceFile.LoadIceFile(strm);
                                }
                                catch
                                {
                                    return;
                                }

                                var innerFiles = new List<byte[]>(iceFile.groupOneFiles);
                                innerFiles.AddRange(iceFile.groupTwoFiles);
                                string outpath = null;

                                for (int i = 0; i < innerFiles.Count; i++)
                                {
                                    string baseName;
                                    /*try
                                    {*/
                                    baseName = IceFile.getFileName(innerFiles[i]);
                                    /*}
                                    catch
                                    {
                                        Debug.WriteLine($"{file} inner file {i} could not have its name read!");
                                        continue;
                                    }*/
                                    if (baseName.Contains(".text") || baseName == "namelessFile.bin")
                                    {
                                        if (outpath == null)
                                        {
                                            if (file.Contains("_na"))
                                            {
                                                if (file.Contains("reboot"))
                                                {
                                                    outpath = outWin32RebootNA;
                                                }
                                                else
                                                {
                                                    outpath = outWin32NA;
                                                }
                                            }
                                            else
                                            {
                                                if (file.Contains("reboot"))
                                                {
                                                    outpath = outWin32Reboot;
                                                }
                                                else
                                                {
                                                    outpath = outWin32;
                                                }
                                            }

                                            var dirName = Path.Combine(outpath, Path.GetFileName(file));
                                            Directory.CreateDirectory(dirName);
                                            var text = AquaMiscMethods.ReadPSO2Text(innerFiles[i]);

                                            var output = (baseName + ".txt was created: " + File.GetCreationTime(file).ToString()) + "\nFilesize is: " + len + " bytes\n";
                                            output += text.ToString();
                                            File.WriteAllText(Path.Combine(dirName, baseName + ".txt"), output);
                                        }

                                    }
                                }
                            }
                        });
                    }
                }

            }
        }

        private void convertSoulsflverTofbxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select From Software flver, MDL4, TPF, or BND file(s)",
                Filter = "From Software flver, MDL4, or BND Files (*.flver, *.flv, *.mdl, *.*bnd, *.dcx, *.tpf)|*.flver;*.flv;*.mdl;*.*bnd;*.dcx;*.tpf|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetSoulsConvertFromForms();
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.ConvertFile(file);
                }
            }
        }

        private void assimpExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(currentFile);
            //Model saving
            if (modelExtensions.Contains(ext))
            {
                using (var ctx = new Assimp.AssimpContext())
                {
                    var formats = ctx.GetSupportedExportFormats();
                    List<(string ext, string desc)> filterKeys = new List<(string ext, string desc)>();
                    foreach (var format in formats)
                    {
                        filterKeys.Add((format.FileExtension, format.Description));
                    }
                    filterKeys.Sort();

                    SaveFileDialog saveFileDialog;
                    saveFileDialog = new SaveFileDialog()
                    {
                        Title = "Export model file",
                        Filter = ""
                    };
                    string tempFilter = "";
                    foreach (var fileExt in filterKeys)
                    {
                        tempFilter += $"{fileExt.desc} (*.{fileExt.ext})|*.{fileExt.ext}|";
                    }
                    tempFilter = tempFilter.Remove(tempFilter.Length - 1, 1);
                    saveFileDialog.Filter = tempFilter;
                    saveFileDialog.FileName = "";

                    //Get bone ext
                    string boneExt = "";
                    switch (ext)
                    {
                        case ".aqo":
                        case ".aqp":
                            boneExt = ".aqn";
                            break;
                        case ".tro":
                        case ".trp":
                            boneExt = ".trn";
                            break;
                        default:
                            break;
                    }
                    var bonePath = currentFile.Replace(ext, boneExt);
                    if (!File.Exists(bonePath))
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog()
                        {
                            Title = "Select PSO2 bones",
                            Filter = "PSO2 Bones (*.aqn,*.trn)|*.aqn;*.trn"
                        };
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            bonePath = openFileDialog.FileName;
                        }
                        else
                        {
                            MessageBox.Show("Must be able to read bones to export!");
                            return;
                        }
                    }
                    aquaUI.aqua.aquaBones.Clear();
                    aquaUI.aqua.ReadBones(bonePath);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var id = saveFileDialog.FilterIndex - 1;
                        var scene = ModelExporter.AssimpExport(saveFileDialog.FileName, aquaUI.aqua.aquaModels[0].models[0], aquaUI.aqua.aquaBones[0]);
                        Assimp.ExportFormatDescription exportFormat = null;
                        for (int i = 0; i < formats.Length; i++)
                        {
                            if (formats[i].Description == filterKeys[id].desc && formats[i].FileExtension == filterKeys[id].ext)
                            {
                                exportFormat = formats[i];
                                break;
                            }
                        }
                        if (exportFormat == null)
                        {
                            return;
                        }

                        try
                        {
                            ctx.ExportFile(scene, saveFileDialog.FileName, exportFormat.FormatId, Assimp.PostProcessSteps.FlipUVs);

                            //Dae fix because Assimp 4 and 5.X can't seem to properly get a root node.
                            if (Path.GetExtension(saveFileDialog.FileName) == ".dae")
                            {
                                string replacementLine = $"<skeleton>(0)#" + aquaUI.aqua.aquaBones[0].nodeList[0].boneName.GetString() + "</skeleton>";

                                var dae = File.ReadAllLines(saveFileDialog.FileName);
                                for (int i = 0; i < dae.Length; i++)
                                {
                                    if (dae[i].Contains("<skeleton>"))
                                    {
                                        dae[i] = replacementLine;
                                    }
                                }
                                File.WriteAllLines(saveFileDialog.FileName, dae);
                            }
                        }
                        catch (Win32Exception w)
                        {
                            MessageBox.Show($"Exception encountered: {w.Message}");
                        }

                    }
                }

            }
        }

        public static DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        public string GetTitleString()
        {
            filenameButton.Text = Path.GetFileName(currentFile);
            return $"Aqua Model Tool {buildDate.ToString("yyyy-MM-dd h:mm tt")}";
        }

        private void convertModelToDemonsSoulsflverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ctx = new Assimp.AssimpContext())
            {
                var formats = ctx.GetSupportedImportFormats().ToList();
                formats.Sort();

                OpenFileDialog openFileDialog;
                openFileDialog = new OpenFileDialog()
                {
                    Title = "Import model file, fbx recommended (output .aqp and .aqn will write to import directory)",
                    Filter = ""
                };
                string tempFilter = "(*.fbx,*.dae,*.glb,*.gltf,*.pmx,*.smd)|*.fbx;*.dae;*.glb;*.gltf;*.pmx;*.smd";
                string tempFilter2 = "";
                openFileDialog.Filter = tempFilter + tempFilter2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
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

        private void convertDemonsSoulsPS5CmdlToFbxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select Demon's Souls PS5 cmdl file(s)",
                Filter = "Demon's Souls PS5 cmsh Files (*.cmsh, *.cmdl)|*.cmsh;*.cmdl|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    BluePointConvert.ReadCMDL(file);
                }
            }
        }

        private void convertPSUxnjOrModelxnrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSU xnj/model xnr file(s)",
                Filter = "PSU Model Files (*.xnj, *.xnr)|*.xnj;*.xnr|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    aquaUI.aqua.aquaModels.Clear();
                    ModelSet set = new ModelSet();
                    NNObject xnj = new NNObject();
                    xnj.ReadPSUXNJ(file);

                    set.models.Add(xnj.ConvertToBasicAquaobject(out var aqn));
                    if (set.models[0] != null && set.models[0].tempTris.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false);
                        set.models[0].ConvertToLegacyTypes();
                        set.models[0].CreateTrueVertWeights();

                        var outName = Path.ChangeExtension(file, ".aqp");
                        aquaUI.aqua.WriteNGSNIFLModel(outName, outName);
                        AquaUtil.WriteBones(Path.ChangeExtension(outName, ".aqn"), aqn);
                    }
                }
            }
        }

        private void convertPSUnomTofbxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSU NOM(s)",
                Filter = "PSU NOM Files (*.nom)|*.nom|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select PSU .xnj or model .xnr",
                    Filter = "PSU model Files (*.xnj, *.xnr)|*.xnj;*.xnr|All Files (*.*)|*"
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    ModelSet set = new ModelSet();
                    NNObject xnj = new NNObject();
                    xnj.ReadPSUXNJ(openFileDialog2.FileName);

                    if (xnj != null && xnj.vtxlList.Count > 0)
                    {
                        set.models.Add(xnj.ConvertToBasicAquaobject(out var bones));
                        aquaUI.aqua.aquaModels.Clear();
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false);
                        aquaUI.aqua.aquaModels[0].models[0].ConvertToLegacyTypes();
                        aquaUI.aqua.aquaModels[0].models[0].CreateTrueVertWeights();

                        foreach (var file in openFileDialog.FileNames)
                        {
                            var nom = new AquaModelLibrary.PSU.NOM(File.ReadAllBytes(file));
                            List<AquaMotion> aqms = new List<AquaMotion>();
                            aqms.Add(nom.GetPSO2MotionPSUBody(bones));
                            FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], bones, aqms, file.Replace(".nom", ".fbx"), new List<string>() { Path.GetFileName(file) }, new List<Matrix4x4>(), true);
                        }
                    }
                }
            }
        }

        private void convertAnimsTonomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ctx = new Assimp.AssimpContext())
            {
                var formats = ctx.GetSupportedImportFormats().ToList();
                formats.Sort();

                OpenFileDialog openFileDialog;
                openFileDialog = new OpenFileDialog()
                {
                    Title = "Convert animation model file(s), fbx recommended (output .aqm(s) will be written to same directory)",
                    Filter = ""
                };
                string tempFilter = "(*.fbx,*.dae,*.glb,*.gltf,*.pmx,*.smd)|*.fbx;*.dae;*.glb;*.gltf;*.pmx;*.smd";
                string tempFilter2 = "";

                openFileDialog.Filter = tempFilter + tempFilter2;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    float scaleFactor = 1;

                    foreach (var file in openFileDialog.FileNames)
                    {
                        var animData = ModelImporter.AssimpAQMConvert(file, forceNoCharacterMetadataCheckBox.Checked, true, scaleFactor);
                        foreach (var anim in animData)
                        {
                            var nom = new AquaModelLibrary.PSU.NOM();
                            nom.CreateFromPSO2Motion(anim.aqm);

                            File.WriteAllBytes(Path.ChangeExtension(Path.Combine(file + "_" + anim.fileName), ".nom"), nom.GetBytes());
                        }
                    }
                }
            }
        }

        private void convertPSO2PlayeraqmToPSUnomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 Player Animation(s)",
                Filter = "PSO2 Player Animation (*.aqm)|*.aqm",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select PSU .xnj or model .xnr",
                    Filter = "PSU model Files (*.xnj, *.xnr)|*.xnj;*.xnr|All Files (*.*)|*"
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    OpenFileDialog openFileDialog3 = new OpenFileDialog()
                    {
                        Title = "Select PSO2 .aqn",
                        Filter = "PSO2 aqn Files (*.aqn)|*.aqn|All Files (*.*)|*",
                        Multiselect = true
                    };
                    if (openFileDialog3.ShowDialog() == DialogResult.OK)
                    {
                        NNObject xnj = new NNObject();
                        xnj.ReadPSUXNJ(openFileDialog2.FileName);
                        if (xnj != null && xnj.vtxlList.Count > 0)
                        {
                            xnj.ConvertToBasicAquaobject(out var bones);
                            var aq = new AquaUtil();
                            aq.ReadBones(openFileDialog3.FileName);
                            foreach (var file in openFileDialog.FileNames)
                            {
                                aq.aquaMotions.Clear();
                                aq.ReadMotion(file);
                                if (aq.aquaMotions[0].anims[0].motionKeys.Count < 50)
                                {
                                    continue;
                                }
                                var nom = new AquaModelLibrary.PSU.NOM();
                                nom.CreateFromPSO2BodyMotion(aq.aquaMotions[0].anims[0], bones, aq.aquaBones[0]);
                                File.WriteAllBytes(Path.ChangeExtension(file, ".nom"), nom.GetBytes());
                            }
                        }
                    }
                }

            }
        }

        private void readNNMotionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select NN Animation",
                Filter = "NN Animation (*.xnm;*.ynm)|*.xnm;*.ynm",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var aq = new AquaUtil();
                foreach (var file in openFileDialog.FileNames)
                {
                    aq.aquaMotions.Clear();
                    var nm = new Marathon.Formats.Mesh.Ninja.NinjaMotion();
                    nm.Read(file);
                    var nom = new AquaModelLibrary.PSU.NOM();
                    nom.CreateFromNNMotion(nm);
                    File.WriteAllBytes(Path.ChangeExtension(file, ".nom"), nom.GetBytes());
                }
            }
        }

        private void parseCAWSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select CAWS Animation WorkSpace",
                Filter = "CAWS Animation WorkSpace (*.caws)|*.caws",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(file)))
                    using (Reloaded.Memory.Streams.BufferedStreamReader sr = new Reloaded.Memory.Streams.BufferedStreamReader(ms, 8192))
                    {
                        var caws = new AquaModelLibrary.BluePoint.CAWS.CAWS(sr);
                    }
                }
            }
        }

        private void spirefierToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (aquaUI.aqua.aquaModels.Count == 0)
            {
                return;
            }
            decimal value = 0;

            if (AquaUICommon.ShowInputDialog(ref value) == DialogResult.OK)
            {
                //Spirefier
                for (int i = 0; i < aquaUI.aqua.aquaModels[0].models.Count; i++)
                {
                    var model = aquaUI.aqua.aquaModels[0].models[i];
                    for (int j = 0; j < model.vtxlList[0].vertPositions.Count; j++)
                    {
                        var vec3 = model.vtxlList[0].vertPositions[j];
                        if (vec3.Y > (float)value)
                        {
                            vec3.Y *= 10000;
                            model.vtxlList[0].vertPositions[j] = vec3;
                        }
                    }

                    model.objc.bounds = AquaObjectMethods.GenerateBounding(model.vtxlList);
                }
            }
        }

        private void convertPSO2FileTojsonToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 File",
                Filter = "All Files|*.aqp;*.aqo;*.tro;*.trp;*.aqe;*.aqm;*.trm;*.aqn;*trn;*.text;*.bti;*.cmx|PSO2 NIFL Model (*.aqp, *.aqo, *.trp, *.tro)|*.aqp;*.aqo;*.trp;*.tro|" +
                "PSO2 Aqua Effect (*.aqe)|*.aqe|PSO2 Aqua Motion (*.aqm, *.trm)|*.aqm;*.trm|PSO2 Aqua Node (*.aqn, *.trn)|*.aqn;*.trn|PSO2 Text (*.text)|*.text|Aqua BTI Motion Config (*.bti)|*.bti|PSO2 Character Making Index (*.cmx)|*.cmx",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    AquaUtil aqu = new AquaUtil();
                    aqu.ConvertToJson(file);
                }
            }
        }

        private void convertPSO2FilejsonToPSO2FileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select PSO2 File",
                Filter = "All Files|*.aqp.json;*.aqo.json;*.tro.json;*.trp.json;*.aqe.json;*.aqm.json;*.trm.json;*.aqn.json;*trn.json;*.text.json;*.bti.json;*.cmx.json|" +
                "PSO2 NIFL Model (*.aqp.json, *.aqo.json, *.trp.json, *.tro.json)|*.aqp.json;*.aqo.json;*.trp.json;*.tro.json|" +
                "PSO2 Aqua Effect (*.aqe.json)|*.aqe.json|PSO2 Aqua Motion (*.aqm.json, *.trm.json)|*.aqm.json;*.trm.json|" +
                "PSO2 Aqua Node (*.aqn.json, *.trn.json)|*.aqn.json;*.trn.json|PSO2 Text (*.text.json)|*.text.json|Aqua BTI Motion Config (*.bti.json)|*.bti.json|PSO2 Character Making Index (*.cmx.json)|*.cmx.json",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    AquaUtil aqu = new AquaUtil();
                    aqu.ConvertFromJson(file);
                }
            }
        }

        private void readMCGMCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select MCP/MCG File",
                Filter = "MCP/MCG files|*.mcg;*.mcp",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.ReadSoulsFile(file);
                }
            }
        }

        private void readMSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select MSB File",
                Filter = "MSB files|*.msb",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.ReadSoulsFile(file);
                }
            }
        }

        private void generateMCGMCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
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

        private void nullMCGUnksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select MCG File",
                Filter = "MCG files|*.mcg",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.NullUnkIndices(file);
                }
            }
        }

        private void parseCANIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select Demon's Souls PS5 cani file(s)",
                Filter = "Demon's Souls PS5 cani Files (*.cani)|*.cani|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> failedFiles = new List<string>();
                foreach (var file in openFileDialog.FileNames)
                {
                    var cani = BluePointConvert.ReadCANI(file);
                    /*
                    aquaUI.aqua.aquaModels.Clear();
                    ModelSet set = new ModelSet();
                    set.models.Add(BluePointConvert.ReadCMDL(file, out AquaNode aqn));
                    var outName = Path.ChangeExtension(file, ".aqp");*/
                    /*if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                        set.models[0].ConvertToLegacyTypes();
                        set.models[0].CreateTrueVertWeights();

                        FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], aqn, new List<AquaMotion>(), Path.ChangeExtension(file, ".fbx"), new List<string>(), false);
                    }*/
                }
            }
        }

        private void parseDRBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select DRB File",
                Filter = "DRB files|*.drb",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.ReadSoulsFile(file);
                }
            }
        }

        private void usePCDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterMakingIndex.pcDirectory = usePCDirectoriesToolStripMenuItem.Checked;
            AquaGeneralMethods.useFileNameHash = usePCDirectoriesToolStripMenuItem.Checked;
        }

        private void sortCMSHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select CMSH File",
                Filter = "CMSH files|*.cmsh",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var baseDir = Path.GetDirectoryName(openFileDialog.FileNames[0]);
                Directory.CreateDirectory(Path.Combine(baseDir, "NoInfo", "80"));
                Directory.CreateDirectory(Path.Combine(baseDir, "NoInfo", "81"));

                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "82"));
                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "200"));
                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "500"));
                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "A01"));

                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "AA01"));
                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "2A01"));
                Directory.CreateDirectory(Path.Combine(baseDir, "DeSType", "ACC"));
                Directory.CreateDirectory(Path.Combine(baseDir, "Compact", "88"));

                Directory.CreateDirectory(Path.Combine(baseDir, "Compact", "89"));
                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "5"));
                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "D"));
                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "15"));

                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "41"));
                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "4901"));
                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "5100"));
                Directory.CreateDirectory(Path.Combine(baseDir, "CMSH_Ref", "1100"));

                foreach (var file in openFileDialog.FileNames)
                {
                    BluePointConvert.ReadFileTest(file, out int start, out int flags, out int modelType);
                    switch (start)
                    {
                        case 0x1100:
                            File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "1100", Path.GetFileName(file)));
                            break;
                        case 0x5100:
                            File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "5100", Path.GetFileName(file)));
                            break;
                        case 0x4901:
                            File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "4901", Path.GetFileName(file)));
                            break;
                        case 0x4100:
                            File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "41", Path.GetFileName(file)));
                            break;
                        case 0xAA01:
                            File.Move(file, Path.Combine(baseDir, "DeSType", "AA01", Path.GetFileName(file)));
                            break;
                        case 0x2A01:
                            File.Move(file, Path.Combine(baseDir, "DeSType", "2A01", Path.GetFileName(file)));
                            break;
                        case 0xA8C:
                        case 0x68C:
                            switch (modelType)
                            {
                                case 0x2:
                                case 0xA:
                                    break;
                                case 0x5:
                                    File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "5", Path.GetFileName(file)));
                                    continue;
                                case 0xD:
                                    File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "D", Path.GetFileName(file)));
                                    continue;
                                case 0x15:
                                    File.Move(file, Path.Combine(baseDir, "CMSH_Ref", "15", Path.GetFileName(file)));
                                    continue;
                                default:
                                    break;
                            }

                            switch (flags)
                            {
                                case 0x89:
                                    File.Move(file, Path.Combine(baseDir, "Compact", "89", Path.GetFileName(file)));
                                    break;
                                case 0x88:
                                    File.Move(file, Path.Combine(baseDir, "Compact", "88", Path.GetFileName(file)));
                                    break;
                                case 0x80:
                                    File.Move(file, Path.Combine(baseDir, "NoInfo", "80", Path.GetFileName(file)));
                                    break;
                                case 0x81:
                                    File.Move(file, Path.Combine(baseDir, "NoInfo", "81", Path.GetFileName(file)));
                                    break;
                                case 0x82:
                                    File.Move(file, Path.Combine(baseDir, "DeSType", "82", Path.GetFileName(file)));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 0xACC:
                            File.Move(file, Path.Combine(baseDir, "DeSType", "ACC", Path.GetFileName(file)));
                            break;
                        case 0x200:
                            File.Move(file, Path.Combine(baseDir, "DeSType", "200", Path.GetFileName(file)));
                            break;
                        case 0x500:
                            File.Move(file, Path.Combine(baseDir, "DeSType", "500", Path.GetFileName(file)));
                            break;
                        case 0xA01:
                            File.Move(file, Path.Combine(baseDir, "DeSType", "A01", Path.GetFileName(file)));
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void SaveSoulsSettings(object sender, EventArgs e)
        {
            SaveSoulsSettingsInternal();
        }

        private void SaveSoulsSettingsInternal()
        {
            SMTSetting smtSetting = new SMTSetting();
            smtSetting.useMetaData = exportWithMetadataToolStripMenuItem.Checked;
            smtSetting.mirrorMesh = fixFromSoftMeshMirroringToolStripMenuItem.Checked;
            smtSetting.applyMaterialNamesToMesh = applyMaterialNamesToMeshToolStripMenuItem.Checked;
            smtSetting.transformMesh = transformMeshToolStripMenuItem.Checked;
            smtSetting.soulsGame = SoulsConvert.game;
            smtSetting.extractUnreferencedMapData = mSBExtractionExtractUnreferencedModelsAndTexturesToolStripMenuItem.Checked;
            smtSetting.separateMSBDumpByModel = mSBExtractionSeparateExtractionByModelToolStripMenuItem.Checked;

            string smtSettingText = JsonConvert.SerializeObject(smtSetting, jss);
            File.WriteAllText(mainSettingsPath + soulsSettingsFile, smtSettingText);
        }

        private void scanPOS0GapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog goodFolderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true,
                Title = "Select folder of cmshs",
            };
            if (goodFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                StringBuilder sb = new StringBuilder();
                Dictionary<int, List<(string fileName, byte[] gap)>> posGaps = new Dictionary<int, List<(string filename, byte[] gap)>>();

                var files = Directory.EnumerateFiles(goodFolderDialog.FileName);

                foreach (var file in files)
                {
                    var tuple = (Path.GetFileName(file), BluePointConvert.ReadFileTestVertDef(file).ToArray());
                    var len = tuple.Item2.Length;
                    if (posGaps.ContainsKey(len))
                    {
                        posGaps[len].Add(tuple);
                    }
                    else
                    {
                        posGaps[len] = new List<(string fileName, byte[] gap)>() { tuple };
                    }
                }

                var keys = posGaps.Keys.ToList();
                keys.Sort();

                foreach (var key in keys)
                {
                    sb.Append("\n");
                    sb.Append(key + "\n");
                    var posGapSet = posGaps[key];
                    posGapSet.Sort();
                    foreach (var pair in posGapSet)
                    {
                        foreach (var bt in pair.gap)
                        {
                            sb.Append(bt.ToString("X"));
                        }
                        sb.Append($" {pair.fileName}");
                        sb.Append("\n");
                    }
                }

                File.WriteAllText(Path.Combine(goodFolderDialog.FileName, "cmshPosGaps.txt"), sb.ToString());
            }
        }

        private void gatherMatchingCMSHNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new CommonOpenFileDialog()
            {
                Title = "Select Folder",
                IsFolderPicker = true,
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var baseDir = openFileDialog.FileName;
                var files = Directory.GetFiles(baseDir, "*.cmsh", SearchOption.AllDirectories);

                Dictionary<string, List<string>> paths = new Dictionary<string, List<string>>();
                foreach (var file in files)
                {
                    string baseName = Path.GetFileName(file);
                    string pathStr = baseName;

                    BluePointConvert.ReadFileTest(file, out int start, out int flags, out int modelType);
                    switch (start)
                    {
                        case 0x1100:
                            pathStr += " CMSH_Ref_1100";
                            break;
                        case 0x5100:
                            pathStr += " CMSH_Ref_5100";
                            break;
                        case 0x4901:
                            pathStr += " CMSH_Ref_4901";
                            break;
                        case 0x4100:
                            pathStr += " CMSH_Ref_41";
                            break;
                        case 0xAA01:
                            pathStr += " DeSType_AA01";
                            break;
                        case 0x2A01:
                            pathStr += " DeSType_2A01";
                            break;
                        case 0xA8C:
                        case 0x68C:
                            switch (modelType)
                            {
                                case 0x2:
                                case 0xA:
                                    break;
                                case 0x5:
                                    pathStr += " CMSH_Ref_5";
                                    continue;
                                case 0xD:
                                    pathStr += " CMSH_Ref_D";
                                    continue;
                                case 0x15:
                                    pathStr += " CMSH_Ref_15";
                                    continue;
                                default:
                                    break;
                            }

                            switch (flags)
                            {
                                case 0x89:
                                    pathStr += " Compact_89";
                                    break;
                                case 0x88:
                                    pathStr += " Compact_88";
                                    break;
                                case 0x80:
                                    pathStr += " NoInfo_80";
                                    break;
                                case 0x81:
                                    pathStr += " NoInfo_81";
                                    break;
                                case 0x82:
                                    pathStr += " DeSType_82";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 0xACC:
                            pathStr += " DeSType_ACC";
                            break;
                        case 0x200:
                            pathStr += " DeSType_200";
                            break;
                        case 0x500:
                            pathStr += " DeSType_500";
                            break;
                        case 0xA01:
                            pathStr += " DeSType_A01";
                            break;
                        default:
                            break;
                    }

                    if (paths.ContainsKey(baseName))
                    {
                        paths[baseName].Add(pathStr);
                    }
                    else
                    {
                        paths[baseName] = new List<string> { pathStr };
                    }
                }

                StringBuilder txt = new StringBuilder();
                foreach (var pathSet in paths)
                {
                    if (pathSet.Value.Count > 1)
                    {
                        txt.AppendLine(pathSet.Key);
                        foreach (var path in pathSet.Value)
                        {
                            txt.AppendLine(path);
                        }
                        txt.AppendLine("");
                    }
                }

                File.WriteAllText(Path.Combine(baseDir, "Matches.txt"), txt.ToString());
            }
        }

        private void exportLuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select lua File",
                Filter = "lua files|*.lua;*.evt;*.skit",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PSO2CompressedScripts scriptHandler = new PSO2CompressedScripts();

                foreach (var file in openFileDialog.FileNames)
                {
                    scriptHandler.ParseLooseScript(file);
                    var ext = Path.GetExtension(file);
                    scriptHandler.WriteText(file.Replace(ext, $".out{ext}"), Path.GetFileName(file));
                }
            }
        }

        private void readFCLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select fcl File",
                Filter = "fcl files|*.fcl",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    aquaUI.aqua.ReadFCL(file);
                }
            }
        }

        private void extractBorderBreakPS4FARCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Border Break archive file (Models rigging and skinning is broken at this time)",
                Filter = "*_obj.bin, *.pfa, spr_*.bin, *tex.bin, fld_*.bin files|*_obj.bin;spr_*.bin;*tex.bin;*.pfa;fld_*.bin|Model archive files *_obj.bin|*_obj.bin|spr_*.bin, *tex.bin files|spr_*.bin;*tex.bin|pfa files|*.pfa|FLD Stage Collision Files fld_*.bin|fld_*.bin",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var archiveFile in openFileDialog.FileNames)
                {
                    if (archiveFile.EndsWith("pfa"))
                    {
                        using (Stream stream = new MemoryStream(File.ReadAllBytes(archiveFile)))
                        using (var streamReader = new BufferedStreamReader(stream, 8192))
                        {
                            var pfa = new FARC(streamReader);
                            var path = archiveFile + "_out";
                            Directory.CreateDirectory(path);
                            foreach (var file in pfa.fileEntries)
                            {
                                var fname = Path.Combine(path, file.fileName);
                                File.WriteAllBytes(fname, file.fileData);

                                //Extract txp
                                if (file.fileName.StartsWith("spr_") || file.fileName.EndsWith("tex.bin"))
                                {
                                    BorderBreakPS4Convert.ExtractTXP(fname, file.fileData);
                                }
                                else if (file.fileName.EndsWith("_obj.bin"))
                                {
                                    ConvertAM2BBPS4Model(fname, file.fileData);
                                }
                            }
                        }
                    }
                    else if (archiveFile.EndsWith("_obj.bin"))
                    {
                        var objBinRaw = File.ReadAllBytes(archiveFile);
                        ConvertAM2BBPS4Model(archiveFile, objBinRaw);
                    }
                    else if (Path.GetFileName(archiveFile).StartsWith("fld_"))
                    {
                        var fldBinRaw = File.ReadAllBytes(archiveFile);
                        ConvertAM2BBPS4FLD(archiveFile, fldBinRaw);
                    }
                    else
                    {
                        var txpRaw = File.ReadAllBytes(archiveFile);
                        BorderBreakPS4Convert.ExtractTXP(archiveFile, txpRaw);
                    }
                }
            }
        }

        public static void ConvertEOBJ(string eobj, byte[] eobjRaw)
        {
            using (Stream stream = new MemoryStream(eobjRaw))
            using (var streamReader = new BufferedStreamReader(stream, 8192))
            {
                new E_OBJ(streamReader);
            }
        }

        private void setMOTBONEbinPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select mot_bone.bin file",
                Filter = "mot_bone.bin|mot_bone.bin",
                FileName = "",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                borderBreakPS4BonePath = openFileDialog.FileName;
                SaveMainSettings();
            }
        }

        private void SaveMainSettings()
        {
            MainSetting mainSetting = new MainSetting();
            mainSetting.BBPS4BonePath = borderBreakPS4BonePath;

            string mainSettingText = JsonConvert.SerializeObject(mainSetting, jss);
            File.WriteAllText(mainSettingsPath + mainSettingsFile, mainSettingText);
        }

        private void ConvertAM2BBPS4Model(string eobjPath, byte[] eobjRaw)
        {
            List<AquaNode> borderBreakPS4Bones;
            using (Stream stream = new MemoryStream(File.ReadAllBytes(borderBreakPS4BonePath)))
            using (var streamReader = new BufferedStreamReader(stream, 8192))
            {
                var motBones = new MOT_BONE(streamReader);
                borderBreakPS4Bones = BorderBreakPS4Convert.motBonesToAQN(motBones);
                borderBreakPS4Bones.Add(AquaNode.GenerateBasicAQN());
            }
            List<NGSAquaObject> aqps;
            E_OBJ eobj;
            using (Stream stream = new MemoryStream(eobjRaw))
            using (var streamReader = new BufferedStreamReader(stream, 8192))
            {
                eobj = new E_OBJ(streamReader);
                aqps = BorderBreakPS4Convert.EOBJToAqua(eobj);
            }

            for (int i = 0; i < aqps.Count; i++)
            {
                AquaNode aqn;
                var name = eobj.names[i];

                if (name.Contains("_crw0"))
                {
                    aqn = borderBreakPS4Bones[0];
                }
                else if (name.Contains("_rba_"))
                {
                    aqn = borderBreakPS4Bones[1];
                }
                else if (name.Contains("_rbb_"))
                {
                    aqn = borderBreakPS4Bones[2];
                }
                else if (name.Contains("_rbc_"))
                {
                    aqn = borderBreakPS4Bones[3];
                }
                else if (name.Contains("_rbd_"))
                {
                    aqn = borderBreakPS4Bones[4];
                }
                else
                {
                    aqn = borderBreakPS4Bones[5];
                }

                aquaUI.aqua.aquaModels.Clear();
                ModelSet set = new ModelSet();
                set.models.Add(aqps[i]);
                if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                {
                    aquaUI.aqua.aquaModels.Add(set);
                    aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                    set.models[0].ConvertToLegacyTypes();
                    set.models[0].CreateTrueVertWeights();

                    var path = eobjPath + "_out";
                    Directory.CreateDirectory(path);
                    var fname = Path.Combine(path, name + ".fbx");
                    FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], aqn, new List<AquaMotion>(), fname, new List<string>(), new List<Matrix4x4>(), false);
                }

            }
        }

        private void ConvertAM2BBPS4FLD(string fldPath, byte[] fldRaw)
        {
            List<NGSAquaObject> aqps;
            FLD fld;
            using (Stream stream = new MemoryStream(fldRaw))
            using (var streamReader = new BufferedStreamReader(stream, 8192))
            {
                fld = new FLD(streamReader);
                aqps = BorderBreakPS4Convert.FLDToAqua(fld);
            }

            List<AquaObject> aqpList = new List<AquaObject>();
            List<AquaNode> aqnList = new List<AquaNode>();
            List<string> modelNames = new List<string>();
            List<List<Matrix4x4>> matrices = new List<List<Matrix4x4>>();
            for (int i = 0; i < aqps.Count; i++)
            {
                var name = fld.fldModels[i].modelName.GetString();
                AquaNode aqn = AquaNode.GenerateBasicAQN(name);
                modelNames.Add(name);
                matrices.Add(new List<Matrix4x4>());

                aquaUI.aqua.aquaModels.Clear();
                ModelSet set = new ModelSet();
                set.models.Add(aqps[i]);
                if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                {
                    aquaUI.aqua.aquaModels.Add(set);
                    aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                    set.models[0].ConvertToLegacyTypes();
                    set.models[0].CreateTrueVertWeights();

                    aqpList.Add(set.models[0]);
                    aqnList.Add(aqn);
                }

            }
            var path = fldPath + $"_out.fbx";
            FbxExporter.ExportToFileSets(aqpList, aqnList, modelNames, path, new List<List<Matrix4x4>>(), false);

        }

        private void readMotAnimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select mot_ animation file",
                Filter = "mot_man.bin, mot_rba.bin, mot_rbb.bin, mot_rbc.bin, mot_rbd.bin|mot_man.bin;mot_rba.bin;mot_rbb.bin;mot_rbc.bin;mot_rbd.bin",
                FileName = "",
                Multiselect = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var anims = new MOT_Anim(streamReader);
                    }
                }
            }
        }

        private void readCGPRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select CGPR file",
                Filter = "CGPR file|*.cgpr",
                FileName = "",
                Multiselect = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var cgpr = new CGPR(streamReader);
                    }
                }
            }
        }

        private void dumpAllFromSoulsbndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select From Software *BND or .dcx file(s)",
                Filter = "From Software BND Files (*bnd)|*.*bnd;*.dcx;|All Files (*.*)|*",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.ConvertFile(file, true);
                }
            }
        }

        private void readMusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select .mus file(s)",
                Filter = "PSO2 Music mus Files (*.mus)|*.mus;",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonSerializerSettings jss = new JsonSerializerSettings() { Formatting = Formatting.Indented };
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var mus = new MusicFileReboot(streamReader);
                        string musJson = JsonConvert.SerializeObject(mus, jss);
                        File.WriteAllText(file + ".json", musJson);
                    }
                }
            }
        }

        private void setSoulsGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSoulsGameToolStripText();
            SetSoulsGameInternal();
            SaveSoulsSettingsInternal();
        }

        private void SetSoulsGameToolStripText()
        {
            setSoulsGameToolStripMenuItem.Text = $"Set Game (For MSB Extraction) | Current Game: {SoulsConvert.game}";
        }

        private static void SetSoulsGameInternal()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select .exe, eboot file(s)",
                Filter = "Exe, Eboot Files (*.exe, eboot.bin)|*.exe;eboot.bin;",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
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
            }
        }

        private void extractSoulsMapObjectLayoutFrommsbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select .msb file(s)",
                Filter = "Msb Files (*.msb, *.msb.dcx)|*.msb;*.msb.dcx",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (SoulsConvert.game == SoulsConvert.SoulsGame.None)
                {
                    SetSoulsGameInternal();
                    if (SoulsConvert.game == SoulsConvert.SoulsGame.None)
                    {
                        //User already warned when setting game.
                        return;
                    }
                    SaveSoulsSettingsInternal();
                }
                SetSoulsConvertFromForms();
                foreach (var file in openFileDialog.FileNames)
                {
                    MSBModelExtractor.ExtractMSBMapModels(file);
                }
            }
        }

        private void SetSoulsConvertFromForms()
        {
            SoulsConvert.useMetaData = exportWithMetadataToolStripMenuItem.Checked;
            SoulsConvert.applyMaterialNamesToMesh = applyMaterialNamesToMeshToolStripMenuItem.Checked;
            SoulsConvert.mirrorMesh = fixFromSoftMeshMirroringToolStripMenuItem.Checked;
            SoulsConvert.transformMesh = transformMeshToolStripMenuItem.Checked;
            SoulsConvert.extractUnreferencedMapData = extractSoulsMapObjectLayoutFrommsbToolStripMenuItem.Checked;
            SoulsConvert.separateMSBDumpByModel = mSBExtractionSeparateExtractionByModelToolStripMenuItem.Checked;
        }

        private void readSTGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select stage model layout file",
                Filter = "Stage model layout files stg_*.bin|stg_*.bin",
                FileName = "",
                Multiselect = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var stg = new STG(streamReader);
                    }
                }
            }
        }

        private void readLATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select lat File",
                Filter = "lat files|*.lat",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    aquaUI.aqua.ReadLAT(file);
                }
            }
        }

        private void sTGExportBustedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select stg File",
                Filter = "stg_*.bin files|stg_*.bin",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    BorderBreakPS4Convert.STGLayoutDump(file);
                }
            }
        }

        private void readNSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select DS2 NSA File",
                Filter = "DS2 Anim *.nsa files|*.nsa",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var openFileDialog2 = new OpenFileDialog()
                {
                    Title = "Select DS2 flv File",
                    Filter = "DS2 Flv *.flv files|*.flv",
                    FileName = "",
                    Multiselect = true
                };
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {

                    SoulsConvert.ConvertMorphemeAnims(openFileDialog.FileNames.ToList(), openFileDialog2.FileName);
                }
            }
        }

        private void readNMBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select DS2 NMB File",
                Filter = "DS2 Anim *.nmb files|*.nmb",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    SoulsConvert.ReadNMB(file, File.ReadAllBytes(file));
                }
            }
        }

        private void readCMDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select DeSR CMDL File",
                Filter = "DeSR CMDL *.cmdl files|*.cmdl",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var cmdl = new CMDL(streamReader);
                    }
                }
            }
        }

        private void readMMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Metal Wolf Chaos mmd File",
                Filter = "Metal Wolf Chaos mmd *.mmd files|*.mmd",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    var aqp = MMDConvert.ConvertMMD(File.ReadAllBytes(file), out var aqn);
                    aquaUI.aqua.aquaModels.Clear();
                    ModelSet set = new ModelSet();
                    set.models.Add(aqp);
                    if (set.models[0] != null && set.models[0].vtxlList.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                        set.models[0].ConvertToLegacyTypes();
                        set.models[0].CreateTrueVertWeights();

                        FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], aqn, new List<AquaMotion>(), Path.ChangeExtension(file, ".fbx"), new List<string>(), new List<Matrix4x4>(), false);
                    }
                }
            }
        }

        private void mWCBNDExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Metal Wolf Chaos bnd File",
                Filter = "Metal Wolf Chaos *.bnd files|*.bnd",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    BNDHandler.BNDExtract(file);
                }
            }
        }

        private void mWCBNDPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new CommonOpenFileDialog()
            {
                Title = "Select Metal Wolf Chaos bnd Folder",
                IsFolderPicker = true,
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    BNDHandler.BNDPack(file);
                }
            }
        }

        private void readOTRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Metal Wolf Chaos otr File",
                Filter = "Metal Wolf Chaos Collision *.otr files|*.otr",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    var aqp = AquaModelLibrary.Extra.FromSoft.MetalWolfChaos.OTRConvert.ConvertOTR(File.ReadAllBytes(file), out var aqn);
                    aquaUI.aqua.aquaModels.Clear();
                    ModelSet set = new ModelSet();
                    set.models.Add(aqp);
                    if (set.models[0] != null && set.models[0].vtxlList.Count > 0 || set.models[0].tempTris[0].faceVerts.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                        set.models[0].ConvertToLegacyTypes();
                        set.models[0].CreateTrueVertWeights();

                        FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], aqn, new List<AquaMotion>(), Path.ChangeExtension(file, ".fbx"), new List<string>(), new List<Matrix4x4>(), false);
                    }
                }
            }
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Metal Wolf Chaos Archive File",
                Filter = "Metal Wolf Chaos DEV, DIV, m.dat, t.dat, BND files|*.dev;*.000;*.001;*.002;*.003;*_m.dat;*_t.dat;*.bnd;*.tex",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    switch (Path.GetExtension(file))
                    {
                        case ".dat":
                            MTDATExtract.ExtractDAT(file);
                            break;
                        case ".tex":
                        case ".bnd":
                            BNDHandler.BNDExtract(file);
                            break;
                        default:
                            DEVDIVUtil.DEVDIVExtract(file);
                            break;
                    }
                }
            }
        }

        private void mdlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Metal Wolf Chaos mdl File",
                Filter = "Metal Wolf Chaos Model *.mdl files|*.mdl",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    var aqp = MDLConvert.ConvertMDL(File.ReadAllBytes(file), out var aqn);
                    aquaUI.aqua.aquaModels.Clear();
                    ModelSet set = new ModelSet();
                    set.models.Add(aqp);
                    if (set.models[0] != null && set.models[0].vtxlList.Count > 0 || set.models[0].tempTris[0].faceVerts.Count > 0)
                    {
                        aquaUI.aqua.aquaModels.Add(set);
                        aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                        set.models[0].ConvertToLegacyTypes();
                        set.models[0].CreateTrueVertWeights();

                        FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], aqn, new List<AquaMotion>(), Path.ChangeExtension(file, ".fbx"), new List<string>(), new List<Matrix4x4>(), false);
                    }
                }
            }
        }

        private void readBillyHatchermc2TofbxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Billy Hatcher lnd, mc2 File",
                Filter = "Billy Hatcher Map Render Model *.lnd, Collision Model *.mc2 files|*.lnd;*.mc2|Billy Hatcher Map Render Model *.lnd|*.lnd|Billy Hatcher Map Collision Model *.mc2|*.mc2",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    var outDir = file + "_out";
                    Directory.CreateDirectory(outDir);
                    List<LNDConvert.ModelData> aqpList = new List<LNDConvert.ModelData>();
                    if (file.EndsWith(".mc2"))
                    {
                        LNDConvert.ModelData modelData = new LNDConvert.ModelData();

                        modelData.aqp = MC2Convert.ConvertMC2(File.ReadAllBytes(file), out modelData.aqn);
                        modelData.aqn = AquaNode.GenerateBasicAQN();
                        aqpList.Add(modelData);
                    }
                    else
                    {
                        using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                        using (var streamReader = new BufferedStreamReader(stream, 8192))
                        {
                            var lnd = new LND(streamReader);
                            if (lnd.gvmBytes != null)
                            {
                                File.WriteAllBytes(Path.Combine(outDir, $"{Path.GetFileNameWithoutExtension(file)}.gvm"), lnd.gvmBytes.ToArray());
                            }
                            aqpList = LNDConvert.LNDToAqua(lnd);
                        }
                    }

                    foreach(var modelData in aqpList)
                    {
                        var motionList = new List<AquaMotion>();
                        var motionStrings = new List<string>();
                        if(modelData.aqm != null)
                        {
                            motionStrings.Add("LNDMotion");
                            motionList.Add(modelData.aqm);
                        }

                        //Model
                        aquaUI.aqua.aquaModels.Clear();
                        ModelSet set = new ModelSet();
                        set.models.Add(modelData.aqp);
                        if (set.models[0] != null && set.models[0].vtxlList.Count > 0 || set.models[0].tempTris[0].faceVerts.Count > 0)
                        {
                            aquaUI.aqua.aquaModels.Add(set);
                            aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                            set.models[0].ConvertToLegacyTypes();
                            set.models[0].CreateTrueVertWeights();

                            FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], modelData.aqn, motionList, Path.Combine(outDir,Path.GetFileNameWithoutExtension(file) + $"_{modelData.name}.fbx"), motionStrings, new List<Matrix4x4>(), false);
                        }
                        if(modelData.nightAqp != null)
                        {
                            //Night model
                            aquaUI.aqua.aquaModels.Clear();
                            set = new ModelSet();
                            set.models.Add(modelData.nightAqp);
                            if (set.models[0] != null && set.models[0].vtxlList.Count > 0 || set.models[0].tempTris[0].faceVerts.Count > 0)
                            {
                                aquaUI.aqua.aquaModels.Add(set);
                                aquaUI.aqua.ConvertToNGSPSO2Mesh(false, false, false, true, false, false, false, true);
                                set.models[0].ConvertToLegacyTypes();
                                set.models[0].CreateTrueVertWeights();

                                FbxExporter.ExportToFile(aquaUI.aqua.aquaModels[0].models[0], modelData.aqn, motionList, Path.Combine(outDir, Path.GetFileNameWithoutExtension(file) + $"_{modelData.name}_night.fbx"), motionStrings, new List<Matrix4x4>(), false);
                            }
                        }
                    }
                }
            }
        }

        private void billyHatcherprdArchiveExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Billy Hatcher prd, glk File",
                Filter = "Billy Hatcher PRD, GLK archive *.prd, .glk files|*.prd;*.glk",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        if(Path.GetExtension(file) == ".prd")
                        {
                            var prd = new PRD(streamReader);
                            var outDir = file + "_out";
                            Directory.CreateDirectory(outDir);
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < prd.files.Count; i++)
                            {
                                var prdFile = prd.files[i];
                                var prdFileName = prd.fileNames[i];
                                sb.AppendLine(prdFileName);
                                File.WriteAllBytes(Path.Combine(outDir, prdFileName), prdFile);
                            }
                            
                        } else
                        {
                            var glk = new AquaModelLibrary.Extra.Ninja.BillyHatcher.GLK(streamReader);
                            var outDir = file + "_out";
                            Directory.CreateDirectory(outDir);
                            for (int i = 0; i < glk.files.Count; i++)
                            {
                                var glkFile = glk.files[i];
                                var glkFileName = glk.entries[i].fileName;

                                File.WriteAllBytes(Path.Combine(outDir, glkFileName), glkFile);
                            }
                        }
                    }
                }
            }
        }

        private void readPATHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Billy Hatcher PATH File",
                Filter = "Billy Hatcher PATH *.pth files|*.pth",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var path = new AquaModelLibrary.Extra.Ninja.BillyHatcher.PATH(streamReader);
                    }
                }
            }
        }

        private void packBillyHatcherprdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var commonOpenFileDialog = new CommonOpenFileDialog()
            {
                Title = "Select Billy Hatcher folder to pack",
                Multiselect = true,
                IsFolderPicker = true
            };
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (var folder in commonOpenFileDialog.FileNames)
                {
                    PRD prd = new PRD();
                    var files = Directory.GetFiles(folder);
                    foreach (var fileName in files)
                    {
                        prd.fileNames.Add(Path.GetFileName(fileName));
                        prd.files.Add(File.ReadAllBytes(fileName));
                    }

                    var outName = folder;
                    if(outName.EndsWith("_out"))
                    {
                        outName = outName.Substring(0, outName.Length - 4);
                    } else
                    {
                        outName += ".prd";
                    }
                    File.WriteAllBytes(outName, prd.GetBytes());
                }
            }
        }

        private void billyHatcherbinTextTotxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Billy Hatcher text File",
                Filter = "Billy Hatcher  *.bin files|*.bin",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
                    using (var streamReader = new BufferedStreamReader(stream, 8192))
                    {
                        var msg = new MesBin(file, streamReader);
                        File.WriteAllLines(file + "_out.txt", msg.strings);
                    }
                }
            }
        }

        private void billyHatcherbintxtBackTobinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select Billy Hatcher bin txt File",
                Filter = "Billy Hatcher  *.txt files|*.txt",
                FileName = "",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    var msg = new MesBin();
                    msg.strings = File.ReadAllLines(file).ToList();
                    File.WriteAllBytes(file + ".bin", msg.GetBytes());
                }
            }
        }
    }
}

