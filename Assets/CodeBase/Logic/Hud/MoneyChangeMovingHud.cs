using TMPro;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hud
{
    public class MoneyChangeMovingHud : MonoBehaviour
    {
        public TextMeshProUGUI MoneyText;

        private const string Move = "Move";

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Animator _animator;

        [SerializeField] private Vector2 _spawnAreaMin;
        [SerializeField] private Vector2 _spawnAreaMax;

        public void PlayAnimation() =>
            _animator.SetTrigger(Move);

        public void SetRandomScreenPosition()
        {
            float randomX = Random.Range(_spawnAreaMin.x, _spawnAreaMax.x);
            float randomY = Random.Range(_spawnAreaMin.y, _spawnAreaMax.y);

            _rectTransform.anchoredPosition = new Vector2(randomX, randomY);
        }

        public void TriggerAnimationPlayedEvent() =>
            Destroy(gameObject);
    }
}
