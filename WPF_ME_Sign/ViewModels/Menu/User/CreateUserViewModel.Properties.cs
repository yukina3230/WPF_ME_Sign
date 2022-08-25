using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel : ObservableObject
    {
        private string _MeUserId;
        public string MeUserId { get => _MeUserId; set { _MeUserId = value; OnPropertyChanged(); } }

        private string _UserId;
        public string UserId { get => _UserId; set { _UserId = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private DateTime _CreateDate;

        private ObservableCollection<DeptModel> _DeptList;
        public ObservableCollection<DeptModel> DeptList { get => _DeptList; set { _DeptList = value; OnPropertyChanged(); } }

        private string _DeptId;
        public string DeptId { get => _DeptId; set { _DeptId = value; OnPropertyChanged(); } }

        private string _DeptName;
        public string DeptName { get => _DeptName; set { _DeptName = value; OnPropertyChanged(); } }

        private ObservableCollection<RoleModel> _RoleList;
        public ObservableCollection<RoleModel> RoleList { get => _RoleList; set { _RoleList = value; OnPropertyChanged(); } }

        private string _RoleId;
        public string RoleId { get => _RoleId; set { _RoleId = value; OnPropertyChanged(); } }

        private ObservableCollection<UserModel> _UserList;
        public ObservableCollection<UserModel> UserList { get => _UserList; set { _UserList = value; OnPropertyChanged(); } }

        private ICollectionView _UserFilterList;
        public ICollectionView UserFilterList { get => _UserFilterList; private set { _UserFilterList = value; OnPropertyChanged(); } }

        private string _FilterString;
        public string FilterString { get => _FilterString; set { _FilterString = value; OnPropertyChanged(); FilterCollection(); } }

        private ObservableCollection<string> _UserIdList;
        public ObservableCollection<string> UserIdList { get => _UserIdList; set { _UserIdList = value; OnPropertyChanged(); } }

        private UserModel _UserBinding;
        public UserModel UserBinding { get => _UserBinding; set { _UserBinding = value; OnPropertyChanged(); BindTextBox(); } }
    }
}
