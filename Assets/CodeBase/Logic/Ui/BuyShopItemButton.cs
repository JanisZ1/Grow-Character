﻿using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.UI;
using ShopItemStaticData = Assets.CodeBase.Infrastructure.StaticData.ShopItemStaticData;

namespace Assets.CodeBase.Logic.Ui
{
    public class BuyShopItemButton : MonoBehaviour
    {
        public ShopItem ShopItem;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _buyItemSound;
        public ShopItemType ShopItemType;

        private IStaticDataService _staticData;
        private IPlayerProgressService _playerProgress;
        private IShopItemObserver _shopItemObserver;

        public ShopItemStaticData ShopItemStaticData { get; private set; }

        public void Construct(IStaticDataService staticData, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _staticData = staticData;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;

            ShopItemStaticData = _staticData.ForShopItem(ShopItemType);
        }

        private void Start() =>
            _button.onClick.AddListener(BuyItem);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(BuyItem);

        private void BuyItem()
        {
            MoneyData moneyData = _playerProgress.Progress.MoneyData;

            if (moneyData.Count >= ShopItemStaticData.Price && !ShopItem.Buyed && ShopItem.Unlocked)
            {
                SaveData(moneyData);
                MarkShopItemBuyed();
                UnlockNextItem();
                ChangeBuyedText();
                _buyItemSound.Play();
                _shopItemObserver.OnBuyed(ShopItemStaticData);
            }
        }

        private void SaveData(MoneyData moneyData)
        {
            moneyData.Spend(ShopItemStaticData.Price);
            moneyData.ByClickEarnAmount = ShopItemStaticData.Profit;
        }

        private void MarkShopItemBuyed() =>
            ShopItem.Buyed = true;

        private void UnlockNextItem()
        {
            if (ShopItem.NextShopItem)
            {
                ShopItemType shopItemType = ShopItem.NextShopItem.GetComponentInChildren<BuyShopItemButton>().ShopItemType;
                ShopItemStaticData shopItemStaticData = _staticData.ForShopItem(shopItemType);

                ShopItem.UnlockNextItem(shopItemStaticData);
            }
        }

        private void ChangeBuyedText() =>
            ShopItem.ChangeTextToBuyed();
    }
}
