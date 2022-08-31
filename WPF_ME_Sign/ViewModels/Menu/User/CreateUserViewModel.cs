using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml.Linq;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.User;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel
    {
        CreateUserService _createUserService;

        public CreateUserViewModel()
        {
            _CreateDate = DateTime.Now.Date;

            _createUserService = new CreateUserService();
            UserBinding = new UserModel();
            DeptList = _createUserService.LoadDeptList();
            RoleList = _createUserService.LoadRoleList();
            UserList = _createUserService.LoadUserList();
            UserFilterList = CollectionViewSource.GetDefaultView(UserList);
            UserFilterList.Filter = new Predicate<object>(Filter);
            UserIdList = new ObservableCollection<string>(UserList.Select(x => x.UserId));

            CreateUserCommand = new RelayCommand(CreateUserExecute, () => true);
            EditUserCommand = new RelayCommand(EditUser, () => true);
            DeleteUserCommand = new RelayCommand(DeleteUserExecute, () => true);
            CleanCommand = new RelayCommand(CleanExecute, () => true);
        }

        private bool DetectUserIdExist(string userId)
        {
            if (!String.IsNullOrEmpty(userId))
            {
                if (UserList.SingleOrDefault(x => x.UserId == userId) != null)
                {
                    return true;
                }
            }
            MessageBox.Show("User Id does not exist");
            return false;
        }

        private bool DetectEmailValid(string email)
        {
            if (Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                return true;
            }
            MessageBox.Show("Email is invalid");
            return false;
        }

        private void ClearField()
        {
            UserId = "";
            Password = "";
            UserName = "";
            Email = "";
        }

        private string GetDeptNameById(string deptId)
        {
            return DeptList.SingleOrDefault(x => x.DeptId == deptId).DeptName;
        }

        private string GetRoleNameById(string roleId)
        {
            return RoleList.SingleOrDefault(x => x.RoleId == roleId).RoleName;
        }

        private void BindTextBox()
        {
            if (UserBinding != null)
            {
                MeUserId = UserBinding.MeUserId;
                UserId = UserBinding.UserId;
                UserName = UserBinding.UserName;
                Email = UserBinding.Email;
                Password = UserBinding.Password;
                DeptId = UserBinding.DeptId;
                RoleId = UserBinding.RoleId;
            }
        }

        private void UpdateUserList(string userId)
        {
            var user = UserList.SingleOrDefault(x => x.UserId == userId);
            user.MeUserId = MeUserId;
            user.UserName = UserName;
            user.Email = Email;
            user.Password = EncodeHelper.EncodeString(Password);
            user.DeptId = DeptId;
            user.DeptName = DeptList.SingleOrDefault(x => x.DeptId == DeptId).DeptName;
            user.RoleId = RoleId;
            user.RoleName = RoleList.SingleOrDefault(x => x.RoleId == RoleId).RoleName;
        }

        private void FilterCollection()
        {
            if (UserFilterList != null) UserFilterList.Refresh();
        }

        public bool Filter(object o)
        {
            var user = o as UserModel;
            if (user != null)
            {
                if (!string.IsNullOrEmpty(FilterString))
                {
                    return user.UserId.Contains(FilterString) || user.UserName.Contains(FilterString);
                }
                return true;
            }
            return false;
        }
    }
}
