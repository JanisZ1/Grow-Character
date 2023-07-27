using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/LevelData")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelName;
        public List<CoinSpawnPointData> CoinSpawners;
    }
}