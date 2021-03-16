using System;
using System.Collections.Generic;
using System.Text;
using Task_01.Model;

namespace Task_01.FileManagerService
{
    interface IFileManager
    {
        public List<User> ReadFileContents(string dir);
        public string JsonConverter(List<User> users);
        public void WriteFileContents(string data);

    }
}
