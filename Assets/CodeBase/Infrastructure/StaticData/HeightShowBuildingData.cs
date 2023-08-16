using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "HeightShowBuildingData", menuName = "StaticData/HeightShowBuildingData")]
    public class HeightShowBuildingData : ScriptableObject
    {
        public HeightShowBuildingType BuildingType;
        public float Height;
        public GameObject Prefab;
    }
}
