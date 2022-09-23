using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.Form;

namespace WPF_ME_Sign.ViewModels.Menu.Form.CreateForm
{
    public partial class CreateFormViewModel
    {
        private OpenFileDialog _fileDialog;
        private CreateFormService _createFormService;
        private QuerySignService _querySignService;

        public RelayCommand CreateFormCommand { get; }
        public RelayCommand AddDescribePictureCommand { get; }
        public RelayCommand AddImprovePictureCommand { get; }

        private void CreateFormExecute()
        {
            if (DetectFieldEmpty())
            {
                _createFormService = new CreateFormService(GetFormValues());
                if (_createFormService.Create())
                {
                    _querySignService.Sign(GetSignModel(SignId));
                    MessageBox.Show("Success");
                    ReportHelper.Report(GetFormValues());
                }
                else MessageBox.Show("Fail");
            }
        }

        private void AddDescribePath()
        {
            if ((bool)_fileDialog.ShowDialog())
            {
                using (var stream = _fileDialog.OpenFile())
                {
                    if (_fileDialog.FileName != ImprovePicturePath) DesctibePicturePath = _fileDialog.FileName; DesctibePicturePathTemp = ReportHelper.CopyTempImage(_fileDialog.FileName);
                }
            }
        }

        private void AddImprovePath()
        {
            if ((bool)_fileDialog.ShowDialog())
            {
                using (var stream = _fileDialog.OpenFile())
                {
                    if (_fileDialog.FileName != DesctibePicturePath) ImprovePicturePath = _fileDialog.FileName; ImprovePicturePathTemp = ReportHelper.CopyTempImage(_fileDialog.FileName);
                }
            }
        }
    }
}
