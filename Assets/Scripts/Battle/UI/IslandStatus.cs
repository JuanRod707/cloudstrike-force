using UnityEngine;

namespace Battle.UI
{
    public class IslandStatus : MonoBehaviour
    {
        public BuildingItem BuildingItemPrefab;

        public BuildingItem AddBuilding(string buildingName)
        {
            var item = Instantiate(BuildingItemPrefab, transform);
            item.SetName(buildingName);
            return item;
        }
    }
}
