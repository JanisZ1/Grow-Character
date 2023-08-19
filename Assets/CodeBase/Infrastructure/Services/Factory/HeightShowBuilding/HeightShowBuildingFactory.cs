using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.StaticData;
using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Spawners.HeightShowBuilding;
using Assets.CodeBase.Logic.Ui;
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

        public GameObject CreateBuilding(HeightShowBuildingType buildingType, Transform parent, Vector3 at)
        {
            HeightShowBuildingData heightShowBuildingData = _staticData.ForHeightShowBuilding(buildingType);

            GameObject gameObject = Object.Instantiate(heightShowBuildingData.Prefab, at, parent.rotation, parent);
            gameObject.GetComponentInChildren<HeightShowBuildingUi>().InitializeTextWith(heightShowBuildingData);
            StaticBatch(gameObject);

            return gameObject;
        }

        public void CreateSpawners()
        {
            LevelStaticData levelStaticData = _staticData.ForLevel(SceneManager.GetActiveScene().name);

            foreach (HeightShowBuildingSpawnerData heightShowBuildingData in levelStaticData.HeightShowBuildings)
            {
                GameObject gameObject = _assets.Instantiate(AssetPath.HeightShowBuildingSpawnerPath, heightShowBuildingData.Position);
                HeightShowBuildingSpawner spawner = gameObject.GetComponent<HeightShowBuildingSpawner>();
                spawner.Construct(this);
                spawner.BuildingType = heightShowBuildingData.BuildingType;
            }
        }

        private void StaticBatch(GameObject gameObject) =>
            StaticBatchingUtility.Combine(gameObject);
    }
}
