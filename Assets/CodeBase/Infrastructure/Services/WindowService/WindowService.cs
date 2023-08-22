using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.Services.ShopCache;
using Assets.CodeBase.Logic.Ui;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IUiFactory _uiFactory;
        private readonly IShopCachedObjectService _shopCachedObjectService;
        private readonly IPlayerProgressService _playerProgress;
        private GameObject _shop;

        public WindowService(IUiFactory uiFactory, IShopCachedObjectService shopCachedObjectService, IPlayerProgressService playerProgress)
        {
            _uiFactory = uiFactory;
            _shopCachedObjectService = shopCachedObjectService;
            _playerProgress = playerProgress;
        }

        public void CloseShop() =>
            _shop.GetComponent<ShopWindow>().Close();

        public void OpenShop()
        {
            _shop = _shopCachedObjectService.Enable();
            InformProgressReaders();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _uiFactory.ProgressReaders)
                progressReader.LoadProgress(_playerProgress.Progress);
        }
    }
}
