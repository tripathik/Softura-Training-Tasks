//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LINQEgProject
//{
//    class StudentsClient
//    {
//        public static List<Student> students = new List<Student>();
//        public static void Main()
//        {
//            //List<Student> students = new List<Student>();
//            //students.Add(new Student(1, "Rajeev Shukla", 32, DateTime.Now, "Pune"));
//            //students.Add(new Student(2, "Ramu", 29, DateTime.Now, "Unknown Location"));
//            //students.Add(new Student(3, "Rahul", 40, DateTime.Now, "Chennai"));
//            //students.Add(new Student(4, "Azzu", 26, DateTime.Now, "Gorakhpur"));
//            //students.Add(new Student(5, "Sudheer Gupta", 24, DateTime.Now, "BadahalGanj"));
//            //students.Add(new Student(6, "Ripu Daman", 30, DateTime.Now, "Bihar"));
//            //students.Add(new Student(7, "Atish Pratap", 34, DateTime.Now, "Sikkim"));
//            Console.WriteLine("Please enter the number of students");
//            int size = Convert.ToInt32(Console.ReadLine());
//            for (int i = 0; i < size; i++)
//            {
//                Student s = new Student();
//                Console.WriteLine("please enter Student Id, Name, Marks,Doj and City");
//                s.StudentId = Convert.ToInt32(Console.ReadLine());
//                s.StudentName = Console.ReadLine();
//                s.StudentMarks = Convert.ToInt32(Console.ReadLine());
//                s.StudentDOJ = Convert.ToDateTime(Console.ReadLine());
//                s.StudentCity = Console.ReadLine();
//                students.Add(s);
//            }
//            foreach (var item in students)
//            {
//                Console.WriteLine(item.ToString());
//            }
//            Console.WriteLine("Enter the city to be searched");
//            string SearchCity = Console.ReadLine();
//            var result = (from i in students
//                          where i.StudentMarks > 30 && i.StudentCity==SearchCity
//                          select i).ToList();
//            foreach (var item in result)
//            {
//                Console.WriteLine(item.ToString());
//            }
//            Console.WriteLine("Enter the Id to be searched");
//            int sid = Convert.ToInt32(Console.ReadLine());
//            Student s1 = (from i in students
//                         where i.StudentId == sid
//                         select i).FirstOrDefault();
//            if(s1==null)
//            {
//                Console.WriteLine("invalid entry,please try again");
//            }
//            else
//            {
//                Console.WriteLine(s1.ToString());
//            }
            
//        }
//    }
//}
