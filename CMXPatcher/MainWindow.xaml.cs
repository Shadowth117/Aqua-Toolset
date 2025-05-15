using AquaModelLibrary.Data.PSO2.Aqua.CharacterMakingIndexData;
using AquaModelLibrary.ToolUX.CommonForms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace CMXPatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string settingsPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        CMXPatchHandler patcher = new CMXPatchHandler();
        CommonOpenFileDialog pso2BinSelect = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            Title = "Select pso2_bin",
        };
        CommonOpenFileDialog benchmarkPso2BinSelect = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            Title = "Select Benchmark pso2_bin",
        };

        public MainWindow()
        {
            InitializeComponent();
            SetFunctionality();
        }

        private void SetPSO2Bin(object sender, RoutedEventArgs e)
        {
            if (pso2BinSelect.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //Ensure paths are created and ready
                File.WriteAllText(settingsPath + "settings.txt", pso2BinSelect.FileName + "\\");
                try
                {
                    patcher.InitializeCMX();
                }
                catch (Exception exc)
                {
                    patcher.pso2_binDir = null;
                    File.Delete(settingsPath + "settings.txt");
                    File.WriteAllText(settingsPath + "log.txt", exc.ToString());
                    MessageBox.Show("Unable to to read CMX.\nIf this path leads to a modified benchmark pso2_bin, please choose a current PSO2 pso2_bin and update the benchmark via the Jailbreak Benchmark button.");
                }
                SetFunctionality();
            }
        }

        private void CheckPSO2Bin(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(patcher.pso2_binDir);
        }

        private void SetFunctionality()
        {
            ExtractMenu.IsEnabled = patcher.readyToMod;
            patchCmxButton.IsEnabled = patcher.readyToMod;
            restoreCmxButton.IsEnabled = patcher.readyToMod;
            jailBreakBenchmarkButton.IsEnabled = patcher.readyToMod;
        }

        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExtractEditableEntries(object sender, RoutedEventArgs e)
        {
            foreach (var id in patcher.cmx.costumeDict.Keys)
            {
                ExtractBodyEntryNoPrompt("costume", patcher.cmx.costumeDict, id, true);
            }
            foreach (var id in patcher.cmx.baseWearDict.Keys)
            {
                ExtractBodyEntryNoPrompt("basewear", patcher.cmx.baseWearDict, id, true);
            }
            foreach (var id in patcher.cmx.outerDict.Keys)
            {
                ExtractBodyEntryNoPrompt("outerwear", patcher.cmx.outerDict, id, true);
            }
            foreach (var id in patcher.cmx.carmDict.Keys)
            {
                ExtractBodyEntryNoPrompt("castarm", patcher.cmx.carmDict, id, true);
            }
            foreach (var id in patcher.cmx.clegDict.Keys)
            {
                ExtractBodyEntryNoPrompt("castleg", patcher.cmx.clegDict, id, true);
            }
            foreach (var id in patcher.cmx.hairDict.Keys)
            {
                ExtractHairEntryNoPrompt("hair", patcher.cmx.hairDict, id, true);
            }
        }

        private void ExtractCostumeEntry(object sender, RoutedEventArgs e)
        {
            ExtractBodyEntry("costume", patcher.cmx.costumeDict);
        }
        private void ExtractBasewearEntry(object sender, RoutedEventArgs e)
        {
            ExtractBodyEntry("basewear", patcher.cmx.baseWearDict);
        }
        private void ExtractOuterWearEntry(object sender, RoutedEventArgs e)
        {
            ExtractBodyEntry("outerwear", patcher.cmx.outerDict);
        }
        private void ExtractCarmEntry(object sender, RoutedEventArgs e)
        {
            ExtractBodyEntry("castarm", patcher.cmx.carmDict);
        }
        private void ExtractClegEntry(object sender, RoutedEventArgs e)
        {
            ExtractBodyEntry("castleg", patcher.cmx.clegDict);
        }
        private void ExtractHairEntry(object sender, RoutedEventArgs e)
        {
            ExtractHairEntry("hair", patcher.cmx.hairDict);
        }
        private void ExtractHairEntry(string type, Dictionary<int, HAIRObject> dict)
        {
            var id = NumberPrompt.ShowDialog(type);
            ExtractHairEntryNoPrompt(type, dict, id);
        }

        private void ExtractCMLEntry(object sender, RoutedEventArgs e)
        {
            patcher.ExtractCMLs();
        }

        private void ExtractBodyEntry(string type, Dictionary<int, BODYObject> dict)
        {
            var id = NumberPrompt.ShowDialog(type);
            ExtractBodyEntryNoPrompt(type, dict, id);
        }
        private bool ExtractHairEntryNoPrompt(string type, Dictionary<int, HAIRObject> dict, int id, bool silent = false)
        {
            bool success = false;
            if (id != -1)
            {
                if (dict.ContainsKey(id))
                {
                    Directory.CreateDirectory(settingsPath + "CMXEntryDumps\\");
                    string path = settingsPath + $"CMXEntryDumps\\{type}_{id}_cmxConfig.txt";
                    try
                    {
                        File.WriteAllText(path, HAIRStructHandler.ConvertToString(dict[id], type).ToString());
                        success = true;
                        if (!silent)
                        {
                            MessageBox.Show($"Wrote successfully to {path}.");
                        }
                    }
                    catch
                    {
                        if (!silent)
                        {
                            MessageBox.Show($"Unable to write {path}. Ensure you have all permissions to said directory.");
                        }
                    }
                }
                else
                {
                    if (!silent)
                    {
                        MessageBox.Show("Please Input a valid id to extract.");
                    }
                }
            }
            else
            {
                if (!silent)
                {
                    MessageBox.Show("Please Input a valid id to extract.");
                }
            }

            return success;
        }

        private bool ExtractBodyEntryNoPrompt(string type, Dictionary<int, BODYObject> dict, int id, bool silent = false)
        {
            bool success = false;
            if (id != -1)
            {
                if (dict.ContainsKey(id))
                {
                    Directory.CreateDirectory(settingsPath + "CMXEntryDumps\\");
                    string path = settingsPath + $"CMXEntryDumps\\{type}_{id}_cmxConfig.txt";
                    try
                    {
                        File.WriteAllText(path, BODYStructHandler.ConvertToString(dict[id], type, !silent).ToString());
                        success = true;
                        if (!silent)
                        {
                            MessageBox.Show($"Wrote successfully to {path}.");
                        }
                    }
                    catch
                    {
                        if (!silent)
                        {
                            MessageBox.Show($"Unable to write {path}. Ensure you have all permissions to said directory.");
                        }
                    }
                }
                else
                {
                    if (!silent)
                    {
                        MessageBox.Show("Please Input a valid id to extract.");
                    }
                }
            }
            else
            {
                if (!silent)
                {
                    MessageBox.Show("Please Input a valid id to extract.");
                }
            }

            return success;
        }

        private void cmxPatchClick(object sender, RoutedEventArgs e)
        {
            if (patcher.InjectCMXMods())
            {
                MessageBox.Show("CMX successfully patched.");
            }
            else
            {
                MessageBox.Show("Problem patching CMX.");
            }
        }

        private void cmxRestoreClick(object sender, RoutedEventArgs e)
        {
            if (patcher.InjectCMXMods(true))
            {
                MessageBox.Show("CMX successfully restored.");
            }
            else
            {
                MessageBox.Show("Problem patching CMX.");
            }
        }

        private void cmxDowngradeClick(object sender, RoutedEventArgs e)
        {
            if (patcher.DowngradeCmx())
            {
                MessageBox.Show("CMX successfully downgraded. Output ice written CMXPatcher BenchmarkCMX subfolder.");
            }
            else
            {
                MessageBox.Show("CMX downgrade failed.");
            }
        }

        private void benchmarkJailbreakClick(object sender, RoutedEventArgs e)
        {
            if (benchmarkPso2BinSelect.ShowDialog() == CommonFileDialogResult.Ok && Directory.Exists(benchmarkPso2BinSelect.FileName + "\\data\\win32\\") && !File.Exists(benchmarkPso2BinSelect.FileName + "\\GameGuard.des"))
            {
                Character_Making_File_Tool.WIPBox box = new("Please wait while part files are copied. \nThis may take a moment");
                box.Show();
                box.CenterWindowOnScreen();
                try
                {
                    if (patcher.JailBreakBenchmark(benchmarkPso2BinSelect.FileName))
                    {
                        box.Hide();
                        box.Close();
                        MessageBox.Show("Benchmark Jailbreak successful!");
                    }
                    else
                    {
                        box.Hide();
                        box.Close();
                        MessageBox.Show("Benchmark Jailbreak failed.");
                    }

                }
                catch (Exception exc)
                {
                    box.Hide();
                    box.Close();
                    File.WriteAllText(settingsPath + "log.txt", exc.ToString());
                    MessageBox.Show("Exception occured trying to jailbreak benchmark. See log.txt for details.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid character creator benchmark pso2_bin path!");
            }
        }

        private void openModsFolder(object sender, RoutedEventArgs e)
        {
            patcher.OpenModsFolder();
        }
        private void openDumpsFolder(object sender, RoutedEventArgs e)
        {
            patcher.OpenDumpsFolder();
        }
    }
}
