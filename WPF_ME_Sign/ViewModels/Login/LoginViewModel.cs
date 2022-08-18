using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<object>(o => LoginExecute(), o => LoginCanExecute());
        }
    }
}
