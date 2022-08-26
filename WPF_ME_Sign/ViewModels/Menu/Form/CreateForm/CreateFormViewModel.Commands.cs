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

        public RelayCommand CreateFormCommand { get; }
        public RelayCommand AddDescribePictureCommand { get; }
        public RelayCommand AddImprovePictureCommand { get; }

        private void CreateFormExecute()
        {
            if (DetectFieldEmpty())
            {
                _createFormService = new CreateFormService(GetFormValues(), GetKPIValues(), GetSignValues());
                if (_createFormService.Create())
                {
                    MessageBox.Show("Success");
                }
                else MessageBox.Show("Fail");
            }
            else MessageBox.Show("One or some fields are not filled");
        }

        private void AddDescribePath()
        {
            if ((bool)_fileDialog.ShowDialog())
            {
                DesctibePicturePath = _fileDialog.FileName;
            }
        }

        private void AddImprovePath()
        {
            if ((bool)_fileDialog.ShowDialog())
            {
                ImprovePicturePath = _fileDialog.FileName;
            }
        }
    }
}
