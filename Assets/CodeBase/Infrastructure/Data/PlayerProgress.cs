using System;

[Serializable]
public class PlayerProgress
{
    public MoneyData MoneyData;

    public PlayerProgress() =>
        MoneyData = new MoneyData();
}
