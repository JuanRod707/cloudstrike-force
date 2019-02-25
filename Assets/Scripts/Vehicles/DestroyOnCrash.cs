using Effects;
using UnityEngine;

namespace Vehicles
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
