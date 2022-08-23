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

        private bool DetectFieldEmpty()
        {
            if (!String.IsNullOrEmpty(UserBinding.UserId) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(UserBinding.UserName) && !String.IsNullOrEmpty(UserBinding.Email) && !String.IsNullOrEmpty(DeptId) && !String.IsNullOrEmpty(RoleId))
            {
                return true;
            }
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
            return DeptList.First(item => item.DeptId == deptId).DeptName;
        }

        private string GetRoleNameById(string roleId)
        {
            return RoleList.First(item => item.RoleId == roleId).RoleName;
        }
    }
}
