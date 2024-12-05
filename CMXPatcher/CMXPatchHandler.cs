using AquaModelLibrary.Data.PSO2.Aqua;
using AquaModelLibrary.Data.PSO2.Constants;
using AquaModelLibrary.Data.Utility;
using AquaModelLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Zamboni;
using Zamboni.IceFileFormats;

namespace CMXPatcher
{
    public class CMXPatchHandler
    {
        public bool readyToMod = false;
        public string settingsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        public string backupPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\BackupCMX\\";
        public string moddedCMXPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\ModdedCMX\\";
        public string downgradeCMXPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\BenchmarkCMX\\";
        public string modPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Mods\\";
        public string pso2_binDir;
        public IceFile cmxIce;
        public CharacterMakingIndex cmx;
        public byte[] cmxRaw;

        public CMXPatchHandler()
        {
            InitializeCMX();
        }

        public void InitializeCMX()
        {
            Directory.CreateDirectory(modPath);
            if (File.Exists(settingsPath + "settings.txt"))
            {
                var lines = File.ReadAllLines(settingsPath + "settings.txt");
                pso2_binDir = lines[0];


                BackupCMX();
                if (File.Exists(backupPath + "\\pl_data_info.cmx"))
                {
                    cmx = new CharacterMakingIndex(File.ReadAllBytes(backupPath + "\\pl_data_info.cmx"));
                    cmxRaw = File.ReadAllBytes(backupPath + "\\pl_data_info.cmx");
                }
                //InjectCMXMods();
            }
            else
            {
                MessageBox.Show("Must set pso2_bin before attempting to patch .cmx!");
            }
        }

        public bool InjectCMXMods(bool restoreMode = false)
        {
            if (readyToMod == false)
            {
                MessageBox.Show("Please set all paths properly and attempt this again.");
                return false;
            }

            //Reload backup cmx
            if (File.Exists(backupPath + "\\pl_data_info.cmx"))
            {
                cmx = new CharacterMakingIndex(File.ReadAllBytes(backupPath + "\\pl_data_info.cmx"));
                cmxRaw = File.ReadAllBytes(backupPath + "\\pl_data_info.cmx");
            }

            //Write cmx to ice
            string cmxPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCMX));
            if (File.Exists(cmxPath))
            {
                var strm = new MemoryStream(File.ReadAllBytes(cmxPath));
                cmxIce = IceFile.LoadIceFile(strm);
                strm.Dispose();

                InjectCmxToIceGroup(cmxIce.groupOneFiles, cmxRaw);
                InjectCmxToIceGroup(cmxIce.groupTwoFiles, cmxRaw);
            }

