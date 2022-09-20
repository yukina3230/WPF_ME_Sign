using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models
{
    public class PriorityModel
    {
        //Menu Item
        private bool _MenuForm = false;
        public bool MenuForm { get => _MenuForm; set { _MenuForm = value; } }

        private bool _MenuUser = false;
        public bool MenuUser { get => _MenuUser; set { _MenuUser = value; } }

        //Sub Menu Item
        private bool _CreateForm = false;
        public bool CreateForm { get => _CreateForm; set { _CreateForm = value; } }

        private bool _SendMail = false;
        public bool SendMail { get => _SendMail; set { _SendMail = value; } }

        private bool _QuerySign = false;
        public bool QuerySign { get => _QuerySign; set { _QuerySign = value; } }

        private bool _CreateUser = false;
        public bool CreateUser { get => _CreateUser; set { _CreateUser = value; } }

        private bool _ChangePasswrod = false;
        public bool ChangePassword { get => _ChangePasswrod; set { _ChangePasswrod = value; } }
    }
}
