namespace DemoExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPhoto")]
    public partial class ProductPhoto
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1000)]
        public string PhotoPath { get; set; }

        public virtual Product Product { get; set; }
    }
}