            //Gather and write mods to cmx
            if (restoreMode == false)
            {
                GatherCMXModText();
            }
#if DEBUG
            File.WriteAllBytes(settingsPath + "test.cmx", cmxRaw);
#endif
            //Write ice - We recreate the file in case for some strange reason it was something other than a v4 ice
            byte[] rawData = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), cmxIce.groupOneFiles, cmxIce.groupTwoFiles).getRawData(false, false);

            try
            {
                File.WriteAllBytes(cmxPath, rawData);
                return true;
            }
            catch
            {
                MessageBox.Show("Unable to write cmx to game directory. Check file permissions. \nIf using the MS Store version, this may not be fixable.\n" +
                    $"Attempting to write to {moddedCMXPath}");
                try
                {
                    Directory.CreateDirectory(moddedCMXPath);
                    File.WriteAllBytes(moddedCMXPath + HashHelpers.GetFileHash(CharacterMakingIce.classicCMX), rawData);
                    return false;
                }
                catch
                {
                    MessageBox.Show("Unable to write cmx to patcher directory. Check file permissions.");
                    return false;
                }
            }
        }

        private void InjectCmxToIceGroup(byte[][] group, byte[] cmxRaw)
        {
            //Loop through files to get what we need
            for (int i = 0; i < group.Length; i++)
            {
                if (IceFile.getFileName(group[i]).ToLower().Contains(".cmx"))
                {
                    group[i] = cmxRaw;
                    //We can break here since we're really only expecting an NGS cmx and there's only one of those.
                    break;
                }
            }
        }

        private void InjectCmtToIceGroup(byte[][] group, byte[] cmtRaw)
        {
            //Loop through files to get what we need
            for (int i = 0; i < group.Length; i++)
            {
                if (IceFile.getFileName(group[i]).ToLower().Contains(".cmt"))
                {
                    group[i] = cmtRaw;
                    break;
                }
            }
        }

        private void InjectNamedFileToIceGroup(byte[][] group, byte[] fileRaw, string fileName)
        {
            //Loop through files to get what we need
            for (int i = 0; i < group.Length; i++)
            {
                if (IceFile.getFileName(group[i]).ToLower() == fileName)
                {
                    group[i] = fileRaw;
                    break;
                }
            }
        }

        public bool DowngradeCmx()
        {
            if (readyToMod == false)
            {
                MessageBox.Show("Please set all paths properly and attempt this again.");
                return false;
            }

            //Reload backup cmx
            if (File.Exists(backupPath + "\\pl_data_info.cmx"))
            {
                cmx = new CharacterMakingIndex(File.ReadAllBytes(backupPath + "\\pl_data_info.cmx"));
                cmxRaw = File.ReadAllBytes(backupPath + "\\pl_data_info.cmx");
            }
            string cmxPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCMX));
            if (File.Exists(cmxPath))
            {
                var strm = new MemoryStream(File.ReadAllBytes(cmxPath));
                cmxIce = IceFile.LoadIceFile(strm);
                strm.Dispose();

                InjectCmxToIceGroup(cmxIce.groupOneFiles, cmxRaw);
                InjectCmxToIceGroup(cmxIce.groupTwoFiles, cmxRaw);
            }

            //ACCE replacement
            PatchACCE(cmx, cmxRaw);

            cmx.WriteMode = 0;
            cmxRaw = cmx.GetBytesNIFL();

            //Write ice - We recreate the file in case for some strange reason it was something other than a v4 ice
            byte[] rawData = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), cmxIce.groupOneFiles, cmxIce.groupTwoFiles).getRawData(false, false);

            try
            {
                Directory.CreateDirectory(downgradeCMXPath);
                File.WriteAllBytes(downgradeCMXPath + HashHelpers.GetFileHash(CharacterMakingIce.classicCMX), rawData);
                return true;
            }
            catch
            {
                MessageBox.Show("Unable to write cmx to patcher directory. Check file permissions.");
            }
            return false;
        }

        public byte[] PatchACCE(CharacterMakingIndex cmx, byte[] cmxRaw)
        {
            List<byte> acceBytes = new List<byte>();
            foreach (var acceKey in cmx.accessoryDict.Keys)
            {
                acceBytes.AddRange(DataHelpers.ConvertStruct(cmx.accessoryDict[acceKey].acce));
                acceBytes.AddRange(DataHelpers.ConvertStruct(cmx.accessoryDict[acceKey].acce2a));
            }
            Array.Copy(acceBytes.ToArray(), 0, cmxRaw, cmx.cmxTable.accessoryAddress, acceBytes.Count);

            return cmxRaw;
        }

        public void BackupCMX()
        {
            bool isOldCmx = false;
            //Check original CMX to see if we need to do a new backup.
            string cmxPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCMX));
            if (File.Exists(cmxPath))
            {
                //bool foundCmx = false;
                var strm = new MemoryStream(File.ReadAllBytes(cmxPath));
                cmxIce = IceFile.LoadIceFile(strm);
                strm.Dispose();

                List<byte[]> files = (new List<byte[]>(cmxIce.groupOneFiles));
                files.AddRange(cmxIce.groupTwoFiles);

                //Loop through files to get what we need
                foreach (byte[] file in files)
                {
                    if (IceFile.getFileName(file).ToLower().Contains(".cmx"))
                    {
                        //If the filesize is actually different, since it should be the same between modded ones and the originals, we want to back it up
                        if (cmxRaw == null || file.Length != cmxRaw.Length)
                        {
                            isOldCmx = true;
                            cmxRaw = file;
                            cmx = new CharacterMakingIndex(file);
                        }
                        //foundCmx = true;

                        //We can break here since we're really only expecting an NGS cmx and there's only one of those.
                        break;
                    }
                }
                files.Clear();
            }
            else
            {
                MessageBox.Show("Cannot find CMX ice!");
                return;
            }

            //Backup if the file didn't exist or the CMX was old
            if (!File.Exists(backupPath + "\\pl_data_info.cmx") || isOldCmx)
            {
                Directory.CreateDirectory(backupPath);
                File.WriteAllBytes(backupPath + "\\pl_data_info.cmx", cmxRaw);
            }
            readyToMod = true;
        }

        public void GatherCMXModText()
        {
            var files = Directory.EnumerateFiles(modPath, "*_cmxConfig.txt", SearchOption.AllDirectories).ToArray();
            foreach (var file in files)
            {
                var cmxText = File.ReadAllLines(file);
                var cmxEntry = new List<string>();
                string cmxType = "";
                int cmxId = -1;
                foreach (var line in cmxText)
                {
                    //Ignore empty lines
                    if (line == "")
                    {
                        continue;
                    }

                    //Check if this line defines a new entry
                    var value = line.Split(':');
                    if (value.Length == 2)
                    {
                        if (cmxType != null)
                        {
                            ProcessEntry(ref cmxType, ref cmxId, cmxEntry);
                        }
                        cmxType = value[0];
                        cmxId = Int32.Parse(value[1]);
                        continue;
                    }

                    //Add data to current entry
                    cmxEntry.Add(line);

                }

                //Flush the last potential entry if needed
                if (cmxType != null)
                {
                    ProcessEntry(ref cmxType, ref cmxId, cmxEntry);
                }

            }
        }

        public void ProcessEntry(ref string cmxType, ref int cmxId, List<string> cmxEntry)
        {
            byte[] entryRaw;
            switch (cmxType.ToLower())
            {
                case "base ":
                case "basewear ":
                    var baseEntry = cmx.baseWearDict[cmxId];
                    BODYStructHandler.PatchBody(cmx.baseWearDict[cmxId], cmxEntry);
                    entryRaw = BODYStructHandler.GetBODYAsBytes(baseEntry);
                    Array.Copy(entryRaw, 0, cmxRaw, baseEntry.originalOffset, entryRaw.Length);
                    break;
                case "outer ":
                case "outerwear ":
                    var ouEntry = cmx.outerDict[cmxId];
                    BODYStructHandler.PatchBody(cmx.outerDict[cmxId], cmxEntry);
                    entryRaw = BODYStructHandler.GetBODYAsBytes(ouEntry);
                    Array.Copy(entryRaw, 0, cmxRaw, ouEntry.originalOffset, entryRaw.Length);
                    break;
                case "carm ":
                case "castarm ":
                    var carmEntry = cmx.carmDict[cmxId];
                    BODYStructHandler.PatchBody(cmx.carmDict[cmxId], cmxEntry);
                    entryRaw = BODYStructHandler.GetBODYAsBytes(carmEntry);
                    Array.Copy(entryRaw, 0, cmxRaw, carmEntry.originalOffset, entryRaw.Length);
                    break;
                case "cleg ":
                case "castleg ":
                    var clegEntry = cmx.clegDict[cmxId];
                    BODYStructHandler.PatchBody(cmx.clegDict[cmxId], cmxEntry);
                    entryRaw = BODYStructHandler.GetBODYAsBytes(clegEntry);
                    Array.Copy(entryRaw, 0, cmxRaw, clegEntry.originalOffset, entryRaw.Length);
                    break;
                case "body ":
                case "costume ":
                    var bodyEntry = cmx.costumeDict[cmxId];
                    BODYStructHandler.PatchBody(cmx.costumeDict[cmxId], cmxEntry);
                    entryRaw = BODYStructHandler.GetBODYAsBytes(bodyEntry);
                    Array.Copy(entryRaw, 0, cmxRaw, bodyEntry.originalOffset, entryRaw.Length);
                    break;
                case "hair ":
                    var hairEntry = cmx.hairDict[cmxId];
                    HAIRStructHandler.PatchBody(cmx.hairDict[cmxId], cmxEntry);
                    entryRaw = HAIRStructHandler.GetHAIRAsBytes(hairEntry);
                    Array.Copy(entryRaw, 0, cmxRaw, hairEntry.originalOffset, entryRaw.Length);
                    break;
                default:
                    break;
            }
            cmxType = "";
            cmxId = -1;
        }

        public bool JailBreakBenchmark(string benchmarkPSO2Bin)
        {
            string classicColorPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicColor));
            string cmxPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCMX));
            string collectPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCollect));
            string partsTextPath;
            string acceTextpath;
            if (Directory.Exists(Path.Combine(pso2_binDir, CharacterMakingIndex.dataNADir)) && Directory.Exists(Path.Combine(benchmarkPSO2Bin + "\\", CharacterMakingIndex.dataNADir)))
            {
                partsTextPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataNADir, HashHelpers.GetFileHash(CharacterMakingIce.classicPartText));
                acceTextpath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataNADir, HashHelpers.GetFileHash(CharacterMakingIce.classicAcceText));
            }
            else
            {
                partsTextPath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicPartText));
                acceTextpath = Path.Combine(pso2_binDir, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicAcceText));
            }
            IceFile cmxIce;
            IceFile collectIce;
            CharacterMakingIndex cmx = new CharacterMakingIndex();
            CharacterMakingTemplate cmt = new CharacterMakingTemplate();
            List<byte> ccoOut = new List<byte>();
            List<byte> cmtOut = new List<byte>();
            List<byte> cmxOut = new List<byte>();

            if (File.Exists(cmxPath))
            {
                cmxIce = IceFile.LoadIceFile(new MemoryStream(File.ReadAllBytes(cmxPath)));
            }
            else
            {
                MessageBox.Show($"Error, could not read {cmxPath}");
                return false;
            }

            //Get the CMX and CMT
            List<byte[]> files = (new List<byte[]>(cmxIce.groupOneFiles));
            files.AddRange(cmxIce.groupTwoFiles);

            //Loop through files to get what we need
            foreach (byte[] file in files)
            {
                var ext = Path.GetExtension(IceFile.getFileName(file).ToLower());

                switch (ext)
                {
                    case ".cmt":
                        cmt = new CharacterMakingTemplate(file);
                        cmt.ConvertToNGSBenchmark1();
                        cmt.SetNGSBenchmarkEnableFlag();
                        break;
                    case ".cmx":
                        cmx.Read(file);
                        break;
                }
            }

            //Generate a new CCO. They're so simple it's not worth keeping what's in the old one, especially since we're gutting the old values
            ccoOut.AddRange(CCO.GenerateAccessoryCCO(cmx));
            ccoOut.InsertRange(0, (new IceHeaderStructures.IceFileHeader(CharacterMakingStatic.accessoryCostName, (uint)ccoOut.Count)).GetBytes());
            cmtOut.AddRange(cmt.GetBytesNIFL());
            cmtOut.InsertRange(0, (new IceHeaderStructures.IceFileHeader(CharacterMakingStatic.cmtName, (uint)cmtOut.Count)).GetBytes());
            cmx.WriteMode = 0;
            var cmxBytes = cmx.GetBytesNIFL();
            cmxOut.AddRange(cmxBytes);
            cmxOut.InsertRange(0, (new IceHeaderStructures.IceFileHeader(CharacterMakingStatic.cmxName, (uint)cmxOut.Count)).GetBytes());

            if (File.Exists(collectPath))
            {
                collectIce = IceFile.LoadIceFile(new MemoryStream(File.ReadAllBytes(collectPath)));
            }
            else
            {
                MessageBox.Show($"Error, could not read {collectPath}");
                return false;
            }

            //Write system collect ice
            var ccoRaw = ccoOut.ToArray();
            InjectNamedFileToIceGroup(collectIce.groupOneFiles, ccoRaw, CharacterMakingStatic.accessoryCostName);
            InjectNamedFileToIceGroup(collectIce.groupTwoFiles, ccoRaw, CharacterMakingStatic.accessoryCostName);
            byte[] rawDataSystemCollect = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), collectIce.groupOneFiles, collectIce.groupTwoFiles).getRawData(false, false);
            File.WriteAllBytes(Path.Combine(benchmarkPSO2Bin, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCollect)), rawDataSystemCollect);

            //Write system ice
            var cmxRaw = cmxOut.ToArray();
            var cmtRaw = cmtOut.ToArray();
            InjectCmxToIceGroup(cmxIce.groupOneFiles, cmxRaw);
            InjectCmxToIceGroup(cmxIce.groupTwoFiles, cmxRaw);
            InjectCmtToIceGroup(cmxIce.groupOneFiles, cmtRaw);
            InjectCmtToIceGroup(cmxIce.groupTwoFiles, cmtRaw);
            byte[] rawDataSystem = new IceV4File((new IceHeaderStructures.IceArchiveHeader()).GetBytes(), cmxIce.groupOneFiles, cmxIce.groupTwoFiles).getRawData(false, false);
            File.WriteAllBytes(Path.Combine(benchmarkPSO2Bin, CharacterMakingIndex.dataDir, HashHelpers.GetFileHash(CharacterMakingIce.classicCMX)), rawDataSystem);

            TryCopy(benchmarkPSO2Bin, pso2_binDir, classicColorPath);
            TryCopy(benchmarkPSO2Bin, pso2_binDir, partsTextPath);
            TryCopy(benchmarkPSO2Bin, pso2_binDir, acceTextpath);

            //Copy aaaaaaaaaaaaaaaaaaaaaaall the player shit if it's not there already
            var namesDicts = ReferenceGenerator.OutputCharacterPartFileStringDict(pso2_binDir, cmx, out int totalCount);
            foreach (var namesDict in namesDicts.Values)
            {
                foreach (var list in namesDict.Values)
                {
                    foreach (var part in list)
                    {
                        part.CopyFiles(pso2_binDir, benchmarkPSO2Bin);
                    }
                }
            }

            return true;
        }

        private static bool TryCopy(string benchmarkPSO2Bin, string pso2BinDir, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Copy(filePath, filePath.Replace(pso2BinDir, benchmarkPSO2Bin + "\\"), true);
            }
            else
            {
                MessageBox.Show($"Error, could not read {filePath}");
                return true;
            }

            return false;
        }

        public void OpenModsFolder()
        {
            Directory.CreateDirectory(modPath);

            using Process process = new Process();
            process.StartInfo.FileName = "explorer.exe";
            process.StartInfo.Arguments = modPath;
            process.Start();
        }

        public void OpenDumpsFolder()
        {
            string dump = settingsPath + "CMXEntryDumps\\";
            Directory.CreateDirectory(dump);

            using Process process = new Process();
            process.StartInfo.FileName = "explorer.exe";
            process.StartInfo.Arguments = dump;
            process.Start();
        }
    }
}
