using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IPlayerProgressService _playerProgress;

        public SaveLoadService(IPlayerProgressService playerProgress) =>
            _playerProgress = playerProgress;

        public void SaveProgress() =>
            PlayerPrefs.SetString(ProgressKey, _playerProgress.PlayerProgress.ToJson());

        public void LoadProgress()
        {

        }
    }
}
