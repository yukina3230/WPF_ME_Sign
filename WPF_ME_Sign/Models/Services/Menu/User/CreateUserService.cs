using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Repositories.Menu.User;

namespace WPF_ME_Sign.Models.Services.Menu.User
{
    public class CreateUserService
    {
        private CreateUserRepository _createaUserRepository;
        private UserModel _user;

        public CreateUserService()
        {
            _createaUserRepository = new CreateUserRepository();
        }

        public CreateUserService(string userId, string password, string userName, string deptName, string email, string roleId, DateTime createDate)
        {
            _createaUserRepository = new CreateUserRepository();
            _user = new UserModel()
            {
                UserId = userId,
                Password = password,
                UserName = userName,
                CreateDate = createDate.Date
            };
        }

        public bool Create() => _createaUserRepository.AddNewUser(_user);

        public ObservableCollection<string> LoadDeptList() => _createaUserRepository.LoadDeptList();
    }
}
