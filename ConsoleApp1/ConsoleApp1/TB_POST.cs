namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_POST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Postid { get; set; }

        public int Blockid { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Postcontent { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Cover { get; set; }

        [Required]
        [StringLength(50)]
        public string Userid { get; set; }

        public int Recommendid { get; set; }

        [Required]
        [StringLength(150)]
        public string Lable { get; set; }

        public int Examineid { get; set; }
    }
}
