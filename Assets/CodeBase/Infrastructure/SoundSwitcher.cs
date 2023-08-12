using Assets.CodeBase.Logic;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class SoundSwitcher : MonoBehaviour
    {
        private ICoroutineRunner _coroutineRunner;
        [SerializeField] private BackgroundSound _startingSound;
        private BackgroundSound _playingBackgroundSound;

        public void Construct(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        private void Awake() =>
            _playingBackgroundSound = _startingSound;

        public void StartSoundSwitch() =>
            _coroutineRunner.StartCoroutine(SwitchSoundProcess());

        private void PlayNextSound()
        {
            _playingBackgroundSound.NextAudioSource.Play();
            _playingBackgroundSound = _playingBackgroundSound.NextAudioSource.GetComponent<BackgroundSound>();
        }

        private IEnumerator SwitchSoundProcess()
        {
            while (_playingBackgroundSound.AudioSource.isPlaying)
                yield return null;

            if (!Application.isFocused)
            {
                yield return new WaitUntil(() => Application.isFocused);
                yield return SwitchSoundProcess();
            }

            PlayNextSound();

            yield return SwitchSoundProcess();
        }
    }
}