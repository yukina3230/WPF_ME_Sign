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
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.ViewModels.Menu.Form.CreateForm;

namespace WPF_ME_Sign.Views.Menu.Form
{
    /// <summary>
    /// Interaction logic for CreateFormView.xaml
    /// </summary>
    public partial class CreateFormView : UiWindow
    {
        private CreateFormViewModel _viewModel;
        public CreateFormView()
        {
            InitializeComponent();
            _viewModel = new CreateFormViewModel();
            DataContext = _viewModel;
        }

        private void btnImageD_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddDescribePath();
            imgD.Source = ReportHelper.GetImage(_viewModel.DesctibePicturePath);
        }

        private void btnImageI_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddImprovePath();
            imgI.Source = ReportHelper.GetImage(_viewModel.ImprovePicturePath);
        }
    }
}
