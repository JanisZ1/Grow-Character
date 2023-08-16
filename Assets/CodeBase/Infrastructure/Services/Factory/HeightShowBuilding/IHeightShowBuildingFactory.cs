using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeightShowBuilding
{
    public interface IHeightShowBuildingFactory : IService
    {
        GameObject CreateBuilding(HeightShowBuildingType buildingType, Transform parent, Vector3 at);
        void CreateSpawners();
    }
}
