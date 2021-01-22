using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class MovingModule
    {
        internal DrivingModule drivingModule;
        internal FlyingModule flyingModule;
        internal SailingModule sailingModule;
        //rozne konstruktory
        internal MovingModule(bool drives, bool flies, bool sails, int buoyancy, int wheels)
        {
            if (drives)
                drivingModule = new DrivingModule(wheels);
            if (flies)
                flyingModule = new FlyingModule();
            if (sails)
                sailingModule = new SailingModule(buoyancy);
        }
        internal void StopMoving(ref Vehicle.State actualState, Environments actualEnvironment, ref double actualSpeed, string vehicleType)
        {
            if (actualState == Vehicle.State.Staying)
            {
                Console.WriteLine($"{vehicleType} is not moving.");
                return;
            }
            if (actualState == Vehicle.State.Moving && actualEnvironment == Environments.OnGround || actualEnvironment == Environments.Sailing)
            {
                actualSpeed = 0;
                actualState = Vehicle.State.Staying;
                Console.WriteLine($"{vehicleType} has stopped.");
                return;
            }
            Console.WriteLine($"Flying vehicles can not be stopped in air!");
        }
        internal void TryToAccelerate(Environments actualEnvironment, ref Vehicle.State actualState, ref double actualSpeed, double targetSpeed, string vehicleType)
        {
            if (actualSpeed == targetSpeed)
            {
                Console.WriteLine($"{vehicleType} speed is {actualSpeed}.");
                return;
            }
            if (targetSpeed < 0)
            {
                Console.WriteLine($"{vehicleType} can not accelerate to {targetSpeed}");
                return;
            }
            if (targetSpeed < actualSpeed || targetSpeed == 0)
            {
                TryToSlowDown(actualEnvironment, ref actualState, ref actualSpeed, targetSpeed, vehicleType);
                return;
            }
            double min = 0;
            double max = 0;
            switch (actualEnvironment)
            {
                case Environments.OnGround:
                    min = drivingModule.MinSpeed;
                    max = drivingModule.MaxSpeed;
                    if (targetSpeed <= max)
                    {
                        actualSpeed = targetSpeed;
                        Console.WriteLine($"{vehicleType} accelerated to {targetSpeed}{drivingModule.SpeedUnit}");
                        return;
                    }
                    break;
                case Environments.Flying:
                    min = flyingModule.MinSpeed;
                    max = flyingModule.MaxSpeed;
                    if (targetSpeed <= max)
                    {
                        actualSpeed = targetSpeed;
                        Console.WriteLine($"{vehicleType} accelerated to {targetSpeed}{flyingModule.SpeedUnit}");
                        return;
                    }
                    break;
                case Environments.Sailing:
                    min = sailingModule.MinSpeed;
                    max = sailingModule.MaxSpeed;
                    if (targetSpeed <= max)
                    {
                        actualSpeed = targetSpeed;
                        Console.WriteLine($"{vehicleType} accelerated to {targetSpeed}{sailingModule.SpeedUnit}");
                        return;
                    }
                    break;
            }
            Console.WriteLine($"{targetSpeed} is out of range for {actualEnvironment} environment, type speed in range {min}-{max} for {vehicleType}.");
        }
        internal void TryToSlowDown(Environments actualEnvironment, ref Vehicle.State actualState, ref double actualSpeed, double targetSpeed, string vehicleType)
        {
            if (actualSpeed == targetSpeed)
            {
                Console.WriteLine($"{vehicleType} speed is {actualSpeed}.");
                return;
            }
            if (targetSpeed < 0)
            {
                Console.WriteLine($"{targetSpeed} is not valid for {vehicleType}.");
                return;
            }
            if (targetSpeed > actualSpeed)
            {
                TryToAccelerate(actualEnvironment, ref actualState, ref actualSpeed, targetSpeed, vehicleType);
                return;
            }
            double min = 0;
            double max = 0;
            switch (actualEnvironment)
            {
                case Environments.OnGround:
                    min = drivingModule.MinSpeed;
                    max = drivingModule.MaxSpeed;
                    if (targetSpeed >= min)
                    {
                        actualSpeed = targetSpeed;
                        Console.WriteLine($"{vehicleType} slowed down to {targetSpeed}{drivingModule.SpeedUnit}.");
                        if (targetSpeed == 0)
                            actualState = Vehicle.State.Staying;
                        return;
                    }
                    break;
                case Environments.Flying:
                    min = flyingModule.MinSpeed;
                    max = flyingModule.MaxSpeed;
                    if (targetSpeed >= min)
                    {
                        actualSpeed = targetSpeed;
                        Console.WriteLine($"{vehicleType} slowed down to {targetSpeed}{flyingModule.SpeedUnit}");
                        return;
                    }
                    break;
                case Environments.Sailing:
                    min = sailingModule.MinSpeed;
                    max = sailingModule.MaxSpeed;
                    if (targetSpeed >= min)
                    {
                        actualSpeed = targetSpeed;
                        Console.WriteLine($"{vehicleType} slowed down to {targetSpeed}{sailingModule.SpeedUnit}");
                        return;
                    }
                    break;
            }
            Console.Write($"{targetSpeed} is out of range for {actualEnvironment} environment, type speed in range {min}-{max} for {vehicleType}.");
        }
    }
}
