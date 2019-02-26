using AI;
using UnityEngine;

namespace Weapons.Secondary
{
    public class PatrolDroneAI : MonoBehaviour
    {
        public float Speed;
        public float TurnRate;
        public float DistanceToReachNavPoint;

        private NavigationPoints patrolPoints;
        Transform target;

        private bool ReachedTarget =>
            Vector3.Distance(target.position, transform.position) < DistanceToReachNavPoint;

        public void Initialize(NavigationPoints patrol)
        {
            patrolPoints = patrol;
            GetNewNavPoint();
        }

        private void GetNewNavPoint() => target = patrolPoints.GetRandomNavPoint;

        void FixedUpdate()
        {
            transform.Translate(Vector3.forward * Speed);
            if (target != null)
            {
                Steer();
                if(ReachedTarget)
                    GetNewNavPoint();
            }
        }

        void Steer()
        {
            var relativeTargetPosition = transform.InverseTransformPoint(target.position);

            var turnFactor = relativeTargetPosition.x > 0 ? 1f : -1f;
            transform.Rotate(transform.up * TurnRate * turnFactor, Space.World);

            var pitchFactor = relativeTargetPosition.y > 0 ? -1f : 1f;
            transform.Rotate(transform.right * TurnRate * pitchFactor, Space.World);
            Normalize();
        }

        void Normalize()
        {
            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }
    }
}
