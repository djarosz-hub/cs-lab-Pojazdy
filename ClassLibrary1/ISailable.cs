using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    interface ISailable
    {
        void Sail();
        void LeaveWater();
        int Buoyancy { get; }
    }
}
