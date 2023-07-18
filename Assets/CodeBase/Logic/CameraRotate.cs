using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        private Transform _rotateTransform;

        public void Construct(Transform rotateTransform) =>
            _rotateTransform = rotateTransform;

        private void LateUpdate()
        {
            float MouseXInput = Input.GetAxis("Mouse X");
            float MouseYInput = Input.GetAxis("Mouse Y");
            _rotateTransform.rotation *= Quaternion.AngleAxis(MouseXInput * _rotationSpeed, Vector3.right);
            _rotateTransform.rotation *= Quaternion.AngleAxis(MouseYInput * _rotationSpeed, Vector3.up);
        }
    }
}
