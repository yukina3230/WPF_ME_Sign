using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.Models.Helpers
{
    public static class ValidateHelper
    {
        public static bool DetectFieldEmpty(params string[] values)
        {
            foreach (var item in values)
            {
                if (String.IsNullOrEmpty(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
