﻿using System;

public class Mass
{
    public float Current;

    public event Action Changed;

    public void Change(float mass)
    {
        Current = mass;
        Changed?.Invoke();
    }
}