using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface IHeroFactory : IService
    {
        GameObject CreateHero();
    }
}
