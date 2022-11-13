using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Metanoia.Inventory
{
    [Serializable]
    public class Inventory
    {
        public List<InventorySlot> Items = new List<InventorySlot>();
    }
}
