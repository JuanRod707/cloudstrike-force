using Battle.Cloudstrike;
using Battle.Coalition.AI;
using Battle.Coalition.AI.Control;
using Battle.Entities;
using UnityEngine;

namespace Battle.Coalition.Buildings
{
    public class DroneCoordinator : Building
    {
        public Transform DroneContainer;
        public NavigationPoints DronePatrol;
        
        public override void Initialize(IslandBase faction)
        {
            islandBase = faction;
            var cloudstrike = GameObject.FindObjectOfType<CloudstrikeReferences>();
            var drones = DroneContainer.GetComponentsInChildren<PatrolDroneAI>();
            Health.Initialize(Destroy);

            foreach (var d in drones)
                d.Initialize(DronePatrol, cloudstrike.ControlledPlane);           
        }
    }
}
