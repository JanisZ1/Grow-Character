using System;

[Serializable]
public class MoneyData
{
    public float Money;

    public event Action Changed;

    public void Earn(Money money)
    {
        Money += money.Value;
        Changed?.Invoke();
    }
}
