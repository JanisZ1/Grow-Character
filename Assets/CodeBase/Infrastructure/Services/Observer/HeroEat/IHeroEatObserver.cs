using System;

namespace Assets.CodeBase.Infrastructure.Services.Observer.HeroEat
{
    public interface IHeroEatObserver : IService
    {
        event Action EatStarted;
        void OnEatStarted();
    }
}
