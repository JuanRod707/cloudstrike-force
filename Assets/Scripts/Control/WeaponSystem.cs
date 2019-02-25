using UnityEngine;
using Weapons;

namespace Control
{
    public class WeaponSystem : MonoBehaviour
    {
        public GameObject PrimaryWeaponSpot;

        private Weapon[] primaryWeapons;
        private Weapon[] secondaryWeapons;
        
        private bool active = true;

        public void Initialize() => primaryWeapons = PrimaryWeaponSpot.GetComponentsInChildren<Weapon>();

        public void Fire()
        {
            if (active)
            {
                foreach (var w in primaryWeapons)
                    w.Fire();
            }
        }

        public void Disable() => active = false;

        public void Enable() => active = true;
    }
}
