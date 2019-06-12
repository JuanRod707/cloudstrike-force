using Battle.Entities.Vehicles;
using UnityEngine;

namespace Battle.Entities.Control
{
    public class LandMovement : MonoBehaviour
    {
        public LandVehicle AttachedVehicle;
        public Rigidbody Body;

        public void Accelerate()
        {
            if(Body.velocity.magnitude < AttachedVehicle.Stats.MaxSpeed)
                Body.AddForce(AttachedVehicle.transform.forward * AttachedVehicle.Stats.Acceleration);
        }

        public void SteerRight() => 
            Body.AddTorque(AttachedVehicle.transform.up * AttachedVehicle.Stats.TurnRate);
        
        public void SteerLeft() => 
            Body.AddTorque(AttachedVehicle.transform.up * -AttachedVehicle.Stats.TurnRate);
        
        public void Break() =>
            Body.AddForce(-Body.velocity * AttachedVehicle.Stats.Acceleration);
        
        void FixedUpdate() => Accelerate();
        
        public void Stop()
        {
            
        }
    }
}
