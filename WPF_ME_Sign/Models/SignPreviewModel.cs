using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models
{
    public class SignPreviewModel : FormModel
    {
        public string RequestUserId { get; set; }

        public string RequestUserName { get; set; }

        public string RequestSignDate { get; set; }

        public string DeptUserId { get; set; }

        public string DeptUserName { get; set; }

        public string DeptSignDate { get; set; }

        public string QCUserId { get; set; }

        public string QCUserName { get; set; }

        public string QCSignDate { get; set; }

        public string TechUserId { get; set; }

        public string TechUserName { get; set; }

        public string TechSignDate { get; set; }

        public string ProductionUserId { get; set; }

        public string ProductionUserName { get; set; }

        public string ProductionSignDate { get; set; }

        public string MEUserId { get; set; }

        public string MEUserName { get; set; }

        public string MESignDate { get; set; }
    }
}
