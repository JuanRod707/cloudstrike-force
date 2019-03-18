using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Battle.Entities;
using Assets.Scripts.Battle.Entities.Control;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Control
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

        public void AimToClosestTarget(IEnumerable<Transform> targets)
        {
            if (enabled)
            {
                var target = targets.OrderBy(t => Vector3.Distance(transform.position, t.position)).FirstOrDefault();

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
