using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVCWithADo.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt=new DataTable();
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select BookId,Title,AuthorId,Price from tbl_Books", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public int NewBook(string Title,int aid,Double Price)
        //{
        //    SqlConnection con = new SqlConnection(@"data source = LAPTOP-T6TDRH61\SQLEXPRESS; database=DbBooks; Integrated Security=true");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("sp_InsBook", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Title", Title);
        //    cmd.Parameters.AddWithValue("@AuthorId", aid);
        //    cmd.Parameters.AddWithValue("@Price", Price);
        //    return cmd.ExecuteNonQuery();
        //    con.Close();
            
        //}

        public DataTable DisplayAuthor()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"data source=LAPTOP-T6TDRH61\SQLEXPRESS;database=DbBooks;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select * from tbl_Author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewAuthor(string AuthorName)
        {
            SqlConnection con = new SqlConnection(@"data source = LAPTOP-T6TDRH61\SQLEXPRESS; database=DbBooks; Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsAuthor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", AuthorName);
            return cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}