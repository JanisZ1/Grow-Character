using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class SoundFactory : ISoundFactory
    {
        private readonly IStaticDataService _staticData;

        public SoundFactory(IStaticDataService staticData) =>
            _staticData = staticData;

        public void CreateBackgroundSounds()
        {
            List<BackgroundSoundStaticData> allBackgroundSounds = _staticData.ForAllBackgroundSounds();

            foreach (BackgroundSoundStaticData backgroundSoundData in allBackgroundSounds)
            {
                Object.Instantiate(backgroundSoundData.Prefab);
            }
        }
    }
}
