using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ExploreDb
{
    class Program
    {
        public void SelectBooks_Authors()
        {
            
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Books b join tbl_author a on a.AuthorId=b.AuthorId", con);
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
                Console.WriteLine(read["BookId"] + " " + read["AuthorId"] + " " + read["AuthorName"] + " " + read["Title"] + " " + read["Price"].ToString());
            con.Close();

        }
        public void InsertAuthor()
        {
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("insert into tbl_author values('Rajeev Bhatt')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public void DeleteAuthor()
        {
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_author WHERE AuthorId=109", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Author Deleted Successfully!!!!!!!!");

        }
        public void UpdateBooks()
        {
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update tbl_Books set Title='The wars of Mind' where AuthorId=102";
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Server is not working, or something went wrong!!!!!");
            }
            finally
            {
                con.Close();
            }
        }
        public string SP_UpdateBooks(string title, double price, int bid)
        {
            string res = null;
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_UpdBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = bid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "SUCCESS";
            return res;
            
        }
        public string SP_DeleteBooks(int bid)
        {
            string res = null;
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_DelBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@BookId", SqlDbType.Int).Value = bid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "SUCCESS";
            return res;

        }
        public string BookSP(string title,int aid,double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorId", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@Title";
            //p1.SqlDbType = SqlDbType.VarChar;
            //p1.Value = title;
            //cmd.Parameters.Add(p1);
            //SqlParameter p2 = new SqlParameter();
            //p2.ParameterName = "@AuthorId";
            //p2.SqlDbType = SqlDbType.Int;
            //p2.Value = aid;
            //cmd.Parameters.Add(p2);
            //SqlParameter p3 = new SqlParameter();
            //p3.ParameterName = "@Price";
            //p3.SqlDbType = SqlDbType.Money;
            //p3.Value = price;
            //cmd.Parameters.Add(p3);
            con.Open(); 
            cmd.ExecuteNonQuery();
            con.Close();
            res = "SUCCESS";
            return res;
        }
       
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values('Harry Potter',103,950)", con);
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values('Harry Potter',103,950)", con);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into tbl_Books values('Two States',101,782)";
            //cmd.Connection = con;
            string qry = "insert into tbl_Books values(@Title,@authorId,@Price)";
            SqlCommand cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@Title", "Game of Thrones");
            cmd.Parameters.AddWithValue("@AuthorId", 102);
            cmd.Parameters.AddWithValue("@Price", 720);
            try 
            { 
            con.Open();
            cmd.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                Console.WriteLine("Server is not working, or something went wrong!!!!!");
            }
            finally
            {
                con.Close();
            }
            
        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            obj.SP_DeleteBooks(10009);
            obj.SelectBooks_Authors();
            
            //obj.SP_UpdateBooks("Blind Devil",579,10020);
            //obj.DeleteAuthor();
            //obj.InsertAuthor();
            //obj.InsertBooks();
            //obj.UpdateBooks();
            //obj.BookSP("Mind Master V3",107,750);
            //SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            //SqlCommand cmd = new SqlCommand("select * from tbl_Books", con);
            //con.Open();
            //SqlDataReader read = cmd.ExecuteReader();
            //while (read.Read())
            //    Console.WriteLine(read["BookId"] + " " + read["Title"] + " " + read["Price"].ToString());
            //con.Close();
            Console.ReadLine();

           
        }
    }
}
