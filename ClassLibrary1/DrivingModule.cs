using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class DrivingModule
    {
        internal readonly int _wheelsCount;
        internal readonly int MaxSpeed = 1;
        internal readonly int MinSpeed = 350;
        internal readonly SpeedUnits SpeedUnit = SpeedUnits.KMpH;
        internal DrivingModule(int wheelsCount)
        {
            _wheelsCount = wheelsCount;
        }
        public int WheelsCount => _wheelsCount;
    }
}
