using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [Serializable]
    public class CoinSpawnPointData
    {
        public Vector3 Position;

        public CoinSpawnPointData(Vector3 position) =>
            Position = position;
    }
}
