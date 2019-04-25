using System.Collections.Generic;
using System.Linq;
using Battle.AI.Control;
using Common;
using UnityEngine;

namespace Battle.AI.Buildings
{
    public class SamCoordinator : MonoBehaviour, AICoordinator
    {
        public float LockingRange;
        public float TimeToLock;

        private float elapsedLockTime;
        IEnumerable<SamAI> turrets;
        IEnumerable<Transform> targets;

        bool TargetIsInRange(Transform target) =>
            Vector3.Distance(target.position, transform.position) < LockingRange;

        Transform ClosestTarget =>
            targets.OrderBy(t => Vector3.Distance(transform.position, t.position)).FirstOrDefault();

        public void Initialize(TargetProvider targetProvider, Transform vehicles, Transform turretContainer, PatrolContainer patrols)
        {
            targetProvider.RegisterController(this);
            turrets = turretContainer.GetComponentsInChildren<SamAI>();

            foreach (var t in turrets)
                t.Initialize();
        }

        public void UpdateTargets(IEnumerable<Transform> possibleTargets) => targets = possibleTargets;

        public void Deactivate() => enabled = false;

        void FixedUpdate()
        {
            if (targets.Any())
            {
                if (TargetIsInRange(ClosestTarget))
                {
                    foreach (var t in turrets)
                        t.AimToTarget(ClosestTarget);

                    elapsedLockTime += Time.fixedDeltaTime;

                    if (elapsedLockTime > TimeToLock)
                        FireMissile(ClosestTarget);
                }
                else
                    elapsedLockTime = 0;
            }
        }

        private void FireMissile(Transform target)
        {
            if (turrets.Any(t => t.enabled))
            {
                turrets.Where(t => t.enabled).PickOne().Attack(target);
                elapsedLockTime = 0;
            }
        }
    }
}
