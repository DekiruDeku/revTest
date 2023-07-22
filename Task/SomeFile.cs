using System.IO;
using System.Text;

namespace TestTask.Task
{
    
    public class SomeFile : IFile,IOriginalFile,IReverseFile
    {
       
        public SomeFile(string path)
        {
            CheckForFileExtension(@path);
            Path = @path;
            FindAPathWithoutNameOfFileAndNameOfFile();
        }
        
       
        public string Path { get; private set; }
        
        public string PathWithoutNameOfFile { get; private set; }
        
        public string NameOfFile { get; private set; }
        
        
        
        public void MakeANewPathOfFile(string path)
        {
            PathWithoutNameOfFile = path;
        }
        
        
        public void MakeANewNameOfFile(string name)
        {
            CheckForFileExtension(name);

            NameOfFile = name;

        }

        public void FindAPathWithoutNameOfFileAndNameOfFile()
        {
            for (int i = Path.Length - 1; i >= 0; i--)
            {
                if (Path[i] == '\\')
                {
                    string pathWithoutName = Path.Substring(0, i);
                    PathWithoutNameOfFile = pathWithoutName;
                    string nameOfFile = Path.Substring(i + 1, Path.Length - 1);
                    NameOfFile = nameOfFile;
                }
            }
        }


        public byte[] ReadFileInBytes()
        {
            using (FileStream fstream = new FileStream(Path, FileMode.Open)) 
            {
                byte[] buffer = new byte[fstream.Length]; 
                /*await не хочет здесь работать в main добавить Wait*/ fstream.ReadAsync(buffer, 0, buffer.Length);
                return buffer;
            }
            
        }

        public void CheckForFileExtension(string path)
        {
            if (!path.EndsWith(".dat"))
            {
                
            }
        }

        public void UpdateBytesInFile(byte[] subsequence)
        {
            throw new System.NotImplementedException();
        }
    }
}