using System;

namespace PixelClickerBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            Emerald emerald = new Emerald(6);
            Console.WriteLine("The Gem's type is: " + emerald.type);
            Console.WriteLine("Hello World!");
        }
    }
}
