namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Goods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodsID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Photo { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Introduce { get; set; }

        public int NumofKind { get; set; }

        public int CountOfBuyed { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }
    }
}
