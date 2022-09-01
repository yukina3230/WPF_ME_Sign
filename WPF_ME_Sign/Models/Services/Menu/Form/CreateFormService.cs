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

namespace WPF_ME_Sign.Models.Services.Menu.Form
{
    public class CreateFormService
    {
        private CreateFormRepository _createFormRepository;
        private FormModel _form;
        private KPIModel _kpi;
        private SignModel _sign;

        public CreateFormService()
        {
            _createFormRepository = new CreateFormRepository();
        }

        public CreateFormService(FormModel form, KPIModel kpi, SignModel sign)
        {
            _createFormRepository = new CreateFormRepository();
            _form = form;
            _kpi = kpi;
            _sign = sign;
        }

        public bool Create() => _createFormRepository.CreateNewForm(_form, _kpi, _sign);

        public ObservableCollection<DeptModel> LoadDeptList() => _createFormRepository.LoadDeptList();

        public void Report(FormModel form, KPIModel kpi)
        {
            const string outputFile = @"D:\\Output\report.xlsx";

            using (var template = new XLTemplate(FileHelper.GetTemplatePath("ReportTemplate")))
            {
                var values = TypeMerger.TypeMerger.Merge(form, kpi);
                template.AddVariable(values);
                template.Generate();

                template.SaveAs(outputFile);
            }

            Process.Start(new ProcessStartInfo(outputFile) { UseShellExecute = true });
        }
    }
}
