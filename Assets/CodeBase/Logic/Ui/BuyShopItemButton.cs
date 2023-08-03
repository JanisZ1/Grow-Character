using Assets.CodeBase.Infrastructure.Data;
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
        [SerializeField] private ShopItem _shopItem;
        [SerializeField] private Button _button;
        [SerializeField] private ShopItemType _shopItemType;

        private IStaticDataService _staticData;
        private IPlayerProgressService _playerProgress;
        private IShopItemObserver _shopItemObserver;
        private ShopItemStaticData _shopItemStaticData;

        public void Construct(IStaticDataService staticData, IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _staticData = staticData;
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;

            _shopItemStaticData = _staticData.ForShopItem(_shopItemType);
        }

        private void Start() =>
            _button.onClick.AddListener(BuyItem);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(BuyItem);

        private void BuyItem()
        {
            MoneyData moneyData = _playerProgress.Progress.MoneyData;

            if (moneyData.Count >= _shopItemStaticData.Price && !_shopItem.Buyed && _shopItem.Unlocked)
            {
                SaveData(moneyData);
                MarkShopItemBuyed();
                UnlockNextItem();
                ChangeBuyedText();
                _shopItemObserver.OnBuyed(_shopItemStaticData);
            }
        }

        private void SaveData(MoneyData moneyData)
        {
            moneyData.Spend(_shopItemStaticData.Price);
            moneyData.ByClickEarnAmount = _shopItemStaticData.Profit;
        }

        private void MarkShopItemBuyed() =>
            _shopItem.Buyed = true;

        private void UnlockNextItem() =>
            _shopItem.UnlockNextItem();

        private void ChangeBuyedText() =>
            _shopItem.ChangeTextToBuyed();
    }
}
