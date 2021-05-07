using System;
using TransportDALLibrary;
using System.Collections.Generic;
using System.Linq;
namespace TransportBLLibrary
{
    public class DriverBL : IRepos<Driver>
    {
        DriverDAL dal;
        public DriverBL()
        {
            dal = new DriverDAL();
        }
        public bool Add(Driver t)
        {
            try
            {
                return dal.DriverAdd(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<Driver> GetAll()
        {
            List<Driver> drivers;
            try
            {
                drivers = dal.SelectAllDrivers().ToList();
                return drivers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateDriverPhone(int id, Driver t)
        {
            try
            {
                return dal.UpdateDriverPhone(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateDriverStatus(Driver t)
        {
            try
            {
                return dal.UpdateDriverStatus(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
