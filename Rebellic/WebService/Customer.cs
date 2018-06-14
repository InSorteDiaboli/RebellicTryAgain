namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Adress { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Zipcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_City { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Email { get; set; }

        public int Customer_Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime Customer_Birthday { get; set; }

        [Required]
        [StringLength(20)]
        public string Customer_Password { get; set; }
    }
}
