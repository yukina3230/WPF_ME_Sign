using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.User;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel
    {
        public RelayCommand CreateUserCommand { get; }
        public RelayCommand DeleteUserCommand { get; }

        public RelayCommand CleanCommand { get; }

        private void CreateUserExecute()
        {
            if (ValidateHelper.DetectFieldEmpty(UserBinding.UserId, Password, UserBinding.UserName, DeptId, UserBinding.Email, RoleId))
            {
                _createUserService = new CreateUserService(UserBinding.UserId, Password, UserBinding.UserName, DeptId, UserBinding.Email, RoleId, _CreateDate);
                if (_createUserService.Create())
                {
                    MessageBox.Show("Success");
                    UserList.Add
                    (
                        new UserModel()
                        {
                            UserId = UserBinding.UserId,
                            UserName = UserBinding.UserName,
                            DeptName = GetDeptNameById(DeptId),
                            Email = UserBinding.Email,
                            RoleName = GetRoleNameById(RoleId),
                            CreateDate = _CreateDate.ToString("dd/MM/yyyy"),
                            Status = "A"
                        }
                    );
                }
                else MessageBox.Show("Something Wrong!");
            }
            else MessageBox.Show("One or some fields are not filled");
        }

        private void DeleteUserExecute()
        {
            if (DetectUserIdExist(UserBinding.UserId))
            {
                if (_createUserService.Delete(UserBinding.UserId))
                {
                    MessageBox.Show("Success");
                    var item = UserList.Single(x => x.UserId == UserBinding.UserId);
                    UserList.Remove(item);
                }
                else MessageBox.Show("Something Wrong!");

            }
        }

        private void CleanExecute()
        {
            UserId = "";
            Password = "";
            UserName = "";
            Email = "";
        }
    }
}
