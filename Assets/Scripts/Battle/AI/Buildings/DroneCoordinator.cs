﻿using System.Collections.Generic;
using Battle.AI.Control;
using UnityEngine;

namespace Battle.AI.Buildings
{
    public class DroneCoordinator : MonoBehaviour, AICoordinator
    {
        Transform droneContainer;
        NavigationPoints dronePatrol;

        private IEnumerable<PatrolDroneAI> drones;
        IEnumerable<Transform> targets;

        public void Initialize(TargetProvider targetProvider, Transform vehicles, Transform turrets, PatrolContainer patrols)
        {
            dronePatrol = patrols.DronePatrol;
            droneContainer = vehicles;
            
            targetProvider.RegisterController(this);
            InitializeDrones();
        }

        void RefreshDrones()
        {
            drones = droneContainer.GetComponentsInChildren<PatrolDroneAI>();

            foreach (var d in drones)
                d.UpdateTargets(targets);
        }

        void InitializeDrones()
        {
            drones = droneContainer.GetComponentsInChildren<PatrolDroneAI>();

            foreach (var d in drones)
                d.Initialize(dronePatrol, targets);
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
