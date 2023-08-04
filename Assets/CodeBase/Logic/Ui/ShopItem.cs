using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
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

        public void UnlockNextItem()
        {
            if (_nextShopItem != null)
                _nextShopItem.Unlocked = true;
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
        }
    }
}
