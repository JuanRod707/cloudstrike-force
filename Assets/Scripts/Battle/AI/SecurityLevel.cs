using UnityEngine;

namespace Battle.AI
{
    public class SecurityLevel
    {
        public int Level { get; }
        public GameObject Building { get; }
        public int Count { get; }

        public SecurityLevel(int level, GameObject building, int count)
        {
            Level = level;
            Building = building;
            Count = count;
        }
    }
}