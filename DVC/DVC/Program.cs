using System;
using System.Collections.Generic;
using System.Linq;


namespace _3Chains
{
    class Program
    {
        static void Main(string[] args)
        {
            int Min = 0;
            int Max = 100;
            Random randNum = new Random();
            int[] input = Enumerable
                .Repeat(0, 16)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();

            //var result = MergeSort(input);
            var result = BestWorst(input, 0);
        }

        private static int[] BestWorst(int[] input, int level)
        {
            List<int> badList = new List<int>();
            List<int> goodList = new List<int>();

            for (int i = 0; i < input.Length; i+=2)
            {
                Console.WriteLine($"I = {input[i]}, I+1={input[i + 1]}");
                if (input[i] > input[i + 1])
                {
                    badList.Add(input[i + 1]);
                    goodList.Add(input[i]);
                }
                else
                {
                    goodList.Add(input[i + 1]);
                    badList.Add(input[i]);
                }
            }

            if (goodList.Count + badList.Count == 2)
            {
                return badList.Concat(goodList).ToArray();
            }
            else
            {
                if (level == 0)
                {
                    return BestWorst(badList.Concat(goodList).ToArray(), level+1);
                }
                else
                {
                    var quarter = input.Length / 4;
                    var firstQuarter = badList.Take(quarter);
                    var lastQuarter = goodList.Skip(quarter);
                    return BestWorst(firstQuarter.Concat(lastQuarter).ToArray(), level + 1);
                }
                
            }
        }

        private static int[] MergeSort(int[] input)
        {
            int[] left;
            int[] right;
            if (input.Length <= 1)
            {
                return input;
            }
            int middle = input.Length / 2;
            left = input.Take(middle).ToArray();
            right = input.Skip(middle).ToArray();
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
            
        }

        private static int[] Merge(int[] left, int[] right)
        {
            if (left.Length == 0)
            {
                return right;
            }

            if (right.Length == 0)
            {
                return left;
            }

            if (left[0] < right[0])
            {
                return left.Take(1).Concat(Merge(left.Skip(1).ToArray(),right)).ToArray();
            }
            else
            {
                return right.Take(1).Concat(Merge(left, right.Skip(1).ToArray())).ToArray();
            }
        }

    }

}
