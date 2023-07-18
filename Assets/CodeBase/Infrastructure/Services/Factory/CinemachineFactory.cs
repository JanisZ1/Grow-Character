using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.States.GameStates;
using Assets.CodeBase.Logic;
using UnityEngine;
using CinemachineVirtualCamera = Cinemachine.CinemachineVirtualCamera;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class CinemachineFactory : ICinemachineFactory
    {
        private readonly IAssets _assets;
        private readonly IHeroHandler _heroHandler;

        public CinemachineFactory(IAssets assets, IHeroHandler heroHandler)
        {
            _assets = assets;
            _heroHandler = heroHandler;
        }

        public GameObject CreateCameraRotatePoint()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CameraRotatePointPath);
            gameObject.GetComponent<CameraRotatePoint>().Construct(_heroHandler);

            return gameObject;
        }

        public GameObject CreateVirtualCamera(Transform cameraRotatePoint)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.CineMachineVirtualCameraPath);
            gameObject.GetComponent<CinemachineVirtualCamera>().Follow = cameraRotatePoint;
            gameObject.GetComponent<CameraRotate>().Construct(cameraRotatePoint);
            return gameObject;
        }
    }
}