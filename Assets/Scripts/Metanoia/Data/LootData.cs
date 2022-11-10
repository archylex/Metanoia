using System;

namespace Assets.Scripts.Metanoia.Data
{
    [Serializable]
    public class LootData
    {
        public Action Changed;

        public int Collected;

        public UnpickedLoot UnpickedLoot;

        public LootData()
        {
            UnpickedLoot = new UnpickedLoot();
        }

        public void Collect(Loot loot)
        {
            Collected += loot.Value;
            Changed?.Invoke();
        }

        public void Add(int loot)
        {
            Collected += loot;
            Changed?.Invoke();
        }
    }
}
