using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.Data
{
    [Serializable]
    public class ShopBuyData
    {
        public List<int> UnlockedItems = new List<int>();
        public List<int> BuyedItems = new List<int>();
    }
}