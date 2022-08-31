using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models
{
    public class MailModel
    {
        public string FromAddress { get; set; }
        public ObservableCollection<string> ToAddress { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ObservableCollection<FileModel> FileList { get; set; }
    }
}
