using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Repositories.Menu.Form;

namespace WPF_ME_Sign.Models.Services.Menu.Form
{
    public class QuerySignService
    {
        private QuerySignRepository _querySignRepository;

        public QuerySignService()
        {
            _querySignRepository = new QuerySignRepository();
        }

        public ObservableCollection<SignModel> LoadSignList(string fromDate, string toDate) => _querySignRepository.LoadSignList(fromDate, toDate);

        public bool Sign(SignModel sign) => _querySignRepository.InsertSign(sign);
    }
}
