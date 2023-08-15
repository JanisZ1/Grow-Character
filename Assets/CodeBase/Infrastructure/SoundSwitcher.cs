using Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class SoundSwitcher : MonoBehaviour
    {
        private IBackgroundSoundObserver _backgroundSoundObserver;

        public void Construct(IBackgroundSoundObserver backgroundSoundObserver) =>
            _backgroundSoundObserver = backgroundSoundObserver;

        private void Start() =>
            _backgroundSoundObserver.SoundFinished += OnSoundFinished;

        private void OnDestroy() =>
            _backgroundSoundObserver.SoundFinished -= OnSoundFinished;

        private void OnSoundFinished(BackgroundSound backgroundSound) =>
            backgroundSound.PlayNext();
    }
}