using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Logic;
using Assets.CodeBase.Logic.Hero;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAssets _assets;
        private readonly IInputService _inputService;
        private readonly IPlayerProgressService _playerProgressService;

        public HeroFactory(IAssets assets, IInputService inputService, IPlayerProgressService playerProgressService)
        {
            _assets = assets;
            _inputService = inputService;
            _playerProgressService = playerProgressService;
        }

        public GameObject CreateHero()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.HeroPath);

            gameObject.GetComponent<HeroMove>().Construct(_inputService);
            gameObject.GetComponent<HeroScale>().Construct(_inputService);
            gameObject.GetComponent<MoneyEarn>().Construct(_inputService, _playerProgressService);

            return gameObject;
        }
    }
}
