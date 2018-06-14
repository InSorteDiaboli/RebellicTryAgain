using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WebService;
using Rebellic.Persistency;
using Rebellic.Handler;

namespace Rebellic
{
    class LoginHandler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region LoginProperties
        private static string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email { get; set; }
        public string Password { get; set; }
        private static Visibility _menuProfileVisibility;
        public Visibility MenuProfileVisibilty
        {
            get { return _menuProfileVisibility; }
            set
            {
                _menuProfileVisibility = value;
                OnPropertyChanged();
            }
        }

        private static Visibility _menuLoginVisibility;
        public Visibility MenuLoginVisibilty
        {
            get { return _menuLoginVisibility; }
            set
            {
                _menuLoginVisibility = value;
                OnPropertyChanged();
            }
        }

        private static Visibility _menuLogoutVisibility;
        public Visibility MenuLogoutVisibility
        {
            get { return _menuLogoutVisibility; }
            set
            {
                _menuLogoutVisibility = value;
                OnPropertyChanged();
            }
        }

        private static Visibility _menuCreateUserGrid;

        public Visibility MenuCreateUserGrid
        {
            get { return _menuCreateUserGrid; }
            set
            {
                _menuCreateUserGrid = value;
                OnPropertyChanged();
            }
        }
        private static Visibility _loginUserGrid;
        public Visibility LoginUserGrid
        {
            get { return _loginUserGrid; }
            set
            {
                _loginUserGrid = value;
                OnPropertyChanged();
            }
        }

        private static Visibility _profileUserGrid;
        public Visibility ProfileUserGrid
        {
            get { return _profileUserGrid; }
            set
            {
                _profileUserGrid = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public Frame frame = (Frame)Window.Current.Content;

        #region CreateUserProperties

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

        private DateTime Birthday = Convert.ToDateTime("01/01/1700 00:00:00");
        public void SetBirthday(object sender, DatePickerValueChangedEventArgs e)
        {
            Birthday = e.NewDate.Date;
        }
        #endregion
        public CustomerHandler Ch { get; set; }
        public LoginHandler()
        {
            Ch = new CustomerHandler();
            MenuLoginVisibilty = Visibility.Visible;
            MenuLogoutVisibility = Visibility.Collapsed;
            MenuProfileVisibilty = Visibility.Collapsed;
            MenuCreateUserGrid = Visibility.Collapsed;
            LoginUserGrid = Visibility.Visible;

        }

        public LoginHandler(Visibility menuLoginVisibility, Visibility menuLogoutVisibility, Visibility menuProfileVisibility, Visibility menuCreateUserGrid, string customerName, string customerAdress, string customerZipcode, string customerCity, string customerEmail, string customerPhone, string customerGender, DateTime customerBirthday, string customerPassword, Visibility loginUserGrid, CustomerHandler ch, Visibility profileUserGrid)
        {
            Ch = ch;
            MenuLoginVisibilty = menuLoginVisibility;
            MenuLogoutVisibility = menuLogoutVisibility;
            MenuProfileVisibilty = menuProfileVisibility;
            MenuCreateUserGrid = menuCreateUserGrid;
            LoginUserGrid = loginUserGrid;
            ProfileUserGrid = profileUserGrid;
        }

        public void CreateCustomerLogin()
        {
            Ch.CreateCustomer();

            MenuCreateUserGrid = Visibility.Collapsed;
            LoginUserGrid = Visibility.Visible;
            ProfileUserGrid = Visibility.Collapsed;
        }

        public bool CanLoginEmp = false;
        public bool CanLoginUser = false;

        public void Login()
        {
            //var GetEmployees = EmployeePersistency.LoadEmployeesFromJsonAsync().Result;

            foreach (var employee in UserSingleton.Instance.Employees)
            {
                if (Email == employee.Employee_Email && Password == employee.Employee_Password)
                {
                    CanLoginEmp = true;
                    UserSingleton.LoggedInEmployee = employee;
                    //break;   
                }
                if (CanLoginEmp)
                {
                    new MessageDialog("Du er nu logget ind som: " + employee.Employee_Name).ShowAsync();
                    Name = employee.Employee_Name;
                    frame.Navigate(typeof(CustProfile));
                    MenuLoginVisibilty = Visibility.Collapsed;
                    MenuLogoutVisibility = Visibility.Visible;
                    MenuProfileVisibilty = Visibility.Visible;
                    //ProfileUserGrid = Visibility.Collapsed;
                    return;
                }

                foreach (var customer in CustomerSingleton.Instance.Customers)
                {
                    if (Email == customer.Customer_Email && Password == customer.Customer_Password)
                    {
                        CanLoginUser = true;
                        CustomerSingleton.LoggedInCustomer = customer;
                        //break;
                    }
                    if (CanLoginUser)
                    {
                        frame.Navigate(typeof(CustProfile));
                        Name = customer.Customer_Name;
                        MenuProfileVisibilty = Visibility.Visible;
                        MenuLoginVisibilty = Visibility.Collapsed;
                        MenuLogoutVisibility = Visibility.Visible;
                        ProfileUserGrid = Visibility.Visible;
                        new MessageDialog("Du er nu logget ind som: " + customer.Customer_Name).ShowAsync();
                        return;
                    }

                }
                if (!CanLoginEmp || !CanLoginUser)
                {
                    new MessageDialog("Forkert email eller kodeord").ShowAsync();
                }
            }



        }

        public void LogOut()
        {
            frame.Navigate(typeof(MainPage));
            new MessageDialog("Du er nu logget ud").ShowAsync();
        }
    }
}
