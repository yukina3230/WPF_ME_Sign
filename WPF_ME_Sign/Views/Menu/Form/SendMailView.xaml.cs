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
using Wpf.Ui.Controls;
using WPF_ME_Sign.ViewModels.Menu.Form.SendMail;

namespace WPF_ME_Sign.Views.Menu.Form
{
    /// <summary>
    /// Interaction logic for SendMailView.xaml
    /// </summary>
    public partial class SendMailView : UiWindow
    {
        SendMailViewModel viewModel;
        public SendMailView()
        {
            InitializeComponent();
            viewModel = new SendMailViewModel();
            DataContext = viewModel;
        }
    }
}
