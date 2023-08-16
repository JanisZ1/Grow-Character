using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class MoneyData
    {
        public float ByClickEarnAmount;
        public float Count;
        public event Action Changed;
        public event Action<float> MoneySpended;
        public event Action<float> MoneyEarned;

        public void Earn(float moneyValue)
        {
            Count += moneyValue;
            Changed?.Invoke();
            MoneyEarned?.Invoke(moneyValue);
        }

        public void Spend(float money)
        {
            Count -= money;
            Changed?.Invoke();
            MoneySpended?.Invoke(money);
        }
    }
}