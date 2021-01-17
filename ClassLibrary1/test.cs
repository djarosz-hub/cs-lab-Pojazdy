using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class testowaKlasa : EnginePoweredVehicle
    {
        public int Losulosu;
        public testowaKlasa(int x, Engine.FuelType y) : base(x, y)
        {
            Losulosu = 5;

        }
        public override string ToString()
        {
            return $"{_engine}";
        }
    }
}
