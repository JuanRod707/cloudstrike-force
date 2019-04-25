using System.Linq;
using Common;
using Data;
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

        SecurityLevel[] mainBuildingRules;
        SecurityLevel[] droneRules;
        SecurityLevel[] tankRules;
        SecurityLevel[] interceptorRules;
        SecurityLevel[] cruiserRules;
        SecurityLevel[] turretRules;
        SecurityLevel[] samRules;

        void SetRules()
        {
            tankRules = new[]
            {
                new SecurityLevel(1, Prefabs.Tank, 4),
                new SecurityLevel(3, Prefabs.Tank, 2),
                new SecurityLevel(5, Prefabs.Tank, 2),
                new SecurityLevel(6, Prefabs.Tank, 2),
                new SecurityLevel(7, Prefabs.Tank, 2),
                new SecurityLevel(8, Prefabs.Tank, 2),
                new SecurityLevel(10, Prefabs.Tank, 2),
            };

            droneRules = new[]
            {
                new SecurityLevel(2, Prefabs.Drone, 4),
                new SecurityLevel(4, Prefabs.Drone, 2),
                new SecurityLevel(6, Prefabs.Drone, 2),
                new SecurityLevel(8, Prefabs.Drone, 2),
                new SecurityLevel(10, Prefabs.Drone, 2),
            };

            turretRules = new[]
            {
                new SecurityLevel(3, Prefabs.Turret, 4),
                new SecurityLevel(5, Prefabs.Turret, 1),
                new SecurityLevel(7, Prefabs.Turret, 1),
                new SecurityLevel(8, Prefabs.Turret, 1),
                new SecurityLevel(9, Prefabs.Turret, 1),
                new SecurityLevel(10, Prefabs.Turret, 2),
            };

            samRules = new[]
            {
                new SecurityLevel(4, Prefabs.SAMTurret, 2), 
                new SecurityLevel(6, Prefabs.SAMTurret, 1), 
                new SecurityLevel(8, Prefabs.SAMTurret, 1), 
                new SecurityLevel(10, Prefabs.SAMTurret, 1), 
            };

            cruiserRules = new[]
            {
                new SecurityLevel(8, Prefabs.Cruiser, 1), 
                new SecurityLevel(9, Prefabs.Cruiser, 1), 
            };

            interceptorRules = new[]
            {
                new SecurityLevel(7, Prefabs.Interceptor, 3), 
                new SecurityLevel(9, Prefabs.Interceptor, 1), 
                new SecurityLevel(10, Prefabs.Interceptor, 1), 
            };
            
            mainBuildingRules = new[]
            {
                new SecurityLevel(1, Prefabs.Refinery, 1),
                new SecurityLevel(2, Prefabs.DroneTower, 1),
                new SecurityLevel(3, Prefabs.TurretControl, 1),
                new SecurityLevel(4, Prefabs.SAMTower, 1),
                new SecurityLevel(5, Prefabs.MassDriver, 1),
                new SecurityLevel(6, Prefabs.Refinery, 1),
                new SecurityLevel(6, Prefabs.Bunker, 1),
                new SecurityLevel(7, Prefabs.InterceptorBase, 1),
                new SecurityLevel(8, Prefabs.MassDriver, 1),
                new SecurityLevel(9, Prefabs.Factory, 1),
                new SecurityLevel(10, Prefabs.ShieldBattery, 3),
                new SecurityLevel(10, Prefabs.MassDriver, 1)
            };
        }
        
        public void PlaceDefenses(int islandLevel)
        {
            SetRules();
            foreach (var rule in mainBuildingRules.Where(r => r.Level <= islandLevel))
            {
                foreach(var _ in Enumerable.Range(0, rule.Count))
                    CreateBuilding(rule.Building, BuildingContainer, BigSpots.ConsumeSpot());
            }
        }

        GameObject CreateBuilding(GameObject prefab, Transform container, Transform position)
        {
            var rotation = new Vector3(0f, RandomService.GetRandom(0, 360), 0f);
            var building = Instantiate(prefab, position.position, Quaternion.Euler(rotation));
            building.transform.SetParent(container);

            return building;
        }
    }
}
