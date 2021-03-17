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
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string inputfile = Path.Combine(projectDirectory, Constants.filefir, Constants.BDG_Input);

            // File Service
            var serviceProvider = new ServiceCollection().AddSingleton<IFileManager, FileManager>().BuildServiceProvider();


            Console.WriteLine("Starting application....");

            var fileManager = serviceProvider.GetService<IFileManager>();


            Console.WriteLine("Read the file from the file directory");
            var fileContents = fileManager.ReadFileContents(inputfile);

            // check if file exist
            if (File.Exists(inputfile))
            {
                Console.WriteLine("Convert file json data");
                var jsonData = fileManager.JsonConverter(fileContents);

                Console.WriteLine("Create json file");
                fileManager.WriteFileContents(jsonData);
            }
            else
            {
                Console.WriteLine("File does not exist ... ");
            }

            // exit
            Console.WriteLine("Press any key to stop -- exit ...");
            Console.ReadKey();
        }
    }
}
