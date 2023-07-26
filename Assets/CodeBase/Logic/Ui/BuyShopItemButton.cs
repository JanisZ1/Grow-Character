using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic.Ui
{
    public class BuyShopItemButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ShopItemType _shopItemType;

        private IStaticDataService _staticData;
        private IShopItemObserver _shopItemObserver;
        private ShopItemData _shopItemData;

        public void Construct(IStaticDataService staticData, IShopItemObserver shopItemObserver)
        {
            _staticData = staticData;
            _shopItemObserver = shopItemObserver;

            _shopItemData = _staticData.ForShopItem(_shopItemType);
        }

        private void Start() =>
            _button.onClick.AddListener(BuyItem);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(BuyItem);

        private void BuyItem() =>
            _shopItemObserver.OnBuyed(_shopItemData);
    }
}
