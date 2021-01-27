using System;

namespace LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] X = new string[] { "b", "c", "d", "b", "c", "d", "a" };
            string[] Y = new string[] { "a", "b", "e", "c", "b", "a", "b" };
            // Answer 4: b,c,b,a
            Console.WriteLine("LCS: "+LCS(X,Y));
        }

        private static int LCS(string[] X, string[] Y)
        {
            int[,] L = new int[X.Length + 1, Y.Length + 1];
            for(int i = 1; i < X.Length +1; i++)
            {
                Console.WriteLine("i: " + i);
                Console.WriteLine("i value: " + X[i - 1]);
                for (int j = 1; j < Y.Length+1; j++)
                {
                    Console.WriteLine("j: " + j);
                    Console.WriteLine("j value: " + Y[j - 1]);

                    if (X[i - 1] == Y[j - 1])
                    {
                        L[i, j] = 1 + L[i - 1, j - 1];
                    }
                    else
                    {
                        L[i, j] = Math.Max(L[i, j - 1], L[i - 1, j]);
                    }
                }
            }

            return L[X.Length, Y.Length];
        }
    }
}
