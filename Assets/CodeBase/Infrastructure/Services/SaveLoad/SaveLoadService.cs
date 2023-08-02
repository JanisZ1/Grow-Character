using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.Factory.HeroFactory;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IPlayerProgressService _playerProgress;
        private readonly IHeroFactory _heroFactory;
        private readonly IUiFactory _uiFactory;

        public SaveLoadService(IPlayerProgressService playerProgress, IHeroFactory heroFactory, IUiFactory uiFactory)
        {
            _playerProgress = playerProgress;
            _heroFactory = heroFactory;
            _uiFactory = uiFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _heroFactory.ProgressWriters)
                progressWriter.SaveProgress(_playerProgress.Progress);

            foreach (ISavedProgress progressWriter in _uiFactory.ProgressWriters)
                progressWriter.SaveProgress(_playerProgress.Progress);

            PlayerPrefs.SetString(ProgressKey, _playerProgress.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?
                .ToDeserialized<PlayerProgress>();
    }
}
