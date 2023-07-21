using System.IO;

namespace TestTask.Task
{
    
    public class OriginalFile : IFile,IOriginalFile
    {
       
        public OriginalFile(string path,string nameOfFile)
        {
        
           
            if (nameOfFile.Substring(path.Length-3) != "dat")
            {
                
            }

            
            Path = path;
            TitleOfFile = nameOfFile;
            
            FullPath = path + nameOfFile;
            
        }
        
       
        public string Path { get; private set; }
       
        public string TitleOfFile { get; private set; }
        
       
        public string FullPath { get; private set; }
        
        
        
        public void MakeANewPathOfFile(string path)
        {
            
            Path = path;
            
            FullPath = Path + TitleOfFile;
            
        }
        
        
        public void MakeANewTitleOfFile(string title)
        {
            if (title.Substring(title.Length - 3) != "dat")
            {
                
            }

            TitleOfFile = title;
            
            FullPath = Path + TitleOfFile;
            
        }

        
        public byte[] ReadFile()
        {
            throw new System.NotImplementedException();
        }
    }
}