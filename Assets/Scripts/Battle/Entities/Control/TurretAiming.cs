using UnityEngine;

namespace Battle.Entities.Control
{
    public class TurretAiming : MonoBehaviour
    {
        public Turret Turret;
        public float FrontAngleThreshold;

        private float turn;
        private float amountTurned;

        public bool TargetIsInFront(Transform target) => 
            SteeringToTarget(target.position).z > 5 &&
            Mathf.Abs(SteeringToTarget(target.position).y) < FrontAngleThreshold &&
            Mathf.Abs(SteeringToTarget(target.position).x) < FrontAngleThreshold;

        Vector3 SteeringToTarget(Vector3 target) => transform.InverseTransformPoint(target);

        void Steer(Vector3 steer)
        {
            var steerVector = steer * Turret.Stats.TurnRate;
            this.transform.Rotate(0f, steerVector.x, 0f);

            if (steerVector.y > 0 && amountTurned <= Turret.Stats.MaxPitch)
            {
                amountTurned += steerVector.y;
                this.transform.Rotate(steerVector.y, 0f, 0f);
            }
            else if (steerVector.y < 0 && amountTurned >= Turret.Stats.MinPitch)
            {
                amountTurned += steerVector.y;
                this.transform.Rotate(steerVector.y, 0f, 0f);
            }

            Normalize();
        }

        void Normalize()
        {
            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }

        public void AimTo(Transform target)
        {
            var steerVector = NormalizeSteering(SteeringToTarget(target.position));
            Steer(steerVector);
        }

        Vector3 NormalizeSteering(Vector3 steering)
        {
            steering.y *= -1;
            return steering * Turret.Stats.TurnRate;
        }
    }
}
