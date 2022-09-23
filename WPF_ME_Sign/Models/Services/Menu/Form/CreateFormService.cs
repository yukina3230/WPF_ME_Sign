using ClosedXML.Report;
using TypeMerger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Repositories.Menu.Form;
using System.IO;
using System.Windows;

namespace WPF_ME_Sign.Models.Services.Menu.Form
{
    public class CreateFormService
    {
        private CreateFormRepository _createFormRepository;
        private FormModel _form;

        public CreateFormService()
        {
            _createFormRepository = new CreateFormRepository();
        }

        public CreateFormService(FormModel form)
        {
            _createFormRepository = new CreateFormRepository();
            _form = form;
        }

        public bool Create()
        {
            try
            {
                _createFormRepository.CreateNewForm(_form);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        public ObservableCollection<DeptModel> LoadDeptList() => _createFormRepository.LoadDeptList();

        public void Report(FormModel form)
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
    }
}
