using System;
using TestTask.Task;

namespace TestTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SomeFile file = new SomeFile();
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine(
                    "Приветствую! В этом приложении получает на вход бинарный файл произвольного размера " +
                    "и в качестве результата создает новый файл");
                System.Console.WriteLine();
                System.Console.WriteLine("Укажите путь и имя файла с которого будем считывать данные");
                var inputfile = System.Console.ReadLine();
                System.Console.WriteLine("Укажите путь и имя файла в который будет записаны данные");
                var outputfile = System.Console.ReadLine();
                var buffer = file.ReadFileInBytes(@inputfile);
                byte[] inversebytes = new byte[buffer.Result.Length];
                var cursorForCicle = inversebytes.Length-1;
                // сам перенос файла работает надо сделать нормальный реверс, возможно все таки через BINAryreader уже 24 посмотрю
                for (int i = 0; i < buffer.Result.Length; i++)
                {
                    inversebytes[i] = buffer.Result[cursorForCicle];
                    cursorForCicle--;
                }
                file.MakeOrUpdateBytesInFile(inversebytes, @outputfile);
                System.Console.ReadLine();
                break;
            }
        }
    }
}