using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class MoneyEarn : MonoBehaviour
    {
        private IInputService _inputService;
        private IPlayerProgressService _playerProgressService;
        private IShopItemObserver _shopItemObserver;

        public float EarnValue { get; set; }

        public void Construct(IInputService inputService, IPlayerProgressService playerProgressService, IShopItemObserver shopItemObserver)
        {
            _inputService = inputService;
            _playerProgressService = playerProgressService;
            _shopItemObserver = shopItemObserver;
        }

        private void Start()
        {
            _inputService.MouseButtonDown += Earn;
            _shopItemObserver.Buyed += ChangeEarnValue;
        }

        private void OnDestroy()
        {
            _inputService.MouseButtonDown -= Earn;
            _shopItemObserver.Buyed -= ChangeEarnValue;
        }

        private void ChangeEarnValue(ShopItemData shopItemData) =>
            EarnValue = shopItemData.Calories;

        private void Earn() =>
            _playerProgressService.Progress.MoneyData.Earn(EarnValue);
    }
}
