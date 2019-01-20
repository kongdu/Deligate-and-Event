using System;

namespace GenericDelegate
{
    internal delegate int Compare<T>(T a, T b);

    internal class MainApp
    {
        private static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        private static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1; //-1을 곱하면 자신보다 큰 경우에는 -1, 같으면 0, 작으면 1을 반환
        }

        private static void BubbleSort<T>(T[] DataSet, Compare<T> MyCompare)
        {
            int i = 0;
            int j = 0;
            T temp;
            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (MyCompare(DataSet[j], DataSet[j + 1]) > 0)
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

            BubbleSort<int>(array, new Compare<int>(AscendCompare));
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };
            Console.WriteLine("\n내림차순 정렬...");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]} ");
            }
            Console.WriteLine();
        }
    }
}