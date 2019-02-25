using UnityEngine;
using Weapons;

namespace Control
{
    public class WeaponSystem : MonoBehaviour
    {
        public GameObject PrimaryWeaponSpot;
        public GameObject SecondaryWeaponSpot;

        private Weapon[] primaryWeapons;
        private Weapon[] secondaryWeapons;
        
        private bool active = true;

        public void Initialize()
        {
            primaryWeapons = PrimaryWeaponSpot.GetComponentsInChildren<Weapon>();
            secondaryWeapons = SecondaryWeaponSpot.GetComponentsInChildren<Weapon>();
        }

        public void FirePrimary()
        {
            if (active)
            {
                foreach (var w in primaryWeapons)
                    w.Fire();
            }
        }

        public void FireSecondary()
        {
            if (active)
            {
                foreach (var w in secondaryWeapons)
                    w.Fire();
            }
        }

        public void Disable() => active = false;

        public void Enable() => active = true;
    }
}
