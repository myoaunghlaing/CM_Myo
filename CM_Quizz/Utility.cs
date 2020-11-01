using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM_Quizz
{
    public static class Utility
    {
        public static bool IsNullOrEmptyString(string str)
        {
            return (str == null || str == String.Empty) ? true : false;
        }

        public static int[] GetDivisors(int num)
        {
            List<int> divisors = new List<int>();

            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    divisors.Add(i);
                    if (num / i != i)
                    {
                        divisors.Add(num / i);
                    }
                }
            }
            return divisors.OrderBy(x => x).ToArray();
        }

        public static double GetTriangleArea(int a, int b, int c)
        {
            double area = 0;

            if (a < 0 || b < 0 || c < 0)
            {
                throw new InvalidTriangleException("Length cannot be negative");
            }

            if (a + b < c || a + c < b || b + c < a)
            {
                throw new InvalidTriangleException("The three sides cannot form a triangle");
            }

            double halfparimeter = (a + b + c) / 2.0;
            area = Math.Sqrt(halfparimeter * (halfparimeter - a) * (halfparimeter - b) * (halfparimeter - c));
            return area;
        }

        public static int[] GetMostCommonNums(int[] inputNums)
        {
            List<int> comNums = new List<int>();
            var numByGroup = inputNums.GroupBy(num => num).OrderByDescending(num => num.Count());

            foreach (var g in numByGroup)
            {
                if (g.Count() == numByGroup.First().Count())
                {
                    comNums.Add(g.Key);
                }
            }
            return comNums.ToArray();

        }
    }
}
