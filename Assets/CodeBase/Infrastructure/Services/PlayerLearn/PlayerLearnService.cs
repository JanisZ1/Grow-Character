using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.PlayerLearn
{
    public class PlayerLearnService : IPlayerLearnService
    {
        private readonly IUiFactory _uiFactory;

        public PlayerLearnService(IUiFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void StartLearn()
        {
            Vector3 position = Camera.main.ScreenToViewportPoint(new Vector2(Screen.width / 2, Screen.height / 2));

            _uiFactory.CreateClickLearnObject(at: position);
        }
    }
}
