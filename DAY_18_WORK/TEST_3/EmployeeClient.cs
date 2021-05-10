using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LINQEgProject.PubsModel;

namespace LINQEgProject.PubsModel
{
    class EmployeeClient
    {
        public static pubsContext db = new pubsContext(); 
        public static  void Main()
        {
            List<Employee> emps = db.Employees.ToList();
            var result = (from i in emps
                          where i.JobId==5
                          select i).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.EmpId+ "  : " + item.Fname + "  : "+item.Lname + "  :"+  item.HireDate );
            }
            Console.WriteLine("     ");
            Console.WriteLine("The Total Count of Data is: " + result.Count());
        }
    }
}
