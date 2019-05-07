using System.Collections.Generic;
using Battle.AI.Control;
using UnityEngine;

namespace Battle.AI.Buildings
{
    [RequireComponent(typeof(MassDriverAI))]
    public class MassDriverTargetter : MonoBehaviour, AICoordinator
    {
        public float RateOfFire;
        
        IEnumerable<Transform> targets;
        MassDriverAI ai;

        void FixedUpdate() => ai.AimToClosestTarget(targets);
        
        public void Initialize(TargetProvider targetProvider, Transform vehicleContainer, Transform turretContainer,
            PatrolContainer patrolContainer)
        {
            UpdateTargets(targetProvider);
            ai = GetComponent<MassDriverAI>();
            ai.Initialize(RateOfFire);
        }

        public void UpdateTargets(TargetProvider targetProvider) => targets = targetProvider.PossibleBigTargets;

        public void Deactivate()
        {
            
        }
    }
}