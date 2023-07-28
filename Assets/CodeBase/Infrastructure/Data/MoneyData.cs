using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class MoneyData
    {
        public float Count;
        public event Action Changed;

        public void Earn(float moneyValue)
        {
            Count += moneyValue;
            Changed?.Invoke();
        }
    }
}