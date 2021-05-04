using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionProject
{
    class ManageMovie
    {

        //List<Movie> movies;
        Dictionary<int, Movie> DictMovie;
        public ManageMovie()
        {
            DictMovie =new Dictionary<int, Movie>();
        }
        private int GenerateId()
        {
            if(DictMovie.Count==0)
                return 1;
            int id = DictMovie[DictMovie.Count - 1].Id;
            id++;
            return id;
        }
        public Movie CreateMovie()
        {
            Movie movie = new Movie();
            movie.Id = GenerateId();
            movie.TakeMovieDetails();
            return movie;
        }
        public int GetMovieIndexById(int id)
        {
            List<KeyValuePair<int, Movie>> mlist = DictMovie.ToList();
            return mlist.FindIndex(m => m.Key == id);//Lambda Expression
        }
        public Movie UpdateMovieName(int id, string name)
        {
            Movie movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                DictMovie[idx].Name = name;
                movie = DictMovie[idx];
            }
            return movie;
        }
        public void PrintMovieById()
        {
            Console.WriteLine("Please enter the movie Id to be printed");
            int id = Convert.ToInt32(Console.ReadLine());
            int idx = GetMovieIndexById(id);
            if (idx >=0)
                PrintMovie(DictMovie[idx]);
            else
                Console.WriteLine("No such movie");
        }

        private void DeleteMovie()
        {
            Console.WriteLine("Please enter the movie id to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                DictMovie.Remove(GetMovieIndexById(id));
            }
            catch (Exception e)
            {

                Console.WriteLine("Oops something went wrong,,, please try again");
            }
        }

        public Movie UpdateMovieDuration(int id, double duration)
        {
            Movie movie = null;
            int idx = GetMovieIndexById(id);
            if(idx!=-1)
            {
                DictMovie[idx].Duration = duration;
                movie = DictMovie[idx];
            }
            return movie;
        }

        private void PrintMovieById(int id)
        {
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                PrintMovie(DictMovie[idx]);
            }
            else
                Console.WriteLine("No such Movie");
        }

        public void PrintAllMovies()
        {
            if(DictMovie.Count==0)
            {
                Console.WriteLine("No movies Present");
            }
            else
            {
                foreach (var item in DictMovie.Keys)
                {
                    PrintMovie(DictMovie[item]);
                }
            }
        }
        void AddMovies()
        {
            int choice = 0;
            do
            {
                Movie movie = CreateMovie();
                DictMovie.Add(movie.Id,movie);
                Console.WriteLine("Do you wish to addanother movie?? if yes enter any number other than 0, to exit enter 0");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException format)
                {
                    Console.WriteLine("Not a correct input");
                }
            } while (choice!=0);
        }
        public void SortMovies()
        {
            if(DictMovie.Count!=0)
            {
                DictMovie.OrderBy(i => i.Key);
            }
            else
            {
                Console.WriteLine("No elemets to sort");
            }


                Console.WriteLine("No movies to be sorted");
        }
        public void PrintMovie( Movie movie)
        {
            Console.WriteLine("..........................");
            Console.WriteLine(movie);
            Console.WriteLine("...........................");
        }
        void UpdateMovie()
        {
            Console.WriteLine("Please enter the movie id For updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to update name or duation or both");
            string choice = Console.ReadLine();
            string name;
            double duration;
            switch(choice)
            {
                case "name":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    break;
                case "duration":
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(),out duration))
                    {
                        Console.WriteLine("Invalid Entry for duration please try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;

                case "both":
                    Console.WriteLine("Please enter the new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    Console.WriteLine("Please enter the new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid Entry for duration please try again");
                    }
                    UpdateMovieDuration(id, duration);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Add a list of movies");
                Console.WriteLine("3. Update the movie");
                Console.WriteLine("4. delete the movie");
                Console.WriteLine("5. Print the movie by id");
                Console.WriteLine("6. Print all the movie");
                Console.WriteLine("7. Sort movies");
                Console.WriteLine("8. Exit the application");

                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Movie movie = CreateMovie();
                        DictMovie.Add(movie.Id,movie);
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        UpdateMovie();
                        break;
                    case 4:
                        DeleteMovie();
                        break;
                    case 5:
                        PrintMovieById();
                        break;
                    case 6:
                        PrintAllMovies();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice!=8);
        }

        public static void Main(string[] a)
        {
            new ManageMovie().PrintMenu();
            Console.ReadKey();
        }

    }
}
