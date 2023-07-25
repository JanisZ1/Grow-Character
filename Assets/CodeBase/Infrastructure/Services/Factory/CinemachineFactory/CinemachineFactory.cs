using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.HeroHandler;
using Assets.CodeBase.Logic.Hero;
using Cinemachine;
using UnityEngine;
using CinemachineVirtualCamera = Cinemachine.CinemachineVirtualCamera;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory
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

            Cinemachine3rdPersonFollow thirdPersonFollow = gameObject.GetComponentInChildren<Cinemachine3rdPersonFollow>();
            gameObject.GetComponent<CameraRotate>().Construct(cameraRotatePoint);
            gameObject.GetComponent<CameraDistanceChange>().Construct(cameraRotatePoint, thirdPersonFollow);
            return gameObject;
        }
    }
}