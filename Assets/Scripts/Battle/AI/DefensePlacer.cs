using Assets.Scripts.Battle.AI;
using Assets.Scripts.Common;
using UnityEngine;

namespace Battle.AI
{
    public class DefensePlacer : MonoBehaviour
    {
        public BuildingPrefabs Prefabs;

        public SpotProvider MainBuildingSpots;
        public SpotProvider TurretSpots;

        public Transform BuildingContainer;
        public Transform TurretContainer;

        void AddRefinery() => CreateBuilding(Prefabs.Refinery, BuildingContainer, MainBuildingSpots.ConsumeSpot());

        GameObject CreateBuilding(GameObject prefab, Transform container, Transform position)
        {
            var building = Instantiate(prefab, position.position, position.rotation);
            building.transform.SetParent(container);

            return building;
        }
    }
}
