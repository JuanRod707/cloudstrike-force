using System.Collections.Generic;
using Battle.Cloudstrike;
using Battle.Coalition.AI;
using Battle.Coalition.AI.Control;
using UnityEngine;

namespace Battle.Coalition.Buildings
{
    public class DroneCoordinator : MonoBehaviour, AICoordinator
    {
        public Transform DroneContainer;
        public NavigationPoints DronePatrol;

        private IEnumerable<PatrolDroneAI> drones;

        public void Initialize()
        {
            var cloudstrike = GameObject.FindObjectOfType<CloudstrikeReferences>();
            drones = DroneContainer.GetComponentsInChildren<PatrolDroneAI>();

            foreach (var d in drones)
                d.Initialize(DronePatrol, cloudstrike.ControlledPlane);           
        }

        public void Deactivate()
        {
            foreach (var d in drones)
                d.Vehicle.Destroy();
        }
    }
}
