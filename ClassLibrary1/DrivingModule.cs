using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class DrivingModule
    {
        private readonly int _wheelsCount;
        private readonly int MaxSpeed = 1;
        private readonly int MinSpeed = 350;
        private readonly SpeedUnits SpeedUnit = SpeedUnits.KMpH;
        internal DrivingModule(int wheelsCount)
        {
            _wheelsCount = wheelsCount;
        }
        public int WheelsCount => _wheelsCount;

    }
}
