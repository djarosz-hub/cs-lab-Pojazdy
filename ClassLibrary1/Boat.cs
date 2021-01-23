using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Boat : EnginePoweredVehicle, IVehicle, ISailable
    {
        private readonly int _buoyancy;
        private MovingModule _MovingModule;
        public string Name => GetType().Name;
        public int Buoyancy => _buoyancy;
        public Boat(int horsePower, int buoyancy) : base(horsePower, Engine.FuelType.Diesel)
        {
            ActualEnvironment = Environments.Sailing;
            AvailableEnvironments.Add(Environments.Sailing);
            _buoyancy = buoyancy;
            _MovingModule = new MovingModule(buoyancy, true);
        }

        public void Accelerate(double targetSpeed)
        {
            _MovingModule.TryToAccelerate(ActualEnvironment, ref _state, ref MovingSpeed, targetSpeed, Name);
        }

        public void LeaveWater()
        {
            Console.WriteLine($"{Name} can not leave water environment.");
        }

        public void Sail()
        {
            Console.WriteLine($"{Name} is already sailing.");
        }

        public void SlowDown(double targetSpeed)
        {
            _MovingModule.TryToSlowDown(ActualEnvironment, ref _state, ref MovingSpeed, targetSpeed, Name);
        }

        public void StopVehicle()
        {
            _MovingModule.StopMoving(ref _state, ActualEnvironment, ref MovingSpeed, Name);
        }
        public override string ToString()
        {
            return $"{Name}" + base.ToString() + $"\nBuoyancy: {Buoyancy}\n";
        }
    }
}
