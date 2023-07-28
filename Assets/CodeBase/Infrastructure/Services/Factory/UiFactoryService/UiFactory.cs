using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Logic.Ui;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticDataService;
        private readonly IShopItemObserver _shopItemObserver;
        private Transform _uiRootTransform;       

        public UiFactory(IAssets assets, IStaticDataService staticDataService, IShopItemObserver shopItemObserver)
        {
            _assets = assets;
            _staticDataService = staticDataService;
            _shopItemObserver = shopItemObserver;
        }

        public void CreateUiRoot() =>
            _uiRootTransform = _assets.Instantiate(AssetPath.UiRootPath).transform;

        public GameObject CreateShop()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.ShopPath, _uiRootTransform);

            foreach (BuyShopItemButton buyShopItemButton in gameObject.GetComponentsInChildren<BuyShopItemButton>())
                buyShopItemButton.Construct(_staticDataService, _shopItemObserver);

            return gameObject;
        }
    }
}

