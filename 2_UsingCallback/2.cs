using System;

namespace UsingCallback
{
    internal delegate int Compare(int a, int b);

    internal class MainApp
    {
        private static int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        private static int DescendCompare(int a, int b)
        {
            if (a < b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        private static void BubbleSort(int[] DataSet, Compare myCompare)
        {
            int temp = 0;
            for (int i = 0; i < DataSet.Length - 1; i++)
            {
                for (int j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (myCompare(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };
            Console.WriteLine("오름차순 정렬...");

            BubbleSort(array, new Compare(AscendCompare));
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            int[] array2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\n내림차순 정렬...");

            BubbleSort(array2, new Compare(AscendCompare));
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write("{0} ", array2[i]);
            }
        }
    }
}