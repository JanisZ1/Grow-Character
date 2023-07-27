using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;

namespace Assets.CodeBase.Logic.CoinLogic
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _value;

        private IPlayerProgressService _playerProgress;

        public void Construct(IPlayerProgressService playerProgress) =>
            _playerProgress = playerProgress;

        public void Collect()
        {
            _playerProgress.PlayerProgress.MoneyData.Earn(_value);
            Destroy(gameObject);
        }
    }
}
