using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface IHeroFactory : IService
    {
        void CreateHero(Vector3 at);
    }
}
