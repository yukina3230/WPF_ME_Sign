using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models.Helpers
{
    public static class FileHelper
    {
        static string ProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static string GetSQLString(string sqlFileName)
        {
            string filePath = Path.Combine(ProjectPath, "Models", "Repositories", "SQL", String.Concat(sqlFileName, ".sql"));
            return File.ReadAllText(filePath);
        }
    }
}
