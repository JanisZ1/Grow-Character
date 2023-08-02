﻿using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.UI;
using ShopItemData = Assets.CodeBase.Infrastructure.StaticData.ShopItemData;

namespace Assets.CodeBase.Logic.Ui
{
    public class BuyShopItemButton : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItem;
        [SerializeField] private Button _button;
        [SerializeField] private ShopItemType _shopItemType;

        private IStaticDataService _staticData;
        private IPlayerProgressService _playerProgress;
        private IShopItemObserver _shopItemObserver;
        private ShopItemData _shopItemData;

        public void Construct(IStaticDataService staticData, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _staticData = staticData;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;

            _shopItemData = _staticData.ForShopItem(_shopItemType);
        }

        private void Start()
        {
            if (!_shopItem.Buyed)
                _button.onClick.AddListener(BuyItem);
        }

        private void OnDestroy()
        {
            if (!_shopItem.Buyed)
                _button.onClick.RemoveListener(BuyItem);
        }

        private void BuyItem()
        {
            MoneyData moneyData = _playerProgress.Progress.MoneyData;

            if (moneyData.Count >= _shopItemData.Price && !_shopItem.Buyed)
            {
                SaveData(moneyData);
                MarkShopItemBuyed();
                ChangeBuyedText();
                _shopItemObserver.OnBuyed(_shopItemData);
            }
        }

        private void SaveData(MoneyData moneyData)
        {
            moneyData.Spend(_shopItemData.Price);
            moneyData.ByClickEarnAmount = _shopItemData.Profit;
        }

        private void MarkShopItemBuyed() =>
            _shopItem.Buyed = true;

        private void ChangeBuyedText() =>
            _shopItem.ChangeTextToBuyed();
    }
}
