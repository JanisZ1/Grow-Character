using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeightShowBuilding
{
    public class HeightShowBuildingFactory : IHeightShowBuildingFactory
    {
        private readonly IStaticDataService _staticData;

        public HeightShowBuildingFactory(IStaticDataService staticData) =>
            _staticData = staticData;

        public GameObject CreateBuilding(HeightShowBuildingType buildingType)
        {

        }
    }
    public interface IHeightShowBuildingFactory : IService
    {
        GameObject CreateBuilding(HeightShowBuildingType buildingType);
    }
}
