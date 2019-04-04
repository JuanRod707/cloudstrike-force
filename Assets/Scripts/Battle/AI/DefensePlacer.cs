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
        
        void AddShieldGenerator() => CreateBuilding(Prefabs.Refinery, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        
        void AddShipyard() => CreateBuilding(Prefabs.Refinery, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        
        void AddMassDriver() => CreateBuilding(Prefabs.Refinery, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        
        void AddBunker() => CreateBuilding(Prefabs.Refinery, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        
        void AddCruisers(int count)
        {
            
        }
        
        void AddTanks(int count)
        {
            
        }
        
        void AddDrones(int count)
        {
            CreateBuilding(Prefabs.DroneTower, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        }
        
        void AddInterceptors(int count)
        {
            CreateBuilding(Prefabs.DroneTower, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        }
        
        void AddTurrets(int count)
        {
            CreateBuilding(Prefabs.TurretControl, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        }
        
        void AddSAMs(int count)
        {
            CreateBuilding(Prefabs.SAMTower, BuildingContainer, MainBuildingSpots.ConsumeSpot());
        }

        GameObject CreateBuilding(GameObject prefab, Transform container, Transform position)
        {
            var building = Instantiate(prefab, position.position, position.rotation);
            building.transform.SetParent(container);

            return building;
        }
    }
}
