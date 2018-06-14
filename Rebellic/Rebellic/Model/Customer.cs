namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Customer
    {

        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_Adress { get; set; }

        public string Customer_Zipcode { get; set; }

        public string Customer_City { get; set; }

        public string Customer_Email { get; set; }

        public int Customer_Phone { get; set; }

        public string Customer_Gender { get; set; }

        public DateTime Customer_Birthday { get; set; }

        public string Customer_Password { get; set; }

        public Customer(int customer_Id, string customer_Name, string customer_Adress, string customer_Zipcode, string customer_City, string customer_Email, int customer_Phone, string customer_Gender, DateTime customer_Birthday, string customer_Password)
        {
            Customer_Id = customer_Id;
            Customer_Name = customer_Name;
            Customer_Adress = customer_Adress;
            Customer_Zipcode = customer_Zipcode;
            Customer_City = customer_City;
            Customer_Email = customer_Email;
            Customer_Phone = customer_Phone;
            Customer_Gender = customer_Gender;
            Customer_Birthday = customer_Birthday;
            Customer_Password = customer_Password;
        }

        public Customer()
        {

        }
    }
}
