//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeleFileServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Goods
    {
        public int GoodsID { get; set; }
        public byte[] Photo { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public int NumofKind { get; set; }
        public int CountOfBuyed { get; set; }
        public double Price { get; set; }
        public string Path { get; set; }
    }
}
