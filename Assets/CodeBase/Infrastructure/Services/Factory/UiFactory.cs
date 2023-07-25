﻿using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssets _assets;
        private Transform _uiRootTransform;

        public UiFactory(IAssets assets) =>
            _assets = assets;

        public void CreateUiRoot() =>
            _uiRootTransform = _assets.Instantiate(AssetPath.UiRootPath).transform;
    }
}
