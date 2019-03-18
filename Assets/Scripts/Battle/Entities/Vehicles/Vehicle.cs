using System;
using Assets.Scripts.Battle.Entities.Control;
using UnityEngine;

namespace Assets.Scripts.Battle.Entities.Vehicles
{
    public class Vehicle : MonoBehaviour
    {
        public WeaponSystem Weapons;
        public PlaneMovement Movement;
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

        public void Undock()
        {
            transform.SetParent(null);
            Movement.Launch();
        }

        public void Launch() => Movement.Launch();

        public void Destroy()
        {
            Movement.Stop();
            View.SetActive(false);
            controller.Disable();
            Instantiate(DeathExplosion, transform.position, Quaternion.identity);
            Colliders.SetActive(false);
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
