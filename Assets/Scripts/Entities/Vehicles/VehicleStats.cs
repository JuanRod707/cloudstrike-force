using System;

namespace Entities.Vehicles
{
    [Serializable]
    public class VehicleStats
    {
        public float MaxSpeed;
        public float MinSpeed;
        public float Acceleration;
        public float TurnRate;

        public float MaxClimbAngle;
        public float MaxDiveAngle;
    }
}
