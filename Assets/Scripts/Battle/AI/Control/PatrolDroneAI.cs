using Battle.Entities.Control;
using Battle.Entities.Vehicles;
using UnityEngine;

namespace Battle.AI.Control
{
    public class PatrolDroneAI : MonoBehaviour, Controller
    {
        public Vehicle Vehicle;
     
        public float DistanceToReachNavPoint;
        public float DistanceToEngage;
        public float DistanceToDisengage;
        public float DistanceToAttack;
     
        private NavigationPoints patrolPoints;
        Transform target;
        Transform player;

        private bool ReachedTarget =>
            Vector3.Distance(target.position, transform.position) < DistanceToReachNavPoint;

        private bool PlayerIsNearby =>
            Vector3.Distance(player.position, transform.position) < DistanceToEngage;

        private bool PlayerIsTooFar =>
            Vector3.Distance(player.position, transform.position) > DistanceToDisengage;

        private bool PlayerIsInAttackRange =>
            Vector3.Distance(player.position, transform.position) < DistanceToAttack;

        private bool PlayerIsInFront => SteeringToTarget.z > 5;

        private Vector3 SteeringToTarget => transform.InverseTransformPoint(target.position);

        private bool PlayerIsTarget => target == player;

        public void Initialize(NavigationPoints patrol, Transform player)
        {
            this.player = player;
            patrolPoints = patrol;
            GetNewNavPoint();
            Vehicle.Initialize(this);
            Vehicle.Launch();
        }

        private void GetNewNavPoint() => target = patrolPoints.GetRandomNavPoint;

        void FixedUpdate()
        {
            if (target != null)
            {
                var steerVector = NormalizeSteering(SteeringToTarget);
                Vehicle.Movement.Steer(steerVector);

                if (ReachedTarget)
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
            if (PlayerIsInAttackRange && PlayerIsInFront)
                Vehicle.Weapons.FirePrimary(player.transform.position);
        }

        private void ScanForPlayer()
        {
            if(PlayerIsNearby)
                EngagePlayer();

            if(PlayerIsTarget && PlayerIsTooFar)
                DisengagePlayer();
        }

        void EngagePlayer() => target = player;

        void DisengagePlayer() => GetNewNavPoint();

        public void Disable() => enabled = false;

        public void ShootDown()
        {
            Disable();
            Vehicle.Destroy();
        }

        public void Enable() => enabled = true;
    }
}
