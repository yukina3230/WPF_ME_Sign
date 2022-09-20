using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Main;

namespace WPF_ME_Sign.ViewModels.Main
{
    public partial class MainViewModel : BaseViewModel
    {
        private MainService _mainService;
        public MainViewModel()
        {
            _mainService = new MainService();
            Priority = _mainService.GetPriority(InfoHelper.RoleId);

            MenuCreateFormCommand = new RelayCommand<object>(o => MenuCreateFormExecute(), o => true);
            MenuQuerySignCommand = new RelayCommand<object>(o => MenuQuerySignExecute(), o => true);
            MenuSendEmailCommand = new RelayCommand<object>(o => MenuSendEmailExecute(), o => true);
            MenuCreateUserCommand = new RelayCommand<object>(o => MenuCreateUserExecute(), o => true);
            MenuChangePasswordCommand = new RelayCommand<object>(o => MenuChangePasswordExecute(), o => true);
        }
    }
}
