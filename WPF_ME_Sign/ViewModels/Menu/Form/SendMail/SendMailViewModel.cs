using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Services.Menu.Form;

namespace WPF_ME_Sign.ViewModels.Menu.Form.SendMail
{
    public partial class SendMailViewModel
    {
        public SendMailViewModel()
        {
            _fileDialog = new OpenFileDialog();
            _fileDialog.Multiselect = true;
            _sendMailService = new SendMailService();
            FileList = new ObservableCollection<FileModel>();
            //ToAddress = _sendMailService.GetToAddress();
            ToAddress = new ObservableCollection<string>();
            ToAddress.Add("cherleyallard@gmail.com");
            ToAddress.Add("SPG-IT011@spg-sportsgear.com");

            AddFileCommand = new RelayCommand(AddFileExecute);
            OpenFileCommand = new RelayCommand<object>(o => OpenFileExecute(o), o => true);
            RemoveFileCommand = new RelayCommand<object>(o => RemoveFileExecute(o), o => true);
            SendMailCommand = new RelayCommand(SendMailExecute);
        }

        private MailModel GetMailModel()
        {
            return new MailModel()
            {
                //FromAddress = FromAddress,
                FromAddress = "SPG-IT010@spg-sportsgear.com",
                ToAddress = ToAddress,
                Title = Title,
                Content = Content,
                FileList = FileList
            };
        }
    }
}
