using System.Collections.Generic;
using Battle.AI.Control;
using UnityEngine;

namespace Battle.AI.Buildings
{
    public interface AICoordinator
    {
        void Initialize(TargetProvider targetProvider, Transform vehicleContainer, Transform turretContainer, PatrolContainer patrolContainer);
        void UpdateTargets(IEnumerable<Transform> possibleTargets);
        void Deactivate();
    }
}
