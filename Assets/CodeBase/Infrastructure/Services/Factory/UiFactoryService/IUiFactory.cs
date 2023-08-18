using Assets.CodeBase.Infrastructure.Services.SaveLoad;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService
{
    public interface IUiFactory : IService
    {
        void CreateUiRoot();
        GameObject CreateShop();

        List<ISavedProgress> ProgressWriters { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        void Cleanup();
        GameObject CreateClickLearnObject();
    }
}
