using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using AquaModelLibrary.AquaStructs;
using FalseIdola.Audio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Reloaded.Memory.Streams;
using SonicAudioLib.Archives;
using VGAudio.Containers.Wave;
using Zamboni;

namespace FalseIdola
{
    public class AudioPlayer
    {
        public IWaveProvider audioFile;
        public FileType type = 0;
        public FileStream cpkStream;
        public CriCpkArchive cpk;
        public List<string> hcaStr = new List<string>();
        public List<int> hcaWait = new List<int>();
        public int hcaStrIndex = 0;
        public List<WaveOutEvent> hcaDevices = new List<WaveOutEvent>();

        public AudioPlayer()
        {
            //Test
            var strm = new MemoryStream(File.ReadAllBytes(@"A:\PS4_NGS_PreRetem\datareboot\sound\music\adaptive\mu_11_bgm02_defense_1.ice"));
            var fVarIce = IceFile.LoadIceFile(strm);
            MusicFileReboot mus = new MusicFileReboot();
            strm.Dispose();

            List<byte[]> files = new List<byte[]>(fVarIce.groupOneFiles);
            files.AddRange(fVarIce.groupTwoFiles);

            //Loop through files to get what we need
            foreach (byte[] ffile in files)
            {
                var name = IceFile.getFileName(ffile).ToLower();
                if (name.EndsWith(".mus"))
                {
                    using (var stream = new MemoryStream(ffile))
                    using (var sr = new BufferedStreamReader(stream, 8192))
                    {
                        mus = new MusicFileReboot(sr);
                    }
                }
            }
            files.Clear();
            files = null;


            cpkStream = new FileStream(@"A:\PS4_NGS_PreRetem\datareboot\sound\music\adaptive\mu_11_bgm02_defense_1.cpk", FileMode.Open);
            cpk = new CriCpkArchive();
            cpk.Read(cpkStream);

            foreach(var composition in mus.compositions)
            {
                foreach(var part in composition.parts)
                {
                    foreach(var movement in part.movements)
                    {
                        foreach(var phrase in movement.phrases)
                        {
                            foreach(var bar in phrase.bars)
                            {
                                if(bar.mainClips.Count > 0 && bar.mainClips[0].clipFileName != "")
                                {
                                    hcaStr.Add(bar.mainClips[0].clipFileName);
                                    hcaWait.Add((int)(bar.barStruct.beat / ((double)bar.barStruct.beatsPerMinute / 60) * 1000)); //Divide beat count by bpm / seconds in a minute (60) * 1000 to convert to milliseconds for thread sleep
                                }
                            }
                        }
                    }
                }
            }

            foreach(var str in hcaStr)
            {
                var file = cpk.GetFileByName(cpkStream, str);
                var header = cpk.GetByName(str);

                //var testHca = File.ReadAllBytes(@"C:\Users\Shadi\Downloads\PSO2_Audio_Tools\sonicaudiotools\04_player_rod\00000.hca");
                type = AudioInfo.GetFileTypeFromName(hcaStr[hcaStrIndex]);
                var hcaFile = Audio.IO.OpenFile(file, type);
                //var bytes = AudioInfo.Containers[type].GetWriter().GetFile(audioFile, GetConfiguration(SelectedFileType));
                var bytes = AudioInfo.Containers[FileType.Wave].GetWriter().GetFile(hcaFile, new WaveConfiguration() { Codec = WaveCodec.Pcm16Bit });
                //File.WriteAllBytes(@"C:\Users\Shadi\Downloads\PSO2_Audio_Tools\sonicaudiotools\04_player_rod\00000.wav", bytes);
                //audioFile = new AudioFileReader(@"A:\AC6 OST\ACVI_FOR_SOUNDTRACK\47_Stargazer.mp3");
                //IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(bytes), new WaveFormat(48000, 16, 1));
                IWaveProvider provider = new WaveFileReader(new MemoryStream(bytes));
                audioFile = provider;
                var outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                //outputDevice.PlaybackStopped += playEventTest;
                //hcaDevices.Add(outputDevice);
                //Thread.Sleep(2617);
                Thread.Sleep(hcaWait[hcaStrIndex] - 40);
                hcaStrIndex++;
            }
           
            /*
            var file = cpk.GetFileByName(cpkStream, "B1-001_O-1_1M_B.hca");

            //var testHca = File.ReadAllBytes(@"C:\Users\Shadi\Downloads\PSO2_Audio_Tools\sonicaudiotools\04_player_rod\00000.hca");
            type = AudioInfo.GetFileTypeFromName("test.hca");
            var hcaFile = Audio.IO.OpenFile(file, type);
            //var bytes = AudioInfo.Containers[type].GetWriter().GetFile(audioFile, GetConfiguration(SelectedFileType));
            var bytes = AudioInfo.Containers[FileType.Wave].GetWriter().GetFile(hcaFile, new WaveConfiguration() { Codec = WaveCodec.Pcm16Bit });
            //File.WriteAllBytes(@"C:\Users\Shadi\Downloads\PSO2_Audio_Tools\sonicaudiotools\04_player_rod\00000.wav", bytes);
            //audioFile = new AudioFileReader(@"A:\AC6 OST\ACVI_FOR_SOUNDTRACK\47_Stargazer.mp3");
            //IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(bytes), new WaveFormat(48000, 16, 1));
            IWaveProvider provider = new WaveFileReader(new MemoryStream(bytes));
            audioFile = provider;
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            */
        }

        public void playEventTest(object sender, StoppedEventArgs stoppedEvent)
        {
            hcaStrIndex++;
            hcaDevices[hcaStrIndex].Play();
        }
    }
}
