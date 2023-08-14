using Assets.CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;
using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Logic;
using Assets.CodeBase.Infrastructure.Services.BackgroundSoundObserver;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class SoundFactory : ISoundFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private readonly IBackgroundSoundObserver _backgroundSoundObserver;

        public GameObject SoundSwitcher { get; private set; }

        public SoundFactory(IAssets assets, IStaticDataService staticData, IBackgroundSoundObserver backgroundSoundObserver)
        {
            _assets = assets;
            _staticData = staticData;
            _backgroundSoundObserver = backgroundSoundObserver;
        }

        public void CreateSoundSwitcher()
        {
            SoundSwitcher = _assets.Instantiate(AssetPath.SoundSwitcherPath);
            SoundSwitcher.GetComponent<SoundSwitcher>().Construct(_backgroundSoundObserver);

            foreach (BackgroundSound backgroundSound in SoundSwitcher.GetComponentsInChildren<BackgroundSound>())
                backgroundSound.Construct(_backgroundSoundObserver);
        }
    }
}
