﻿using Assets.CodeBase.Infrastructure.Data;
using Assets.CodeBase.Infrastructure.Services.Factory.UiFactoryService;
using Assets.CodeBase.Infrastructure.Services.PlayerProgressService;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IPlayerProgressService _playerProgress;
        private readonly IUiFactory _uiFactory;

        public SaveLoadService(IPlayerProgressService playerProgress, IUiFactory uiFactory)
        {
            _playerProgress = playerProgress;
            _uiFactory = uiFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _uiFactory.ProgressWriters)
                progressWriter.SaveProgress(_playerProgress.PlayerProgress);

            PlayerPrefs.SetString(ProgressKey, _playerProgress.PlayerProgress.ToJson());
        }

        public void LoadProgress()
        {
        }
    }
}
