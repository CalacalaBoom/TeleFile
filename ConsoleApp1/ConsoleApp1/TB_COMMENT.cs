namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_COMMENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Commentid { get; set; }

        public int Postid { get; set; }

        [Required]
        [StringLength(50)]
        public string Userid { get; set; }

        [Required]
        [StringLength(150)]
        public string CommentContent { get; set; }

        public DateTime Date { get; set; }
    }
}
