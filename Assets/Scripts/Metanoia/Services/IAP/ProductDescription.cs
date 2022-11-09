using System;
using UnityEngine.Purchasing;

namespace Assets.Scripts.Metanoia.Services.IAP
{
    [Serializable]
    public class ProductDescription
    {
        public string Id;
        public Product Product;
        public ProductConfig Config;
        public int AvailablePurchasesLeft;
    }
}
