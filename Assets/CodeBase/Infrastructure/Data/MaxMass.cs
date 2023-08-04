using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class MaxMass
    {
        public float Current;

        public event Action Changed;

        public void Change(float mass)
        {
            Current = mass;
            Changed?.Invoke();
        }
    }
}