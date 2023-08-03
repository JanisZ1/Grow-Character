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
        [SerializeField] private int _id;

        public bool Unlocked { get; set; }

        public bool Buyed { get; set; }

        private void Start()
        {
            if (_id == 0)
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
            List<int> unlockedItemsList = progress.ShopBuyData.UnlockedItems;

            if (Buyed && !buyedItemsList.Contains(_id))
                buyedItemsList.Add(_id);

            if (Unlocked && !unlockedItemsList.Contains(_id))
                unlockedItemsList.Add(_id);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            List<int> buyedItems = progress.ShopBuyData.BuyedItems;
            List<int> unlockedItemsList = progress.ShopBuyData.UnlockedItems;

            if (buyedItems.Contains(_id))
            {
                Buyed = true;
                ChangeTextToBuyed();
            }

            if (unlockedItemsList.Contains(_id - 1) || _id == 0)
                Unlocked = true;
        }
    }
}
