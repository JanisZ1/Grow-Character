using UnityEngine;

namespace Assets.CodeBase.Logic.Ui
{
    public class ShopWindow : MonoBehaviour
    {
        public void Close() =>
            Destroy(gameObject);
    }
}
