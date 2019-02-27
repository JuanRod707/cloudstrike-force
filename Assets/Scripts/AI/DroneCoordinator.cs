using Cloudstrike;
using UnityEngine;
using Weapons.Secondary;

namespace AI
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
