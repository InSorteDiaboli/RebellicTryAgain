using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;
using Rebellic.Persistency;
using System.Collections.ObjectModel;

namespace Rebellic
{
    class CustomerSingleton
    {
        private static CustomerSingleton _instance = new CustomerSingleton();

        public static CustomerSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerSingleton();
                return _instance;
            }



        }
        public static Customer LoggedInCustomer { get; set; }

        public ObservableCollection<Customer> Customers { get; set; }
        private CustomerSingleton()
        {
            Customers = new ObservableCollection<Customer>();
            LoadCustomersAsync();
            foreach (var customer in Customers.ToList())
            {
                Customers.Add(customer);
            }
        }



        public async void LoadCustomersAsync()
        {
            var customers = await CustomerPersistency.LoadCustomersFromJsonAsync();
            if (customers != null)
                foreach (var cs in customers)
                {
                    Customers.Add(cs);
                }
            else
            {
                //Data til testformål
                //Events.Add(new Event(1, "Pitching 2end semester Projects", "Auditorium 202", new DateTime(2014, 12, 24, 9, 0, 0), "De studerende fremlægger deres eksamensprojekt"));
                //Events.Add(new Event(2, "Eksamen", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 1. semester"));
            }
        }



        public void Add(Customer newCustomer)
        {
            Customers.Add(newCustomer);
            CustomerPersistency.SaveCustomersAsJsonAsync(newCustomer);
        }

        public void Add(int cusId, string cusName, string cusAdress, string cusZip, string cusCity, string cusEmail, int cusPhone, string cusGender, DateTime cusBirthday, string cusPassword)
        {
            Customer cus = new Customer(cusId, cusName, cusAdress, cusZip, cusCity, cusEmail, cusPhone, cusGender, cusBirthday, cusPassword);
            Customers.Add(cus);
            CustomerPersistency.SaveCustomersAsJsonAsync(cus);
        }

        public void Remove(Customer customerToBeRemoved)
        {
            Customers.Remove(customerToBeRemoved);
            //PersistencyService.SaveEventsAsJsonAsync(Events);
            CustomerPersistency.DeleteCustomersAsync(customerToBeRemoved);
        }
    }
}
