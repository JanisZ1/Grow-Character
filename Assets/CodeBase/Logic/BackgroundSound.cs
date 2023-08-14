using Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _nextSoundSource;

        private IBackgroundSoundObserver _backgroundSoundObserver;

        private bool _soundFinished;

        public AudioSource NextAudioSource => _nextSoundSource;

        public void Construct(IBackgroundSoundObserver backgroundSoundObserver) =>
            _backgroundSoundObserver = backgroundSoundObserver;

        private void Update()
        {
            if (!_audioSource.isPlaying && !_soundFinished && Application.isFocused)
            {
                _soundFinished = true;
                _backgroundSoundObserver.OnSoundFinished(this);
            }

            if (_audioSource.isPlaying && _soundFinished)
                _soundFinished = false;
        }
    }
}
