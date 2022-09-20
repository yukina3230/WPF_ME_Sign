using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models;
using ClosedXML.Report;
using System.Diagnostics;

namespace WPF_ME_Sign.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected virtual SignModel GetSignModel(string signId)
        {
            return new SignModel()
            {
                SignId = signId,
                UserId = InfoHelper.UserId,
                SignDate = DateTime.Today.ToString("dd/MM/yyyy")
            };
        }

        protected virtual void Report(FormModel form)
        {
            const string outputFile = @"D:\\Output\report.xlsx";

            using (var template = new XLTemplate(FileHelper.GetTemplatePath("ReportTemplate")))
            {
                template.AddVariable(form);
                template.Generate();

                template.SaveAs(outputFile);
            }

            Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true });
        }

        protected virtual void Report(SignPreviewModel form)
        {
            const string outputFile = @"D:\\Output\report.xlsx";

            using (var template = new XLTemplate(FileHelper.GetTemplatePath("ReportSignTemplate")))
            {
                template.AddVariable(form);
                template.Generate();

                template.SaveAs(outputFile);
            }

            Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true });
        }
    }
}
