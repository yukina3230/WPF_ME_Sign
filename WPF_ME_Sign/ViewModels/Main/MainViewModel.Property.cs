using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Main
{
    public partial class MainViewModel
    {
        private PriorityModel _Priority;
        public PriorityModel Priority { get => _Priority; set { _Priority = value; OnPropertyChanged(); } }
    }
}
