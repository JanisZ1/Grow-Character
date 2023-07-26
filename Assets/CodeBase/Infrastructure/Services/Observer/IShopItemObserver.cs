using Assets.CodeBase.Infrastructure.StaticData;
using System;

namespace Assets.CodeBase.Infrastructure.Services.Observer
{
    public interface IShopItemObserver : IService
    {
        event Action<ShopItemData> Buyed;
        void OnBuyed(ShopItemData shopItemData);
    }
}
