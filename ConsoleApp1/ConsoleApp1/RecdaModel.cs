using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RecdaModel
    {
        public int Postid { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public byte[] Cover { get; set; }
    }
}
