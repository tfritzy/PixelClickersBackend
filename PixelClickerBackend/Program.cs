using System;

namespace PixelClickerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpNumber num = new ExpNumber(2, 0);
            for (int i = 0; i < 100000000; i++){
                num.Pow(1);
                Console.WriteLine(num);
            }
        }
    }
}
