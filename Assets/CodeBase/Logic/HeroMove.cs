using Assets.CodeBase.Infrastructure.States.GameStates;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private IInputService _inputService;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start() =>
            _inputService.SpaceDown += Jump;

        private void OnDestroy() =>
            _inputService.SpaceDown -= Jump;

        private void Update()
        {
            Vector3 axis = _inputService.Axis;

            _rigidbody.velocity += new Vector3(axis.x, 0, axis.z);
        }

        private void Jump()
        {
        }
    }
}
