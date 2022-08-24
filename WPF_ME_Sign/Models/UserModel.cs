using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models
{
    public class UserModel
    {
        public string Me_UserId { get; set; }
        public string UserId { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string DeptId { get; set; }

        public string DeptName { get; set; }

        public string Email { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public string CreateDate { get; set; }

        public string Status { get; set; }
    }
}
