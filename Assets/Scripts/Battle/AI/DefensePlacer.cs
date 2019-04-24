using System.Linq;
using Assets.Scripts.Battle.AI;
using Assets.Scripts.Common;
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

        SecurityLevel[] securityRules;

        void SetRules()
        {
            securityRules = new[]
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
                new SecurityLevel(10, Prefabs.MassDriver, 1),
            };
        }
        
        public void PlaceDefenses(int islandLevel)
        {
            SetRules();
            foreach (var rule in securityRules.Where(r => r.Level <= islandLevel))
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
