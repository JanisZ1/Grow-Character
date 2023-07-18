using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using UnityEngine;
using CinemachineVirtualCamera = Cinemachine.CinemachineVirtualCamera;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class CinemachineFactory : ICinemachineFactory
    {
        private readonly IAssets _assets;

        public CinemachineFactory(IAssets assets) =>
            _assets = assets;

        public GameObject CreateVirtualCamera(Transform heroTransform)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CineMachineVirtualCameraPath);
            gameObject.GetComponent<CinemachineVirtualCamera>().Follow = heroTransform;
            return gameObject;
        }
    }
}