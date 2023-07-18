using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.HeroHandler
{
    public interface IHeroHandler : IService
    {
        GameObject HeroGameObject { get; }
        void Handle(GameObject hero);
    }
}