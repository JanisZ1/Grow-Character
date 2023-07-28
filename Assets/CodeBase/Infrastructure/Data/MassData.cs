using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class MassData
    {
        public Mass Mass;
        public MaxMass MaxMass;

        public MassData()
        {
            Mass = new Mass();
            MaxMass = new MaxMass();
        }
    }
}