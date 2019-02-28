using Cloudstrike;
using UnityEngine;

namespace AI.Control
{
    public class DroneCoordinator : MonoBehaviour
    {
        public Transform DroneContainer;
        public NavigationPoints DronePatrol;

        void Start()
        {
            var cloudstrike = GameObject.FindObjectOfType<CloudstrikeReferences>();
            var drones = DroneContainer.GetComponentsInChildren<PatrolDroneAI>();
            foreach(var d in drones)
                d.Initialize(DronePatrol, cloudstrike.ControlledPlane);
        }
    }
}
