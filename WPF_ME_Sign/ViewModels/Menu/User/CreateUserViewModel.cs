using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
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
            DeptList = _createUserService.LoadDeptList();
            RoleList = _createUserService.LoadRoleList();
            UserList = _createUserService.LoadUserList();

            CreateUserCommand = new RelayCommand(CreateUserExecute, () => true);
        }

        public bool DetectFieldEmpty()
        {
            if (!String.IsNullOrEmpty(UserId) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(DeptName) && !String.IsNullOrEmpty(RoleName))
            {
                return true;
            }
            return false;
        }
    }
}
