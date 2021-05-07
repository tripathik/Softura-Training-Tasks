using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TransportDALLibrary
{
    public class DriverDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        string strConnection;

        public DriverDAL()
        {
            strConnection = @"server=DESKTOP-EBPUJ98\SQLEXPRESS;Integrated security=true; Initial catalog=dbSofTransport";
            con = new SqlConnection(strConnection);
        }

        public bool DriverAdd(Driver driver)
        {
            cmd = new SqlCommand("proc_InsertDrivers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eName", driver.Name);
                cmd.Parameters.AddWithValue("@ePhone", driver.Phone);
                cmd.Parameters.AddWithValue("@eStatus", driver.Status);
                cmd.Parameters.AddWithValue("@eArea", driver.Area);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateDriverPhone(Driver driver)
        {
            cmd = new SqlCommand("proc_UpdateDriversPhone", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eId", driver.Id);
                cmd.Parameters.AddWithValue("@ePhone", driver.Phone);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateDriverStatus(Driver driver)
        {
            cmd = new SqlCommand("proc_UpdateDriversStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eId", driver.Id);
                cmd.Parameters.AddWithValue("@eStatus", driver.Status);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public ICollection<Driver> SelectAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            SqlCommand cmd = new SqlCommand("proc_GetAllDrivers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daDriver = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();//collection of datatables
            try
            {
                daDriver.Fill(ds, "Driver");
                Driver driver;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    driver = new Driver();
                    driver.Id = Convert.ToInt32(dr[0]);
                    driver.Name = dr[1].ToString();
                    driver.Phone = dr[2].ToString();
                    driver.Status = dr[3].ToString();
                    driver.Area = dr[3].ToString();
                    drivers.Add(driver);
                }
                return drivers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
