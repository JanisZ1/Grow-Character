using System;

namespace Assets.CodeBase.Infrastructure.Services.Observer.HeroEat
{
    public class HeroEatObserver : IHeroEatObserver
    {
        public event Action EatStarted;

        public void OnEatStarted() =>
            EatStarted?.Invoke();
    }
}
