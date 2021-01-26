using System;
using System.Linq;


namespace _3Chains
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = new int[] {10,13,7,8,14,11};
            // Answer is 5
            Console.WriteLine("Number of 3 chains: " + Chains(sequence));
        }

        private static int Chains(int[] sequence)
        {
            int[] T = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.WriteLine("i position: " + sequence[i]);
                //T[i] = 0;
                if(T[i] == 0 && i != 0)
                {
                    Console.WriteLine("Skipping as it's not connect to a chain");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine("j position: " + sequence[j]);
                    if (sequence[j] - 3 <= sequence[i] && sequence[j] + 3 >= sequence[i])
                    {
                        T[i] = Math.Max(T[i], T[j] + 1);
                    }
                }
                Console.WriteLine("sequence:       " + String.Join(',', sequence));
                Console.WriteLine("sequence count: " + String.Join(',', T));
            }

            return T[sequence.Length];
        }
    }

}
