using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    public class HeightShowBuildingData
    {
        public HeightShowBuildingType BuildingType;
        public Vector3 Position;

        public HeightShowBuildingData(HeightShowBuildingType buildingType, Vector3 position)
        {
            BuildingType = buildingType;
            Position = position;
        }
    }
}