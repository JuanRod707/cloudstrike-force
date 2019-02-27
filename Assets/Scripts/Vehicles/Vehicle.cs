using Control;
using Entities;
using UnityEngine;

namespace Vehicles
{
    public class Vehicle : MonoBehaviour
    {
        public WeaponSystem Weapons;
        public PlaneMovement Movement;
        public VehicleStats Stats;
        public GameObject View;
        public GameObject DeathExplosion;
        public Health VehicleHealth;

        void Start()
        {
            VehicleHealth.Initialize(Destroy);
            Weapons.Initialize();
        }

        public void Undock()
        {
            transform.SetParent(null);
            Movement.Launch();
        }

        internal void Destroy()
        {
            Movement.Stop();
            Weapons.Disable();
            View.SetActive(false);
            Instantiate(DeathExplosion, transform.position, Quaternion.identity);
        }

        public void Dock(Transform hangar)
        {
            transform.SetParent(hangar);
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;

            Movement.Stop();
        }
    }
}
