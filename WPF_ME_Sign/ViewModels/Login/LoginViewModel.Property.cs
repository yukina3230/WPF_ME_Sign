using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel : ReactiveObject
    {
        private string _UserId;
        public string UserId { get => _UserId; set { this.RaiseAndSetIfChanged(ref _UserId, value); } }

        private string _Password;
        public string Password { get => _Password; set { this.RaiseAndSetIfChanged(ref _Password, value); } }
    }
}
