using Assets.CodeBase.Logic.CoinLogic;
using UnityEngine;

namespace Assets.CodeBase.Logic.Hero
{
    public class HeroCoinCollect : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
                coin.Collect();
        }
    }
}
