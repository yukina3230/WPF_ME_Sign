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
        public RelayCommand EditUserCommand { get; }
        public RelayCommand DeleteUserCommand { get; }
        public RelayCommand CleanCommand { get; }
        public RelayCommand ChangePasswordCommand { get; }

        private void CreateUserExecute()
        {
            if (ValidateHelper.DetectFieldEmpty(UserId, Password, UserName, DeptId, Email, RoleId))
            {
                if (DetectEmailValid(Email))
                {
                    _createUserService = new CreateUserService(UserId, Password, UserName, DeptId, Email, RoleId, _CreateDate);
                    if (_createUserService.Create())
                    {
                        MessageBox.Show("Success");
                        UserList.Add
                        (
                            new UserModel()
                            {
                                UserId = UserId,
                                UserName = UserName,
                                DeptName = GetDeptNameById(DeptId),
                                Email = Email,
                                RoleName = GetRoleNameById(RoleId),
                                CreateDate = _CreateDate.ToString("dd/MM/yyyy"),
                                Status = "A"
                            }
                        );
                    }
                    else MessageBox.Show("Something Wrong!");
                }
            }
        }

        public void EditUser()
        {
            if (_createUserService.Edit(Password, UserName, Email, DeptId, RoleId, _CreateDate, MeUserId))
            {
                MessageBox.Show("Edit Success");
                UpdateUserList(UserId);
                UserFilterList.Refresh();
            }
            else MessageBox.Show("Something Wrong!");
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

        private void ChangePasswordExecute()
        {
            if (!ValidateHelper.DetectFieldEmpty(CurrentPassword, NewPassword, RetypeNewPassword)) return;
            if (EncodeHelper.EncodeString(CurrentPassword) != InfoHelper.EncodedPassword) { MessageBox.Show("The current password is incorrect"); return; }
            if (NewPassword != RetypeNewPassword) { MessageBox.Show("Retype password does not match"); return; }
            if (EncodeHelper.EncodeString(NewPassword) == InfoHelper.EncodedPassword) { MessageBox.Show("Try a different password"); return; }

            if (_createUserService.UpdatePassword(InfoHelper.UserId, NewPassword))
            {
                MessageBox.Show($"Done");
            }
            else
            {
                MessageBox.Show($"Fail");
            }
        }
    }
}
