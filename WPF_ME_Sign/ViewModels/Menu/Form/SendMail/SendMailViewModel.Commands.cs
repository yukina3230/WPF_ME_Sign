﻿using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                    if (!FileList.Contains(str))
                    {
                        FileList.Add(str);
                    }
                }
            }
        }

        private void OpenFileExecute(object o)
        {
            _sendMailService.OpenFile(o.ToString());
        }

        private void RemoveFileExecute(object o)
        {
            FileList.Remove(o.ToString());
        }

        private void SendMailExecute()
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
