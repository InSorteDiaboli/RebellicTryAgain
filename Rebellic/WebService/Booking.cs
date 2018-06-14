namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Booking_Date { get; set; }

        public TimeSpan Booking_Time { get; set; }

        public double Booking_TotalPrice { get; set; }

        public int fk_Product_Id { get; set; }

        public int fk_Employee_Id { get; set; }

        public int fk_Customer_Id { get; set; }

        public int fk_Room_Id { get; set; }
    }
}
