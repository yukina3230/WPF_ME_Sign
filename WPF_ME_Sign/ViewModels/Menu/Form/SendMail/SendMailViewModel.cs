using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.ViewModels.Menu.Form.SendMail
{
    public partial class SendMailViewModel
    {
        public SendMailViewModel()
        {
            AddFileCommand = new RelayCommand(AddFileExecute);
            SendMailCommand = new RelayCommand(SendMailExecute);
        }
    }
}
