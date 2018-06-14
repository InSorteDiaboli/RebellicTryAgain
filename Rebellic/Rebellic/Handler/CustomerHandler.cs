using Rebellic.Persistency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebService;
using Windows.UI.Popups;

namespace Rebellic.Handler
{
    class CustomerHandler
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _customer_Name;
        public string Customer_Name
        {
            get { return _customer_Name; }
            set
            {
                _customer_Name = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Adress;
        public string Customer_Adress
        {
            get { return _customer_Adress; }
            set
            {
                _customer_Adress = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Zipcode;
        public string Customer_Zipcode
        {
            get { return _customer_Zipcode; }
            set
            {
                _customer_Zipcode = value;
                OnPropertyChanged();
            }
        }

        private string _customer_City;
        public string Customer_City
        {
            get { return _customer_City; }
            set
            {
                _customer_City = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Email;
        public string Customer_Email
        {
            get { return _customer_Email; }
            set
            {
                _customer_Email = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Phone;
        public string Customer_Phone
        {
            get { return _customer_Phone; }
            set
            {
                _customer_Phone = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Gender;
        public string Customer_Gender
        {
            get { return _customer_Gender; }
            set
            {
                _customer_Gender = value;
                OnPropertyChanged();
            }
        }

        private DateTime _customer_BirthDay;
        public DateTime Customer_Birthday
        {
            get { return _customer_BirthDay; }
            set
            {
                _customer_BirthDay = value;
                OnPropertyChanged();
            }
        }

        private string _customer_Password;
        public string Customer_Password
        {
            get { return _customer_Password; }
            set
            {
                _customer_Password = value;
                OnPropertyChanged();
            }
        }

        public CustomerHandler()
        {

        }

        public CustomerHandler(string customerName, string customerAdress, string customerZipcode, string customerCity, string customerEmail, string customerPhone, DateTime customerBirthday, string customerGender, string customerPassword)
        {
            Customer_Name = customerName;
            Customer_Adress = customerAdress;
            Customer_Zipcode = customerZipcode;
            Customer_City = customerCity;
            Customer_Email = customerEmail;
            Customer_Phone = customerPhone;
            Customer_Birthday = customerBirthday;
            Customer_Gender = customerGender;
            Customer_Password = customerPassword;
        }

        public void CreateCustomer()
        {
            Customer newCustomer = new Customer();
            newCustomer.Customer_Name = Customer_Name;
            newCustomer.Customer_Adress = Customer_Adress;
            newCustomer.Customer_Zipcode = Customer_Zipcode;
            newCustomer.Customer_City = Customer_City;
            newCustomer.Customer_Email = Customer_Email;
            newCustomer.Customer_Phone = Convert.ToInt32(Customer_Phone);
            newCustomer.Customer_Gender = Customer_Gender;
            newCustomer.Customer_Birthday = Customer_Birthday;
            newCustomer.Customer_Password = Customer_Password;

            new MessageDialog(Customer_Name + ", du har nu oprettet din bruger").ShowAsync();
            CustomerPersistency.SaveCustomersAsJsonAsync(newCustomer);

        }


    }
}
