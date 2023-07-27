using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.AssetProvider
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, Transform parent);
        GameObject Instantiate(string path, Transform parent, Vector3 at);
    }
}
