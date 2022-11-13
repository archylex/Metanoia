using Assets.Scripts.Metanoia.Data;
using Assets.Scripts.Metanoia.Inventory;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public Sprite uiSprite;
    public ItemType type;
    public ItemBuff[] buffs;

    [TextArea(20, 30)]
    public string description;

       
}
