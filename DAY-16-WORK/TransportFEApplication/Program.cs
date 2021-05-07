using System;
using TransportDALLibrary;
using TransportBLLibrary;
namespace TransportFEApplication
{
    class Program
    {
        EmployeeLogin login;
        EmployeeManagement management;
        EmployeeBL bl;
        DriverBL drivers;
        DriverManagement driver;

        public Program()
        {
            bl = new EmployeeBL();
            drivers = new DriverBL();
            login = new EmployeeLogin(bl);
            management = new EmployeeManagement(bl);
            driver = new DriverManagement(drivers);
        }

        void PrintMenu()
        {
           int  choice = 0;
            do
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Print All");
                Console.WriteLine("4. Sort and Print All");
                Console.WriteLine("5. Update Password");
                Console.WriteLine("6. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        login.RegisterEmployee();
                        break;
                    case 2:
                        login.UserLogin();
                        break;
                    case 3:
                        management.PrintAllEmployee();
                        break;
                    case 4:
                        management.PrintEmployeesSortedById();
                        break;
                    case 5:
                        management.ResetPassword();
                        break;
                    case 6:
                        Console.WriteLine("Exiting........!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }

            } while (true);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().PrintMenu();
            Console.ReadKey();
        }
    }
}
