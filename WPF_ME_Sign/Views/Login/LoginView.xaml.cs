using System;
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
using Wpf.Ui.Controls;
using WPF_ME_Sign.ViewModels.Login;

namespace WPF_ME_Sign.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginViewModel _viewModel;
        public LoginView()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
        }

        private void passwordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Password = passwordBox.Password;
        }
    }
}
