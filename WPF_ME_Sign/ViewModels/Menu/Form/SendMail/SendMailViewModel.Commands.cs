using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.Form;
using Path = System.IO.Path;

namespace WPF_ME_Sign.ViewModels.Menu.Form.SendMail
{
    public partial class SendMailViewModel
    {
        private OpenFileDialog _fileDialog;
        private SendMailService _sendMailService;

        public RelayCommand AddFileCommand { get; }
        public RelayCommand<object> OpenFileCommand { get; }
        public RelayCommand<object> RemoveFileCommand { get; }
        public RelayCommand SendMailCommand { get; }

        private void AddFileExecute()
        {
            if ((bool)_fileDialog.ShowDialog())
            {
                foreach (string str in _fileDialog.FileNames)
                {
                    if (FileList.FirstOrDefault(x => x.FileName == str) == null && _sendMailService.FileSizeLimit(str))
                    {
                        FileList.Add(new FileModel { FileName = str, FileSize = FileHelper.GetFileSize(str) });
                    }
                }
            }
        }

        private void OpenFileExecute(object o)
        {
            FileModel fileModel = o as FileModel;
            _sendMailService.OpenFile(fileModel.FileName);
        }

        private void RemoveFileExecute(object o)
        {
            FileList.Remove((FileModel)o);
        }

        private void SendMailExecute()
        {
            if (ValidateHelper.DetectFieldEmpty(Title, Content))
            {
                if (_sendMailService.SentToMail(GetMailModel()))
                {
                    MessageBox.Show("Success!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }
    }
}
