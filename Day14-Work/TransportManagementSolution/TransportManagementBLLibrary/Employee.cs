using System;
using System.Diagnostics.CodeAnalysis;

namespace TransportManagementBLLibrary
{
    public class Employee :IComparable<Employee>
    {
        const string DEFAULT_PASSWORD = "1234";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public Employee() //default constructor
        {
            Password = DEFAULT_PASSWORD;
        }

        public Employee(int id, string name, string location, string phone, string password)
        {
            Id = id;
            Name = name;
            Location = location;
            Phone = phone;
            Password = password;
        }
        public void GetEmployeeDetails()
        {
            Console.WriteLine("Please Enter the Employee Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Please Enter the employee Phone");
            Phone= Console.ReadLine();
            Console.WriteLine("Please Enter the employee Location");
            Location = Console.ReadLine();
        }
        public override string ToString()
        {
            string maskPassword = GetMaskedPassword(Password);
            return "Employee Id: " + Id + " Name: " + Name + " Phone: " + Phone + "Location: " + Location + " Password:  " + maskPassword;
        }

        private string GetMaskedPassword(string password)
        {
            string result = password.Substring(0, 2);
            for (int i = 0; i < password.Length; i++)
            {
                result = result + "*";
            }
            return result;
        }

        public int CompareTo([AllowNull] Employee other)
        {
            return this.Location.CompareTo(other.Location);
        }
    }
}
