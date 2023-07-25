using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestTask.Task;
using TestTask.Task.Exception;

namespace TestTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SomeFile file = new SomeFile();
            char quotes = '"';
            bool checker = true;
            while (checker)
            {
                System.Console.Clear();
                System.Console.WriteLine(
                    "Приветствую! В этом приложении получает на вход бинарный файл произвольного размера " +
                    "и в качестве результата создает новый файл");
                System.Console.WriteLine();
                Console.WriteLine("Выберите для вас удобный вариант:\n"+
                                  "1.Из текущей директории(bin папка компилятора)\n"+
                                  "2.Из выбраного пути\n" +
                                  "3.Указать полный путь\n" +
                                  "Или другую цифру чтобы выйти");
                var choose = System.Console.ReadLine();
                switch (Convert.ToInt32(choose))
                {
                    case 1:
                        string currentDirectory = Directory.GetCurrentDirectory();
                        Console.WriteLine("Укажите имя файла с которого будем считывать данные, в случае ошибки придется указывать полный путь");
                        var inputnameInCase1 = Console.ReadLine();
                        inputnameInCase1 = inputnameInCase1.Replace(quotes.ToString(), String.Empty);
                        file.CheckForRightName(ref inputnameInCase1);
                        
                        Task<Stack<byte>> bufferforCase1 = file.ReadFileInBytes(currentDirectory+"\\"+@inputnameInCase1);
                        Stack<byte> inversebytesForCase1 = bufferforCase1.Result;
                        
                        Console.WriteLine("Укажите имя файла в который будем записывать данные, в случае ошибки придется указывать полный путь");
                        var outputnameInCase1 = Console.ReadLine();
                        outputnameInCase1 = outputnameInCase1.Replace(quotes.ToString(), String.Empty);
                        file.CheckForRightName(ref outputnameInCase1);
                        file.MakeOrUpdateBytesInFile(inversebytesForCase1, currentDirectory+"\\"+@outputnameInCase1);
                        
                        Console.ReadLine();
                        break;
                    case 2:
                        
                        Console.WriteLine("Укажите путь к катологу без расширения, не забудьте в конце указать \\");
                        string inputDirectory = Console.ReadLine();
                        inputDirectory = inputDirectory.Replace(quotes.ToString(), String.Empty);
                        if (!inputDirectory.EndsWith("\\"))
                            inputDirectory += "\\";
                        
                        Console.WriteLine("Укажите имя файла с которого будем считывать данные, в случае ошибки придется указывать полный путь(оно не должно содержать \\)");
                        var inputnameInCase2 = Console.ReadLine();
                        inputnameInCase2 = inputnameInCase2.Replace(quotes.ToString(), String.Empty);
                        file.CheckForRightName(ref inputnameInCase2);
                        Task<Stack<byte>> bufferforCase2 = file.ReadFileInBytes(inputDirectory+@inputnameInCase2);
                        Stack<byte> inversebytesForCase2 = bufferforCase2.Result;
                        
                        Console.WriteLine("Укажите имя файла в который будем записывать данные(оно не должно содержать \\)");
                        var outputnameInCase2 = Console.ReadLine();
                        outputnameInCase2 = outputnameInCase2.Replace(quotes.ToString(), String.Empty);
                        file.CheckForRightName(ref outputnameInCase2);
                        file.MakeOrUpdateBytesInFile(inversebytesForCase2, inputDirectory+@outputnameInCase2);
                        
                        Console.ReadLine();
                        break;
                    case 3:
                        
                        Console.WriteLine("Укажите путь и имя файла с которого будем считывать данные");
                        var inputfileForCase3 = System.Console.ReadLine();
                        inputfileForCase3 = inputfileForCase3.Replace(quotes.ToString(), String.Empty);
                        Task<Stack<byte>> bufferForCase3 = file.ReadFileInBytes(@inputfileForCase3);
                        Stack<byte> inversebytesForCase3 = bufferForCase3.Result;
                        
                        Console.WriteLine("Укажите путь и имя файла в который будет записаны данные");
                        var outputfileForCase3 = System.Console.ReadLine();
                        outputfileForCase3 = outputfileForCase3.Replace(quotes.ToString(), String.Empty);
                        file.MakeOrUpdateBytesInFile(inversebytesForCase3, @outputfileForCase3);
                        
                        Console.ReadLine();
                        break;
                    
                    default:
                        Console.WriteLine("Удачи!");
                        checker = false;
                        break;
                }
            }
        }
    }
}