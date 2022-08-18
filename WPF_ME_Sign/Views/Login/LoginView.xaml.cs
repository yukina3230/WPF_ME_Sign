using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_ME_Sign.ViewModels.Login;

namespace WPF_ME_Sign.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        LoginViewModel loginVM;
        public LoginView()
        {
            InitializeComponent();
            loginVM = new LoginViewModel();
            DataContext = loginVM;
        }

        private void passwordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            loginVM.Password = passwordBox.Password;
        }
    }
}
