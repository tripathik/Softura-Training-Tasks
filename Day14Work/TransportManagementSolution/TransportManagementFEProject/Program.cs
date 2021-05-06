using System;
using TransportManagementBLLibrary;

namespace TransportManagementFEProject
{
    class Program
    {
        EmployeeLogin login;
        EmployeeRepo employeeRepo;
        EmployeeCRUD employeeCRUD;
        public Program()
        {
            employeeRepo = new EmployeeRepo();
            login = new EmployeeLogin(employeeRepo);
            employeeCRUD = new EmployeeCRUD(employeeRepo);
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Print All Records");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Select your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        login.Login();
                        break;
                    case 2:
                        login.Register();
                        break;
                    case 3:
                        employeeCRUD.PrintAllEmployee();
                        break;
                    case 4:
                        employeeCRUD.UpdateEmployee();
                        break;
                    case 5:
                        employeeCRUD.DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting........!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }
            } while (choice != 6);
        }
        static void Main(string[] args)
        {
            
            new Program().PrintMenu();
            Console.ReadKey();
        }
    }
}