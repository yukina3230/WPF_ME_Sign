using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Services.Menu.User;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel
    {
        public RelayCommand CreateUserCommand { get; }

        private void CreateUserExecute()
        {
            if (DetectFieldEmpty())
            {
                _createUserService = new CreateUserService(UserId, Password, UserName, DeptId, Email, RoleId, _CreateDate);
                UserList.Clear();
                UserList = _createUserService.LoadUserList();
                if (_createUserService.Create()) MessageBox.Show("Success"); else MessageBox.Show("Something Wrong!");
            }
            else
            {
                MessageBox.Show("One or some fields are not filled");
            }
        }

        private bool CreateUserCanExecute()
        {
            bool canExecute =
                !String.IsNullOrEmpty(UserId) && !String.IsNullOrEmpty(Password)
                && !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(DeptId)
                && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(RoleId);
            if (canExecute)
            {
                return true;
            }
            return false;
        }
    }
}
