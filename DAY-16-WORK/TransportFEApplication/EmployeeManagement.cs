using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class EmployeeManagement
    {
        private IRepo<Employee> _repo;

        public EmployeeManagement()
        {

        }
        public EmployeeManagement(IRepo<Employee> repo)
        {
            _repo = repo;
        }

        public void CreateEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_repo.Add(employee))
                    Console.WriteLine("Employee created");
                else
                    Console.WriteLine("Sorry could not complete creating an employee");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add employee");
                Console.WriteLine(e.Message);
            }
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return employees;
        }
        public void PrintAllEmployee()
        {
            var employees = GetAllEmployees();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public List<CompleteEmployee> SortEmployees()
        {
            List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach (var item in GetAllEmployees())
            {
                employees.Add(new CompleteEmployee(item));
            }
            return employees;
        }
        public void PrintEmployeesSortedById()
        {
            var employees = SortEmployees();
            employees.Sort();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public void ResetPassword()
        {
            Console.WriteLine("Please enter the employee id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the old password");
            string password = Console.ReadLine();
            Employee employee = GetAllEmployees().Find(e => e.Id == id && e.Password == password);
            try
            {
                if (employee != null)
                {
                    Console.WriteLine("Please enter the new password");
                    var newPassword = Console.ReadLine();
                    Console.WriteLine("Please retype  the new password");
                    var repeatPassword = Console.ReadLine();
                    if (newPassword == repeatPassword)
                    {
                        employee.Password = newPassword;
                        if (_repo.Update(employee))
                            Console.WriteLine("Password updated");
                        else
                            Console.WriteLine("Please try again");
                    }
                    else
                        Console.WriteLine("Password mismatch");
                }
                else
                {
                    Console.WriteLine("Incorrect username or password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update password at this moment");
                Console.WriteLine(e.Message);
            }
        }

    }
}