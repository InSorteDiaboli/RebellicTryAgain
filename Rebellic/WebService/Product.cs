namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Product_Desc { get; set; }

        public int Product_Category { get; set; }

        public double Product_Price { get; set; }

        public TimeSpan Product_Time { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
