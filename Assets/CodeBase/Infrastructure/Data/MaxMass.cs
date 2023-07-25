using System;

public class MaxMass
{
    public float Current;

    public event Action Changed;

    public void Change(float mass)
    {
        Current += mass;
        Changed?.Invoke();
    }
}
