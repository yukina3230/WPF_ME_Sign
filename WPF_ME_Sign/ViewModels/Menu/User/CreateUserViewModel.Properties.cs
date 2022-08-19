using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel : ObservableObject
    {
        private string _UserId;
        public string UserId { get => _UserId; set { _UserId = value; OnPropertyChanged(); CreateUserCommand.NotifyCanExecuteChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); CreateUserCommand.NotifyCanExecuteChanged(); } }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); CreateUserCommand.NotifyCanExecuteChanged(); } }

        private string _Dept;
        public string Dept { get => _Dept; set { _Dept = value; OnPropertyChanged(); CreateUserCommand.NotifyCanExecuteChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); CreateUserCommand.NotifyCanExecuteChanged(); } }

        private string _RoleId;
        public string RoleId { get => _RoleId; set { _RoleId = value; OnPropertyChanged(); CreateUserCommand.NotifyCanExecuteChanged(); } }

        private DateTime _CreateDate;

        private ObservableCollection<string> _DeptList;
        public ObservableCollection<string> DeptList { get => _DeptList; set { _DeptList = value; OnPropertyChanged(); } }
    }
}
