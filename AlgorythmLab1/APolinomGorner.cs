namespace AlgorithmLab1;

public class APolinomGorner : Enumeration
{
    public override void AlgRun(int[] array, int value = 0)
    {
        GornerAlg(array);
    }
    static double GornerAlg(int[] array)
    {
        double x = 1.5;
        double result = 0;

        for (int k = 1; k < array.Length + 1; k++)
        {
            result += array[k - 1] * Math.Pow(x, k - 1);
        }

        return result;
    }

    public APolinomGorner(int size, string name) : base(size, name)
    {
    }
}