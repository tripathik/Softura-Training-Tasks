using System;
using System.Collections.Generic;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;
namespace TransportFEApplication
{
    class EmployeeLogin
    {
        private IUserLogin<Employee> _login;

        public EmployeeLogin()
        {

        }
        public EmployeeLogin(IUserLogin<Employee> login)
        {
            _login = login;
        }
        public void UserLogin()
        {
            Console.WriteLine("Please enter the employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the password");
            string password = Console.ReadLine();
            Employee employee = new Employee();
            employee.Id = id;
            employee.Password = password;
            try
            {
                if (_login.Login(employee))
                    Console.WriteLine("Welcome");
                else
                    Console.WriteLine("Incorrect id or password");
            }
            catch (Exception e)
            {
                Console.WriteLine("Login exception");
                Console.WriteLine(e.Message);
            }
        }
        public void RegisterEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_login.Add(employee))
                    Console.WriteLine("Employee Registered");
                else
                    Console.WriteLine("Sorry could not complete creating an employee");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add employee");
                Console.WriteLine(e.Message);
            }
        }
    }
}