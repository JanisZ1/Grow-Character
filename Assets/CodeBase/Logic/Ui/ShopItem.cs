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

        [SerializeField] private string _id;

        public bool Buyed { get; set; }

        public void ChangeTextToBuyed() =>
            _priceText.text = "Buyed";

        public void SaveProgress(PlayerProgress progress)
        {
            List<string> buyedItemsList = progress.ShopBuyData.BuyedItems;

            if (Buyed && !buyedItemsList.Contains(_id))
                buyedItemsList.Add(_id);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            List<string> buyedItems = progress.ShopBuyData.BuyedItems;

            if (buyedItems.Contains(_id))
            {
                Buyed = true;
                ChangeTextToBuyed();
            }
        }
    }
}
