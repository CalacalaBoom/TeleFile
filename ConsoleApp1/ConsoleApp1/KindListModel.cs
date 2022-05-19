using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class KindListModel
    {
        public List<RecdaModel> ZList { get; set; } = new List<RecdaModel>();

        public List<RecdaModel> XList { get; set; } = new List<RecdaModel>();

        public List<RecdaModel> SList { get; set; } = new List<RecdaModel>();

        public List<RecdaModel> FList { get; set; } = new List<RecdaModel>();

        public List<RecdaModel> TList { get; set; } = new List<RecdaModel>();
    }
}
