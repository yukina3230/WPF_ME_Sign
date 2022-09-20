using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Services.Menu.Form;
using WPF_ME_Sign.Views.Share;

namespace WPF_ME_Sign.ViewModels.Menu.Form.QuerySign
{
    public partial class QuerySignViewModel
    {
        public RelayCommand<object> PreviewCommand { get; }
        public RelayCommand<object> ExportCommand { get; }
        public RelayCommand<object> SignCommand { get; }

        private void PreviewExectute(object o)
        {
            var a = o as SignModel;
            string signId = a.SignId;
            PreviewSignView previewSignView = new PreviewSignView(signId);
            previewSignView.Show();
        }

        private void ExportExectute(object o)
        {
            var a = o as SignModel;
            string signId = a.SignId;
            Report(_previewSignService.GetPreview(signId));
        }

        private void SignExectute(object o)
        {
            var a = o as SignModel;
            SignModel sign = GetSignModel(a.SignId);
            if (_querySignService.Sign(sign))
            {
                MessageBox.Show($"Form {sign.SignId} has been signed");
                UpdateSignStatus(sign.SignId);
            }
            else
            {
                MessageBox.Show("Error encountered");
            }
        }
    }
}
