using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [Serializable]
    public class HeightShowBuildingSpawnerData
    {
        public HeightShowBuildingType BuildingType;
        public Vector3 Position;

        public HeightShowBuildingSpawnerData(HeightShowBuildingType buildingType, Vector3 position)
        {
            BuildingType = buildingType;
            Position = position;
        }
    }
}