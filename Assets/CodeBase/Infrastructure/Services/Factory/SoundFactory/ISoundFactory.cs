using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface ISoundFactory : IService
    {
        void CreateSoundSwitcher();
        GameObject SoundSwitcher { get; }
    }
}