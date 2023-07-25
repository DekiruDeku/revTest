using System;

namespace TestTask.Task.Exception
{
    public class FileExtensionException : System.Exception
    {
        public FileExtensionException(string path)
            : base("Ошибка формата файла.")
        {
            var fin = RemakePath(path);
            FinalPath = fin;
        }
        
        public string FinalPath { get; private set; }
        public string RemakePath(string Path)
        {
            bool check = false;
            string final = String.Empty;
            while (check == false)
            {
                Console.WriteLine("Вы не правильно ввели путь, попробуйте еще раз(без кавычек)");
                var inputfile = System.Console.ReadLine();
                if (inputfile.EndsWith(".dat"))
                {
                    final = inputfile;    
                    break;
                }
            }
            return final;
        }
    }
}