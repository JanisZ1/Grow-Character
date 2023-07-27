using Assets.CodeBase.Infrastructure.StaticData;
using Assets.CodeBase.Logic.Spawners.Coin;
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

            if (GUILayout.Button("Generate coin spawn points"))
            {
                CoinSpawnArea coinSpawnArea = FindObjectOfType<CoinSpawnArea>();

                CoinSpawnPointsGenerator coinSpawnPointsGenerator = new CoinSpawnPointsGenerator();

                levelStaticData.CoinSpawners = coinSpawnPointsGenerator.GenerateProbeStaticData(coinSpawnArea);
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