using System;
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

            var result = MergeSort(input);
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
