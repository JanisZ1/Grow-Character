using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using ShopItemData = Assets.CodeBase.Infrastructure.StaticData.ShopItemData;

namespace Assets.CodeBase.Logic.CoinLogic
{
    public class Coin : MonoBehaviour, ISavedProgressReader
    {
        private IPlayerProgressService _playerProgress;
        private IShopItemObserver _shopItemObserver;

        public float Value { get; set; }

        public void Construct(IPlayerProgressService playerProgress, IShopItemObserver shopItemObserver)
        {
            _playerProgress = playerProgress;
            _shopItemObserver = shopItemObserver;
        }

        private void Start() =>
            _shopItemObserver.Buyed += ChangeValue;

        private void OnDestroy() =>
            _shopItemObserver.Buyed -= ChangeValue;

        private void ChangeValue(ShopItemData shopItemData) =>
            Value = shopItemData.Calories;

        public void Collect()
        {
            _playerProgress.Progress.MoneyData.Earn(Value);

            Destroy(gameObject);
        }

        public void LoadProgress(PlayerProgress progress) =>
            Value = progress.MoneyData.ByClickEarnAmount;
    }
}
