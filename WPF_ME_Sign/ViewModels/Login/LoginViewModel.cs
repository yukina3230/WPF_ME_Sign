using ReactiveUI;
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
            var _loginCanExecute = this.WhenAnyValue(x => x.UserId, (userId) => !string.IsNullOrEmpty(userId));
            LoginCommand = ReactiveCommand.Create(LoginExecute, _loginCanExecute);
        }
    }
}
