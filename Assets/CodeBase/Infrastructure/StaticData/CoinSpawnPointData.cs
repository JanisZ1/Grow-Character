using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    public class CoinSpawnPointData
    {
        public Vector3 Position { get; private set; }

        public CoinSpawnPointData(Vector3 position) =>
            Position = position;
    }
}
