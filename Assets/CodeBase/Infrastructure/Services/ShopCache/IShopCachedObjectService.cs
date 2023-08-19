using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.ShopCache
{
    public interface IShopCachedObjectService : IService
    {
        void Cache(GameObject shop);
        void Disable();
        GameObject Enable();
    }
}
