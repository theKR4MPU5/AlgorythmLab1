namespace AlgorithmLab1
{
    class AConst : Enumeration
    {
        // присваивает массиву значение 1
        public int Returning(int[] array)
        {
            return 1;
        }
        //запуск программы
        public override void AlgRun(int[] array, int value)
        {
            Returning(array);
        }
        // Инцилизация объекта класса
        public AConst(int size, string name) : base(size, name)
        {
        }
    }
}