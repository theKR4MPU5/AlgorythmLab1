﻿namespace AlgorithmLab1
{
    class ABubbleSort : Enumeration
    {
        //Конструктор класса, который принимает имя и размер массива.
        public ABubbleSort(int size, string name) : base(size, name)
        {
        }

        public override void AlgRun(int[] array, int value)
        {
            //Прогоняем итерации сортировки.
            for (int i = 0; i < array.Length; i++)
            {
                //Проходим по элементам массива.
                for (int j = 0; j < array.Length - 1; j++)
                {
                    //Cравниваем два соседних элемента
                    if (array[j] > array[j + 1])
                    {
                        //Меняем их местами, если они находятся в неправильном порядке.
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
        }
    }
}