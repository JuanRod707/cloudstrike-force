using UnityEngine;

namespace Battle.UI
{
    public class IslandStatus : MonoBehaviour
    {
        public BuildingItem BuildingItemPrefab;

        public void AddBuilding()
        {
            Instantiate(BuildingItemPrefab, transform);
        }
    }
}
