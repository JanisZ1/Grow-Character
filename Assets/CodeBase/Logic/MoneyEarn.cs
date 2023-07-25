using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class MoneyEarn : MonoBehaviour
    {
        private IInputService _inputService;
        private IPlayerProgressService _playerProgressService;

        public void Construct(IInputService inputService, IPlayerProgressService playerProgressService)
        {
            _inputService = inputService;
            _playerProgressService = playerProgressService;
        }

        private void Start() =>
            _inputService.MouseButtonDown += Earn;

        private void OnDestroy() =>
            _inputService.MouseButtonDown -= Earn;

        public void Earn()
        {
            Money money = new Money
            {
                //TODO: Get value from current buyed upgrades
                Value = 2
            };

            _playerProgressService.PlayerProgress.MoneyData.Earn(money);
        }
    }
}
