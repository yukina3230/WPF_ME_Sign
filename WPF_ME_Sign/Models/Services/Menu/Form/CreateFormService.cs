using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Repositories.Menu.Form;
using WPF_ME_Sign.Models.Repositories.Menu.User;

namespace WPF_ME_Sign.Models.Services.Menu.Form
{
    public class CreateFormService
    {
        private CreateFormRepository _createFormRepository;
        private FormModel _form;
        private KPIModel _kpi;
        private SignModel _sign;

        public CreateFormService(FormModel form, KPIModel kpi, SignModel sign)
        {
            _createFormRepository = new CreateFormRepository();
            _form = form;
            _kpi = kpi;
            _sign = sign;
        }

        public bool Create() => _createFormRepository.CreateNewForm(_form, _kpi, _sign);
    }
}
