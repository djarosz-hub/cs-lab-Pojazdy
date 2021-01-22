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
            testowaKlasa testowa = new testowaKlasa(60, Engine.FuelType.Electric);
            Console.WriteLine();
            Console.WriteLine(testowa.ToString());
            //Console.WriteLine(testowa.Losulosu);
            Console.WriteLine(testowa.Wheels);
            testowa.Accelerate(550);
            Console.WriteLine(testowa.ToString());
            Console.WriteLine(testowa.Name);
            Console.WriteLine(Vehicle.UnitConverter(20,SpeedUnits.MpS,SpeedUnits.Knots));

            //double val = AbstractVehicle.UnitConverter(10, AbstractVehicle.SpeedUnits.KMpH, AbstractVehicle.SpeedUnits.Knots);
            //double val1 = AbstractVehicle.UnitConverter(val, AbstractVehicle.SpeedUnits.Knots, AbstractVehicle.SpeedUnits.MpS);
            //double val2 = AbstractVehicle.UnitConverter(val1, AbstractVehicle.SpeedUnits.MpS, AbstractVehicle.SpeedUnits.Knots);
            //double val3 = AbstractVehicle.UnitConverter(val2, AbstractVehicle.SpeedUnits.Knots, AbstractVehicle.SpeedUnits.KMpH);
            //double val4 = AbstractVehicle.UnitConverter(val3, AbstractVehicle.SpeedUnits.KMpH, AbstractVehicle.SpeedUnits.MpS);
            //double val5 = AbstractVehicle.UnitConverter(val4, AbstractVehicle.SpeedUnits.MpS, AbstractVehicle.SpeedUnits.KMpH);
            //Console.WriteLine(val);
            //Console.WriteLine(val1);
            //Console.WriteLine(val2);
            //Console.WriteLine(val3);
            //Console.WriteLine(val4);
            //Console.WriteLine(val5);
        }
    }
}
