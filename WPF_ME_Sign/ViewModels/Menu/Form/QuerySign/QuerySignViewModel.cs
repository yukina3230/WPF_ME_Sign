using CommunityToolkit.Mvvm.Input;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.Form;
using WPF_ME_Sign.Models.Services.Share;

namespace WPF_ME_Sign.ViewModels.Menu.Form.QuerySign
{
    public partial class QuerySignViewModel : BaseViewModel
    {
        QuerySignService _querySignService;
        PreviewSignService _previewSignService;

        public QuerySignViewModel()
        {
            _querySignService = new QuerySignService();
            _previewSignService = new PreviewSignService();
            UnsignCheck = true;
            SignShow = SignVisibility(InfoHelper.UserId);
            FromDate = DateTime.Today;
            ToDate = DateTime.Today;

            SignList = _querySignService.LoadSignList(FromDate.ToString("dd/MM/yyyy"), ToDate.ToString("dd/MM/yyyy"));
            SignFilterList = CollectionViewSource.GetDefaultView(SignList);
            SignFilterList.Filter = new Predicate<object>(Filter);
            FilterCollection();

            PreviewCommand = new RelayCommand<object>(o => PreviewExectute(o), o => true);
            ExportCommand = new RelayCommand<object>(o => ExportExectute(o), o => true);
            SignCommand = new RelayCommand<object>(o => SignExectute(o), o => true);
        }

        private bool SignVisibility(string userId) => _previewSignService.SignCheck(userId) && UnsignCheck;

        private void LoadSignList()
        {
            if (FromDate != null && ToDate != null)
            {
                SignList = _querySignService.LoadSignList(FromDate.ToString("dd/MM/yyyy"), ToDate.ToString("dd/MM/yyyy"));
                SignFilterList = CollectionViewSource.GetDefaultView(SignList);
                SignFilterList.Filter = new Predicate<object>(Filter);
            }
        }

        private void FilterCollection()
        {
            if (SignFilterList != null) SignFilterList.Refresh();
        }

        public bool Filter(object o)
        {
            var sign = o as SignModel;

            if (sign != null)
            {
                if (UnsignCheck)
                {
                    if (!string.IsNullOrEmpty(FilterString))
                    {
                        return sign.SignStatus.Contains("W") && (sign.SignId.Contains(FilterString) || sign.FormUserId.Contains(FilterString) || sign.FormUserName.Contains(FilterString));
                    }
                    else
                    {
                        return sign.SignStatus.Contains("W");
                    }
                }
                if (SignedCheck)
                {
                    if (!string.IsNullOrEmpty(FilterString))
                    {
                        return sign.SignStatus.Contains("D") && (sign.SignId.Contains(FilterString) || sign.FormUserId.Contains(FilterString) || sign.FormUserName.Contains(FilterString));
                    }
                    else
                    {
                        return sign.SignStatus.Contains("D");
                    }
                }
            }

            return false;
        }

        private void UpdateSignStatus(string signId)
        {
            SignList.Where(x => x.SignId == signId).ForEach(x => x.SignStatus = "D");
            FilterCollection();
        }
    }
}
