using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class MoneyData
    {
        public float Count;
        public float ByClickEarnAmount;
        public event Action Changed;

        public void Earn(float moneyValue)
        {
            Count += moneyValue;
            Changed?.Invoke();
        }

        public void Spend(float money)
        {
            Count -= money;
            Changed?.Invoke();
        }
    }
}