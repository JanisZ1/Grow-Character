using Assets.CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;
using Assets.CodeBase.Infrastructure.Services.AssetProvider;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class SoundFactory : ISoundFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private readonly ICoroutineRunner _coroutineRunner;

        public GameObject SoundSwitcher { get; private set; }

        public SoundFactory(IAssets assets, IStaticDataService staticData, ICoroutineRunner coroutineRunner)
        {
            _assets = assets;
            _staticData = staticData;
            _coroutineRunner = coroutineRunner;
        }

        public void CreateSoundSwitcher()
        {
            SoundSwitcher = _assets.Instantiate(AssetPath.SoundSwitcherPath);
            SoundSwitcher.GetComponent<SoundSwitcher>().Construct(_coroutineRunner);
        }
    }
}
