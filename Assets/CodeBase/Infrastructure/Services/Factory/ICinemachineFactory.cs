using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface ICinemachineFactory : IService
    {
        GameObject CreateCameraRotatePoint();
        GameObject CreateVirtualCamera(Transform heroTransform);
    }
}