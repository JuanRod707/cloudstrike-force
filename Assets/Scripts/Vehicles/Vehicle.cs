using Control;
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

        void Start() => Weapons.Initialize();

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
