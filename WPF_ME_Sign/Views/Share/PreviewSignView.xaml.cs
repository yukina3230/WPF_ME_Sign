using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.ViewModels.Share.PreviewSign;

namespace WPF_ME_Sign.Views.Share
{
    /// <summary>
    /// Interaction logic for PreviewSignView.xaml
    /// </summary>
    public partial class PreviewSignView : UiWindow
    {
        private PreviewSignViewModel _previewSignViewModel;

        public PreviewSignView()
        {
            InitializeComponent();
        }

        public PreviewSignView(string signId)
        {
            InitializeComponent();
            _previewSignViewModel = new PreviewSignViewModel(signId);
            DataContext = _previewSignViewModel;

            imgD.Source = ReportHelper.GetImage(_previewSignViewModel.SignPreview.DesctibePicturePath);
            imgI.Source = ReportHelper.GetImage(_previewSignViewModel.SignPreview.ImprovePicturePath);
        }
    }
}
