using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.WindowService;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hud
{
    public class Hud : MonoBehaviour
    {
        private IInputService _inputService;
        private IWindowService _windowService;
        private IPlayerProgressService _playerProgress;

        private bool _shopOpened;

        public void Construct(IInputService inputService, IWindowService windowService, IPlayerProgressService playerProgress)
        {
            _inputService = inputService;
            _windowService = windowService;
            _playerProgress = playerProgress;
        }

        private void Start()
        {
            _inputService.EKeyDown += () =>
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
    }
}
