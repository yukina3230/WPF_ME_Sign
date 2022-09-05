using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;
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

            PreviewCommand = new RelayCommand<object>(o => PreviewExectute(o), o => true);
            ExportCommand = new RelayCommand<object>(o => ExportExectute(o), o => true);
            SignCommand = new RelayCommand<object>(o => SignExectute(o), o => true);
        }
    }
}
