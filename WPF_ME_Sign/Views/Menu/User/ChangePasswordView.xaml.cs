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
using Wpf.Ui.Mvvm.Interfaces;
using WPF_ME_Sign.ViewModels.Menu.User;

namespace WPF_ME_Sign.Views.Menu.User
{
    /// <summary>
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : Window
    {
        private CreateUserViewModel _viewModel;
        public ChangePasswordView()
        {
            InitializeComponent();
            _viewModel = new CreateUserViewModel();
            DataContext = _viewModel;
        }

        private void pwbCurrentPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.CurrentPassword = pwbCurrentPassword.Password;
        }

        private void pwbNewPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.NewPassword = pwbNewPassword.Password;
        }

        private void pwbRetypeNewPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.RetypeNewPassword = pwbRetypeNewPassword.Password;
        }
    }
}
