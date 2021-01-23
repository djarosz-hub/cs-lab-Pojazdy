using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class SailingModule
    {
        internal readonly int _buoyancy;
        public static readonly int MaxSpeed = 40;
        public static readonly int MinSpeed = 1;
        public static readonly SpeedUnits SpeedUnit = SpeedUnits.Knots;

        internal SailingModule(int buoyancy)
        {
            _buoyancy = buoyancy;
        }
        public int Buoyancy => _buoyancy;
    }
}
