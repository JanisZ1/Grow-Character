using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface ICinemachineFactory : IService
    {
        GameObject CreateVirtualCamera(Transform heroTransform);
    }
}