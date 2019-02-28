using UnityEngine;

namespace Entities.Control
{
    public class TurretAiming : MonoBehaviour
    {
        public Turret Turret;
        
        private float turn;
        private float amountTurned;

        public void Steer(Vector3 steer)
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
    }
}
