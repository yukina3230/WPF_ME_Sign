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
        CreateUserService _createUserService;

        public CreateUserViewModel()
        {
            _createUserService = new CreateUserService();
            DeptList = _createUserService.LoadDeptList();

            CreateUserCommand = new RelayCommand(CreateUserExecute, CreateUserCanExecute);
        }
    }
}
