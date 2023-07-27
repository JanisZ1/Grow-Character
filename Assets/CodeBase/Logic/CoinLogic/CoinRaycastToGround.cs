﻿using UnityEngine;

namespace Assets.CodeBase.Logic.CoinLogic
{
    public class CoinRaycastToGround : MonoBehaviour
    {
        [SerializeField] private SphereCollider _sphereCollider;

        private void Start() =>
            AddY();

        private void FixedUpdate()
        {
            if (Physics.SphereCast(transform.position, _sphereCollider.radius, Vector3.down, out RaycastHit hit))
            {
                Ray ray = new Ray(transform.position, Vector3.down);

                Vector3 position = ray.GetPoint(hit.distance);

                transform.position = position;
            }
        }

        private void AddY() =>
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
}
