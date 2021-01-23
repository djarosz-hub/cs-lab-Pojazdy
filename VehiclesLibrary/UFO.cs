using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

namespace VehiclesLibrary
{
    public class UFO : EnginePoweredVehicle, IVehicle, ISailable, IFlyable, IWaterLandable, IDriveable
    {
        private readonly int _wheels;
        private readonly int _buoyancy;
        private MovingModule _MovingModule;
        public string Name => GetType().Name;
        public int Buoyancy => _buoyancy;
        public int Wheels => _wheels;
        public UFO() : base(int.MaxValue, Engine.FuelType.Electric)
        {
            AvailableEnvironments.Add(Environments.OnGround);
            AvailableEnvironments.Add(Environments.Sailing);
            AvailableEnvironments.Add(Environments.Flying);
            _wheels = 50;
            _buoyancy = 100000;
            _MovingModule = new MovingModule(true, Wheels, true, true, Buoyancy);
        }
        public void Accelerate(double targetSpeed)
        {
            _MovingModule.TryToAccelerate(ActualEnvironment, ref _state, ref MovingSpeed, targetSpeed, Name);
        }

        public void Fly()
        {
            _MovingModule.TryToFly(ref ActualEnvironment, _state, ref MovingSpeed, Name);
        }

        public void Land()
        {
            _MovingModule.TryToDrive(ref ActualEnvironment, _state, ref MovingSpeed, Name);
        }

        public void LandOnWater()
        {
            _MovingModule.TryToSail(ref ActualEnvironment, _state, ref MovingSpeed, Name);
        }

        public void LeaveWater()
        {
            _MovingModule.TryToDrive(ref ActualEnvironment, _state, ref MovingSpeed, Name);
        }

        public void Sail()
        {
            _MovingModule.TryToSail(ref ActualEnvironment, _state, ref MovingSpeed, Name);
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
            return $"{Name}" + base.ToString() + $"\nWheels: {Wheels}\nBuoyancy: {Buoyancy}\n";
        }
    }
}
