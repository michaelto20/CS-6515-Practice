using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CountThree
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = new int[] { 10, 13, 7, 8, 14, 11 };
            //Solution: [10,13,14,11], [10,13,11], [10,11], [10,7,8,11], [10,8,11]
            int[] A = new int[] { 10, 13, 7, 8, 14, 11, 16, 18 };
            //int[] A = new int[] { 10, 12 };
            Console.WriteLine(CountThree(A));
        }


        /// <summary>
        /// This way does not work... just merging for future ref. 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        private static int CountThree(int[] A)
        {
            int[] T = new int[A.Length];
            T[0] = 0;
            int fElm = A[0];
            int lElm = A[A.Length - 1];
            if (Math.Abs(fElm - lElm) <= 3)
            {
                T[0] = 1;
            }
            for (int i = 1; i < A.Length - 1; i++)
            {
                int numThreeChains = 0;

                if (Math.Abs(fElm - A[i]) <= 3)
                {
                    if (Math.Abs(lElm - A[i]) <= 3)
                    {
                        numThreeChains++;
                    }
                    int lastChain = A[i];
                    for (int j = i + 1; j < A.Length - 1; j++)
                    {
                        if (Math.Abs(lastChain - A[j]) <= 3 && Math.Abs(lElm - A[j]) <= 3)
                        {
                            lastChain = A[j];
                            numThreeChains++;
                        }
                    }
                }
                T[i] = numThreeChains;
            }
            return T.Sum();
        }

    }
}
