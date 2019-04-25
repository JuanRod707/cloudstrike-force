using System;

namespace Battle.Weapons
{
    [Serializable]
    public class DamageMultiplier
    {
        public DamageType DamageType;
        public float Multiplier = 1f;
    }
}
