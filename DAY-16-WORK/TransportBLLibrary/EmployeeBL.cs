using System;
using TransportDALLibrary;
using System.Collections.Generic;
using System.Linq;
namespace TransportBLLibrary
{
    public class EmployeeBL : IRepo<Employee>, IUserLogin<Employee>
    {
        EmployeeDAL dal;
        public EmployeeBL()
        {
            dal = new EmployeeDAL();
        }
        public bool Add(Employee t)
        {
            try
            {
                return dal.AddEmployee(t);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ICollection<Employee> GetAll()
        {
            List<Employee> employees;
            try
            {
                employees = dal.SelectAllEmployees().ToList();
                return employees;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Login(Employee t)
        {
            bool result = false;
            try
            {
                List<Employee> employees = GetAll().ToList();
                //Select * from tblEmployee where id=@id and password=@password
                Employee employee = employees.Find(e => e.Id == t.Id && e.Password == t.Password);
                if (employee != null)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Update(Employee t)
        {
            try
            {
                return dal.UpdatePassword(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
