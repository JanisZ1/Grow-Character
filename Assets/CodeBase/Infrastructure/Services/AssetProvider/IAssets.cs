using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.AssetProvider
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path, Vector3 at);
    }
}
