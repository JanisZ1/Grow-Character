using Assets.CodeBase.Infrastructure.StaticData;
using System;

namespace Assets.CodeBase.Infrastructure.Services.Observer
{
    public interface IShopItemObserver : IService
    {
        event Action<ShopItemStaticData> Buyed;
        void OnBuyed(ShopItemStaticData shopItemData);
    }
}
