using Entities;
using Entities.Control;
using UnityEngine;

namespace AI.Control
{
    public class TurretAI : MonoBehaviour, Controller
    {
        public float DistanceToAim;
        public float DistanceToEngage;
        public Turret Turret;
     
        bool TargetIsNearby(Vector3 target) =>
            Vector3.Distance(target, transform.position) < DistanceToAim;
        
        bool TargetIsInRange(Vector3 target) =>
            Vector3.Distance(target, transform.position) < DistanceToEngage;

        bool TargetIsInFront(Vector3 target) => SteeringToTarget(target).z > 5;

        Vector3 SteeringToTarget(Vector3 target) => transform.InverseTransformPoint(target);

        public void Initialize() => Turret.Initialize(this);

        public void AimToTarget(Vector3 target)
        {
            if (enabled)
            {
                if (TargetIsNearby(target))
                {
                    var steerVector = NormalizeSteering(SteeringToTarget(target));
                    Turret.Aiming.Steer(steerVector);
                }

                if (TargetIsInRange(target) && TargetIsInFront(target))
                    Attack(target);
            }
        }

        Vector3 NormalizeSteering(Vector3 steering)
        {
            steering.y *= -1;
            return steering * Turret.Stats.TurnRate;
        }

        void Attack(Vector3 target) => Turret.Weapons.FirePrimary(target);

        public void Disable() => enabled = false;

        public void ShootDown() => Turret.Destroy();

        public void Enable() => enabled = true;
    }
}
