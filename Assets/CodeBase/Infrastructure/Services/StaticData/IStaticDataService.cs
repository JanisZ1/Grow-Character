using Assets.CodeBase.Infrastructure.StaticData;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        ShopItemStaticData ForShopItem(ShopItemType shopItemType);
        LevelStaticData ForLevel(string level);
        void Load();
    }
}