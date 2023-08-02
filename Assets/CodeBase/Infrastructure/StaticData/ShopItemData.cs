using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "ShopItemData", menuName = "StaticData/ShopItemData")]
    public class ShopItemData : ScriptableObject
    {
        public float Price;
        public float Calories;
        public float MaximumMass;

        public ShopItemType ShopItemType;
    }
}
