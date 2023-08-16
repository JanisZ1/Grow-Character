using Assets.CodeBase.Infrastructure.StaticData;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        ShopItemStaticData ForShopItem(ShopItemType shopItemType);
        HeightShowBuildingData ForHeightShowBuilding(HeightShowBuildingType buildingType);
        LevelStaticData ForLevel(string level);
        List<BackgroundSoundStaticData> ForAllBackgroundSounds();
        void Load();
    }
}