using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class testowaKlasa : EnginePoweredVehicle, IDriveable
    {
        private int _wheels;
        public testowaKlasa(int x, Engine.FuelType y) : base(x, y)
        {
            AvailableEnvironments.Add(Environments.Flying);
            AvailableEnvironments.Add(Environments.OnGround);
            _wheels = 4;
            
        }
        public string Name => GetType().Name;

        public int Wheels => _wheels;
        public void Accelerate(int value)
        {
            MovingSpeed = IDriveable.TryToAccelerate(MovingSpeed,value);
        }
        //public override string ToString()
        //{
        //    return $"{GetEngineInfo()}";
        //}
    }
}
