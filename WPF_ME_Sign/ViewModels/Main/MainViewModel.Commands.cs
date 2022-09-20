using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Views.Menu.Form;
using WPF_ME_Sign.Views.Menu.User;

namespace WPF_ME_Sign.ViewModels.Main
{
    public partial class MainViewModel
    {
        public RelayCommand<object> MenuCreateFormCommand { get; }
        public RelayCommand<object> MenuQuerySignCommand { get; }
        public RelayCommand<object> MenuSendEmailCommand { get; }
        public RelayCommand<object> MenuCreateUserCommand { get; }
        public RelayCommand<object> MenuChangePasswordCommand { get; }

        private void MenuCreateFormExecute()
        {
            CreateFormView view = new CreateFormView();
            view.Show();
        }

        private void MenuQuerySignExecute()
        {
            QuerySignView view = new QuerySignView();
            view.Show();
        }

        private void MenuSendEmailExecute()
        {
            SendMailView view = new SendMailView();
            view.Show();
        }

        private void MenuCreateUserExecute()
        {
            CreateUserView view = new CreateUserView();
            view.Show();
        }

        private void MenuChangePasswordExecute()
        {
        }
    }
}
