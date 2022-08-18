using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Login
{
    public partial class LoginViewModel : ObservableObject
    {
        private string _UserId;
        public string UserId { get => _UserId; set { _UserId = value; OnPropertyChanged(); LoginCommand.NotifyCanExecuteChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); LoginCommand.NotifyCanExecuteChanged(); } }
    }
}
