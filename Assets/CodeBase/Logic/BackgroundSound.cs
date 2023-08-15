using Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _nextSoundSource;

        private IBackgroundSoundObserver _backgroundSoundObserver;

        public bool SoundFinished { get; set; } = true;

        public void Construct(IBackgroundSoundObserver backgroundSoundObserver) =>
            _backgroundSoundObserver = backgroundSoundObserver;

        private void Start()
        {
            if (_audioSource.playOnAwake)
                SoundFinished = false;
        }

        private void Update()
        {
            if (AudioPlaying() || !Application.isFocused)
                return;

            if (!SoundFinished && !AudioPlaying())
            {
                _backgroundSoundObserver.OnSoundFinished(this);
                SoundFinished = true;
            }
        }

        public void PlayNext()
        {
            _nextSoundSource.Play();
            _nextSoundSource.GetComponent<BackgroundSound>().SoundFinished = false;
        }

        private bool AudioPlaying() =>
            _audioSource.isPlaying;
    }
}
