namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Broad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string BroadContent { get; set; }

        [StringLength(150)]
        public string BroadTitle { get; set; }
    }
}
