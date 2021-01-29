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
            int[] denominations = new int[] { 3,5,10 };
            Console.WriteLine(Problem6_17(denominations, 9));

            denominations = new int[] { 1, 5, 10, 20 };
            Console.WriteLine(Problem6_18(denominations, 30));

            denominations = new int[] { 1, 5, 10, 20 };
            Console.WriteLine(Problem6_18(denominations, 40));


            denominations = new int[] { 3, 5, 7, 15 };
            Console.WriteLine(Problem6_19(denominations, 20, 3));

            denominations = new int[] { 3, 5, 7, 15 };
            Console.WriteLine(Problem6_19(denominations, 16, 3));
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

        private static bool Problem6_18(int[] denominations, int V)
        {
            //T represents the number of coins needed to make this value
            int n = denominations.Length;
            bool[,] T = new bool[V+1,n];
            for (int i = 0; i < n; i++)
            {
                //when value is zero change can be made
                T[0, i] = true;
            }

            // loop all the way to V
            for (int v = 1; v <= V; v++)
            {
                for (int d = 1; d < denominations.Length; d++)
                {
                    var currentCoin = denominations[d];
   
                    if (currentCoin > v)
                    {
                        T[v, d] = T[v, d - 1];
                    }
                    else
                    {
                        //can change be made using this coin and the past coins or just this coin
                        T[v, d] = T[v - currentCoin, d - 1] || T[v, d - 1];
                    }

                }

            }
            return T[V,n-1];
        }

        private static bool Problem6_19(int[] denominations, int V, int k)
        {
            //T represents the number of coins needed to make this value
            int n = denominations.Length;
            int[] T = new int[V+1];
            T[0] = 0;

            // loop all the way to V
            for (int v = 1; v <= V; v++)
            {
                T[v] = 9999999;
                for (int d = 0; d < denominations.Length; d++)
                {
                    var currentCoin = denominations[d];
                    //current coin < current value && old min > minimum for this recurrence
                    if (currentCoin <= v && T[v] > 1 + T[v - currentCoin])
                    {
                        T[v] = 1 + T[v - currentCoin];
                    }
                }
            }
            return (T[V] < k);
        }
    }
}
