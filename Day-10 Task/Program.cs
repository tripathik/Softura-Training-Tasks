using System;

namespace FirstConsoleApplication
{
    class Program
    {
        static int num1, num2;//class level scope
        static void GetTwoNosfromUser()
        {
            Console.WriteLine("Please enter an num1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter an num2:");
            num1 = Convert.ToInt32(Console.ReadLine());
            
        }
        static void FirstMethod()
        {
            //Console.WriteLine("Hey Krishna ,,,,this is my first method");
            Console.WriteLine("Please enter something,,,,,,");
            string data = Console.ReadLine();
            Console.WriteLine("User Entered: "+data);
        }
        static void DealingNumbers()
        {
            GetTwoNosfromUser();
            Console.WriteLine("Please enter an num1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            num1 = num1 * 100;
            Console.WriteLine("The answer is:"+num1);
        }

        static void Calculate()
        {
            GetTwoNosfromUser();
            Console.WriteLine("Please enter first Number:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter 2nd Number:");
            num2 = Int32.Parse(Console.ReadLine());
            int sum=num1+num2;
            Console.WriteLine("The sum of the numbers {0} and {1} is {2}:",num1,num2,sum);
        }


        //print greater of two


        static void PrintDayWeek()
        {
            Console.WriteLine("Please enter a Day");
            string Day = Console.ReadLine();
            switch (Day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                    Console.WriteLine("Weekday");
                    break;
                case "Friday":
                    Console.WriteLine("Weekday is going to end");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("invalid day");
                    break;

            }
        }

        static void IterationUnderstanding()
        {
            //for-finite iteration
            // for(init;cond;updat)
            //first time init, cond
            //then on upd and aond
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("For loof ended");

        }


        static void IterationUnderstandingUsingWhile()
        {
            //  int flag = 0, sum = 0;
            //while(flag>=0)
            //  {
            //      sum += flag;
            //      Console.WriteLine("Please enter number");
            //      flag = Convert.ToInt32(Console.ReadLine());
            //  }

            //  Console.WriteLine("The sum is " +sum);


            int flag = -1, sum = 0;
            do
            {
                Console.WriteLine("enter");
                flag = Convert.ToInt32(Console.ReadLine());
                sum += flag;
            } while (flag >= 0);
            Console.WriteLine("the sum is :" + sum);
            
        }


        static void UnderStandingErrorHandling()
        {
            int num = 0;
            Console.WriteLine("Please enter any ingteger");
            //num = Int32.Parse(Console.ReadLine());
            //bool check = Int32.TryParse(Console.ReadLine(), out num);
            while (Int32.TryParse(Console.ReadLine(), out num) == false)
                Console.WriteLine("Invalid input, please enter an integer");

            Console.WriteLine("The number is:" + num);
        }






        //.............................................................DAY-10 TASK..............................................................

        //1) write a method that will check if a given number is even or not
        static void EvenOddNumm()
        {
            int num, rem;
            Console.Write("Check whether a number is even or odd :\n");        
            Console.Write("Input an integer : ");
            num = Convert.ToInt32(Console.ReadLine());
            rem = num % 2;
            if (rem == 0)
                Console.WriteLine("{0} is an even integer.", num);
            else
                Console.WriteLine("{0} is an odd integer.", num);
        }



        //2) Take numbers from user until the user enters a negative number and Print the sum of the numbers that are divisible by 7


        static void CheckNumDivisibleBy7()
        {
            int flag = 0, sum = 0;
            while (flag >= 0)
            {
                Console.WriteLine("Enter the number");
                flag = Convert.ToInt32(Console.ReadLine());
                if (flag % 7 == 0)
                {
                    sum += flag;
                }
            }
            Console.WriteLine("Sum of numbers which are divisble by 7 is " + sum);


        }



        //3) Take a minimum and a maximum number from user and print all teh prime numebrs in teh range

        static void PrintNumInRange()
        {
            int number, i, from, to,count;
            Console.Write("Enter the starting number: ");
            from = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the ending number : ");
            to = Convert.ToInt32(Console.ReadLine());
            Console.Write("The prime numbers between {0} and {1} are : \n", from, to);

            for (number = from; number <= to; number++)
            {
                count= 0;

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

        }



        //4) Take teh username and password from user and check if it is "Ramu" and "1234". If yes print welcome else
        //ask teh user to try again If teh user enters the wrong values for 3 times inform the user that teh account is locked

        static void CheckUserAndPassword()
        {
            string name, password;
            int count = 0;
            do
            {
                Console.Write("Enter Name");
                name = Console.ReadLine();

                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                if (name != "Ramu" || password != "1234")
                    count = count + 1;
                else
                    count = 1;
                Console.Write("Try again");

            }
            while ((name != "Ramu" || password != "1234") && (count != 3));

            if (count== 3)

                Console.Write("You account is locked");
            else
                Console.Write("Welcome");
}


        //5) Create a program that will take 2 numbers and then ask the user for teh operation + or - or * or / Based on tehuser input perform teh operation and print the result
        static void NumOperation()
        {
            int num1, num2;
            string operators;
            Console.WriteLine("Enter two numbers:");
            num1= Convert.ToInt32(Console.ReadLine());
            num2= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any Operators:");
            operators = Console.ReadLine();
            switch(operators)
            {

                case "+":
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
                    break;
                case "-":
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 - num2);
                    break;
                case "*":
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 * num2);
                    break;
                case "/":
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 / num2);
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
        }

        static void Main(string[] args)
        {
            //FirstMethod();
            //DealingNumbers();
            //Calculate();
            //IterationUnderstandingUsingWhile();
            //UnderStandingErrorHandling();
            //EvenOddNumm();
            //PrintNumInRange();
            NumOperation();
        }
    }
}
