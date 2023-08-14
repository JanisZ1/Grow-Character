using Assets.CodeBase.Logic;
using System;

namespace Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver
{
    public interface IBackgroundSoundObserver : IService
    {
        event Action<BackgroundSound> SoundFinished;
        void OnSoundFinished(BackgroundSound backgroundSound);
    }
}
