using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.Logic.Ui
{
    public class ShopItem : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private ShopItem _nextShopItem;

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
