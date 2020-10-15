using System;
using System.Linq;

namespace Multiplication
{
    public static class MultiplicationHelper
    {
        private static int[] tripleMax(int[] input)
        {
            int f = int.MinValue, s = int.MinValue, t = int.MinValue;
            foreach (var num in input)
            {
                if (num > f)
                {
                    t = s;
                    s = f;
                    f = num;
                }
                else if (num > s)
                {
                    t = s;
                    s = num;
                }
                else if (num > t)
                {
                    t = num;
                }
            }

            return new int[]{f, s, t};
        }
        private static int[] doubleMin(int[] input)
        {
            int f = int.MaxValue, s = int.MaxValue;
            foreach (var num in input)
            {
                if (num < f)
                {
                    s = f;
                    f = num;
                }
                else if (num < s)
                {
                    s = num;
                }
            }

            return new int[]{f, s};
        }

        public static int GetHighestProductOfThree(int[] input)
        {
            if (input.Length < 3){throw new ArgumentException();}
            if (input.Length == 3)
            {
                return input.Aggregate(1, (a, b) => a * b);
            }

            int[] maxes = tripleMax(input);
            int[] mins = doubleMin(input);
            
            return Math.Max(maxes.Aggregate(1, (a,b)=>a*b), maxes[0] * mins[0] * mins[1]);
            
        }
    }
}