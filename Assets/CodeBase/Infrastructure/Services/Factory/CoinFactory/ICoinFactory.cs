using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.CoinFactory
{
    public interface ICoinFactory : IService
    {
        void CreateSpawner(Vector3 at);
        void CreateCoin(Vector3 at);
    }
}
