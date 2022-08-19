using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Views.Menu.User;

namespace WPF_ME_Sign.ViewModels
{
    public partial class MainViewModel
    {
        public RelayCommand<object> MenuCreateUserCommand { get; }

        private void MenuCreateUserExecute()
        {
            CreateUserView view = new CreateUserView();
            view.Show();
        }
        private bool MenuCreateUserCanExecute() => true;
    }
}
