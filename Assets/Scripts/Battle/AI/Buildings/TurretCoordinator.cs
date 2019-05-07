using System.Collections.Generic;
using Battle.AI.Control;
using UnityEngine;

namespace Battle.AI.Buildings
{
    public class TurretCoordinator : MonoBehaviour, AICoordinator
    {
        IEnumerable<TurretAI> turrets;
        IEnumerable<Transform> targets;

        public void Initialize(TargetProvider targetProvider, Transform vehicles, Transform turretContainer, PatrolContainer patrols)
        {
            targetProvider.RegisterController(this);
            turrets = turretContainer.GetComponentsInChildren<TurretAI>();

            foreach (var t in turrets)
                t.Initialize();
        }

        public void Deactivate() => enabled = false;

        void FixedUpdate()
        {
            foreach (var t in turrets)
                t.AimToClosestTarget(targets);
        }

        public void UpdateTargets(TargetProvider targetProvider) => targets = targetProvider.PossibleSmallTargets;

    }
}
