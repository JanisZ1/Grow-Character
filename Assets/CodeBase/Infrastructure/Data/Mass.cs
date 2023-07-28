using System;

[Serializable]
public class Mass
{
    public float Current;
    public float ScaleFactor;

    public event Action Changed;

    public void Change(float mass)
    {
        Current = mass;
        Changed?.Invoke();
    }
}