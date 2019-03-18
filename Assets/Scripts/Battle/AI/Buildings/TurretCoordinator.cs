using System.Collections.Generic;
using Assets.Scripts.Battle.AI.Control;
using Assets.Scripts.Battle.Cloudstrike;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Buildings
{
    public class TurretCoordinator : MonoBehaviour, AICoordinator
    {
        public Transform TurretContainer;
        IEnumerable<TurretAI> turrets;
        IEnumerable<Transform> targets;

        public void Initialize(TargetProvider targetProvider)
        {
            targetProvider.RegisterController(this);
            turrets = TurretContainer.GetComponentsInChildren<TurretAI>();

            foreach (var t in turrets)
                t.Initialize();
        }

        public void Deactivate() => enabled = false;

        void FixedUpdate()
        {
            foreach (var t in turrets)
                t.AimToClosestTarget(targets);
        }

        public void UpdateTargets(IEnumerable<Transform> possibleTargets) => targets = possibleTargets;

    }
}
