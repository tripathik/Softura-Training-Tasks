using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementBLLibrary;

namespace TransportManagementFEProject
{
    public class EmployeeCRUD
    {
        IRepo<Employee> repo;

        public EmployeeCRUD(IRepo<Employee> repo)
        {
            this.repo = repo;
        }

        public EmployeeCRUD() { }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            employee.GetEmployeeDetails();
            repo.Add(employee);
        }

        public void UpdateEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the id the need to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            repo.Update(id, employee);
        }

        public void PrintAllEmployee()
        {
            var employees = repo.GetAll();
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Please enter the id the need to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = repo.Get(id);
            if (employee == null)
                Console.WriteLine("Cannot delete. No such employee");
            else
                repo.Delete(id);
        }
    }
}