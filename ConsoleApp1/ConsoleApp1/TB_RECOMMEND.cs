namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_RECOMMEND
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Recommendid { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Recommender { get; set; }

        public int Postid { get; set; }

        [Required]
        [StringLength(50)]
        public string Userid { get; set; }
    }
}
