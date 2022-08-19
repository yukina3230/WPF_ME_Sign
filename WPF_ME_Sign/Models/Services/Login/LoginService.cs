using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Repositories;

namespace WPF_ME_Sign.Models.Services.Login
{
    public class LoginService
    {
        LoginRepository loginRepository;

        public LoginService()
        {
            loginRepository = new LoginRepository();
        }

        public bool Login(string userId, string password) => loginRepository.LoginById(userId, password) == userId ? true : false;
    }
}
