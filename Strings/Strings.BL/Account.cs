using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings.BL
{
    public class Account
    {
        public int UserId { get; set; }
        public decimal Sum { get; set; }
        public string Culture { get; set; }

        public void AddSum (decimal addingSum)
        {
            Sum += addingSum;
        }
    }
}
