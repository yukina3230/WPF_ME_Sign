using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Repositories.Login;

namespace WPF_ME_Sign.Models.Services.Login
{
    public class LoginService
    {
        private LoginRepository _loginRepository;

        public LoginService()
        {
            _loginRepository = new LoginRepository();
        }

        public bool Login(string userId, string password) => _loginRepository.LoginById(userId, password) == userId ? true : false;

        public void InsertGlobalInfo(string userId)
        {
            InfoHelper.UserId = userId;
            InfoHelper.UserName = _loginRepository.GetUserNamebyId(userId);
            InfoHelper.RoleId = _loginRepository.GetRoleIdbyId(userId);
        }
    }
}
