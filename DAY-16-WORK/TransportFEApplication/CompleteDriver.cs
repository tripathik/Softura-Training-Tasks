using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using TransportDALLibrary;

namespace TransportFEApplication
{
    public class CompleteDriver : Driver, IComparable<Driver>
    {
        public CompleteDriver()
        {

        }

        public CompleteDriver(Driver driver)
        {
            this.Id = driver.Id;
            this.Area = driver.Area;
            this.Name = driver.Name;
            this.Phone = driver.Phone;
            this.Status = driver.Status;
        }
        public void TakeDriverDetails()
        {
            Console.WriteLine("Please enter driver Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter driver Phone");
            Phone = Console.ReadLine();
            Console.WriteLine("Please enter driver apointed are");
            Area = Console.ReadLine();
            Console.WriteLine("Please enter driver status");
            Status = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Area: " + Area + " Status: " + Status;
        }
        public int CompareTo([AllowNull] Driver other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
