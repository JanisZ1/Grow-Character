using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Spawners.Coin;
using Assets.CodeBase.Logic.Spawners.HeightShowBuilding;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelStaticData = (LevelStaticData)target;

            if (GUILayout.Button("Collect Data"))
            {
                CoinSpawnArea coinSpawnArea = FindObjectOfType<CoinSpawnArea>();
                HeightShowBuildingSpawnMarker[] heightShowBuildingMarkers = FindObjectsOfType<HeightShowBuildingSpawnMarker>();

                CoinSpawnPointsGenerator coinSpawnPointsGenerator = new CoinSpawnPointsGenerator();

                levelStaticData.CoinSpawners = coinSpawnPointsGenerator.GenerateProbeStaticData(coinSpawnArea);
                levelStaticData.HeightShowBuildings = heightShowBuildingMarkers
                    .Select(x => new HeightShowBuildingSpawnerData(x.BuildingType, x.transform.position))
                    .ToList();
            }

            if (Time.frameCount % 100 == 0)
            {
                SceneView.duringSceneGui += duringScene =>
                {
                    Handles.color = Color.green;
                    foreach (CoinSpawnPointData spawnerData in levelStaticData.CoinSpawners)
                    {
                        float distance = Vector3.Distance(Camera.current.transform.position, spawnerData.Position);
                        if (distance < 5)
                        {
                            Handles.DrawWireCube(spawnerData.Position, Vector3.one);
                        }
                    }
                };
            }
            EditorUtility.SetDirty(target);
        }
    }
}