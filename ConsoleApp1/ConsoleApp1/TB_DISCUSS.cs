namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_DISCUSS
    {
        public int Postid { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Dicscuss { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Discussid { get; set; }
    }
}
