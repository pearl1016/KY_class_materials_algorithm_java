using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciDP
{
    internal class Program
    {
        static long[] d = new long[51];

        static void Main(string[] args)
        {

            for (int i = 1; i <= 45; i++)
                Console.WriteLine(i + ": " + Fibonacci(i));

            for (int i = 1; i<=45; i++)
                Console.WriteLine(i + ": " + FibonacciDP(i));
        }

        private static long FibonacciDP(int i)
        {
            if (i == 1 || i == 2)
                return 1;
            else if (d[i] == 0)
            {
                d[i] = FibonacciDP(i - 1) + FibonacciDP(i - 2);
                return d[i];
            }

            else
                return d[i];
        }

        private static long Fibonacci(int i)
        {
            if (i == 1 || i == 2)
                return 1;
            else
                return Fibonacci(i - 1) + Fibonacci(i - 2);
        }
    }
}
