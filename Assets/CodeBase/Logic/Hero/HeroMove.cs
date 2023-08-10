using Assets.CodeBase.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Transform _cameraTransform;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;

            transform.position = AddY();
        }

        private void FixedUpdate()
        {
            Vector3 axis = _inputService.Axis.normalized;
            Vector3 direction = Direction(axis);
            AddVelocity(to: direction);

            if (Moving())
                SetRotationLikeCamera();
        }

        private void AddVelocity(Vector3 to) => 
            _rigidbody.velocity += (to.x * transform.right + to.z * transform.forward) * (_speed + transform.localScale.x);

        private Vector3 Direction(Vector3 axis) =>
            new Vector3(axis.z, _rigidbody.velocity.y, axis.x);

        private void SetRotationLikeCamera()
        {
            Vector3 rotation = new Vector3(transform.eulerAngles.x, _cameraTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.eulerAngles = rotation;
        }

        private Vector3 AddY() =>
            new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        private bool Moving() =>
            _rigidbody.velocity != Vector3.zero;
    }
}
