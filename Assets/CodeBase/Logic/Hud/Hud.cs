﻿using Assets.CodeBase.Infrastructure.Services.InputService;
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
        [SerializeField] private TextMeshProUGUI _mass;
        [SerializeField] private TextMeshProUGUI _maxMass;

        private string _massText;
        private string _maxMassText;

        private bool _shopOpened;

        public void Construct(IInputService inputService, IWindowService windowService, IPlayerProgressService playerProgress)
        {
            _inputService = inputService;
            _windowService = windowService;
            _playerProgress = playerProgress;
        }

        private void Start()
        {
            _massText = _mass.text;
            _maxMassText = _maxMass.text;

            _playerProgress.PlayerProgress.MoneyData.Changed += UpdateMoneyInHud;
            _playerProgress.PlayerProgress.MassData.Mass.Changed += UpdateMassInHud;
            _playerProgress.PlayerProgress.MassData.MaxMass.Changed += UpdateMaxMassInHud;

            _inputService.EKeyDown += OpenOrCloseShop;
        }

        private void OnDestroy()
        {
            _playerProgress.PlayerProgress.MoneyData.Changed -= UpdateMoneyInHud;
            _playerProgress.PlayerProgress.MassData.Mass.Changed -= UpdateMassInHud;
            _playerProgress.PlayerProgress.MassData.MaxMass.Changed -= UpdateMaxMassInHud;

            _inputService.EKeyDown -= OpenOrCloseShop;
        }

        private void OpenOrCloseShop()
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
            }
        }

        private void UpdateMaxMassInHud() =>
            _maxMass.text = _maxMassText + _playerProgress.PlayerProgress.MassData.MaxMass.Current;

        private void UpdateMassInHud() =>
            _mass.text = _massText + _playerProgress.PlayerProgress.MassData.Mass.Current.ToString("0.00");

        private void UpdateMoneyInHud() =>
            _money.text = $"{_playerProgress.PlayerProgress.MoneyData.Money}";
    }
}
