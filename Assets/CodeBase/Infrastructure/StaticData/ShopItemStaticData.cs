using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "ShopItemData", menuName = "StaticData/ShopItemData")]
    public class ShopItemStaticData : ScriptableObject
    {
        public float Profit;
        public int Price;
        public float Calories;
        public float MaximumMass;
        public int Id;
        public Sprite IconSprite;

        public ShopItemType ShopItemType;
    }
}
