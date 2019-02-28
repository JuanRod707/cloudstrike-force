using System.Linq;
using UnityEngine;
using Weapons;
using Weapons.Data;

namespace Entities.Control
{
    public class WeaponSystem : MonoBehaviour
    {
        public GameObject PrimaryWeaponSpot;
        public GameObject SecondaryWeaponSpot;

        private Weapon[] primaryWeapons;
        private Weapon[] secondaryWeapons;

        private int secondaryIndex;
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
            primaryWeapons[primaryIndex].Fire(target);
            primaryIndex++;
            primaryIndex = primaryIndex >= primaryWeapons.Length ? 0 : primaryIndex;
        }

        public void FireSecondary(Transform target)
        {
            secondaryWeapons[secondaryIndex].Fire(target);
            secondaryIndex++;
            secondaryIndex = secondaryIndex >= secondaryWeapons.Length ? 0 : secondaryIndex;
        }
    }
}
