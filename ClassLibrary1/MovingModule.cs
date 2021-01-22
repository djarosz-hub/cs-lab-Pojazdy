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
        /// <summary>
        /// for driving vehicles only
        /// </summary>
        /// <param name="drives"></param>
        /// <param name="wheels"></param>
        internal MovingModule(bool drives, int wheels)
        {
            drivingModule = new DrivingModule(wheels);
        }
        /// <summary>
        /// for driving and sailing vehicles
        /// </summary>
        /// <param name="drives"></param>
        /// <param name="wheels"></param>
        /// <param name="sails"></param>
        /// <param name="buoyancy"></param>
        internal MovingModule(bool drives, int wheels, bool sails, int buoyancy)
        {
            drivingModule = new DrivingModule(wheels);
            sailingModule = new SailingModule(buoyancy);
        }
        /// <summary>
        /// for driving and flying vehicles
        /// </summary>
        /// <param name="drives"></param>
        /// <param name="wheels"></param>
        /// <param name="flies"></param>
        internal MovingModule(bool drives, int wheels, bool flies)
        {
            drivingModule = new DrivingModule(wheels);
            flyingModule = new FlyingModule();
        }
        /// <summary>
        /// for driving, flying and sailing vehicles
        /// </summary>
        /// <param name="drives"></param>
        /// <param name="wheels"></param>
        /// <param name="flies"></param>
        /// <param name="sails"></param>
        /// <param name="buoyancy"></param>
        internal MovingModule(bool drives, int wheels, bool flies, bool sails, int buoyancy)
        {
            drivingModule = new DrivingModule(wheels);
            flyingModule = new FlyingModule();
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
            if (targetSpeed == 0)
            {
                StopMoving(ref actualState, actualEnvironment, ref actualSpeed, vehicleType);
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
        internal void TryToSail(ref Environments actualEnvironment, Vehicle.State actualState, ref double actualSpeed, string vehicleType)
        {
            if (!ValidatingConditions(sailingModule, actualState, Environments.Sailing, actualEnvironment, vehicleType))
                return;
            double convertedSpeed = 0;
            if (actualEnvironment == Environments.Flying)
            {
                if (actualSpeed != flyingModule.MinSpeed)
                {
                    Console.WriteLine($"Flying vehicles can land only at minimum speed {flyingModule.MinSpeed}{flyingModule.SpeedUnit}, your actual speed is {actualSpeed}{flyingModule.SpeedUnit}, slow down first before landing.");
                    return;
                }
                convertedSpeed = Vehicle.UnitConverter(actualSpeed, SpeedUnits.MpS, SpeedUnits.Knots);
                Console.WriteLine($"Succesfully landed on water, your actual speed is {convertedSpeed}{sailingModule.SpeedUnit}");
            }
            if (actualEnvironment == Environments.OnGround)
            {
                convertedSpeed = Vehicle.UnitConverter(actualSpeed, SpeedUnits.KMpH, SpeedUnits.Knots);
                if (convertedSpeed > sailingModule.MaxSpeed)
                {
                    Console.WriteLine($"Your actual speed {actualSpeed}{drivingModule.SpeedUnit} = {convertedSpeed}{sailingModule.SpeedUnit} is too fast to sail, slow down at least to {sailingModule.MaxSpeed}{sailingModule.SpeedUnit}");
                    return;
                }
                if (convertedSpeed < sailingModule.MinSpeed)
                {
                    Console.WriteLine($"Your actual speed {actualSpeed}{drivingModule.SpeedUnit} = {convertedSpeed}{sailingModule.SpeedUnit} is too slow to sail, speed up at least to {sailingModule.MinSpeed}{sailingModule.SpeedUnit}");
                    return;
                }
                Console.WriteLine($"Succesfully started to sail, your actual speed is {convertedSpeed}{SpeedUnits.Knots}");
            }
            actualSpeed = convertedSpeed;
            actualEnvironment = Environments.Sailing;
        }
        internal void TryToDrive(ref Environments actualEnvironment, Vehicle.State actualState, ref double actualSpeed, string vehicleType)
        {
            if (!ValidatingConditions(drivingModule, actualState, Environments.OnGround, actualEnvironment, vehicleType))
                return;
            double convertedSpeed = 0;
            if (actualEnvironment == Environments.Flying)
            {
                if (actualSpeed != flyingModule.MinSpeed)
                {
                    Console.WriteLine($"Flying vehicles can land only at minimum speed {flyingModule.MinSpeed}{flyingModule.SpeedUnit}, your actual speed is {actualSpeed}{flyingModule.SpeedUnit}, slow down first before landing.");
                    return;
                }
                convertedSpeed = Vehicle.UnitConverter(actualSpeed, SpeedUnits.MpS, SpeedUnits.KMpH);
                Console.WriteLine($"Succesfully landed on ground, your actual speed is {convertedSpeed}{drivingModule.SpeedUnit}");
            }
            if(actualEnvironment == Environments.Sailing)
            {
                convertedSpeed = Vehicle.UnitConverter(actualSpeed, SpeedUnits.Knots, SpeedUnits.KMpH);
                Console.WriteLine($"Succesfully left watar and started to drive, your actual speed is {convertedSpeed}{drivingModule.SpeedUnit}");
            }
            actualSpeed = convertedSpeed;
            actualEnvironment = Environments.OnGround;
        }
        internal void TryToFly(ref Environments actualEnvironment, Vehicle.State actualState, ref double actualSpeed, string vehicleType)
        {
            if (!ValidatingConditions(flyingModule, actualState, Environments.Flying, actualEnvironment, vehicleType))
                return;
            double convertedSpeed = 0;
            if(actualEnvironment == Environments.OnGround)
            {
                convertedSpeed = Vehicle.UnitConverter(actualSpeed, SpeedUnits.KMpH, SpeedUnits.MpS);
                if (convertedSpeed < flyingModule.MinSpeed)
                {
                    Console.WriteLine($"Your actual speed is {actualSpeed}{drivingModule.SpeedUnit} = {convertedSpeed}{flyingModule.SpeedUnit}. Minimum speed required to get off ground is {flyingModule.MinSpeed}{flyingModule.SpeedUnit}. Speed up!");
                    return;
                }
            }
            if(actualEnvironment == Environments.Sailing)
            {
                convertedSpeed = Vehicle.UnitConverter(actualSpeed, SpeedUnits.Knots, SpeedUnits.MpS);
                if(convertedSpeed < flyingModule.MinSpeed)
                {
                    Console.WriteLine($"Your actual speed is {actualSpeed}{sailingModule.SpeedUnit} = {convertedSpeed}{flyingModule.SpeedUnit}. Minimum speed required to get off water is {flyingModule.MinSpeed}{flyingModule.SpeedUnit}. Speed up!");
                    return;
                }
            }
            Console.WriteLine($"Succefully started to fly. Your actual speed is {convertedSpeed}{flyingModule.SpeedUnit}");
            actualSpeed = convertedSpeed;
            actualEnvironment = Environments.Flying;
        }
        private void NotMovingVehicleMsg(string vehicleType) => Console.WriteLine($"{vehicleType} is not moving.");
        private bool IsAlreadyInProperEnvironment(Environments target, Environments actual) => target == actual ? true : false;
        private bool IsVehicleStaying(Vehicle.State actual) => actual == Vehicle.State.Staying ? true : false;
        private bool ValidatingConditions(object module, Vehicle.State actualState, Environments targetEnvironment, Environments actualEnvironment, string vehicleType)
        {
            if (module == null)
            {
                Console.WriteLine($"{vehicleType} is not able to travel in given environment ({targetEnvironment}).");
                return false;
            }
            if (IsVehicleStaying(actualState))
            {
                NotMovingVehicleMsg(vehicleType);
                return false;
            }
            if (IsAlreadyInProperEnvironment(targetEnvironment, actualEnvironment))
            {
                Console.WriteLine($"{vehicleType} is already in target environment.");
                return false;
            }
            return true;
        }
    }
}
