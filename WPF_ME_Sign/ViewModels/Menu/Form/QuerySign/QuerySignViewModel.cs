using CommunityToolkit.Mvvm.Input;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.Form;

namespace WPF_ME_Sign.ViewModels.Menu.Form.QuerySign
{
    public partial class QuerySignViewModel
    {
        public QuerySignViewModel()
        {
            FromDate = DateTime.Today.ToString();
            ToDate = DateTime.Today.ToString();
            UnsignCheck = true;
            _querySignService = new QuerySignService();

            SignList = _querySignService.LoadSignList();
            SignFilterList = CollectionViewSource.GetDefaultView(SignList);
            SignFilterList.Filter = new Predicate<object>(Filter);

            PreviewCommand = new RelayCommand<object>(o => PreviewExectute(o), o => true);
            ExportCommand = new RelayCommand<object>(o => ExportExectute(o), o => true);
            SignCommand = new RelayCommand<object>(o => SignExectute(o), o => true);
        }

        private SignModel GetSignModel(SignModel sign)
        {
            return new SignModel()
            {
                SignId = sign.SignId,
                UserId = InfoHelper.UserId,
                SignDate = DateTime.Today.ToString("dd/MM/yyyy")
            };
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
                        return sign.SignStatus.Contains("U") && (sign.SignId.Contains(FilterString) || sign.FormUserId.Contains(FilterString) || sign.FormUserName.Contains(FilterString));
                    }
                    else
                    {
                        return sign.SignStatus.Contains("U");
                    }
                }
                if (SignedCheck)
                {
                    if (!string.IsNullOrEmpty(FilterString))
                    {
                        return sign.SignStatus.Contains("S") && (sign.SignId.Contains(FilterString) || sign.FormUserId.Contains(FilterString) || sign.FormUserName.Contains(FilterString));
                    }
                    else
                    {
                        return sign.SignStatus.Contains("S");
                    }
                }
                return true;
            }

            return false;
        }

        private void UpdateSignStatus(string signId)
        {
            SignList.Where(x => x.SignId == signId).ForEach(x => x.SignStatus = "S");
            FilterCollection();
        }
    }
}
