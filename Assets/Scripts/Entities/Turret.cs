using Entities.Control;
using Entities.Vehicles;
using UnityEngine;

namespace Entities
{
    public class Turret : MonoBehaviour
    {
        public WeaponSystem Weapons;
        public TurretStats Stats;
        public TurretAiming Aiming;
        public GameObject View;
        public GameObject DeathExplosion;
        public Health Health;

        Controller controller;

        public void Initialize(Controller controller)
        {
            Health.Initialize(Destroy);
            Weapons.Initialize();
            this.controller = controller;
        }

        public void Destroy()
        {
            View.SetActive(false);
            controller.Disable();
            Instantiate(DeathExplosion, transform.position, Quaternion.identity);
        }
    }
}
