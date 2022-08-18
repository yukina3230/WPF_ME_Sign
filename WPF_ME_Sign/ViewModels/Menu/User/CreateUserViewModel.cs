using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.ViewModels.Menu.User
{
    public partial class CreateUserViewModel
    {
        public CreateUserViewModel()
        {
            CreateUserCommand = new RelayCommand(CreateUserExecute, CreateUserCanExecute);
        }
    }
}
