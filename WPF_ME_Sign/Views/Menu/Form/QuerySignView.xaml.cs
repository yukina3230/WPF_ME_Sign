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
using WPF_ME_Sign.ViewModels.Menu.Form.QuerySign;

namespace WPF_ME_Sign.Views.Menu.Form
{
    /// <summary>
    /// Interaction logic for QuerySignView.xaml
    /// </summary>
    public partial class QuerySignView : UiWindow
    {
        QuerySignViewModel viewModel;
        public QuerySignView()
        {
            InitializeComponent();
            viewModel = new QuerySignViewModel();
            DataContext = viewModel;
        }

        private void dpFromDate_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void dpToDate_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
