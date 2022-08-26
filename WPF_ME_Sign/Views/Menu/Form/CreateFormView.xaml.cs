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
using WPF_ME_Sign.ViewModels.Menu.Form.CreateForm;

namespace WPF_ME_Sign.Views.Menu.Form
{
    /// <summary>
    /// Interaction logic for CreateFormView.xaml
    /// </summary>
    public partial class CreateFormView : Window
    {
        CreateFormViewModel viewModel;
        public CreateFormView()
        {
            InitializeComponent();
            viewModel = new CreateFormViewModel();
            DataContext = viewModel;
        }
    }
}
