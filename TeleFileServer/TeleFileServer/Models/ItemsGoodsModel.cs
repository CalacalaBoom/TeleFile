using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleFileServer.Models
{
    public class ItemsGoodsModel
    {
        public int gid { get; set; }

        public string name { get; set; }

        public string intro { get; set; }

        public int nofk { get; set; }

        public int cofb { get; set; }

        public float pri { get; set; }

        public string pa { get; set; }
    }
}
