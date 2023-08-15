using Assets.CodeBase.Infrastructure.Services.Factory.HeightShowBuilding;
using Assets.CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Logic.Spawners.HeightShowBuilding
{
    public class HeightShowBuildingSpawner : MonoBehaviour
    {
        public HeightShowBuildingType BuildingType;

        private IHeightShowBuildingFactory _heightShowBuildingFactory;

        public void Construct(IHeightShowBuildingFactory heightShowBuildingFactory) =>
            _heightShowBuildingFactory = heightShowBuildingFactory;

        private void Start() =>
            Spawn();

        private void Spawn() =>
            _heightShowBuildingFactory.CreateBuilding(BuildingType);
    }
}
