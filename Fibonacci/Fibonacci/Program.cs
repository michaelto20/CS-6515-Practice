using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(6));
        }

        private static int Fib(int fibNum)
        {
            if (fibNum == 0)
            {
                return 0;
            }
            else if (fibNum == 1)
            {
                return 1;
            }
            else
            {
                // Generate Fibonnaci sequence
                int[] fibs = new int[fibNum + 1];
                fibs[0] = 0;
                fibs[1] = 1;
                for (int i = 2; i <= fibNum; i++)
                {
                    fibs[i] = fibs[i - 1] + fibs[i - 2];
                }

                return fibs[fibNum];
            }
        }
    }
}
