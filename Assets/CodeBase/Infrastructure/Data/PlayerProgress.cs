using System;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public MoneyData MoneyData;
        public MassData MassData;
        public ShopItemData ShopBuyData;

        public PlayerProgress(string bootstrapLevel)
        {
            WorldData = new WorldData(bootstrapLevel);
            MoneyData = new MoneyData();
            MassData = new MassData();
            ShopBuyData = new ShopItemData();
        }
    }
}