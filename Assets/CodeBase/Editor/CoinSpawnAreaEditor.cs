using Assets.CodeBase.Logic.Spawners.Coin;
using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(CoinSpawnArea))]
    public class CoinSpawnAreaEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CoinSpawnArea spawnArea, GizmoType gizmo)
        {
            Gizmos.color = new Color(1f, 0.962f, 0.016f, 0.3f);

            BoxCollider[] boxColliders = spawnArea.GetComponents<BoxCollider>();

            foreach (BoxCollider collider in boxColliders)
                Gizmos.DrawCube(spawnArea.transform.position + collider.center, collider.size);
        }
    }
}