using System.Linq;
using Battle.Weapons;
using Battle.Weapons.Data;
using UnityEngine;

namespace Battle.Entities.Control
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

        public void FirePrimary(Vector3 position, Transform target)
        {
            primaryWeapons[primaryIndex].Fire(position, target);
            primaryIndex++;
            primaryIndex = primaryIndex >= primaryWeapons.Length ? 0 : primaryIndex;
        }

        public void FireSecondary(Vector3 position, Transform target)
        {
            secondaryWeapons[secondaryIndex].Fire(position, target);
            secondaryIndex++;
            secondaryIndex = secondaryIndex >= secondaryWeapons.Length ? 0 : secondaryIndex;
        }
    }
}
