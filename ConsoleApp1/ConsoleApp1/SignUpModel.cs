using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SignUpModel
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public string Region { get; set; }

        public string Sex { get; set; }

        public string Signature { get; set; }

        public byte[] Photo { get; set; }
    }
}
