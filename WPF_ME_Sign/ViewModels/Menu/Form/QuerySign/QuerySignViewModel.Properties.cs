using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Menu.Form.QuerySign
{
    public partial class QuerySignViewModel : ObservableObject
    {
        private string _QueryString;
        public string QueryString { get => _QueryString; set { _QueryString = value; OnPropertyChanged(); } }

        private string _FromDate;
        public string FromDate { get => _FromDate; set { _FromDate = value; OnPropertyChanged(); } }

        private string _ToDate;
        public string ToDate { get => _ToDate; set { _ToDate = value; OnPropertyChanged(); } }

        private bool _UnsignCheck;
        public bool UnsignCheck { get => _UnsignCheck; set { _UnsignCheck = value; OnPropertyChanged(); } }

        private bool _SignedCheck;
        public bool SignedCheck { get => _SignedCheck; set { _SignedCheck = value; OnPropertyChanged(); } }

        private ObservableCollection<SignModel> _SignList;
        public ObservableCollection<SignModel> SignList { get => _SignList; set { _SignList = value; OnPropertyChanged(); } }
    }
}
