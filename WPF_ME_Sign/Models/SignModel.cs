using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models
{
    public class SignModel
    {
        public string SignId { get; set; }

        // Cái này để insert
        public string UserId { get; set; }

        public string SignDate { get; set; }


        // Cái này để load list
        public string ProjectTitle { get; set; }

        public string CreateDate { get; set; }

        public string FormUserId { get; set; }

        public string FormUserName { get; set; }

        public string DeptName { get; set; }
    }
}
