using Assets.Scripts.Battle.AI;
using Assets.Scripts.Common;
using UnityEngine;

namespace Battle.AI
{
    public class DefensePlacer : MonoBehaviour
    {
        public DefensePrefabs Prefabs;

        public SpotProvider BigSpots;
        public SpotProvider SmallSpots;

        public Transform BuildingContainer;
        public Transform TurretContainer;

        public void PlaceDefenses(int islandLevel)
        {
            AddRefinery();
        }

        void AddRefinery() => CreateBuilding(Prefabs.Refinery, BuildingContainer, BigSpots.ConsumeSpot());

        void AddFactory() => CreateBuilding(Prefabs.Factory, BuildingContainer, BigSpots.ConsumeSpot());
        
        void AddMassDriver() => CreateBuilding(Prefabs.MassDriver, BuildingContainer, BigSpots.ConsumeSpot());
        
        void AddBunker() => CreateBuilding(Prefabs.Bunker, BuildingContainer, BigSpots.ConsumeSpot());

        void AddDroneBase() => CreateBuilding(Prefabs.DroneTower, BuildingContainer, BigSpots.ConsumeSpot());

        void AddInterceptorBase() => CreateBuilding(Prefabs.InterceptorBase, BuildingContainer, BigSpots.ConsumeSpot());

        void AddTurretControl() => CreateBuilding(Prefabs.TurretControl, BuildingContainer, BigSpots.ConsumeSpot());

        void AddSAMTower() => CreateBuilding(Prefabs.SAMTower, BuildingContainer, BigSpots.ConsumeSpot());

        void AddShields()
        {

        }

        void AddDrone(int count)
        {
            
        }

        void AddInterceptor(int count)
        {
            
        }

        void AddTurret(int count)
        {
            
        }

        void AddSAM(int count)
        {
            
        }

        void AddCruiser(int count)
        {
            
        }
        
        void AddTank(int count)
        {
            
        }

        GameObject CreateBuilding(GameObject prefab, Transform container, Transform position)
        {
            var building = Instantiate(prefab, position.position, position.rotation);
            building.transform.SetParent(container);

            return building;
        }
    }
}
