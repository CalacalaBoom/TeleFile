using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PushGoodsModel
    {
        public int Num { get; set; }

        public byte[] Photo { get; set; }

        public string Name { get; set; }

        public string Introduce { get; set; }

        public int NumOfKind { get; set; }

        public int CountOfBuyed { get; set; }

        public float Price { get; set; }

        public string Path { get; set; }
    }
}
