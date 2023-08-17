﻿using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer.HeroEat;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.WindowService;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic.Hud
{
    public class Hud : MonoBehaviour
    {
        private IInputService _inputService;
        private IWindowService _windowService;
        private IPlayerProgressService _playerProgress;
        private IHeroEatObserver _heroEatObserver;

        [SerializeField] private float _eatTime;

        [SerializeField] private Image _eatTimerImage;
        [SerializeField] private TextMeshProUGUI _eatTimerText;

        [SerializeField] private TextMeshProUGUI _money;
        [SerializeField] private TextMeshProUGUI _mass;
        [SerializeField] private TextMeshProUGUI _maxMass;

        [SerializeField] private MoneyChangeMovingHud _moneyChangeUiPrefab;

        private string _massText;
        private string _maxMassText;

        private bool _shopOpened;

        public void Construct(IInputService inputService, IWindowService windowService, IHeroEatObserver heroEatObserver, IPlayerProgressService playerProgress)
        {
            _inputService = inputService;
            _windowService = windowService;
            _playerProgress = playerProgress;
            _heroEatObserver = heroEatObserver;
        }

        private void Start()
        {
            _massText = _mass.text;
            _maxMassText = _maxMass.text;
            UpdateTexts();

            _playerProgress.Progress.MoneyData.Changed += UpdateMoneyInHud;
            _playerProgress.Progress.MoneyData.MoneyEarned += ShowMoneyEarnedChange;
            _playerProgress.Progress.MoneyData.MoneySpended += ShowMoneySpendedChange;
            _playerProgress.Progress.MassData.Mass.Changed += UpdateMassInHud;
            _playerProgress.Progress.MassData.MaxMass.Changed += UpdateMaxMassInHud;

            _heroEatObserver.EatStarted += EatStarted;

            _inputService.EKeyDown += OpenOrCloseShop;
        }

        private void OnDestroy()
        {
            _playerProgress.Progress.MoneyData.Changed -= UpdateMoneyInHud;
            _playerProgress.Progress.MoneyData.MoneyEarned -= ShowMoneyEarnedChange;
            _playerProgress.Progress.MoneyData.MoneySpended -= ShowMoneySpendedChange;
            _playerProgress.Progress.MassData.Mass.Changed -= UpdateMassInHud;
            _playerProgress.Progress.MassData.MaxMass.Changed -= UpdateMaxMassInHud;

            _inputService.EKeyDown -= OpenOrCloseShop;
        }

        private void EatStarted() =>
            StartCoroutine(EatTimerUpdate());

        private IEnumerator EatTimerUpdate()
        {
            float value = 0;

            while (value < _eatTime)
            {
                yield return new WaitForEndOfFrame();
                UpdateEatTimer(value);

                value += Time.deltaTime;
            }
            SetDefaultEatTimerValues();
        }

        private void UpdateEatTimer(float value)
        {
            _eatTimerImage.fillAmount = value / _eatTime;
            _eatTimerText.text = (_eatTime - value).ToString("0.0");
        }

        private void SetDefaultEatTimerValues()
        {
            _eatTimerImage.fillAmount = 1;
            _eatTimerText.text = "0";
        }

        private void ShowMoneySpendedChange(float moneySpended) =>
            ShowMoneyChange(-moneySpended);

        private void ShowMoneyEarnedChange(float moneyEarned) =>
            ShowMoneyChange(moneyEarned);

        private void UpdateTexts()
        {
            UpdateMoneyInHud();
            UpdateMassInHud();
            UpdateMaxMassInHud();
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
            _maxMass.text = _maxMassText + _playerProgress.Progress.MassData.MaxMass.Current;

        private void UpdateMassInHud() =>
            _mass.text = _massText + _playerProgress.Progress.MassData.Mass.Current.ToString("0.00");

        private void UpdateMoneyInHud() =>
            _money.text = _playerProgress.Progress.MoneyData.Count.ToString("0.0");

        private void ShowMoneyChange(float money)
        {
            MoneyChangeMovingHud moneyChangeMovingUi = Instantiate(_moneyChangeUiPrefab, transform);

            moneyChangeMovingUi.MoneyText.text = $"{money}";
            moneyChangeMovingUi.SetRandomScreenPosition();
            moneyChangeMovingUi.PlayAnimation();
        }
    }
}
