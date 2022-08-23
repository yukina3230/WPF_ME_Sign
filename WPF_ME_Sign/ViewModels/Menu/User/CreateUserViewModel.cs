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
        CreateUserService _createUserService;

        public CreateUserViewModel()
        {
            _CreateDate = DateTime.Now.Date;

            _createUserService = new CreateUserService();
            UserBinding = new UserModel();
            DeptList = _createUserService.LoadDeptList();
            RoleList = _createUserService.LoadRoleList();
            UserList = _createUserService.LoadUserList();

            CreateUserCommand = new RelayCommand(CreateUserExecute, () => true);
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
            UserId = UserBinding.UserId;
            UserName = UserBinding.UserName;
            Email = UserBinding.Email;
        }
    }
}
