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
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.Views.Share
{
    /// <summary>
    /// Interaction logic for PreviewSignView.xaml
    /// </summary>
    public partial class PreviewSignView : UiWindow
    {
        public PreviewSignView()
        {
            InitializeComponent();
        }

        public PreviewSignView(FormModel form, SignPreviewModel signPreview)
        {
            InitializeComponent();
        }
    }
}
