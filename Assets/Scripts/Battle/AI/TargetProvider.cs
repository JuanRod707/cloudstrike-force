using System.Collections.Generic;
using Assets.Scripts.Battle.AI.Buildings;
using UnityEngine;

namespace Assets.Scripts.Battle.AI
{
    public interface TargetProvider
    {
        IEnumerable<Transform> PossibleTargets { get; }

        void RegisterController(AICoordinator coordinator);
        void UpdateTargets(IEnumerable<Transform> possibleTargets);
    }
}
