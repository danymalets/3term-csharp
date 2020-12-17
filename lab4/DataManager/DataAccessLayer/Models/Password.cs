using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Password
    {
        public string passwordHash { set; get; }

        public Password(string hash)
        {
            passwordHash = hash;
        }
    }
}
