using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.ViewModels
{
    public partial class MainViewModel
    {
        public MainViewModel()
        {
            MenuCreateUserCommand = new RelayCommand<object>(o => MenuCreateUserExecute(), o => MenuCreateUserCanExecute());
        }
    }
}
