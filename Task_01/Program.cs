using Microsoft.Extensions.DependencyInjection;
using System;
using Task_01.FileManagerService;


namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = @"D:\\Projects\\Learning\\Programming\\Tasks\\Task_01\\file\\BDG_Input.txt";
            var serviceProvider = new ServiceCollection().AddSingleton<IFileManager, FileManager>().BuildServiceProvider();


            Console.WriteLine("Starting application....");

            var fileManager = serviceProvider.GetService<IFileManager>();

            Console.WriteLine("Read the file from the directory");
            var fileContents = fileManager.ReadFileContents(dir);

            Console.WriteLine("Convert the file into json data");
            var jsonData = fileManager.JsonConverter(fileContents);

            Console.WriteLine("Create new json file with the data");
            fileManager.WriteFileContents(jsonData);

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
