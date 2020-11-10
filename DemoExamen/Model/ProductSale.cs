namespace DemoExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSale")]
    public partial class ProductSale
    {
        public int ID { get; set; }

        public DateTime SaleDate { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductID { get; set; }

        public int Quantity { get; set; }

        public int? ClientServiceID { get; set; }

        public virtual ClientService ClientService { get; set; }

        public virtual Product Product { get; set; }
    }
}
