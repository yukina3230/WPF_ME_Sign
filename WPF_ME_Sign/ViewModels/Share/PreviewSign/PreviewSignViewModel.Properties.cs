using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Share.PreviewSign
{
    public partial class PreviewSignViewModel : ObservableObject
    {
        private SignPreviewModel _signPreview;
        public SignPreviewModel SignPreview { get => _signPreview; set { _signPreview = value; OnPropertyChanged(); } }
    }
}
