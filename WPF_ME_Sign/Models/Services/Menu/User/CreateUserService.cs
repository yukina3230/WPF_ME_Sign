using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Repositories.Menu.User;

namespace WPF_ME_Sign.Models.Services.Menu.User
{
    public class CreateUserService
    {
        private CreateUserRepository _createUserRepository;
        private UserModel _user;

        public CreateUserService()
        {
            _createUserRepository = new CreateUserRepository();
        }

        public CreateUserService(string userId, string password, string userName, string deptId, string email, string roleId, DateTime _createDate)
        {
            _createUserRepository = new CreateUserRepository();
            _user = new UserModel()
            {
                UserId = userId,
                Password = EncodeHelper.EncodeString(password),
                UserName = userName,
                DeptId = deptId,
                Email = email,
                RoleName = roleId,
                CreateDate = _createDate.Date.ToString("ddMMyyyy")
            };
        }

        public bool Create() => _createUserRepository.AddNewUser(_user);

        public bool Delete(string userId) => _createUserRepository.SuspendUser(userId);

        public bool Edit(string Password, string UserName, string Email, string DeptId, string RoleId, DateTime CreateDate, string Me_UserId) => _createUserRepository.EditUser(Password, UserName, Email, DeptId, RoleId, CreateDate, Me_UserId);

        public ObservableCollection<DeptModel> LoadDeptList() => _createUserRepository.LoadDeptList();
        public ObservableCollection<RoleModel> LoadRoleList() => _createUserRepository.LoadRoleList();
        public ObservableCollection<UserModel> LoadUserList() => _createUserRepository.LoadUserList();

        
    }
}
