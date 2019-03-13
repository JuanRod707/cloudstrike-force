using Battle.Entities;
using Battle.Entities.Control;
using UnityEngine;

namespace Battle.Coalition.AI.Control
{
    public class TurretAI : MonoBehaviour, Controller
    {
        public float DistanceToAim;
        public float DistanceToEngage;
        public Turret Turret;
     
        bool TargetIsNearby(Transform target) =>
            Vector3.Distance(target.position, transform.position) < DistanceToAim;

        bool TargetIsInRange(Transform target) =>
            Vector3.Distance(target.position, transform.position) < DistanceToEngage;

        public void Initialize() => Turret.Initialize(this);

        public void AimToTarget(Transform target)
        {
            if (enabled)
            {
                if (TargetIsNearby(target))
                    Turret.Aiming.AimTo(target);

                if (TargetIsInRange(target) && Turret.Aiming.TargetIsInFront(target))
                    Attack(target);
            }
        }

        void Attack(Transform target) => Turret.Weapons.FirePrimary(target.position, target);

        public void Disable() => enabled = false;

        public void ShootDown() => Turret.Destroy();

        public void Enable() => enabled = true;
    }
}
