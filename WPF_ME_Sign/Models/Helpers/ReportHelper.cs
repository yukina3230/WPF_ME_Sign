using ClosedXML.Report;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models.Helpers
{
    public static class ReportHelper
    {
        public static void Report(FormModel form)
        {
            const string outputFile = @"D:\\Output\report.xlsx";

            using (var template = new XLTemplate(FileHelper.GetTemplatePath("ReportTemplate")))
            {
                template.AddVariable(form);
                template.Generate();

                template.SaveAs(outputFile);
            }

            Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true }).Dispose();
        }

        public static void Report(SignPreviewModel form)
        {
            string outputFile = $"{Path.GetTempPath}\\report.xlsx";

            using (var template = new XLTemplate(FileHelper.GetTemplatePath("ReportSignTemplate")))
            {
                template.AddVariable(form);
                template.Generate();

                template.SaveAs(outputFile);
            }

            Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true }).Dispose();
        }

        public static string CopyImageToServer(string signId, string filePath, string destination)
        {
            string date = DateTime.Today.Date.ToString("ddMMyyyy");
            string destinationFile = $"{FileHelper.ImageServerPath}\\{date}\\{signId}\\";
            try
            {
                if (destination == "D")
                {
                    Directory.CreateDirectory($"{destinationFile}\\Describe\\");
                    destinationFile += $"Describe\\D_{date}_{signId}.jpg";
                    File.Copy(filePath, destinationFile, true);
                    return destinationFile;
                }
                else if (destination == "I")
                {
                    Directory.CreateDirectory($"{destinationFile}\\Improve\\");
                    destinationFile += $"Improve\\I_{date}_{signId}.jpg";
                    File.Copy(filePath, destinationFile, true);
                    return destinationFile;
                }
            }
            catch (IOException iox)
            {
                throw iox;
            }

            return "";
        }

        public static string CopyTempImage(string sourceFile)
        {
            string destinationFile = FileHelper.GetTempPath(sourceFile);

            if (!File.Exists(destinationFile))
            {
                try
                {
                    File.Copy(sourceFile, destinationFile, true);
                    return sourceFile;
                }
                catch (IOException iox)
                {
                    throw iox;
                }
            }

            return destinationFile;
        }

        public static void ClearTempFolder()
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileHelper.GetTempPath(""));

            foreach (FileInfo file in dInfo.EnumerateFiles())
            {
                file.Delete();
            }
        }
    }
}
