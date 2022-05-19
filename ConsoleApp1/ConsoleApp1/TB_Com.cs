namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_Com
    {
        [Key]
        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(200)]
        public string ComName { get; set; }

        [StringLength(50)]
        public string ComTele { get; set; }

        [StringLength(200)]
        public string ComAddress { get; set; }
    }
}
