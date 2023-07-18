using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        private Transform _rotateTransform;
        private float _mouseYInput;
        private float _mouseXInput;

        public void Construct(Transform rotateTransform) =>
            _rotateTransform = rotateTransform;

        private void LateUpdate()
        {
            float mouseYInput = Input.GetAxis("Mouse Y");
            float mouseXInput = Input.GetAxis("Mouse X");

            _mouseYInput -= mouseYInput * _rotationSpeed;
            _mouseXInput -= mouseXInput * _rotationSpeed;

            _mouseYInput = ClampValue(_mouseYInput, -20f, 40f);

            _rotateTransform.localRotation = Quaternion.Euler(_mouseYInput, _mouseXInput, 0f);
        }

        private float ClampValue(float value, float min, float max) =>
            Mathf.Clamp(value, min, max);
    }
}