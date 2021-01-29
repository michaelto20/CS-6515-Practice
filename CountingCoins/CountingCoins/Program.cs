using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace CountingCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] sequence = new int[] { 5, 8, 3, 7, 9, 1 };
            // Answer is 19: 3+7+9
            int[] denominations = new int[] { 2,5,10 };
            Console.WriteLine(Problem6_17(denominations, 17));
        }

        private static bool Problem6_17(int [] denominations, int V)
        {
            //T represents the number of coins needed to make this value
            bool[] T = new bool[V+1];
            T[0] = true;

            // loop all the way to V
            for (int v = 1; v <= V; v++)
			{
                for(int d = 0; d < denominations.Length; d++)
                {
                    if (v < denominations[d])
                    {
                        break;
                    }
                    T[v] = T[v- denominations[d]];
                }
                
            }
            return T[V];
        }
    }
}
