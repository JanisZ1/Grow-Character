using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _animator.SetFloat("Horizontal", horizontalInput);
        _animator.SetFloat("Vertical", verticalInput);
    }
}
