using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAssets _assets;
        private readonly IInputService _inputService;

        public HeroFactory(IAssets assets,IInputService inputService)
        {
            _assets = assets;
            _inputService = inputService;
        }


        public GameObject CreateHero(Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.HeroPath, at);
            gameObject.GetComponent<HeroMove>().Construct(_inputService);
            return gameObject;
        }
    }
}
