namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_EXAMINE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Examineid { get; set; }

        public int Postid { get; set; }
    }
}
