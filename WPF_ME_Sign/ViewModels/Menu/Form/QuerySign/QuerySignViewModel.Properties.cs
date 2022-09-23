using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Menu.Form.QuerySign
{
    public partial class QuerySignViewModel
    {
        private DateTime _FromDate;
        public DateTime FromDate { get => _FromDate; set { _FromDate = value; OnPropertyChanged(); LoadSignList(); } }

        private DateTime _ToDate;
        public DateTime ToDate { get => _ToDate; set { _ToDate = value; OnPropertyChanged(); LoadSignList(); } }

        private bool _SignShow;
        public bool SignShow { get => _SignShow; set { _SignShow = value; OnPropertyChanged(); FilterCollection(); } }

        private bool _UnsignCheck;
        public bool UnsignCheck { get => _UnsignCheck; set { _UnsignCheck = value; OnPropertyChanged(); FilterCollection(); } }

        private bool _SignedCheck;
        public bool SignedCheck { get => _SignedCheck; set { _SignedCheck = value; _SignShow = false; OnPropertyChanged(); FilterCollection(); } }

        private ObservableCollection<SignModel> _SignList;
        public ObservableCollection<SignModel> SignList { get => _SignList; set { _SignList = value; OnPropertyChanged(); } }

        private ICollectionView _SignFilterList;
        public ICollectionView SignFilterList { get => _SignFilterList; private set { _SignFilterList = value; OnPropertyChanged(); } }

        private string _FilterString;
        public string FilterString { get => _FilterString; set { _FilterString = value; OnPropertyChanged(); FilterCollection(); } }
    }
}
