﻿using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.AssetProvider
{
    public class AssetProvider : IAssets
    {
        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}
