using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Logic.Ui;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticDataService;
        private readonly IShopItemObserver _shopItemObserver;
        private Transform _uiRootTransform;

        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

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
            GameObject shop = InstantiateRegistered(AssetPath.ShopPath, _uiRootTransform);

            foreach (BuyShopItemButton buyShopItemButton in shop.GetComponentsInChildren<BuyShopItemButton>())
                buyShopItemButton.Construct(_staticDataService, _shopItemObserver);

            return shop;
        }

        private GameObject InstantiateRegistered(string assetPath, Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(assetPath, parent);

            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}

