using Control;
using Entities;
using UnityEngine;
using Vehicles;

namespace AI
{
    public class PatrolDroneAI : MonoBehaviour
    {
        public WeaponSystem Weapons;
        public VehicleStats Stats;
        public GameObject View;
        public GameObject DeathExplosion;
        public Health VehicleHealth;

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

        private bool PlayerIsInRange =>
            Vector3.Distance(player.position, transform.position) < DistanceToAttack;

        private bool PlayerIsTarget => target == player;

        public void Initialize(NavigationPoints patrol, Transform player)
        {
            Weapons.Initialize();
            this.player = player;
            patrolPoints = patrol;
            GetNewNavPoint();
        }

        private void GetNewNavPoint() => target = patrolPoints.GetRandomNavPoint;

        void FixedUpdate()
        {
            transform.Translate(Vector3.forward * Stats.MaxSpeed);
            if (target != null)
            {
                Steer();
                if(ReachedTarget)
                    GetNewNavPoint();
            }

            ScanForPlayer();
            AttackPlayer();
        }

        private void AttackPlayer()
        {
            if (PlayerIsInRange)
                Weapons.FirePrimary(player.transform.position);
        }

        private void ScanForPlayer()
        {
            if(PlayerIsNearby)
                EngagePlayer();

            if(PlayerIsTarget && PlayerIsTooFar)
                DisengagePlayer();
        }

        void Steer()
        {
            var relativeTargetPosition = transform.InverseTransformPoint(target.position);

            var turnFactor = relativeTargetPosition.x > 0 ? 1f : -1f;
            transform.Rotate(transform.up * Stats.TurnRate * turnFactor, Space.World);

            var pitchFactor = relativeTargetPosition.y > 0 ? -1f : 1f;
            transform.Rotate(transform.right * Stats.TurnRate * pitchFactor, Space.World);
            Normalize();
        }

        void Normalize()
        {
            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }

        void EngagePlayer() => target = player;

        void DisengagePlayer() => GetNewNavPoint();
    }
}
