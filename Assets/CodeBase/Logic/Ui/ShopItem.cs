using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Infrastructure.StaticData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic.Ui
{
    public class ShopItem : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private ShopItem _nextShopItem;

        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _profitText;
        [SerializeField] private TextMeshProUGUI _massGiveText;
        [SerializeField] private TextMeshProUGUI _maximumMassText;

        public TextMeshProUGUI PriceText => _priceText;

        public TextMeshProUGUI ProfitText => _profitText;

        public TextMeshProUGUI MassGiveText => _massGiveText;

        public TextMeshProUGUI MaximumMassText => _maximumMassText;

        public Image Icon => _icon;

        public int Id { get; set; }

        public bool Unlocked { get; set; }

        public bool Buyed { get; set; }

        private void Start()
        {
            if (Id == 0)
                Unlocked = true;
        }

        public void ChangeTextToBuyed() =>
            _priceText.text = "Buyed";

        public void UnlockNextItem(ShopItemStaticData shopItemStaticData)
        {
            if (_nextShopItem != null)
            {
                _nextShopItem.Unlocked = true;

                UpdateTextWith(shopItemStaticData);
            }
        }

        public void SaveProgress(PlayerProgress progress)
        {
            List<int> buyedItemsList = progress.ShopBuyData.BuyedItems;

            if (Buyed && !buyedItemsList.Contains(Id))
                buyedItemsList.Add(Id);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            List<int> buyedItems = progress.ShopBuyData.BuyedItems;

            if (buyedItems.Contains(Id))
            {
                Buyed = true;
                ChangeTextToBuyed();
            }

            if (buyedItems.Contains(Id - 1) || Id == 0)
                Unlocked = true;
            else
                UpdateTextToUnknown();
        }

        private void UpdateTextWith(ShopItemStaticData shopItemStaticData)
        {
            _nextShopItem.PriceText.text = $"{shopItemStaticData.Price}";
            _nextShopItem.ProfitText.text = $"Profit {shopItemStaticData.Profit}";
            _nextShopItem.MassGiveText.text = $"Calories {shopItemStaticData.Calories}";
            _nextShopItem.MaximumMassText.text = $"MaximumMass {shopItemStaticData.MaximumMass}";
        }

        private void UpdateTextToUnknown()
        {
            _priceText.text = "???";
            _profitText.text = "Profit ???";
            _massGiveText.text = "Calories ???";
            _maximumMassText.text = "MaximumMass ???";
        }
    }
}
