using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using static AquaModelLibrary.Data.PSO2.Constants.WeaponNames;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using AquaModelLibrary.Helpers;

namespace WeaponInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WeaponRow> swordList = new List<WeaponRow>();
        List<WeaponRow> wiredLanceList = new List<WeaponRow>();
        List<WeaponRow> partizanList = new List<WeaponRow>();
        List<WeaponRow> twinDaggerList = new List<WeaponRow>();
        List<WeaponRow> doubleSaberList = new List<WeaponRow>();
        List<WeaponRow> knucklesList = new List<WeaponRow>();
        List<WeaponRow> gunslashList = new List<WeaponRow>();
        List<WeaponRow> rifleList = new List<WeaponRow>();
        List<WeaponRow> launcherList = new List<WeaponRow>();
        List<WeaponRow> tmgList = new List<WeaponRow>();
        List<WeaponRow> rodList = new List<WeaponRow>();
        List<WeaponRow> talisList = new List<WeaponRow>();
        List<WeaponRow> wandList = new List<WeaponRow>();
        List<WeaponRow> katanaList = new List<WeaponRow>();
        List<WeaponRow> bowList = new List<WeaponRow>();
        List<WeaponRow> jetbootsList = new List<WeaponRow>();
        List<WeaponRow> dualBladesList = new List<WeaponRow>();
        List<WeaponRow> tactList = new List<WeaponRow>();

        List<WeaponRow> swordNGSList = new List<WeaponRow>();
        List<WeaponRow> wiredLanceNGSList = new List<WeaponRow>();
        List<WeaponRow> partizanNGSList = new List<WeaponRow>();
        List<WeaponRow> twinDaggerNGSList = new List<WeaponRow>();
        List<WeaponRow> doubleSaberNGSList = new List<WeaponRow>();
        List<WeaponRow> knucklesNGSList = new List<WeaponRow>();
        List<WeaponRow> gunslashNGSList = new List<WeaponRow>();
        List<WeaponRow> rifleNGSList = new List<WeaponRow>();
        List<WeaponRow> launcherNGSList = new List<WeaponRow>();
        List<WeaponRow> tmgNGSList = new List<WeaponRow>();
        List<WeaponRow> rodNGSList = new List<WeaponRow>();
        List<WeaponRow> talisNGSList = new List<WeaponRow>();
        List<WeaponRow> wandNGSList = new List<WeaponRow>();
        List<WeaponRow> katanaNGSList = new List<WeaponRow>();
        List<WeaponRow> bowNGSList = new List<WeaponRow>();
        List<WeaponRow> jetbootsNGSList = new List<WeaponRow>();
        List<WeaponRow> dualBladesNGSList = new List<WeaponRow>();
        List<WeaponRow> tactNGSList = new List<WeaponRow>();

        List<List<WeaponRow>> wepListList;

        List<WeaponRow> WeaponList = new List<WeaponRow>();
        CommonOpenFileDialog pso2BinSelect = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            Title = "Select pso2_bin",
        };


        bool canUpdate = false;
        string win32Folder = null;
        string win32RebootFolder = null;
        string trueWin32Folder = null;
        string trueWin32RebootFolder = null;
        string currentFile = null;

        public MainWindow()
        {
            InitializeComponent();
            LoadPSO2Bin();
#if DEBUG
            replaceSelectedFromChecked.Visibility = Visibility.Visible;
#endif
            canUpdate = true;
        }

        private void LoadPSO2Bin()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Weapons\\weaponSettings.txt"))
            {
                var settings = File.ReadAllLines(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Weapons\\weaponSettings.txt");
                win32Folder = settings[0];
                win32RebootFolder = settings[1];
                if (settings.Length < 4)
                {
                    MessageBox.Show("Re set your pso2bin please!");
                }
                trueWin32Folder = settings[2];
                trueWin32RebootFolder = settings[3];
                AddRowsToList();
                LoadWeaponRows();
                UpdateList();
            }
            else
            {
                MessageBox.Show("Must set pso2_bin before attempting to install weapons!");
            }
        }

        private void SetPSO2Bin(object sender, RoutedEventArgs e)
        {
            if (pso2BinSelect.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //Ensure paths are created and ready
                List<string> pso2Bin = new List<string>();
                if (Directory.Exists(pso2BinSelect.FileName + "\\Mods\\"))
                {
                    pso2Bin.Add(pso2BinSelect.FileName + "\\Mods\\");
                    pso2Bin.Add(pso2BinSelect.FileName + "\\ModsReboot\\");
                    win32Folder = pso2BinSelect.FileName + "\\Mods\\";
                    win32RebootFolder = pso2BinSelect.FileName + "\\ModsReboot\\";
                    MessageBox.Show("Weapons will be installed to Tweaker Mods and ModsReboot folders");
                }
                else
                {
                    pso2Bin.Add(pso2BinSelect.FileName + "\\data\\win32\\");
                    pso2Bin.Add(pso2BinSelect.FileName + "\\data\\win32reboot\\");
                    win32Folder = pso2BinSelect.FileName + "\\data\\win32\\";
                    win32RebootFolder = pso2BinSelect.FileName + "\\data\\win32reboot\\";
                    MessageBox.Show("Weapons will be installed to your win32 and win32reboot folders");
                }
                pso2Bin.Add(pso2BinSelect.FileName + "\\data\\win32\\");
                pso2Bin.Add(pso2BinSelect.FileName + "\\data\\win32reboot\\");
                trueWin32Folder = pso2BinSelect.FileName + "\\data\\win32\\";
                trueWin32RebootFolder = pso2BinSelect.FileName + "\\data\\win32reboot\\";
                Directory.CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Weapons\\");
                File.WriteAllLines(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Weapons\\weaponSettings.txt", pso2Bin);
                LoadPSO2Bin();
            }
        }

        /// <summary>
        /// Add all potential items to datagrid from a clean list
        /// </summary>
        private void UpdateList()
        {
            WeaponList.Clear();

            if (swordCheck.IsChecked == true)
            {
                AddList(WeaponList, swordList, swordNGSList);
            }
            if (wiredLanceCheck.IsChecked == true)
            {
                AddList(WeaponList, wiredLanceList, wiredLanceNGSList);
            }
            if (partizanCheck.IsChecked == true)
            {
                AddList(WeaponList, partizanList, partizanNGSList);
            }
            if (twinDaggerCheck.IsChecked == true)
            {
                AddList(WeaponList, twinDaggerList, twinDaggerNGSList);
            }
            if (doubleSaberCheck.IsChecked == true)
            {
                AddList(WeaponList, doubleSaberList, doubleSaberNGSList);
            }
            if (knucklesCheck.IsChecked == true)
            {
                AddList(WeaponList, knucklesList, knucklesNGSList);
            }
            if (gunslashCheck.IsChecked == true)
            {
                AddList(WeaponList, gunslashList, gunslashNGSList);
            }
            if (assaultRifleCheck.IsChecked == true)
            {
                AddList(WeaponList, rifleList, rifleNGSList);
            }
            if (launcherCheck.IsChecked == true)
            {
                AddList(WeaponList, launcherList, launcherNGSList);
            }
            if (tmgCheck.IsChecked == true)
            {
                AddList(WeaponList, tmgList, tmgNGSList);
            }
            if (rodCheck.IsChecked == true)
            {
                AddList(WeaponList, rodList, rodNGSList);
            }
            if (talisCheck.IsChecked == true)
            {
                AddList(WeaponList, talisList, talisNGSList);
            }
            if (wandCheck.IsChecked == true)
            {
                AddList(WeaponList, wandList, wandNGSList);
            }
            if (katanaCheck.IsChecked == true)
            {
                AddList(WeaponList, katanaList, katanaNGSList);
            }
            if (bowCheck.IsChecked == true)
            {
                AddList(WeaponList, bowList, bowNGSList);
            }
            if (jetbootsCheck.IsChecked == true)
            {
                AddList(WeaponList, jetbootsList, jetbootsNGSList);
            }
            if (dualBladeCheck.IsChecked == true)
            {
                AddList(WeaponList, dualBladesList, dualBladesNGSList);
            }
            if (tactCheck.IsChecked == true)
            {
                AddList(WeaponList, tactList, tactNGSList);
            }
            dataGrid.BeginInit();
            dataGrid.ItemsSource = WeaponList;
            dataGrid.EndInit();
        }

        private void AddList(List<WeaponRow> uiWepList, List<WeaponRow> pso2WepList, List<WeaponRow> ngsWepList)
        {
            switch (gameSetCB.SelectedIndex)
            {
                case 0:
                    uiWepList.AddRange(pso2WepList);
                    uiWepList.AddRange(ngsWepList);
                    break;
                case 1:
                    uiWepList.AddRange(pso2WepList);
                    break;
                case 2:
                    uiWepList.AddRange(ngsWepList);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Populate wepListList for iteration.
        /// </summary>
        private void AddRowsToList()
        {
            wepListList = new List<List<WeaponRow>>()
            {
                swordList,
                wiredLanceList,
                partizanList,
                twinDaggerList,
                doubleSaberList,
                knucklesList,
                gunslashList,
                rifleList,
                launcherList,
                tmgList,
                rodList,
                talisList,
                wandList,
                katanaList,
                bowList,
                jetbootsList,
                dualBladesList,
                tactList,
                swordNGSList,
                wiredLanceNGSList,
                partizanNGSList,
                twinDaggerNGSList,
                doubleSaberNGSList,
                knucklesNGSList,
                gunslashNGSList,
                rifleNGSList,
                launcherNGSList,
                tmgNGSList,
                rodNGSList,
                talisNGSList,
                wandNGSList,
                katanaNGSList,
                bowNGSList,
                jetbootsNGSList,
                dualBladesNGSList,
                tactNGSList,
            };
        }

        /// <summary>
        /// Parse weapon lists from CSVs for usage
        /// </summary>
        public void LoadWeaponRows()
        {
            for (int i = 0; i < wepListList.Count; i++)
            {
                var file = csvFilenames[i];
                int len = file.Length;
                string type = file.Replace("NGSNames.csv", "");
                bool isOldType = type.Length == len;

                if (isOldType)
                {
                    type = file.Replace("Names.csv", "");
                }
                if (type == "Tact")
                {
                    type = type.Replace('c', 'k');
                }

                CheckForWeapon(type, isOldType, wepListList[i]);
            }
        }

        public void CheckForWeapon(string type, bool isOldType, List<WeaponRow> rows)
        {
            Dictionary<int, string> names = new Dictionary<int, string>();
            string pso2Path;
            if (isOldType)
            {
                pso2Path = trueWin32Folder;
            }
            else
            {
                pso2Path = trueWin32RebootFolder;
            }

            int typeInt = 0;
            switch (type)
            {
                case "Sword":
                    typeInt = 1;
                    names = swordNames;
                    break;
                case "WiredLance":
                    typeInt = 2;
                    names = wiredLanceNames;
                    break;
                case "Partizan":
                    typeInt = 3;
                    names = partizanNames;
                    break;
                case "TwinDagger":
                    typeInt = 4;
                    names = twinDaggerNames;
                    break;
                case "DoubleSaber":
                    typeInt = 5;
                    names = doubleSaberNames;
                    break;
                case "Knuckles":
                    typeInt = 6;
                    names = knucklesNames;
                    break;
                case "Gunslash":
                    typeInt = 7;
                    names = gunslashNames;
                    break;
                case "Rifle":
                    typeInt = 8;
                    names = rifleNames;
                    break;
                case "Launcher":
                    typeInt = 9;
                    names = launcherNames;
                    break;
                case "TwinMachineGun":
                    typeInt = 10;
                    names = tmgNames;
                    break;
                case "Rod":
                    typeInt = 11;
                    names = rodNames;
                    break;
                case "Talis":
                    typeInt = 12;
                    names = talysNames;
                    break;
                case "Wand":
                    typeInt = 13;
                    names = wandNames;
                    break;
                case "Katana":
                    typeInt = 14;
                    names = katanaNames;
                    break;
                case "Bow":
                    typeInt = 15;
                    names = bowNames;
                    break;
                case "JetBoots":
                    typeInt = 16;
                    names = jetBootsNames;
                    break;
                case "DualBlades":
                    typeInt = 17;
                    names = dualBladesNames;
                    break;
                case "Takt":
                    typeInt = 18;
                    names = tactNames;
                    break;
            }

            //Clear in case of reloading names for a new pso2_bin
            rows.Clear();

            for (int i = 0; i < 999; i++)
            {
                var idStr = $"{i:D3}";
                var weaponPreHash = $"item/weapon/it_wp_{typeInt:D2}_{idStr}.ice";
                var weapon = HashHelpers.GetFileHash(weaponPreHash);

                if (!isOldType)
                {
                    weapon = HashHelpers.GetRebootHash(weapon);
                }

                if (File.Exists(pso2Path + weapon))
                {
                    string[] nameArr = new string[] { "", "" };
                    if (names.ContainsKey(i))
                    {
                        nameArr = names[i].Split(",");
                    }
                    rows.Add(new WeaponRow(type, idStr, nameArr[1], nameArr[0], weaponPreHash, weapon));
                }
            }
        }

        public void ReadWeaponCSV(string file, string type, List<WeaponRow> rows)
        {
            using (StreamReader reader = new(file))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    if (line.Length > 0)
                    {
                        rows.Add(new WeaponRow(type, line[2].Substring(21, 3), line[1], line[0], line[2], line[3]));
                    }
                }
            }
        }

        public class WeaponRow
        {
            public bool Replace { get; set; }
            public string Type { get; }
            public string Id { get; }
            public string Game { get; }
            public string EnName { get; }
            public string JpName { get; }
            public string Filename { get; }
            public string Md5Hash { get; }

            public WeaponRow()
            {
            }

            public WeaponRow(string type, string id, string enName, string jpName, string filename, string md5, bool replace = false)
            {
                Replace = replace;
                Type = type;
                Game = md5.Contains('\\') ? "NGS" : "PSO2";
                Id = id;
                EnName = enName;
                JpName = jpName;
                Filename = filename;
                Md5Hash = md5;
            }
        }

        private void selectButtonClick(object sender, RoutedEventArgs e)
        {
            using (CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog())
            {
                if (currentFile != null)
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(currentFile);
                }
                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    currentFile = openFileDialog.FileName;
                    currentFileLabel.Content = Path.GetFileName(currentFile);
                }
            }
        }

        private void replaceButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentFile == null || win32Folder == null || win32RebootFolder == null)
            {
                MessageBox.Show("Be sure a file is selected and that your pso2Bin is set!");
            }
            else
            {
                bool success = ReplaceFiles(currentFile);
                if(success)
                {
                    MessageBox.Show("Successfully Replaced!");
                }
            }
        }

        private bool ReplaceFiles(string selectedFile)
        {
            var bytes = File.ReadAllBytes(selectedFile);
            bool checkSomethingPlease = true;
            foreach (var weapon in WeaponList)
            {
                if (weapon.Md5Hash == null || weapon.Md5Hash == "")
                {
                    continue;
                }
                if (weapon.Replace == true)
                {
                    checkSomethingPlease = false;
                    ReplaceFile(bytes, weapon.Game, weapon.Md5Hash);
                }
            }

            if (checkSomethingPlease)
            {
                MessageBox.Show("Please select a file to replace!");
            }

            return checkSomethingPlease;
        }

        private void ReplaceFile(byte[] bytes, string game, string hash)
        {
            string filePath;
            filePath = GetGameFilePath(game, hash);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllBytes(filePath, bytes);
        }

        private string GetGameFilePath(string game, string hash, bool truePaths = false)
        {
            string win32 = truePaths ? trueWin32Folder : win32Folder;
            string reboot = truePaths ? trueWin32RebootFolder : win32RebootFolder;
            string filePath;
            var baseDir = game == "NGS" ? reboot : win32;
            if (game == "NGS" && reboot.Contains("modsreboot", StringComparison.OrdinalIgnoreCase))
            {
                filePath = baseDir + hash.Replace("\\", "");
            }
            else
            {
                filePath = baseDir + hash;
            }

            return filePath;
        }

        private void showAllClick(object sender, RoutedEventArgs e)
        {
            canUpdate = false;

            swordCheck.IsChecked = true;
            wiredLanceCheck.IsChecked = true;
            partizanCheck.IsChecked = true;
            twinDaggerCheck.IsChecked = true;
            doubleSaberCheck.IsChecked = true;
            knucklesCheck.IsChecked = true;
            gunslashCheck.IsChecked = true;
            assaultRifleCheck.IsChecked = true;
            launcherCheck.IsChecked = true;
            tmgCheck.IsChecked = true;
            rodCheck.IsChecked = true;
            talisCheck.IsChecked = true;
            wandCheck.IsChecked = true;
            katanaCheck.IsChecked = true;
            bowCheck.IsChecked = true;
            jetbootsCheck.IsChecked = true;
            dualBladeCheck.IsChecked = true;
            tactCheck.IsChecked = true;

            canUpdate = true;
            UpdateList();
        }

        private void showNoneClick(object sender, RoutedEventArgs e)
        {
            canUpdate = false;

            swordCheck.IsChecked = false;
            wiredLanceCheck.IsChecked = false;
            partizanCheck.IsChecked = false;
            twinDaggerCheck.IsChecked = false;
            doubleSaberCheck.IsChecked = false;
            knucklesCheck.IsChecked = false;
            gunslashCheck.IsChecked = false;
            assaultRifleCheck.IsChecked = false;
            launcherCheck.IsChecked = false;
            tmgCheck.IsChecked = false;
            rodCheck.IsChecked = false;
            talisCheck.IsChecked = false;
            wandCheck.IsChecked = false;
            katanaCheck.IsChecked = false;
            bowCheck.IsChecked = false;
            jetbootsCheck.IsChecked = false;
            dualBladeCheck.IsChecked = false;
            tactCheck.IsChecked = false;

            canUpdate = true;
            UpdateList();
        }

        private void gameSetCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            canUpdate = false;
            UpdateList();
            canUpdate = true;
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            if (canUpdate)
            {
                canUpdate = false;
                UpdateList();
                canUpdate = true;
            }
        }

        private void allCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (canUpdate == true)
            {
                foreach (var weapon in WeaponList)
                {
                    if (allCheck.IsChecked == true)
                    {
                        weapon.Replace = true;
                    }
                    else
                    {
                        weapon.Replace = false;
                    }
                }
                dataGrid.BeginInit();
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = WeaponList;
                dataGrid.EndInit();
            }
        }

        private void InstallFromConfigClick(object sender, RoutedEventArgs e)
        {
            if (win32Folder == null || win32RebootFolder == null)
            {
                MessageBox.Show("Be sure the pso2Bin is set!");
                return;
            }
            string startPath;
            if (currentFile != null)
            {
                startPath = Path.GetDirectoryName(currentFile);
            }
            else
            {
                startPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            using (OpenFileDialog openDialog = new OpenFileDialog()
            {
                Filter = "Weapon Config (*.wepConfig)|*.wepConfig",
                Title = "Select a Weapon Config file",
                Multiselect = true,
                InitialDirectory = startPath
            })
            {
                if (openDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                List<string> failedFiles = new List<string>();
                foreach (var file in openDialog.FileNames)
                {
                    var config = File.ReadAllLines(file);
                    var configDir = Path.GetDirectoryName(file) + "\\";
                    foreach (var filesRaw in config)
                    {
                        var iceFiles = filesRaw.Split('>');
                        if (iceFiles.Length < 2)
                        {
                            continue;
                        }

                        //Fix spacing
                        if (iceFiles[0].LastOrDefault() == ' ')
                        {
                            iceFiles[0] = iceFiles[0][0..^1];
                        }
                        if (iceFiles[1][0] == ' ')
                        {
                            iceFiles[1] = iceFiles[1][1..];
                        }

                        //Get path
                        var modPath = configDir + iceFiles[0];
                        if (!File.Exists(modPath))
                        {
                            if (!failedFiles.Contains(iceFiles[0]))
                            {
                                failedFiles.Add(iceFiles[0]);
                            }
                            continue;
                        }

                        //Get game
                        string game = "PSO2";
                        if (iceFiles[1].Contains("\\"))
                        {
                            game = "NGS";
                        }

                        ReplaceFile(File.ReadAllBytes(modPath), game, iceFiles[1]);
                    }
                }

                //Report failed files
                if (failedFiles.Count > 0)
                {
                    string message = "Unable to load";
                    foreach (var file in failedFiles)
                    {
                        message += $" {file},";
                    }
                    message = message[0..^1];
                    MessageBox.Show(message);
                }
            }
        }

        private void ExportConfigClick(object sender, RoutedEventArgs e)
        {
            if (currentFile == null)
            {
                MessageBox.Show("Be sure a file is selected!");
                return;
            }
            using (SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "Weapon Config, save to same folder as the selected weapon file (*.wepConfig)|*.wepConfig",
                InitialDirectory = Path.GetDirectoryName(currentFile),
                Title = "Save the Weapon Config to same folder as the selected weapon file",
                FileName = Path.ChangeExtension(Path.GetFileName(currentFile), ".wepConfig")
            })
            {
                if (saveDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                List<string> lines = new List<string>();
                if (File.Exists(saveDialog.FileName))
                {
                    if (MessageBox.Show("Would you like to add to the existing file?", "Append", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        lines.AddRange(File.ReadAllLines(saveDialog.FileName));
                    }
                }

                foreach (var weapon in WeaponList)
                {
                    if (weapon.Replace == true)
                    {
                        lines.Add($"{Path.GetFileName(currentFile)} > {weapon.Md5Hash}");
                    }
                }

                File.WriteAllLines(saveDialog.FileName, lines);
            }

        }

        public void ReplaceSelectedFromCheckedClick(object sender, RoutedEventArgs e)
        {
            if (currentFile == null || win32Folder == null || win32RebootFolder == null)
            {
                MessageBox.Show("Be sure a file is selected and that your pso2Bin is set!");
                return;
            }

            foreach (var weapon in WeaponList)
            {
                if (weapon.Replace == false)
                {
                    continue;
                }

                var file = GetGameFilePath(weapon.Game, weapon.Md5Hash, true);
                if (File.Exists(file))
                {
                    File.WriteAllBytes(currentFile, File.ReadAllBytes(file));
                    MessageBox.Show($"{Path.GetFileName(currentFile)} replaced with {weapon.Md5Hash}!");
                }
                else
                {
                    MessageBox.Show($"{Path.GetFileName(file)} not found!");
                }
            }
        }

        public void SetRowAsSelectedClick(object sender, RoutedEventArgs e)
        {
            WeaponRow row = (WeaponRow)dataGrid.SelectedItem;
            currentFile = GetGameFilePath(row.Game, row.Md5Hash, true);
            currentFileLabel.Content = Path.GetFileName(currentFile);
            row = null;
        }
    }
}
