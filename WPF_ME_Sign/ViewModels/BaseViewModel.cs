using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models;
using ClosedXML.Report;
using System.Diagnostics;
using System.IO;

namespace WPF_ME_Sign.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected virtual SignModel GetSignModel(string signId)
        {
            return new SignModel()
            {
                SignId = signId,
                UserId = InfoHelper.UserId,
                SignDate = DateTime.Today.ToString("dd/MM/yyyy")
            };
        }
    }
}
