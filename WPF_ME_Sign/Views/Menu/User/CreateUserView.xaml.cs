﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_ME_Sign.ViewModels.Menu.User;

namespace WPF_ME_Sign.Views.Menu.User
{
    /// <summary>
    /// Interaction logic for CreateUserView.xaml
    /// </summary>
    public partial class CreateUserView : Window
    {
        private CreateUserViewModel _viewModel;
        public CreateUserView()
        {
            InitializeComponent();
            _viewModel = new CreateUserViewModel();
            DataContext = _viewModel;
        }
    }
}
