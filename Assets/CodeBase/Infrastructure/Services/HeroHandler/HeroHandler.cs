using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.HeroHandler
{
    public class HeroHandler : IHeroHandler
    {
        public GameObject HeroGameObject { get; private set; }

        public void Handle(GameObject hero) =>
            HeroGameObject = hero;
    }
}