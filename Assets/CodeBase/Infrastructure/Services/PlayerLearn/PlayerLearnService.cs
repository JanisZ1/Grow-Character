using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.PlayerLearn
{
    public class PlayerLearnService : IPlayerLearnService
    {
        private readonly IUiFactory _uiFactory;

        public PlayerLearnService(IUiFactory uiFactory) =>
            _uiFactory = uiFactory;

        public bool NewPlayerLoaded { get; set; }

        public void StartLearn()
        {
            GameObject gameObject = _uiFactory.CreateClickLearnObject();

            gameObject.GetComponentInChildren<ClickLearnUi>().PlayAnimation();
        }
    }
}
