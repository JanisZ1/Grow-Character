using Assets.CodeBase.Infrastructure.StaticData;
using System;

namespace Assets.CodeBase.Infrastructure.Services.Observer
{
    public class ShopItemObserver : IShopItemObserver
    {
        public event Action<ShopItemStaticData> Buyed;

        public void OnBuyed(ShopItemStaticData shopItemData) =>
            Buyed?.Invoke(shopItemData);
    }
}
