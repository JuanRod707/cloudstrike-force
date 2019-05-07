using System.Collections.Generic;
using Battle.AI.Buildings;
using UnityEngine;

namespace Battle.AI
{
    public interface TargetProvider
    {
        IEnumerable<Transform> PossibleSmallTargets { get; }
        IEnumerable<Transform> PossibleBigTargets { get; }

        void RegisterController(AICoordinator coordinator);
        void UpdateTargets(IEnumerable<Transform> possibleTargets);
    }
}
