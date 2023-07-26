using System;

[Serializable]
public class PlayerProgress
{
    public MoneyData MoneyData;
    public MassData MassData;

    public PlayerProgress()
    {
        MoneyData = new MoneyData();
        MassData = new MassData();
    }
}
