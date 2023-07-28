using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory
{
    public interface IHeroFactory : IService
    {
        GameObject CreateHero();
        List<ISavedProgress> ProgressWriters { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        void Cleanup();
    }
}
