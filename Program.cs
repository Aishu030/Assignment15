using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15
{
    internal class Program
    {
        private static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }


        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;

            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }

        static bool IsSorted(int[] arr)
        {
            int n = arr.Length;
            for(int i = 1; i < n;i++)
            {
                if (arr[i] < arr[i - 1])
                    return false;
            }
            return true;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            int[] array1 = { 9, -3, 5, 2, 6, 8, -6, 1, 3 ,55, 22,11,84,10,61,33,24,49,15,19};
           
            Console.WriteLine("Original Array");
            Print(array1);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(array1);
            stopwatch.Stop();
            Console.WriteLine("After Quick sort");
            Print(array1);
            Console.WriteLine($"\nArray sorted or not: \t {IsSorted(array1)}");
            Console.WriteLine($"ArraySize {array1.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds\n");

            int[] array2 = {9, -3, 5, 2, 6, 8, -6, 1, 3, 55, 22, 11, 84, 10, 61, 33, 24, 49, 15, 19 };

            Console.WriteLine("Original Array :\n" + string.Join(",", array2));
            stopwatch.Start();
            MergeSort(array2);
            stopwatch.Stop();
            MergeSort(array2);
            Console.WriteLine("\nMergeSorted Array:\n" + string.Join(",", array2));
            Console.WriteLine($"\nArray sorted or not:\t {IsSorted(array2)}");
            Console.WriteLine($"\nArraySize {array2.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds \n");


            Console.ReadKey();

        }

    }
}
