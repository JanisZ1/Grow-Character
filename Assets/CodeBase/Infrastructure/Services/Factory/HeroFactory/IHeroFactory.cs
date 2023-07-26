using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory
{
    public interface IHeroFactory : IService
    {
        GameObject CreateHero();
    }
}
