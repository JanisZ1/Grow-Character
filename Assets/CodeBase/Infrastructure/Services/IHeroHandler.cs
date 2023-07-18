using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public interface IHeroHandler : IService
    {
        GameObject HeroGameObject { get; }
        void Handle(GameObject hero);
    }
}