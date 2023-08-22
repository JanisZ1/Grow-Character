using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.ShopCache
{
    public class ShopCachedObjectService : IShopCachedObjectService
    {
        private GameObject _shop;

        public void Cache(GameObject shop) =>
            _shop = shop;

        public void Disable() =>
            _shop.SetActive(false);

        public GameObject Enable()
        {
            _shop.SetActive(true);
            return _shop;
        }
    }
}
