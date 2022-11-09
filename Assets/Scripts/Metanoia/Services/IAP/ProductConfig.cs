using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Purchasing;

namespace Assets.Scripts.Metanoia.Services.IAP
{
    [Serializable]
    public class ProductConfig
    {
        public string Id;
        public ProductType ProductType;
        public int MaxPurchaseCount;
        public ItemType ItemType;
        public int Quantity;
        public string Price;
        public string Icon;
    }
}
