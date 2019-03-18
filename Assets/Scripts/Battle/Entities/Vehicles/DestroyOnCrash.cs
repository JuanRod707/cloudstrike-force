using Assets.Scripts.Battle.Effects;
using UnityEngine;

namespace Assets.Scripts.Battle.Entities.Vehicles
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
