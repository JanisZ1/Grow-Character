using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.CodeBase.Infrastructure.StaticData;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<ShopItemType, ShopItemStaticData> _shopItems;
        private Dictionary<string, LevelStaticData> _levels;

        private const string ShopItemsStaticDataPath = "StaticData/ShopItems";
        private const string LevelsStaticDataPath = "StaticData/Level";

        public void Load()
        {
            _shopItems = Resources.LoadAll<ShopItemStaticData>(ShopItemsStaticDataPath)
                .ToDictionary(x => x.ShopItemType, x => x);

            _levels = Resources.LoadAll<LevelStaticData>(LevelsStaticDataPath)
                .ToDictionary(x => x.LevelName, x => x);
        }

        public ShopItemStaticData ForShopItem(ShopItemType shopItemType) =>
            _shopItems.TryGetValue(shopItemType, out ShopItemStaticData itemData)
                ? itemData
                : null;

        public LevelStaticData ForLevel(string level) =>
            _levels.TryGetValue(level, out LevelStaticData levelData)
                ? levelData
                : null;
    }
}
