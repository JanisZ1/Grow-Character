using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic.Ui
{
    public class BuyShopItemButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private float _moneyValue;

        private readonly IPlayerProgressService _playerProgressService;

        public BuyShopItemButton(IPlayerProgressService playerProgressService) =>
            _playerProgressService = playerProgressService;

        private void Start() =>
            _button.onClick.AddListener(BuyItem);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(BuyItem);

        private void BuyItem()
        {
            //_playerProgressService.PlayerProgress.MoneyData.Value = _moneyValue;
        }
    }
}
