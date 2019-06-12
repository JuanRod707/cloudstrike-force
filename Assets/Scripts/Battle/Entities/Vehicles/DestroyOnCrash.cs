using Battle.Effects;
using UnityEngine;

namespace Battle.Entities.Vehicles
{
    public class DestroyOnCrash : MonoBehaviour
    {
        public AirVehicle attachedAirVehicle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ColliderImpact>() != null)
                attachedAirVehicle.Destroy();
        }
    }
}
