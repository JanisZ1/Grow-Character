using Assets.CodeBase.Infrastructure.StaticData;
using System;

namespace Assets.CodeBase.Infrastructure.Services.Observer
{
    public class ShopItemObserver : IShopItemObserver
    {
        public event Action<ShopItemData> Buyed;

        public void OnBuyed(ShopItemData shopItemData) =>
            Buyed?.Invoke(shopItemData);
    }
}
