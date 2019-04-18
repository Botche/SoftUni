using System;
using System.Numerics;
namespace snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = int.Parse(Console.ReadLine());
            BigInteger snowballMaxValue = uint.MinValue;int snowballSnow1=0, snowballTime1=0, snowballQuality1=0;
            for(int i=0;i<numberOfBalls;i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow( snowballSnow / snowballTime, snowballQuality);
                if (snowballMaxValue <= snowballValue)
                {
                    snowballMaxValue = snowballValue;
                    snowballSnow1 = snowballSnow;
                    snowballQuality1 = snowballQuality;
                    snowballTime1 = snowballTime;
                }
            }
            Console.WriteLine($"{snowballSnow1} : {snowballTime1} = {snowballMaxValue} ({snowballQuality1})");
        }
    }
}
