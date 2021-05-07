using System;
using System.Collections.Generic;
using System.Text;

namespace TransportDALLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Location{ get; set; }
        public string VehicleNumber{ get; set; }

        public override string ToString()
        {
            
            return "ID :" + Id + " Name : " + Name + " Location : " + Location + " Phone : " + Phone + " Password: " + Password;
        }
    }
}
