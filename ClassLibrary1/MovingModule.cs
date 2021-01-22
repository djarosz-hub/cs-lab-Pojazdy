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
        internal static void StopMoving(ref Vehicle.State actualState, Environments actualEnvironment, ref double actualSpeed, string vehicleType)
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
        internal static void StartMoving(ref Vehicle.State actualState, Environments actualEnvironment, ref double actualSpeed, double targetSpeed,string vehicleType)
        {
            if(actualState == Vehicle.State.Moving)
            {
                Console.WriteLine($"{vehicleType} is already moving.");
                return;
            }
        }
    }
}
