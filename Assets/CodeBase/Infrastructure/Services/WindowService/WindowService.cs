using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Logic.Ui;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IUiFactory _uiFactory;
        private readonly IPlayerProgressService _playerProgress;
        private GameObject _shop;

        public WindowService(IUiFactory uiFactory, IPlayerProgressService playerProgress)
        {
            _uiFactory = uiFactory;
            _playerProgress = playerProgress;
        }

        public void CloseShop() =>
            _shop.GetComponent<ShopWindow>().Close();

        public void OpenShop()
        {
            _shop = _uiFactory.CreateShop();
            InformProgressReaders();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _uiFactory.ProgressReaders)
                progressReader.LoadProgress(_playerProgress.Progress);
        }
    }
}
