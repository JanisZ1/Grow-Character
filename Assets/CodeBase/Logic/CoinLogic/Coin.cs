using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.Observer;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using Assets.CodeBase.Logic.Spawners.Coin;
using System.Collections;
using UnityEngine;
using ShopItemStaticData = Assets.CodeBase.Infrastructure.StaticData.ShopItemStaticData;

namespace Assets.CodeBase.Logic.CoinLogic
{
    public class Coin : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private Vector3 _rotation;
        [SerializeField] private float _collectEffectTime = 2f;
        [SerializeField] private float _destroyAfterCollectedTime = 2f;
        [SerializeField] private GameObject _pickupSoundPrefab;
        [SerializeField] private CoinRaycastToGround _coinRaycastToGround;

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

        private void Update() =>
            transform.Rotate(_rotation);

        private void ChangeValue(ShopItemStaticData shopItemData) =>
            Value = shopItemData.Profit;

        public void Collect()
        {
            _playerProgress.Progress.MoneyData.Earn(Value);

            MarkSpawnerNotSpawned();

            _coinRaycastToGround.enabled = false;
            PlayEffects();
            Destroy(gameObject, _destroyAfterCollectedTime);
        }

        private void PlayEffects()
        {
            Instantiate(_pickupSoundPrefab, transform);
            StartCoroutine(PlayCollectEffect(_collectEffectTime));
        }

        private IEnumerator PlayCollectEffect(float effectTime)
        {
            float currentTime = 0f;

            Vector3 position = transform.position;

            while (currentTime < effectTime)
            {
                yield return null;

                transform.position = Vector3.Lerp(position, position + Vector3.up, currentTime);
                currentTime += Time.deltaTime;
            }
        }

        private void MarkSpawnerNotSpawned() =>
            GetComponentInParent<CoinSpawner>().Spawned = false;

        public void LoadProgress(PlayerProgress progress) =>
            Value = progress.MoneyData.ByClickEarnAmount;
    }
}
