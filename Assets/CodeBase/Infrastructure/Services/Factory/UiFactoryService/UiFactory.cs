using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Ui;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerProgressService _playerProgress;
        private readonly IShopItemObserver _shopItemObserver;
        private Transform _uiRootTransform;

        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public UiFactory(IAssets assets, IStaticDataService staticDataService, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _assets = assets;
            _staticDataService = staticDataService;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;
        }

        public void CreateUiRoot() =>
            _uiRootTransform = _assets.Instantiate(AssetPath.UiRootPath).transform;

        public GameObject CreateShop()
        {
            GameObject gameObject = InstantiateRegistered(AssetPath.ShopPath, _uiRootTransform);

            foreach (BuyShopItemButton buyShopItemButton in gameObject.GetComponentsInChildren<BuyShopItemButton>())
            {
                buyShopItemButton.Construct(_staticDataService, _playerProgress, _shopItemObserver);

                ShopItemStaticData shopItemStaticData = buyShopItemButton.ShopItemStaticData;
                ShopItem shopItem = buyShopItemButton.ShopItem;

                shopItem.Id = shopItemStaticData.Id;
                shopItem.Icon.sprite = shopItemStaticData.IconSprite;
                shopItem.PriceText.text = $"{shopItemStaticData.Price}";
                shopItem.ProfitText.text = $"Profit {shopItemStaticData.Profit}";
                shopItem.MassGiveText.text = $"Calories {shopItemStaticData.Calories}";
                shopItem.MaximumMassText.text = $"MaximumMass {shopItemStaticData.MaximumMass}";
            }

            return gameObject;
        }

        private GameObject InstantiateRegistered(string path, Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(path, parent);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                if (progressReader is ISavedProgress progressWriter)
                    ProgressWriters.Add(progressWriter);

                ProgressReaders.Add(progressReader);
            }
        }

        public void Cleanup()
        {
            ProgressWriters.Clear();
            ProgressReaders.Clear();
        }

        public GameObject CreateClickLearnObject() =>
            _assets.Instantiate(AssetPath.ClickLearnUiPath, _uiRootTransform);
    }
}

