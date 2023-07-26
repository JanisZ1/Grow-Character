using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.CodeBase.Infrastructure.StaticData;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<ShopItemType, ShopItemData> _shopItems;

        private const string ShopItemsStaticDataPath = "Resources/StaticData";

        public void Load()
        {
            _shopItems = Resources.LoadAll<ShopItemData>(ShopItemsStaticDataPath)
                .ToDictionary(x => x.ShopItemType, x => x);
        }

        public ShopItemData ForShopItem(ShopItemType shopItemType) =>
            _shopItems.TryGetValue(shopItemType, out ShopItemData itemData)
                ? itemData
                : null;
    }
}
