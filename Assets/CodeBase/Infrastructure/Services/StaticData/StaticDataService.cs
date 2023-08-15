using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.CodeBase.Infrastructure.StaticData;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<ShopItemType, ShopItemStaticData> _shopItems;
        private Dictionary<HeightShowBuildingType, HeightShowBuildingData> _heightShowBuildings;
        private Dictionary<string, LevelStaticData> _levels;
        private List<BackgroundSoundStaticData> _backgroundSounds;

        private const string ShopItemsStaticDataPath = "StaticData/ShopItems";
        private const string HeightShowBuildingsStaticDataPath = "";
        private const string LevelsStaticDataPath = "StaticData/Level";
        private const string BackgroundSoundsStaticDataPath = "StaticData/Sounds";

        public void Load()
        {
            _shopItems = Resources.LoadAll<ShopItemStaticData>(ShopItemsStaticDataPath)
                .ToDictionary(x => x.ShopItemType, x => x);

            _heightShowBuildings = Resources.LoadAll<HeightShowBuildingData>(HeightShowBuildingsStaticDataPath)
                .ToDictionary(x => x.BuildingType, x => x);

            _backgroundSounds = Resources.LoadAll<BackgroundSoundStaticData>(BackgroundSoundsStaticDataPath)
                .ToList();
            _levels = Resources.LoadAll<LevelStaticData>(LevelsStaticDataPath)
                .ToDictionary(x => x.LevelName, x => x);
        }

        public ShopItemStaticData ForShopItem(ShopItemType shopItemType) =>
            _shopItems.TryGetValue(shopItemType, out ShopItemStaticData itemData)
                ? itemData
                : null;

        public List<BackgroundSoundStaticData> ForAllBackgroundSounds() =>
            _backgroundSounds;

        public LevelStaticData ForLevel(string level) =>
            _levels.TryGetValue(level, out LevelStaticData levelData)
                ? levelData
                : null;

        public HeightShowBuildingData ForHeightShowBuilding(HeightShowBuildingType buildingType) =>
            _heightShowBuildings.TryGetValue(buildingType, out HeightShowBuildingData heightShowBuildingData)
                ? heightShowBuildingData
                : null;
    }
}
