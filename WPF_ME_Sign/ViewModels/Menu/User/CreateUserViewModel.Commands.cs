using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models.Services.Menu.User;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel
    {
        public RelayCommand CreateUserCommand { get; }

        private void CreateUserExecute()
        {
            _createUserService = new CreateUserService(UserId, Password, UserName, Dept, Email, RoleId, _CreateDate);
            if (_createUserService.Create()) MessageBox.Show("Success"); else MessageBox.Show("Something Wrong!");
        }

        private bool CreateUserCanExecute()
        {
            bool canExecute =
                !String.IsNullOrEmpty(UserId) && !String.IsNullOrEmpty(Password)
                && !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Dept)
                && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(RoleId);
            if (canExecute)
            {
                return true;
            }
            return false;
        }
    }
}
