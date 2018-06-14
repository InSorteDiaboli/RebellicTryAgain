using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;
using Rebellic.Persistency;

namespace Rebellic
{
    class UserSingleton
    {
        private static UserSingleton _instance = new UserSingleton();

        private static string _loggedInFirstName;

        public static UserSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserSingleton();
                return _instance;
            }



        }
        public static Employee LoggedInEmployee { get; set; }

        public static string LoggedInFirstName
        {
            get
            {
                return LoggedInEmployee.Employee_Name.Split(' ', '\t').First();
            }

            set => _loggedInFirstName = value;
        }

        public static Employee SelectedUser { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Employee> EmployeesObser { get; set; }
        private UserSingleton()
        {
            Employees = new ObservableCollection<Employee>();
            EmployeesObser = new ObservableCollection<Employee>();
            LoadEmployeesAsync();
            foreach (var employee in Employees.ToList())
            {
                EmployeesObser.Add(employee);
            }
        }



        public async void LoadEmployeesAsync()
        {
            var employees = await EmployeePersistency.LoadEmployeesFromJsonAsync();
            Employees.Clear();
            if (employees != null)
                foreach (var ey in employees)
                {
                    Employees.Add(ey);
                }
            else
            {
                //Data til testformål
                //Events.Add(new Event(1, "Pitching 2end semester Projects", "Auditorium 202", new DateTime(2014, 12, 24, 9, 0, 0), "De studerende fremlægger deres eksamensprojekt"));
                //Events.Add(new Event(2, "Eksamen", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 1. semester"));
            }
        }



        public void Add(Employee newEmployee)
        {
            Employees.Add(newEmployee);
            EmployeePersistency.SaveEmployeesAsJsonAsync(newEmployee);
        }

        public void Add(int empId, string empName, string empEmail, string empPassword, int empPhone, int empRole)
        {
            Employee emp = new Employee(empId, empName, empEmail, empPhone, empPassword, empRole);
            Employees.Add(emp);
            EmployeePersistency.SaveEmployeesAsJsonAsync(emp);
        }

        public void Remove(Employee employeeToBeRemoved)
        {
            Employees.Remove(employeeToBeRemoved);
            //PersistencyService.SaveEventsAsJsonAsync(Events);
            EmployeePersistency.DeleteEmployeesAsync(employeeToBeRemoved);
        }
    }
}
