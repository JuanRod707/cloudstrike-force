using Battle.Entities.Vehicles;
using UnityEngine;

namespace Battle.Entities.Control
{
    public class PlaneMovement : MonoBehaviour
    {
        public AirVehicle attachedAirVehicle;
        public float RollFactor;
        public float StrafeSpeed;
        public Transform Model;
        
        private float currentSpeed;
        private float turn;
        private float amountTurned;

        public void IncreaseThrust() => currentSpeed = Mathf.Min(attachedAirVehicle.Stats.MaxSpeed, currentSpeed + attachedAirVehicle.Stats.Acceleration);

        public void DecreaseThrust() => currentSpeed = Mathf.Max(attachedAirVehicle.Stats.MinSpeed, currentSpeed - attachedAirVehicle.Stats.Acceleration);

        public void StrafeLeft() => attachedAirVehicle.transform.Translate(Vector3.left * StrafeSpeed);

        public void StrafeRight() => attachedAirVehicle.transform.Translate(Vector3.right * StrafeSpeed);

        void ThrustForward() => attachedAirVehicle.transform.Translate(Vector3.forward * currentSpeed);

        void FixedUpdate() => ThrustForward();
        
        public void Steer(Vector3 steer)
        {
            var steerVector = steer * attachedAirVehicle.Stats.TurnRate;
            this.transform.Rotate(0f, steerVector.x, 0f);

            if (steerVector.y > 0 && amountTurned <= attachedAirVehicle.Stats.MaxClimbAngle)
            {
                amountTurned += steerVector.y;
                this.transform.Rotate(steerVector.y, 0f, 0f);
            }
            else if (steerVector.y < 0 && amountTurned >= attachedAirVehicle.Stats.MaxDiveAngle)
            {
                amountTurned += steerVector.y;
                this.transform.Rotate(steerVector.y, 0f, 0f);
            }

            Model.localEulerAngles = new Vector3(0f, 0f, steerVector.x * -RollFactor);
            Normalize();
        }

        void Normalize()
        {
            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }
        
        public void Launch() => currentSpeed = attachedAirVehicle.Stats.MinSpeed;

        public void Stop() => currentSpeed = 0;
    }
}
