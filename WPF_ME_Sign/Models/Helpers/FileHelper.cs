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
        public static string ProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static string ImageServerPath = @"\\10.1.0.112\ME_Images\";

        public static string GetSQLString(string sqlFileName)
        {
            string filePath = Path.Combine(ProjectPath, "Models", "Repositories", "SQL", String.Concat(sqlFileName, ".sql"));
            return File.ReadAllText(filePath);
        }

        public static string GetTemplatePath(string templateFileName)
        {
            return Path.Combine(ProjectPath, "Resources", "Templates", String.Concat(templateFileName, ".xlsx"));
        }

        public static string GetTempPath(string tempFilePath)
        {
            return Path.Combine(ProjectPath, "Resources", "Temp", Path.GetFileName(tempFilePath));
        }

        public static string GetFileSize(string filePath)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double size = new FileInfo(filePath).Length;
            int index = 0;
            while (size >= 1024 && index < sizes.Length - 1)
            {
                index++;
                size = size / 1024;
            }

            return String.Format("{0:0.##} {1}", size, sizes[index]);
        }
    }
}
