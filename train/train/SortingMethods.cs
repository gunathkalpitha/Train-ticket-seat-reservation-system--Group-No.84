using System;
using System.Collections.Generic;

namespace Train
{
    public class SortingMethods
    {
        // Bubble Sort (Sorts ticket prices)
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])  // Swap if greater
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // Merge Sort (Sorts reference numbers alphabetically)
        public static void MergeSort(string[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }

        private static void Merge(string[] arr, int left, int middle, int right)
        {
            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            string[] leftArray = new string[leftSize];
            string[] rightArray = new string[rightSize];

            for (int i = 0; i < leftSize; i++)
                leftArray[i] = arr[left + i];

            for (int j = 0; j < rightSize; j++)
                rightArray[j] = arr[middle + 1 + j];

            int iIndex = 0, jIndex = 0, kIndex = left;

            while (iIndex < leftSize && jIndex < rightSize)
            {
                if (string.Compare(leftArray[iIndex], rightArray[jIndex]) <= 0)
                {
                    arr[kIndex] = leftArray[iIndex];
                    iIndex++;
                }
                else
                {
                    arr[kIndex] = rightArray[jIndex];
                    jIndex++;
                }
                kIndex++;
            }

            while (iIndex < leftSize)
            {
                arr[kIndex] = leftArray[iIndex];
                iIndex++;
                kIndex++;
            }

            while (jIndex < rightSize)
            {
                arr[kIndex] = rightArray[jIndex];
                jIndex++;
                kIndex++;
            }
        }

        // Quick Sort (Sorts ticket counts)
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);  // Swap
                }
            }

            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }
}
