using System;
using System.Linq;

namespace LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] sequence = new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            // answer should be 6: 0,2,6,9,13,15

            //int[] sequence = new int[] { 5, 8, 3, 7, 9, 1 };
            // Answer is 3: 5,7,9

            int[] sequence = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 3, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 3 };
            // Answer is 3: 0,1,3
            Console.WriteLine("Longest Increasing Subsequence Length: " + LIS(sequence));
        }

        private static int LIS(int[] sequence)
        {
            int[] T = new int[sequence.Length];
            for(int i = 0; i < sequence.Length; i++)
            {
                Console.WriteLine("i position: "+sequence[i]);
                T[i] = 1;
                for(int j = 0; j < i; j++)
                {
                    Console.WriteLine("j position: "+sequence[j]);
                    if(sequence[j] < sequence[i])
                    {
                        T[i] = Math.Max(T[i], T[j] + 1);
                    }
                }
                Console.WriteLine("sequence:       " + String.Join(',', sequence));
                Console.WriteLine("sequence count: " + String.Join(',', T));
            }

            return T.Max();
        }
    }
}
