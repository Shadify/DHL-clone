namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public int price { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int quantity { get; set; }
    }
}
