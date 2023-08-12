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

        public List<GameObject> CreateBackgroundSounds()
        {
            List<BackgroundSoundStaticData> allBackgroundSounds = _staticData.ForAllBackgroundSounds();

            List<GameObject> createdSounds = new List<GameObject>();

            foreach (BackgroundSoundStaticData backgroundSoundData in allBackgroundSounds)
            {
                GameObject sound = Object.Instantiate(backgroundSoundData.Prefab);
                createdSounds.Add(sound);
            }

            return createdSounds;
        }
    }
}
