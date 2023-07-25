using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.WindowService;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hud
{
    public class Hud : MonoBehaviour
    {
        private IInputService _inputService;
        private IWindowService _windowService;
        private IPlayerProgressService _playerProgress;

        [SerializeField] private TextMeshProUGUI _money;

        private bool _shopOpened;

        public void Construct(IInputService inputService, IWindowService windowService, IPlayerProgressService playerProgress)
        {
            _inputService = inputService;
            _windowService = windowService;
            _playerProgress = playerProgress;
        }

        private void Start()
        {
            _playerProgress.PlayerProgress.MoneyData.Changed += UpdateHud;

            _inputService.EKeyDown += OpenOrCloseShop;
        }

        private void OnDestroy()
        {
            _playerProgress.PlayerProgress.MoneyData.Changed -= UpdateHud;
            _inputService.EKeyDown -= OpenOrCloseShop;
        }

        private void OpenOrCloseShop()
        {
            {
                if (!_shopOpened)
                {
                    _shopOpened = true;
                    _windowService.OpenShop();
                }
                else
                {
                    _shopOpened = false;
                    _windowService.CloseShop();
                };
            };
        }

        private void UpdateHud() =>
            _money.text = $"{_playerProgress.PlayerProgress.MoneyData.Money}";
    }
}
