using Assets.CodeBase.Logic;
using System;

namespace Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver
{
    public class BackgroundSoundObserver : IBackgroundSoundObserver
    {
        public event Action<BackgroundSound> SoundFinished;

        public void OnSoundFinished(BackgroundSound backgroundSound) =>
            SoundFinished?.Invoke(backgroundSound);
    }
}
