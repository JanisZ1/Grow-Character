using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class ShopWindow : MonoBehaviour
    {
        public void Close() =>
            Destroy(gameObject);
    }
}
