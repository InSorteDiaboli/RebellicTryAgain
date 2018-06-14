namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {

        public int Employee_Id { get; set; }

        public string Employee_Name { get; set; }

        public string Employee_Email { get; set; }

        public int Employee_Phone { get; set; }

        public string Employee_Password { get; set; }

        public int? fk_Employee_Role { get; set; }

        public virtual Role Role { get; set; }

        public Employee(int employee_Id, string employee_Name, string employee_Email, int employee_Phone, string employee_Password, int employee_Role)
        {
            Employee_Id = employee_Id;
            Employee_Name = employee_Name;
            Employee_Email = employee_Email;
            Employee_Phone = employee_Phone;
            Employee_Password = employee_Password;
            fk_Employee_Role = employee_Role;
        }
    }
}
