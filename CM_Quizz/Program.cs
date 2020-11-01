using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CM_Quizz
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Null Checking
            string inputStr = "Hello Campaign Monitor!";            
            Console.WriteLine(string.Format("Input String = {0}, IsNullOrEmpty = {1} ", inputStr, Utility.IsNullOrEmptyString(inputStr)));            
            inputStr = "";
            Console.WriteLine(string.Format("Input String = {0}, IsNullOrEmpty = {1} ", inputStr, Utility.IsNullOrEmptyString(inputStr)));
            inputStr = null;
            Console.WriteLine(string.Format("Input String = {0}, IsNullOrEmpty = {1} ", inputStr, Utility.IsNullOrEmptyString(inputStr)));

            // Question 2: Divisors
            int inputNum = 60;
            int[] divisors = Utility.GetDivisors(inputNum);
            Console.Write("Divisors of " + inputNum + " = ");
            foreach (int i in divisors)
            {
                Console.Write(i + " ");
            }
            
            // Question 3: Triangle Area
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Triangle Area of (3, 4, 5): " + Utility.GetTriangleArea(3, 4, 5));
            }
            catch (InvalidTriangleException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            // Question 4: Most Common numbers
            int[] commons = Utility.GetMostCommonNums(new int[] { 5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 });
            Console.WriteLine("Most Common Numbers");
            Console.WriteLine("Input = { 5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 }");
            Console.Write("Output= ");
            for (int i = 0; i < commons.Length; i++)
            {
                Console.Write(commons[i] + " ");
            }            
            Console.ReadKey();
        }
               
    }
}
