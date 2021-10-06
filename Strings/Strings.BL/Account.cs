using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings.BL
{
    public class Account
    {
        public int UserId { get; set; }
        public double Sum { get; set; }

        public void AddSum (int addingSum)
        {
            Sum += addingSum;
        }
    }
}
