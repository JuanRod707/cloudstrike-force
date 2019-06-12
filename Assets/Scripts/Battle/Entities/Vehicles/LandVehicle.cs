using System;
using Battle.Entities.Control;
using UnityEngine;

namespace Battle.Entities.Vehicles
{
    public class LandVehicle : MonoBehaviour
    {
        public WeaponSystem Weapons;
        public LandMovement Movement;
        public VehicleStats Stats;
        public GameObject View;
        public GameObject DeathExplosion;
        public Health VehicleHealth;
        public GameObject Colliders;

        private Controller controller;

        public void Initialize(Controller controller)
        {
            VehicleHealth.Initialize(controller.ShootDown);
            Weapons.Initialize();
            this.controller = controller;
        }
        
        public void Initialize(Controller controller, Action<int> doOnUpdateHp)
        {
            Initialize(controller);
            VehicleHealth.Initialize(controller.ShootDown, doOnUpdateHp);
        }

        public void Destroy()
        {
            Movement.Stop();
            View.SetActive(false);
            controller.Disable();
            Instantiate(DeathExplosion, transform.position, Quaternion.identity);
            Colliders.SetActive(false);
        }
    }
}
