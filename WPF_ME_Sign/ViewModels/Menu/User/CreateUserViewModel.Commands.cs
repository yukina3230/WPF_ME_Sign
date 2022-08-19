using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Services.Menu.User;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel
    {
        public RelayCommand CreateUserCommand { get; }



        private void CreateUserExecute()
        {
            CreateUserService _createUserService = new CreateUserService(UserId, Password, UserName, Dept, Email, RoleId, CreateDate);
            _createUserService.Create();
        }

        private bool CreateUserCanExecute()
        {
            if (!String.IsNullOrEmpty(UserId) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Email))
            {
                return true;
            }
            return false;
        }
    }
}
