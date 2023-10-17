namespace AlgorithmLab1
{
    public class ASumm : Enumeration
    {
        public override void AlgRun(int[] array, int value)
        {
            int sum = 0;
            //Складываем все элементы
            foreach (int elem in array)
            {
                sum += elem;
            }
        }
        public ASumm(int size, string name) : base(size, name)
        {
        }
    }
}