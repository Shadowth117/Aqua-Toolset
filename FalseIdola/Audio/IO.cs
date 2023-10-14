using System.IO;
using VGAudio.Containers;
using VGAudio.Formats;

//Thank you VGAudio.Uwp
namespace FalseIdola.Audio
{
    public static class IO
    {
        public static IAudioFormat OpenFile(string path)
        {
            FileType type = AudioInfo.GetFileTypeFromName(path);
            IAudioReader reader = AudioInfo.Containers[type].GetReader();

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return reader.ReadFormat(stream);
            }
        }

        public static IAudioFormat OpenFile(byte[] file, FileType type)
        {
            IAudioReader reader = AudioInfo.Containers[type].GetReader();

            using (var stream = new MemoryStream(file))
            {
                return reader.ReadFormat(stream);
            }
        }

        public static void SaveFile(AudioData audio, string path)
        {

        }
    }
}