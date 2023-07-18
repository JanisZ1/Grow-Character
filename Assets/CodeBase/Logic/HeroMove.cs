using Assets.CodeBase.Infrastructure.States.GameStates;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundedDrag;
        [SerializeField] private float _jumpDrag;
        private IInputService _inputService;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _inputService.SpaceKeyDown += Jump;

            transform.position = AddY();
        }

        private void OnDestroy() =>
            _inputService.SpaceKeyDown -= Jump;

        private void FixedUpdate()
        {
            Vector3 axis = _inputService.Axis;
            Vector3 direction = new Vector3(axis.z, 0, axis.x).normalized;

            _rigidbody.velocity += (direction.x * transform.right + direction.z * transform.forward) * _speed;

            if (_rigidbody.velocity != Vector3.zero)
            {
                Transform cameraTransform = Camera.main.transform;
                Vector3 rotation = new Vector3(transform.eulerAngles.x, cameraTransform.eulerAngles.y, transform.eulerAngles.z);

                transform.eulerAngles = rotation;
            }

            if (IsGrounded())
                _rigidbody.drag = _groundedDrag;
            else
                _rigidbody.drag = _jumpDrag;
        }

        private void Jump()
        {
            if (IsGrounded())
                _rigidbody.AddForce(Vector3.up * _jumpSpeed);
        }

        private Vector3 AddY() =>
            new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);

        private bool IsGrounded() =>
            Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.1f, _groundLayer);
    }
}
