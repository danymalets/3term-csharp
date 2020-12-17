using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PhoneNumber
    {
        public string Number { set; get; }
        public int Type { set; get; }

        public PhoneNumber(string number, int type)
        {
            Number = number;
            Type = type;
        }
    }
}
