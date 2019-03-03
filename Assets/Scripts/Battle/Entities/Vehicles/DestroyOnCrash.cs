using Battle.Effects;
using UnityEngine;

namespace Battle.Entities.Vehicles
{
    public class DestroyOnCrash : MonoBehaviour
    {
        public Vehicle AttachedVehicle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ColliderImpact>() != null)
                AttachedVehicle.Destroy();
        }
    }
}
