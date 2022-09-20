using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Repositories.Main;

namespace WPF_ME_Sign.Models.Services.Main
{
    public class MainService
    {
        private MainRepository _mainRepository;

        public MainService()
        {
            _mainRepository = new MainRepository();
        }

        public PriorityModel GetPriority(string roleId) => _mainRepository.GetPriority(roleId);
    }
}
