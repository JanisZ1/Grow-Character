using Assets.CodeBase.Infrastructure.Services.InputService;
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
        private Transform _cameraTransform;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;

            _inputService.SpaceKeyDown += Jump;

            transform.position = AddY();
        }

        private void OnDestroy() =>
            _inputService.SpaceKeyDown -= Jump;

        private void FixedUpdate()
        {
            Vector3 axis = _inputService.Axis.normalized;
            Vector3 direction = ExcludeYAxis(axis);
            AddVelocity(to: direction);

            if (Moving())
                SetRotationLikeCamera();

            if (IsGrounded())
                SetRigidbodyDrag(_groundedDrag);
            else
                SetRigidbodyDrag(_jumpDrag);
        }

        private void AddVelocity(Vector3 to) =>
            _rigidbody.velocity += (to.x * transform.right + to.z * transform.forward) * _speed;

        private Vector3 ExcludeYAxis(Vector3 axis) =>
            new Vector3(axis.z, 0, axis.x);

        private void SetRotationLikeCamera()
        {
            Vector3 rotation = new Vector3(transform.eulerAngles.x, _cameraTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.eulerAngles = rotation;
        }

        private void Jump()
        {
            if (IsGrounded())
                _rigidbody.AddForce(Vector3.up * _jumpSpeed);
        }

        private Vector3 AddY() =>
            new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);

        private void SetRigidbodyDrag(float drag) =>
            _rigidbody.drag = drag;

        private bool Moving() =>
            _rigidbody.velocity != Vector3.zero;

        private bool IsGrounded() =>
            Physics.Raycast(transform.position, Vector3.down, transform.localScale.y + 0.1f, _groundLayer);
    }
}
