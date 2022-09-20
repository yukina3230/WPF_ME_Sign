using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Login;
using WPF_ME_Sign.Views;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel
    {
        public RelayCommand<Window> LoginCommand { get; }

        private void LoginExecute(Window window)
        {
            if (ValidateHelper.DetectFieldEmpty(UserId, Password))
            {
                if (_loginService.Login(UserId, Password))
                {
                    _loginService.InsertGlobalInfo(UserId);
                    MainView main = new MainView();
                    App.Current.MainWindow = main;
                    window.Close();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Wrong User Id or Password");
                }
            }
        }
    }
}
