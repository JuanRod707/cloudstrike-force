using System.Linq;
using UnityEngine;
using Weapons;
using Weapons.Data;

namespace Control
{
    public class WeaponSystem : MonoBehaviour
    {
        public GameObject PrimaryWeaponSpot;
        public GameObject SecondaryWeaponSpot;

        private Weapon[] primaryWeapons;
        private Weapon[] secondaryWeapons;

        private int secondaryIndex;
        private bool active = true;
        private int primaryIndex;

        public WeaponStats PrimaryStats => primaryWeapons.First().Stats;
        public WeaponStats SecondaryStats => secondaryWeapons?.First().Stats;

        public void Initialize()
        {
            primaryWeapons = PrimaryWeaponSpot.GetComponentsInChildren<Weapon>();
            secondaryWeapons = SecondaryWeaponSpot == null ? null : SecondaryWeaponSpot.GetComponentsInChildren<Weapon>();
        }

        public void FirePrimary(Vector3 target)
        {
            if (active)
            {
                primaryWeapons[primaryIndex].Fire(target);
                primaryIndex++;
                primaryIndex = primaryIndex >= primaryWeapons.Length ? 0 : primaryIndex;
            }
        }

        public void FireSecondary(Transform target)
        {
            if (active)
            {
                secondaryWeapons[secondaryIndex].Fire(target);
                secondaryIndex++;
                secondaryIndex = secondaryIndex >= secondaryWeapons.Length ? 0 : secondaryIndex;
            }
        }

        public void Disable() => active = false;

        public void Enable() => active = true;
    }
}
