using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public MoneyData MoneyData;
        public MassData MassData;
        public ShopItemData ShopBuyData;

        public PlayerProgress()
        {
            MoneyData = new MoneyData();
            MassData = new MassData();
            ShopBuyData = new ShopItemData();
        }
    }
}