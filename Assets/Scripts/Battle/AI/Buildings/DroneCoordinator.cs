using System.Collections.Generic;
using Assets.Scripts.Battle.AI.Control;
using Assets.Scripts.Battle.Cloudstrike;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Buildings
{
    public class DroneCoordinator : MonoBehaviour, AICoordinator
    {
        public Transform DroneContainer;
        public NavigationPoints DronePatrol;

        private IEnumerable<PatrolDroneAI> drones;
        IEnumerable<Transform> targets;

        public void Initialize(TargetProvider targetProvider)
        {
            targetProvider.RegisterController(this);
            InitializeDrones();
        }

        void RefreshDrones()
        {
            drones = DroneContainer.GetComponentsInChildren<PatrolDroneAI>();

            foreach (var d in drones)
                d.UpdateTargets(targets);
        }

        void InitializeDrones()
        {
            drones = DroneContainer.GetComponentsInChildren<PatrolDroneAI>();

            foreach (var d in drones)
                d.Initialize(DronePatrol, targets);
        }

        public void UpdateTargets(IEnumerable<Transform> possibleTargets)
        {
            targets = possibleTargets;
            RefreshDrones();
        }

        public void Deactivate()
        {
            foreach (var d in drones)
                d.Vehicle.Destroy();
        }
    }
}
