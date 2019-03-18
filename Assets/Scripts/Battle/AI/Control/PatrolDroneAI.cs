using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Battle.Entities.Control;
using Assets.Scripts.Battle.Entities.Vehicles;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Control
{
    public class PatrolDroneAI : MonoBehaviour, Controller
    {
        public Vehicle Vehicle;
     
        public float DistanceToReachNavPoint;
        public float DistanceToEngage;
        public float DistanceToDisengage;
        public float DistanceToAttack;
     
        private NavigationPoints patrolPoints;
        Transform currentTarget;
        IEnumerable<Transform> targets;

        Transform ClosestTarget =>
            targets.OrderBy(t => Vector3.Distance(transform.position, t.position)).FirstOrDefault();

        private bool ReachedDestination =>
            Vector3.Distance(currentTarget.position, transform.position) < DistanceToReachNavPoint;

        private bool TargetIsNearby =>
            Vector3.Distance(ClosestTarget.position, transform.position) < DistanceToEngage;

        private bool TargetIsTooFar =>
            Vector3.Distance(ClosestTarget.position, transform.position) > DistanceToDisengage;

        private bool TargetIsInAttackRange =>
            Vector3.Distance(ClosestTarget.position, transform.position) < DistanceToAttack;

        private bool PlayerIsInFront => SteeringToTarget.z > 5;

        private Vector3 SteeringToTarget => transform.InverseTransformPoint(currentTarget.position);

        private bool PlayerIsTarget => currentTarget == ClosestTarget;

        public void Initialize(NavigationPoints patrol, IEnumerable<Transform> targets)
        {
            patrolPoints = patrol;
            GetNewNavPoint();
            Vehicle.Initialize(this);
            Vehicle.Launch();
        }

        private void GetNewNavPoint() => currentTarget = patrolPoints.GetRandomNavPoint;

        void FixedUpdate()
        {
            if (currentTarget != null)
            {
                var steerVector = NormalizeSteering(SteeringToTarget);
                Vehicle.Movement.Steer(steerVector);

                if (ReachedDestination)
                    GetNewNavPoint();
            }

            ScanForPlayer();
            AttackPlayer();
        }

        private Vector3 NormalizeSteering(Vector3 steering)
        {
            steering.y *= -1;
            return steering * Vehicle.Stats.TurnRate;
        }

        private void AttackPlayer()
        {
            if (TargetIsInAttackRange && PlayerIsInFront)
                Vehicle.Weapons.FirePrimary(ClosestTarget.position, ClosestTarget);
        }

        private void ScanForPlayer()
        {
            if(TargetIsNearby)
                EngageTarget();

            if(PlayerIsTarget && TargetIsTooFar)
                DisengagePlayer();
        }

        void EngageTarget() => currentTarget = ClosestTarget;

        void DisengagePlayer() => GetNewNavPoint();

        public void Disable() => enabled = false;

        public void ShootDown()
        {
            Disable();
            Vehicle.Destroy();
        }

        public void Enable() => enabled = true;

        public void UpdateTargets(IEnumerable<Transform> targets) => this.targets = targets;
    }
}
