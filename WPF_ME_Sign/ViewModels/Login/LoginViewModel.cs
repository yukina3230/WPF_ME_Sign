using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Services.Login;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel
    {
        private LoginService _loginService;

        public LoginViewModel()
        {
            _loginService = new LoginService();
            LoginCommand = new RelayCommand<Window>(o => LoginExecute(o), o => true);
        }
    }
}
