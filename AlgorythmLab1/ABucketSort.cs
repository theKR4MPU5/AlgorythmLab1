using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmLab1;

namespace AlgorithmLab1
{
    public class ABucketSort : Enumeration
    {
        public ABucketSort(int size, string name) : base(size, name)
        {
        }

        public override void AlgRun(int[] array, int value)
        {
            int max = array.Max();
            int min = array.Min();

            int bucketCount = max - min + 1;
            List<List<int>> buckets = new List<List<int>>(bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new List<int>());
            }

            // Распределение элементов по бакетам
            foreach (int num in array)
            {
                int index = num - min;
                buckets[index].Add(num);
            }

            // Сортировка каждого бакета с помощью сортировки слиянием
            foreach (List<int> bucket in buckets)
            {
                MergeSort(bucket);
            }

            // Объединение отсортированных бакетов в исходный массив
            int currentIndex = 0;
            foreach (List<int> bucket in buckets)
            {
                foreach (int num in bucket)
                {
                    array[currentIndex] = num;
                    currentIndex++;
                }
            }
        }

        private void MergeSort(List<int> arr)
        {
            if (arr.Count <= 1)
                return;

            int middle = arr.Count / 2;
            List<int> left = arr.GetRange(0, middle);
            List<int> right = arr.GetRange(middle, arr.Count - middle);

            MergeSort(left);
            MergeSort(right);

            int i = 0, j = 0, k = 0;
            while (i < left.Count && j < right.Count)
            {
                if (left[i] < right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Count)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Count)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
