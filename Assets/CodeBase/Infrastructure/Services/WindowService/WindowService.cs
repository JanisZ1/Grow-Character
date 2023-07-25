﻿using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Logic.Ui;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IUiFactory _uiFactory;
        private GameObject _shop;

        public WindowService(IUiFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void CloseShop() =>
            _shop.GetComponent<ShopWindow>().Close();

        public void OpenShop() =>
            _shop = _uiFactory.CreateShop();
    }
}
