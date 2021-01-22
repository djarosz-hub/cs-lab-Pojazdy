using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public abstract class Vehicle
    {
        public enum State { Moving, Staying }

        protected double MovingSpeed;
        protected State _state = State.Staying;
        protected Environments ActualEnvironment;
        protected List<Environments> AvailableEnvironments = new List<Environments>();
        public static double UnitConverter(double speed, SpeedUnits from, SpeedUnits to)
        {
            double val = 0;
            switch (from)
            {
                case SpeedUnits.KMpH:
                    if (to == SpeedUnits.MpS)
                        val = speed * 0.277;
                    else
                        val = speed * 0.539;
                    break;
                case SpeedUnits.MpS:
                    if (to == SpeedUnits.KMpH)
                        val = speed * 3.6;
                    else
                        val = speed * 1.943;
                        break;
                case SpeedUnits.Knots:
                    if (to == SpeedUnits.KMpH)
                        val = speed * 1.852;
                    else
                        val = speed * 0.514;
                    break;
            }
            return val;
        }
        public override string ToString()
        {
            string temp = string.Join(", ", AvailableEnvironments);
            return $"\nActual enviroment: {ActualEnvironment}\nActual state: {_state}\nActual speed: {MovingSpeed}\nAvaiable environemnts: {temp}";
        }
    }
}
