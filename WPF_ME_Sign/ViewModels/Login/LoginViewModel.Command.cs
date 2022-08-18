using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_ME_Sign.Models.Services;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel
    {
        //public ICommand LoginCommand { get; }
        public RelayCommand<object> LoginCommand { get; }

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
        private bool LoginCanExecute() => (UserId != "" && Password != "") ? true : false;
    }
}
