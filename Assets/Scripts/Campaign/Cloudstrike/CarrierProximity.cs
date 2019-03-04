using Campaign.Environment;
using UnityEngine;

namespace Campaign.Cloudstrike
{
    public class CarrierProximity : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var island = other.GetComponent<IslandProximity>();

            if (island)
            {
                Debug.Log($"Entered proximity with {island.Island.Name}, currently aligned to {island.Island.Alignment}");
            }
        }
    }
}
