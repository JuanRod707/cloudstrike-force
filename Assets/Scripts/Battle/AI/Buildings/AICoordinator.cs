using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Buildings
{
    public interface AICoordinator
    {
        void Initialize(TargetProvider targetProvider);
        void UpdateTargets(IEnumerable<Transform> possibleTargets);
        void Deactivate();
    }
}
