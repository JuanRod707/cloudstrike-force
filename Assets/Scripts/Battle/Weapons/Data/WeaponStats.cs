using System;

namespace Battle.Weapons.Data
{
    [Serializable]
    public class WeaponStats
    {
        public float RateOfFire;
        public float ReloadTime;
        public int Ammo;
        public int Damage;
        public float Range;
        public DamageType[] DamageTypes;
    }
}
