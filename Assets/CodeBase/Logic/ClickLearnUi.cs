using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class ClickLearnUi : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private int _learnAnimationHash = Animator.StringToHash(LearnTriggerName);

        private const string LearnTriggerName = "Learn";

        public void PlayAnimation() =>
            _animator.SetTrigger(_learnAnimationHash);

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Destroy(gameObject);
        }
    }
}
