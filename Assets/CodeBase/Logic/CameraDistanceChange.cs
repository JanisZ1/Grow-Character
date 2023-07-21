using Cinemachine;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class CameraDistanceChange : MonoBehaviour
    {
        [SerializeField] private float _cameraDistanceMultiplier = 2.67f;

        private Cinemachine3rdPersonFollow _cinemachine3rdPersonFollow;
        private Transform _scaleTransform;

        public void Construct(Transform scaleTransform, Cinemachine3rdPersonFollow thirdPersonFollow)
        {
            _scaleTransform = scaleTransform;
            _cinemachine3rdPersonFollow = thirdPersonFollow;
        }

        private void LateUpdate() =>
            SetCameraDistance();

        private void SetCameraDistance() =>
            _cinemachine3rdPersonFollow.CameraDistance = _scaleTransform.localScale.x * _cameraDistanceMultiplier;
    }
}