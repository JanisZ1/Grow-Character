using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States.GameStates
{
    public class HeroHandler : IHeroHandler
    {
        public GameObject HeroGameObject { get; private set; }

        public void Handle(GameObject hero) =>
            HeroGameObject = hero;
    }
}