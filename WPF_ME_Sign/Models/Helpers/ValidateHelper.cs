using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                    MessageBox.Show("One or some fields are not filled");
                    return false;
                }
            }
            return true;
        }
    }
}
