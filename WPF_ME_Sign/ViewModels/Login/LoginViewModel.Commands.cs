using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_ME_Sign.Models.Services.Login;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel
    {
        public RelayCommand LoginCommand { get; }

        private void LoginExecute()
        {
            LoginService loginService = new LoginService();

            if (loginService.Login(UserId, Password))
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Wrong User Id or Password");
            }
        }
        private bool LoginCanExecute() => (!String.IsNullOrEmpty(UserId) && !String.IsNullOrEmpty(Password)) ? true : false;
    }
}
