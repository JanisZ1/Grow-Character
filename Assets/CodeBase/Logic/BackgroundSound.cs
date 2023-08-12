using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _nextSoundSource;

        public AudioSource AudioSource => _audioSource;

        public AudioSource NextAudioSource => _nextSoundSource;
    }
}
