using Assets.Scripts.Metanoia.Inventory;
using System;

namespace Assets.Scripts.Metanoia.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;
        public Stats HeroStats;
        public KillData KillData;
        public PurchaseData PurchaseData;
        public InventoryObject Inventory;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            HeroState = new State();
            HeroStats = new Stats();
            KillData = new KillData();
            PurchaseData = new PurchaseData();
            Inventory = new InventoryObject();
        }
    }
}
