using System;
using System.Data;
using System.Data.SqlClient;
namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = @"server=DESKTOP-EBPUJ98\SQLEXPRESS;Integrated security=true; Initial catalog=pubs";
            con = new SqlConnection(conString);
        }
        void FetchMovieFromDatabase()
        {
            //string strcmd = "select * from authors where city='Oakland'";
            string strcmd = "select * from tblMovie";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Author Id : "+ drMovies[0].ToString());
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("--------------------------------------------");
                    
                }
                Console.WriteLine("The count of the total data is: "+ drMovies.FieldCount);
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }


        void FetchOneMovieFromDatabase()
        {
            //string strcmd = "select * from authors where city='Oakland'";
            string strcmd = "select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                con.Open();
                Console.WriteLine("Please enter the id");
                int id = Convert.ToInt32(Console.ReadLine());

                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Author Id : " + drMovies[0].ToString());
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("--------------------------------------------");

                }
                //Console.WriteLine("The count of the total data is: " + drMovies.FieldCount);
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void UpdateMovieDuration()
        {
            //Update tblMovie set Duration=@mduration where id=@mid
            Console.WriteLine("Please Enter Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set Duration=@mduration where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid",id);
            cmd.Parameters.AddWithValue("@mduration", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Duration Updated");
                else
                    Console.WriteLine("No no Not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        void DeleteMovie()
        {
            //insert into tblMovie(name, duration)values('X-Men', 123.2)"
            Console.WriteLine("Please Enter Movie Id to be deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            //string mName = Console.ReadLine();
            //float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "DELETE FROM tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            //cmd.Parameters.Remove(mDuration);
            //cmd.Parameters.Remove(mName);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Deleted Successfully");
                else
                    Console.WriteLine("No no Not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void AddMovie()
        {
            //insert into tblMovie(name, duration)values('X-Men', 123.2)"
            Console.WriteLine("Please Enter the Movie Name");
            string mName = Console.ReadLine();
            Console.WriteLine("Please Enter the duration");
            float mDuration = (float)Math.Round( float.Parse(Console.ReadLine()),2);
            string strCmd = "insert into tblMovie(name,duration)values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result>0)
                    Console.WriteLine("Movie Inserted");
                else
                    Console.WriteLine("No no Not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Create/Add Movie");
                Console.WriteLine("2. Read All the movies");
                Console.WriteLine("3. Read movies by Id");
                Console.WriteLine("4. Update Movie Duration");
                Console.WriteLine("5. Delete Movie");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Select your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        FetchMovieFromDatabase();
                        break;
                    case 3:
                        FetchOneMovieFromDatabase();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovie();
                        break;
                    case 6:
                        Console.WriteLine("Exiting........!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }
            } while (choice != 6);
        }
        static void Main(string[] args)
        {
           // new Program().AddMovie();
            //new Program().FetchMovieFromDatabase();
           //new  Program().FetchOneMovieFromDatabase();
           // new Program().UpdateMovieDuration();

           // new Program().DeleteMovie();
            new Program().PrintMenu();
            Console.ReadKey();
        }
    }
}
