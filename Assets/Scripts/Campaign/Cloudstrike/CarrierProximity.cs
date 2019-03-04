using Campaign.Environment;
using UnityEngine;

namespace Campaign.Cloudstrike
{
    public class CarrierProximity : MonoBehaviour
    {
        public CarrierInteractions Carrier;

        private void OnTriggerEnter(Collider other)
        {
            var island = other.GetComponent<IslandProximity>();

            if (island)
                Carrier.ArriveOnIsland(island.Island);
        }

        private void OnTriggerExit(Collider other)
        {
            var island = other.GetComponent<IslandProximity>();

            if (island)
                Carrier.DepartFromIsland();
        }
    }
}
