namespace AlgorithmLab1
{
    public class AMultipli : Enumeration
    {
        // Запуск перемножение
        public override void AlgRun(int[] array, int value)
        {
            int difference = 1;
            foreach (int elem in array)
            {
                difference *= elem;
            }
        }
        //Конструктор класса, который принимает имя и размер массива.
        public AMultipli(int size, string name) : base(size, name)
        {
        }
    }
}