using System;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstEg
{
    class Program
    {
        //public static EFContext db = new EFContext();
        public static Product p = new Product();
        static void Main(string[] args)
        {
            PrintMenu();
            Console.ReadKey();
        }

        private static void InsertData(Product p1)
        {
            using(var db=new EFContext())
            {
                db.Products.Add(p1);
                db.SaveChanges();
                Console.WriteLine("Data added to database successfully");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!....................................!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("                                                                  ");
            }
        }
        private static Product AcceptData()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Please Enter the Product Name");
                p.Pname = Console.ReadLine();
                Console.WriteLine("Please Enter the price");
                p.Price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter the Quantity");
                p.Qty = Convert.ToInt32(Console.ReadLine());
                return p;
            }
            
        }
        private static void DisplayProducts()
        {
            using (var db = new EFContext())
            {
                foreach (var item in db.Products)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!....................................!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("                                                                  ");
            }
           
        }

        private static Product GetProductById(int id)
        {
            using(var db=new EFContext())
            {
                p = db.Products.Find(id);
            }
            return p;
        }

        private static void UpdateProducts()
        {
            using(var db=new EFContext())
            {
                Console.WriteLine("Please enter the id for whivh you want to update the record");
                int id = Convert.ToInt32(Console.ReadLine());
                p = GetProductById(id);
                Console.WriteLine(p.ToString());
                p = AcceptData();
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                Console.WriteLine("Data Updated SuccessFully");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!....................................!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("                                                                  ");

            }
        }

        private static void DeleteData()
        {
            using (var db = new EFContext())
            {
                Console.WriteLine("Please enter the id that need to be delete");
                int id = Convert.ToInt32(Console.ReadLine());
                p = GetProductById(id);
                if (p == null)
                {
                    Console.WriteLine("No such Record Exists");
                }
                else
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                    Console.WriteLine("Data has been deleted Successfully");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!....................................!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("                                                                  ");
                }
            }
        }
        private static void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("MENU DETAILS:");
                Console.WriteLine("                                                                  ");
                Console.WriteLine("Select Your Choice");
                Console.WriteLine("1. Create Products to the Database");
                Console.WriteLine("2. Print/Read all the products");
                Console.WriteLine("3. Update the Products");
                Console.WriteLine("4. Delete the product from Database");
                Console.WriteLine("5. Exit From the Application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Product p1 = AcceptData();
                        InsertData(p1);
                        break;
                    case 2:
                        DisplayProducts();
                        break;
                    case 3:
                        UpdateProducts();
                        break;
                    case 4:
                        DeleteData();
                        break;
                    case 5:
                        Console.WriteLine("Exiting........!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }
            } while (choice != 5);
        }
    }
}
