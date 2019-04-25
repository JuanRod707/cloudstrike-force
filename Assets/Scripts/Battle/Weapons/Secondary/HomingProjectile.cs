using UnityEngine;

namespace Battle.Weapons.Secondary
{
    public class HomingProjectile : Rocket
    {
        public float TurnRate;
        
        Transform target;

        private Vector3 SteeringToTarget => transform.InverseTransformPoint(target.position);

        public void Launch(Transform lockedTarget, DamageMessage damage)
        {
            base.Launch(damage);
            target = lockedTarget;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            if (target != null)
            {
                var steerVector = NormalizeSteering(SteeringToTarget);
                Steer(steerVector);
            }
        }

        private Vector3 NormalizeSteering(Vector3 steering)
        {
            steering.y *= -1;
            if (steering.magnitude > 1)
                steering = steering.normalized;

            return steering * TurnRate;
        }

        public void Steer(Vector3 steer)
        {
            var steerVector = steer * TurnRate;
            this.transform.Rotate(0f, steerVector.x, 0f);
            this.transform.Rotate(steerVector.y, 0f, 0f);
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
