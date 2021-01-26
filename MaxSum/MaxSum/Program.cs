using System;
using System.Linq;

namespace MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = new int[] { 5, 8, 3, 7, 9, 1 };
            // Answer is 3: 5,7,9
            Console.WriteLine(MaxSum(sequence));
        }

        private static int MaxSum(int [] sequence)
        {
            int[] T = new int[sequence.Length];
            T[0] = sequence[0];
            for (int i = 0; i < sequence.Length; i++)
			{
                T[i] = sequence[i];
                for(int j = 0; j <= i; j++)
                {

                    Console.WriteLine("j position: "+sequence[j]);
                    if(sequence[j] < sequence[i])
                    {
                        T[i] = sequence[i] +Math.Max(T[i-1], 0);
                    }
                }
			}
            return T.Max();
        }
    }
}
