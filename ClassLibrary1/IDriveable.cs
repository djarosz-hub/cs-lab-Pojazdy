using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public interface IDriveable
    {
        public static int MinSpeed = 1;
        const int MaxSpeed = 350;
        static double TryToAccelerate(double actual, double value)
        {
            if (actual + value < MaxSpeed)
                return actual + value;
            return MaxSpeed;
        }
        double TryToSlowDown(double actual, double value)
        {
            if (actual + value > MinSpeed)
                return actual + value;
            return MinSpeed;
        }
    }
}
