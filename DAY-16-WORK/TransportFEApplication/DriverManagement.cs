using TransportDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportBLLibrary;

namespace TransportFEApplication
{
    
        public class DriverManagement
        {
            IRepos<Driver> _repo;
            public DriverManagement()
            {

            }
            public DriverManagement(IRepos<Driver> repo)
            {
                _repo = repo;
            }

            public void CreateDriver()
            {
                CompleteDriver driver = new CompleteDriver();
                driver.TakeDriverDetails();
                try
                {
                    if (_repo.Add(driver))
                        Console.WriteLine("Driver added");
                    else
                        Console.WriteLine("Sorry cannot add the Driver");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not add Driver");
                    Console.WriteLine(e.Message);
                }
            }
            public void UpdateDriver()
            {
                Driver driver = new Driver();
                int choice = 0;
                do
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Update phone number");
                    Console.WriteLine("2. Update Driver status");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("---------------");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Please enter the id that need to be changed");
                            int id = Convert.ToInt32(Console.ReadLine());
                            _repo.UpdateDriverPhone(id, driver);
                            break;
                        case 2:
                            _repo.UpdateDriverStatus(driver);
                            break;
                        case 3:
                            Console.WriteLine("Exiting...........!!!");
                            break;
                        default:
                            Console.WriteLine("Invalied choice");
                            break;
                    }
                } while (choice != 3);
            }

            public List<Driver> GetAllDrivers()
            {
                List<Driver> drivers = _repo.GetAll().ToList();
                return drivers;
            }
            public void PrintAllDrivers()
            {
                var drivers = GetAllDrivers();
                foreach (Driver driver in drivers)
                {
                    Console.WriteLine(driver);
                }
            }
            public List<CompleteDriver> SortDriver()
            {
                List<CompleteDriver> drivers = new List<CompleteDriver>();
                foreach (var item in GetAllDrivers())
                {
                    drivers.Add(new CompleteDriver(item));
                }
                return drivers;
            }
            public void PrintDriversSortedById()
            {
                var drivers = SortDriver();
                drivers.Sort();
                foreach (Driver driver in drivers)
                {
                    Console.WriteLine(driver);
                }
            }
        }
    
}
