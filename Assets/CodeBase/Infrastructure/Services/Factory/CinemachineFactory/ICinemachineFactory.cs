using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CinemachineFactory
{
    public interface ICinemachineFactory : IService
    {
        GameObject CreateCameraRotatePoint();
        GameObject CreateVirtualCamera(Transform heroTransform);
    }
}