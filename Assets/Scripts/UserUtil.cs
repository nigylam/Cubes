public class UserUtil
{
    private static System.Random s_random = new System.Random();
    public static int GetRandomInt(int numberMinIncluded, int numberMaxExcluded)
    {
        return s_random.Next(numberMinIncluded, numberMaxExcluded);
    }

    public static double GetRandomDouble() => s_random.NextDouble();
}
