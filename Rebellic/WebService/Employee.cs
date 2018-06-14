namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Email { get; set; }

        public int Employee_Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Password { get; set; }

        public int? fk_Employee_Role { get; set; }

        public virtual Role Role { get; set; }
    }
}
