using System;

namespace _6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 5, 15, -30, 10, -5, 40, 10 };
            Console.WriteLine(FindMaximumContiguousSubsequenceSum(data));
        }

        private static int FindMaximumContiguousSubsequenceSum(int[] data)
        {
            if(data.Length == 0)
            {
                return 0;
            }
            else
            {
                int maximumValue = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (maximumValue + data[i] >= maximumValue)
                    {
                        maximumValue += data[i];
                    }
                    else
                    {
                        maximumValue = 0;
                    }
                }
                
                return maximumValue;
            }
        }
    }
}
