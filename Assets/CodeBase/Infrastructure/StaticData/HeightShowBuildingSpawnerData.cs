using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
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