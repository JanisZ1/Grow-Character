using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Hero;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class MoneyEarn : MonoBehaviour
    {
        [SerializeField] private HeroEat _heroEat;

        private IPlayerProgressService _playerProgressService;
        private IShopItemObserver _shopItemObserver;

        public float EarnValue { get; set; }

        public void Construct(IPlayerProgressService playerProgressService, IShopItemObserver shopItemObserver)
        {
            _playerProgressService = playerProgressService;
            _shopItemObserver = shopItemObserver;
        }

        private void Start()
        {
            _shopItemObserver.Buyed += ChangeEarnValue;
            _heroEat.Eated += Earn;
        }

        private void OnDestroy()
        {
            _shopItemObserver.Buyed -= ChangeEarnValue;
            _heroEat.Eated -= Earn;
        }

        private void ChangeEarnValue(ShopItemStaticData shopItemData) =>
            EarnValue = shopItemData.Profit;

        private void Earn() =>
            _playerProgressService.Progress.MoneyData.Earn(EarnValue);
    }
}
