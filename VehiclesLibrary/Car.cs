using System;
using ClassLibrary1;

namespace VehiclesLibrary
{
    public class Car : EnginePoweredVehicle, IVehicle
    {
        private int _wheels;
        private MovingModule _MovingModule;
        public Car(int horsePower, Engine.FuelType fuelType) : base(horsePower, fuelType)
        {
            AvailableEnvironments.Add(Environments.OnGround);
            _wheels = 4;
            _MovingModule = new MovingModule(true, 4);
        }
        public string Name => GetType().Name;
        public int Wheels => _wheels;
        public override string ToString()
        {
            return $"\n{Name}\nWheels: {Wheels}" + base.ToString();
        }
        public void Accelerate(double value)
        {
            throw new NotImplementedException();
        }

        public void SlowDown(double value)
        {
            throw new NotImplementedException();
        }

        public void StopVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
