using Assets.CodeBase.Infrastructure.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Logic.Spawners.Coin
{
    public class CoinSpawnPointsGenerator
    {
        public List<CoinSpawnPointData> GenerateProbeStaticData(CoinSpawnArea spawnArea)
        {
            List<CoinSpawnPointData> spawnPoints = new List<CoinSpawnPointData>();

            BoxCollider collider = spawnArea.GetComponentInParent<BoxCollider>();
            Transform transform = spawnArea.GetComponent<Transform>();

            Vector3 min = MinimalBound(collider);
            Vector3 max = MaximalBound(collider);

            Vector3 P000 = transform.TransformPoint(new Vector3(min.x, min.y, min.z));
            Vector3 P001 = transform.TransformPoint(new Vector3(min.x, min.y, max.z));
            Vector3 P010 = transform.TransformPoint(new Vector3(min.x, max.y, min.z));
            Vector3 P011 = transform.TransformPoint(new Vector3(min.x, max.y, max.z));
            Vector3 P100 = transform.TransformPoint(new Vector3(max.x, min.y, min.z));
            Vector3 P101 = transform.TransformPoint(new Vector3(max.x, min.y, max.z));
            Vector3 P110 = transform.TransformPoint(new Vector3(max.x, max.y, min.z));
            Vector3 P111 = transform.TransformPoint(new Vector3(max.x, max.y, max.z));

            float distanceX = DistanceBetween(P000, P100);
            float distanceY = DistanceBetween(P000, P010);
            float distanceZ = DistanceBetween(P000, P001);

            for (int x = 0; x < distanceX; x += 4)
            {
                for (int y = 0; y < distanceY; y += 2)
                {
                    for (int z = 0; z < distanceZ; z += 4)
                    {
                        Vector3 position = new Vector3(P000.x + x, P000.y + y, P000.z + z);

                        CoinSpawnPointData coinSpawnStaticData = new CoinSpawnPointData(position);
                        spawnPoints.Add(coinSpawnStaticData);
                    }
                }
            }
            return spawnPoints;
        }

        private float DistanceBetween(Vector3 firstPoint, Vector3 secondPoint) =>
            Vector3.Distance(firstPoint, secondPoint);

        private Vector3 MaximalBound(BoxCollider collider) =>
            collider.center + collider.size * 0.5f;

        private Vector3 MinimalBound(BoxCollider collider) =>
            collider.center - collider.size * 0.5f;
    }
}
