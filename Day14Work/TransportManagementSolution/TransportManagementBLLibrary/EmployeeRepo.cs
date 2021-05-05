using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportManagementBLLibrary
{
   public class EmployeeRepo : IRepo<Employee>, ILogin<Employee>
    {
        public Dictionary<int, Employee> employees;
        public EmployeeRepo()
        {
            employees = new Dictionary<int, Employee>();
        }

        public int GenerateEmployeeId()
        {
            if (employees.Count == 0)
                return 1;
            List<int> ids = employees.Keys.ToList();
            ids.Sort();
            int id = ids[ids.Count - 1];
            id++;
            return id;
        }
        public void Add(Employee t)
        {
            try
            {
                t.Id = GenerateEmployeeId();
                employees.Add(t.Id, t);
            }
            catch (ArgumentException argumentexception)
            {

                throw new UnabletoAddEmployeeException();
            }
        }

        public void Update(int id, Employee t)
        {
            Console.WriteLine("Select what do you want to update Location or phone_number or password or all");
            string choice = Console.ReadLine();
            string Location;
            string Phone;
            string Password;
            string all;
            switch (choice)
            {
                case "Location":
                    Console.WriteLine("Please enter New location");
                    Location = Console.ReadLine();
                    UpdateLocation(id, Location);
                    break;
                case "PhoneNumber":
                    Console.WriteLine("Please enter new phone number");
                    Phone = Console.ReadLine();
                    UpdatePhoneNumber(id, Phone);
                    break;
                case "Password":
                    Console.WriteLine("Please enter new password");
                    Password = Console.ReadLine();
                    UpdatePassword(id, Password);
                    break;
                case "all":
                    Console.WriteLine("Please enter new Location");
                    Location = Console.ReadLine();
                    UpdateLocation(id, Location);
                    Console.WriteLine("Please enter new phone nnumber");
                    Phone = Console.ReadLine();
                    UpdatePhoneNumber(id, Phone);
                    Console.WriteLine("Please enter new password");
                    Password = Console.ReadLine();
                    UpdatePassword(id, Password);
                    break;
                default:
                    Console.WriteLine("Invalied Choice");
                    break;
            }
        }

        public Employee UpdatePassword(int id, string password)
        {
            Employee employee = null;
            try
            {
                if (id != -1)
                {
                    employees[id].Password = password;
                    employee = employees[id];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to update the password");
            }
            return employee;
        }

        public Employee UpdatePhoneNumber(int id, string phoneNumber)
        {
            Employee employee = null;
            if (id != -1)
            {
                employees[id].Phone = phoneNumber;
                employee = employees[id];
            }
            return employee;
        }

        public Employee UpdateLocation(int id, string location)
        {
            Employee employee = null;
            List<int> ids = employees.Keys.ToList();
            ids.Sort();
            if (id != -1)
            {
                employees[id].Location = location;
                employee = employees[id];
            }
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            if (employees.Count == 0)
                return null;
            return employees.Values.ToList();
        }

        public Employee Get(int id)
        {
            Employee employee = null;
            try
            {
                employee = employees[id];
            }
            catch (Exception e)
            {
                employee = null;
            }
            return employee;
        }

        public bool Login(Employee t)
        {
            if (employees.ContainsKey(t.Id))
            {
                if (employees[t.Id].Password == t.Password)
                    return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            employees.Remove(id);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}