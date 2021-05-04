using System;
using System.Collections.Generic;
using System.Collections;

namespace CollectionProject
{
    class Program
    {

        List<int> numbers=new List<int>();
        /// <summary>
        /// take number from user until he enters negative numbers
        /// </summary>
        List<int> TakeNumbersFromUser()
        {
            List<int> numbers = new List<int>();
            int number = 0;
            do
            {
                Console.WriteLine("Please enter a number .Enter a negative number to quit");

                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    int result = 10 / number;
                    if (number >= 0)
                        numbers.Add(number);
                }
                catch (DivideByZeroException dbz)
                {

                    Console.WriteLine("We can not devide a number by zero");
                    Console.WriteLine(dbz.Message);
                }
                catch (FormatException frm)
                {

                    Console.WriteLine("We are expacting a number");
                    Console.WriteLine(frm.Message);
                }
                catch (OverflowException over)
                {

                    Console.WriteLine("The number is too long");
                    Console.WriteLine(over.Message);
                }

            } while (number >= 0);
              Console.WriteLine("The number of numbers is " + numbers.Count);
            if (numbers.Count == 0)
                //return null;
                numbers = null;
            return numbers;

        }
        void SortGivenNum()
        {
            //Take number from user
            List<int> myNum = TakeNumbersFromUser();
            //sort the numbers

            try
            {
                if(myNum!=null)
                {
                    myNum.Sort();
                    //print the sorted numbers
                    PrintTheCollection(myNum);
                }
                else
                {
                    Console.WriteLine("The colle tion is empty");
                }

            }
            
            catch (NullReferenceException nre)
            {

                Console.WriteLine("There are no numbers to sorted");
            }
        }
        private void PrintTheCollection(List<int> myNum)
        {
            if(myNum.Count>0)
            {
                foreach (var item in myNum)
                {
                    Console.WriteLine(item);
                }
            }
            
        }
        static void Main(string[] args)
        {
        //  new Program().SortGivenNum();
        //    Console.ReadKey();
        }
    }
}
