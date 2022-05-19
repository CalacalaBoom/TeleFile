namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_BLOCK
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Blockid { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int NumOfPost { get; set; }
    }
}
