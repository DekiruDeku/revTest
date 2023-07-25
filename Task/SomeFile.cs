using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestTask.Task.Exception;

namespace TestTask.Task
{
    
    public class SomeFile : IFile
    {
        public async Task<Stack<byte>> ReadFileInBytes(string Path)
        {
            Path = CheckForFileExtension(Path);
            Stack<byte> bytesinFile = new Stack<byte>();
            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    bytesinFile.Push(reader.ReadByte());
                }
            }
            return bytesinFile;
        }

        

        public void MakeOrUpdateBytesInFile(Stack<byte> subsequence, string Path)
        {
            if (!Path.EndsWith(".dat"))
            {
                Path.Substring(0, Path.Length - 5);
                Path += ".dat";
            }
            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (var bytes in subsequence)
                {
                    writer.Write(bytes);
                }
                Console.WriteLine("Текст записан в файл");
            }
        }

        public void CheckForRightName(ref string inputname)
        {
            if (inputname.Contains(@"\"))
            {
                while (inputname.Contains(@"\"))
                {
                    Console.WriteLine("Вы пытаетесь ввести путь, а не имя файла,попробуйте еще раз:");
                    inputname = System.Console.ReadLine();
                }
            }
        }
        
        private string CheckForFileExtension(string path)
        {
            if (!path.EndsWith(".dat"))
            {
                var Extansion = new FileExtensionException(path);
                return Extansion.FinalPath;
            }

            return path;
        }
    }
}
