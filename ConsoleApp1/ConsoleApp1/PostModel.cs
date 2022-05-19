using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PostModel
    {
        public int Blockid { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public byte[] Postcontent { get; set; }

        public byte[] Cover { get; set; }

        public string Userid { get; set; }

        public string Lable { get; set; }

        public bool IsContribute { get; set; }

        public string Author { get; set; }

        public int Postid { get; set; }

        public bool isFollowed { get; set; }
    }
}
