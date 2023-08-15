using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Spawners.HeightShowBuilding;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrastructure.Services.Factory.HeightShowBuilding
{
    public class HeightShowBuildingFactory : IHeightShowBuildingFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;

        public HeightShowBuildingFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreateBuilding(HeightShowBuildingType buildingType)
        {
            HeightShowBuildingData heightShowBuildingData = _staticData.ForHeightShowBuilding(buildingType);

            return Object.Instantiate(heightShowBuildingData.Prefab);
        }

        public void CreateSpawners()
        {
            LevelStaticData levelStaticData = _staticData.ForLevel(SceneManager.GetActiveScene().name);

            foreach (HeightShowBuildingSpawnerData heightShowBuildingData in levelStaticData.HeightShowBuildings)
            {
                GameObject gameObject = _assets.Instantiate(AssetPath.HeightShowBuildingSpawnerPath);
                gameObject.GetComponent<HeightShowBuildingSpawner>().Construct(this);
            }
        }
    }
}
