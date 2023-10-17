using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AlgorithmLab1
{
    class Program
    {
        //Создаем список алгоритмов для сортировки.
        static void Main(string[] args)
        {
            List<Enumeration> algorythmList = new List<Enumeration>()
            {
                new ABucketSort(250, "Algorithm Bucket"),
                new AConst(200, "Algorithm Const"),
                new ASumm(200, "Algorithm Summ"),
                new AMultipli(200, "Algotithm Multiplication"),
                new APolinomPlain(200,"Algorithm PolinomPlain"),
                new APolinomGorner(200, "Algorithm PolinomGorner"),
                new ABubbleSort(200, "Algorithm BubbleSort"),
                new AQuickSort(200, "Algorithm QuickSort"),
                new ATimSort(200, "Algorithm TimSort")
            };

            foreach (var algol in algorythmList)
            {
                Instrument.ConductResearch(algol);
            }
        }
    }

    class Instrument
    {
        //Создающем массив заданного размера со случайными значениями.
        public static int[] GenerateArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(500000);
            return array;
        }

        //Измеряем время выполнения алгоритма.
        public static long MeasureTime(int[] array, Enumeration algorithm)
        {
            Random random = new Random();
            Stopwatch watch = new Stopwatch();
            algorithm.AlgRun(array, array.Length);
            watch.Start();
            algorithm.AlgRun(array, array.Length);
            watch.Stop();
            return watch.ElapsedTicks / 100;
        }

        //Метод для тестирования
        public static void ConductResearch(Enumeration algorithm, bool sorted = false)
        {
            List<(int, long)> results = new List<(int, long)>();
            results.Add((-1, sorted ? 1 : 0));

            //Тестируем алгоритм 5 раз
            foreach (int dimension in algorithm.TestArray)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Проверка размера {algorithm.Name}: {dimension}");
                    results.Add((dimension,
                        MeasureTime(GenerateArray(dimension), algorithm)));
                }
            }

            Console.WriteLine("Выполнено!");
            //Усредняем время на итерации алгоритма.
            List<(int, long)> res = new List<(int, long)>();
            for (int i = 1; i <= algorithm.TestArray.Length; i++)
            {
                var average = results.Where(x => x.Item1 == i).Average(x => x.Item2);
                res.Add((i, (long)average));
            }
            ExportAsCsv(res, algorithm);
        }

        //Метод, который записывает наши данные в файл
        private static void ExportAsCsv(List<(int, long)> researches, Enumeration algorithm)
        {
            string path =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{algorithm.Name}_{DateTime.Now.ToString("yyyy-M-dd")}.csv";


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tested algorithm:;{algorithm.GetType().Name}({algorithm.Name})");
            sb.AppendLine($"Dimension (elements);Spent time (µs)");
            foreach (var pos in researches)
                sb.AppendLine($"{pos.Item1};{pos.Item2}");
            File.WriteAllText(path, sb.ToString());
            Console.WriteLine($"File saved at: {path}");
        }
    }

    //Абстрактный класс, для алгоритмов, которые будут тестироваться.
    public abstract class Enumeration
    {
        //Принимаем размер и имя в конструктор.
        protected Enumeration(int size, string name)
        {
            TestArray = GenerateArray(size);
            Name = name;
        }
        //Создаем массив по заданным размерам.
        private int[] GenerateArray(int size)
        {
            int[] dimensions = new int[size];
            for (int i = 0; i < dimensions.Length; i++)
            {
                dimensions[i] = i + 1;
            }

            return dimensions;
        }
        //Абстрактный метод, который реализуется в классах наследках.
        public abstract void AlgRun(int[] array, int value = 0);

        public int[] TestArray { get; }
        //Имя, которое отображается в экспортном файле.
        public string Name { get; }
    }
}