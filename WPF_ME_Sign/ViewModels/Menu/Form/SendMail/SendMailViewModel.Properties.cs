using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.ViewModels.Menu.Form.SendMail
{
    public partial class SendMailViewModel : ObservableObject
    {
        private string _Title;
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }

        private string _Content;
        public string Content { get => _Content; set { _Content = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _FileList;
        public ObservableCollection<string> FileList { get => _FileList; set { _FileList = value; OnPropertyChanged(); } }
    }
}
