using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Task_01.FileManagerService;
using Task_01.Utils;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // file directory
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string dir = Path.Combine(projectDirectory, Constants.filefir, Constants.BDG_Input);

            // File Service
            var serviceProvider = new ServiceCollection().AddSingleton<IFileManager, FileManager>().BuildServiceProvider();


            Console.WriteLine("Starting application....");

            var fileManager = serviceProvider.GetService<IFileManager>();

            Console.WriteLine("Read the file from the file directory");
            var fileContents = fileManager.ReadFileContents(dir);

            Console.WriteLine("Convert file json data");
            var jsonData = fileManager.JsonConverter(fileContents);

            Console.WriteLine("Create json file");
            fileManager.WriteFileContents(jsonData);

            Console.WriteLine("Press any key to stop -- exit ...");
            Console.ReadKey();
        }
    }
}
