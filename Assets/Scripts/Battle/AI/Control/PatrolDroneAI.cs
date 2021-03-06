﻿using System.Collections.Generic;
using System.Linq;
using Battle.Entities.Control;
using Battle.Entities.Vehicles;
using UnityEngine;

namespace Battle.AI.Control
{
    public class PatrolDroneAI : MonoBehaviour, Controller
    {
        public AirVehicle airVehicle;
     
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
            airVehicle.Initialize(this);
            airVehicle.Launch();
        }

        private void GetNewNavPoint() => currentTarget = patrolPoints.GetRandomNavPoint;

        void FixedUpdate()
        {
            if (currentTarget != null)
            {
                var steerVector = NormalizeSteering(SteeringToTarget);
                airVehicle.Movement.Steer(steerVector);

                if (ReachedDestination)
                    GetNewNavPoint();
            }

            ScanForPlayer();
            AttackPlayer();
        }

        private Vector3 NormalizeSteering(Vector3 steering)
        {
            steering.y *= -1;
            return steering * airVehicle.Stats.TurnRate;
        }

        private void AttackPlayer()
        {
            if (TargetIsInAttackRange && PlayerIsInFront)
                airVehicle.Weapons.FirePrimary(ClosestTarget.position, ClosestTarget);
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
            airVehicle.Destroy();
        }

        public void Enable() => enabled = true;

        public void UpdateTargets(IEnumerable<Transform> targets) => this.targets = targets;
    }
}
