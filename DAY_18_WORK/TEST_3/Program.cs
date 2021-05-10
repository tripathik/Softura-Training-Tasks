using System;
using System.Collections.Generic;
namespace EvaluationTest_3Project
{
    class Program
    {



        void PrintAllQuestion()
        {
            Console.WriteLine("Questions List");
            int choice = 0;
            do
            {
                Console.WriteLine("Please Select Question Number");
                Console.WriteLine("1. Divisible By 7");
                Console.WriteLine("2. Prime Numbers Between min and max value");
                Console.WriteLine("3. Repeating numbers returns once negative number entered");
                Console.WriteLine("4. Sort the numbers once 0 entered");
                Console.WriteLine("5. Check The UserName and Password");
                Console.WriteLine("6. Cow & Bull Game Program");
                Console.WriteLine("7. Card Validation Program");
                Console.WriteLine("8. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DivisableBySeven1();
                        break;
                    case 2:
                        PrintNumInRange2();
                        break;
                    case 3:
                        RepetationOfNumbers3();
                        break;
                    case 4:
                        SortingUserNum4();
                        break;
                    case 5:
                        CheckUserAndPassword5();
                        break;
                    case 6:
                        CowsAndBulls6();
                        break;
                    case 7:
                        CreditCardValidation7();
                        break;
                    case 8:
                        Console.WriteLine("Exiting........");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }

            } while (choice!=8);
        }
        void DivisableBySeven1()
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Please enter the number");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Numbers divisible by 7 are");
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] % 7 == 0)
                {
                    Console.WriteLine(arr[j]);
                }
            }
        }


        void PrintNumInRange2()
        {
            int number, i, from, to, count;
            Console.Write("Enter the starting number: ");
            from = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the ending number : ");
            to = Convert.ToInt32(Console.ReadLine());
            if (to < from)
            {
                Console.WriteLine("Invalid Entry......, Please Try Again");
            }
            else
            {
                for (number = from; number <= to; number++)
                {
                    count = 0;
                    for (i = 2; i <= number / 2; i++)
                    {
                        if (number % i == 0)
                        {
                            count++;
                            break;
                        }
                    }

                    if (count == 0 && number != 1)
                        Console.Write("{0} ", number);
                }
                Console.Write("The prime numbers between {0} and {1} are : \n", from, to);
            }
        }


        static void RepetationOfNumbers3()
        {
            int num1 = 0;
            List<int> list = new List<int>();
            while (num1 >= 0)
            {
                Console.WriteLine("Please enter the numbers:");
                num1 = Int32.Parse(Console.ReadLine());
                list.Add(num1);
            }
            Console.WriteLine("The Repeating numbers are");
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        Console.WriteLine(list[i]);
                    }
                }
            }
        }

        static void SortingUserNum4()
        {
            var NumberList = new List<int>();
            int input = Convert.ToInt32(Console.ReadLine());
            while (input != 0)
            {
                if (input > 0)
                    NumberList.Add(input);
                input = Convert.ToInt32(Console.ReadLine());

            }
            NumberList.Sort();
            foreach (var item in NumberList)

            {
                Console.WriteLine(item);
            }
        }

        static void CheckUserAndPassword5()
        {
            string name, password;
            int count = 0;
            do
            {
                Console.Write("Enter the Name:");
                name = Console.ReadLine();
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                if (name != "Admin" || password != "admin")
                    count = count + 1;
                else
                    count = 1;
                Console.Write("Ivalid UserName or Password");
                Console.WriteLine("     ");
            }
            while ((name != "Admin" || password != "admin") && (count != 3));
            if (count == 3)
                Console.Write("You already tried 3 times your account is locked!!!!!!    Please Contact Admin");

            else
                Console.Write("Welcome");
        }

        static void CowsAndBulls6()
        {
            string[] arr = { "kite", "four", "neat", "play", "goal" };

            Console.WriteLine("Play.......");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter the guess");
                string GuessWord = Console.ReadLine();
                string guess = arr[i];
                int cow = 0, bulls = 0;
                if (guess.Length == GuessWord.Length)
                {
                    
                    for (i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == GuessWord[i])
                        {
                            cow += 1;
                        }
                        else
                        {
                            for (int j = 0; j < guess.Length; j++)
                            {
                                if (guess[i] == GuessWord[j] && i != j)
                                {
                                    bulls += 1;
                                }
                            }
                        }
                        Console.WriteLine("Cows--" + cow + " Bulls--" + bulls);
                    }
                   
                    if (cow == guess.Length)
                    {
                        Console.WriteLine("Congratulations You Won the Game");
                    }
                    Console.WriteLine("                    ");
                }
                else
                {
                    Console.WriteLine("Must enter " + guess.Length + " letter a Word");
                    Console.WriteLine("");
                }
            }
            
        }
        static void CreditCardValidation7()
        {
            Console.WriteLine("Enter card Number");
            string num1 = Console.ReadLine();
            Console.WriteLine("Enter year");
            int Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month");
            int Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day");
            int Day = Convert.ToInt32(Console.ReadLine());
            DateTime dt = new DateTime(Year, Month, Day);
            Console.WriteLine("Enter the CVV on credit card");
            string num2 = Console.ReadLine();
            string RevrerseString = string.Empty;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                RevrerseString += num1[i];
            }
            Console.WriteLine(RevrerseString);
            int num, num3, sum = 0, num4 = 0, num5 = 0;
            for (int i = 0; i < RevrerseString.Length; i++)
            {
                char v = RevrerseString[i];
                num = (int)Char.GetNumericValue(v);
                if (i % 2 == 0)
                {
                    num3 = num * 2;
                    num5 += num3;
                }
                else
                {
                    num4 += num;
                }
                sum = num5 + num4;
            }
            int value = dt.CompareTo(DateTime.Today);
            if ((num1.Length == 16 || num1.Length == 15) && (value > 0) && (num2.Length == 3) && (sum % 10 == 0))
            {
                Console.WriteLine("Congratulations Your Credit card Is Valid");
            }
            else if ((num1.Length != 16 & num1.Length > 16) || (num1.Length != 15 & num1.Length < 15))
            {
                Console.WriteLine("Invalied Credit Card Number");
            }
            else if (num2.Length != 3)
            {
                Console.WriteLine("Invalied CVV ");
            }
            else if (value < 0)
            {
                Console.WriteLine("Your card has been expired");
            }
            else if (sum % 10 != 0)
            {
                Console.WriteLine("Incorrect Card Number");
            }
            else
            {
                Console.WriteLine("Details are invalid");
            }
        }
        
        static void Main(string [] a)
        {
            //CowsAndBulls9();
            Program p = new Program();
            p.PrintAllQuestion();
        }
    }
}