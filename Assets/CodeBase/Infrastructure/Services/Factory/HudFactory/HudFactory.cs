using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.InputService;
using Assets.CodeBase.Infrastructure.Services.Observer.HeroEat;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using Assets.CodeBase.Infrastructure.Services.WindowService;
using Assets.CodeBase.Logic.Hud;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HudFactory
{
    public class HudFactory : IHudFactory
    {
        private readonly IAssets _assets;
        private readonly IHeroEatObserver _heroEatObserver;
        private readonly IInputService _inputService;
        private readonly IWindowService _windowService;
        private readonly IPlayerProgressService _playerProgress;

        public HudFactory(IAssets assets, IHeroEatObserver heroEatObserver, IInputService inputService, IWindowService windowService, IPlayerProgressService playerProgress)
        {
            _assets = assets;
            _heroEatObserver = heroEatObserver;
            _inputService = inputService;
            _windowService = windowService;
            _playerProgress = playerProgress;
        }

        public void CreateHud()
        {
            GameObject hud = _assets.Instantiate(AssetPath.HudPath);
            hud.GetComponent<Hud>().Construct(_inputService, _windowService, _heroEatObserver, _playerProgress);
        }
    }
}
