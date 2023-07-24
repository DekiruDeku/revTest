using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Task
{
    
    public class SomeFile : IFile
    {
        public async Task<byte[]> ReadFileInBytes(string Path)
        {
            CheckForFileExtension(Path);
            using (FileStream fstream = new FileStream(Path, FileMode.Open)) 
            {
                byte[] buffer = new byte[fstream.Length]; 
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                Console.WriteLine("Байты с файла считаны");
                return buffer;
            }
            
        }

        public void CheckForFileExtension(string path)
        {
            if (!path.EndsWith(".dat"))
            {
                throw new Exception();
            }
        }
        

        public async void MakeOrUpdateBytesInFile(byte[] subsequence, string Path)
        {
            using (FileStream fstream = new FileStream(Path, FileMode.OpenOrCreate)) 
            {
                await fstream.WriteAsync(subsequence, 0, subsequence.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }
    }
}