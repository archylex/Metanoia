using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Metanoia.Inventory
{
    [CreateAssetMenu(fileName = "EquipmentObject", menuName = "Inventory System/Items/Equipment")]
    public class EquipmentObject : ItemObject
    {
        private void Awake()
        {
            type = ItemType.Equipment;
        }
    }
}
