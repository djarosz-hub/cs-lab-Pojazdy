using System;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var d = new Engine(60, Engine.FuelType.LPG);
            //Console.WriteLine(d.ToString());
            testowaKlasa dupa = new testowaKlasa(60, Engine.FuelType.Electric);
            Console.WriteLine(dupa.Losulosu);
            Console.WriteLine();
            Console.WriteLine(dupa.ToString());
        }
    }
}
