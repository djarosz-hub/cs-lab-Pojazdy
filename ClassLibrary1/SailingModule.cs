using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class SailingModule
    {
        private readonly int _buoyancy;
        private readonly int MaxSpeed = 40;
        private readonly int MinSpeed = 1;
        private readonly SpeedUnits SpeedUnit = SpeedUnits.Knots;

        internal SailingModule(int buoyancy)
        {
            _buoyancy = buoyancy;
        }
        public int Buoyancy => _buoyancy;
    }
}
