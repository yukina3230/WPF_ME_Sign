﻿using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models.Services.Menu.Form;

namespace WPF_ME_Sign.ViewModels.Menu.Form.QuerySign
{
    public partial class QuerySignViewModel
    {
        private QuerySignService _querySignService;

        public RelayCommand<object> PreviewCommand { get; }
        public RelayCommand<object> ExportCommand { get; }
        public RelayCommand<object> SignCommand { get; }

        private void PreviewExectute(object o)
        {
            MessageBox.Show("Show Preview");
        }

        private void ExportExectute(object o)
        {
            MessageBox.Show("Exported");
        }

        private void SignExectute(object o)
        {
            MessageBox.Show("Signed");
        }
    }
}