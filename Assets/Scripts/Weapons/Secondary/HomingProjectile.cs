using UnityEngine;

namespace Weapons.Secondary
{
    public class HomingProjectile : Rocket
    {
        public float TurnRate;
        
        Transform target;

        public void Launch(Transform lockedTarget, int damage)
        {
            base.Launch(damage);
            target = lockedTarget;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            if (target != null)
                Steer();
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
