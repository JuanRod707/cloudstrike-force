using System.Collections.Generic;
using System.Linq;
using Battle.Cloudstrike;
using Battle.Coalition.AI.Control;
using Common;
using UnityEngine;

namespace Battle.Coalition.Buildings
{
    public class SamCoordinator : MonoBehaviour, AICoordinator
    {
        public float LockingRange;
        public float TimeToLock;

        public Transform TurretContainer;

        private float elapsedLockTime;
        CloudstrikeReferences cloudstrike;
        IEnumerable<SamAI> turrets;

        bool TargetIsInRange(Transform target) =>
            Vector3.Distance(target.position, transform.position) < LockingRange;

        public void Initialize()
        {
            cloudstrike = FindObjectOfType<CloudstrikeReferences>();
            turrets = TurretContainer.GetComponentsInChildren<SamAI>();

            foreach (var t in turrets)
                t.Initialize();
        }

        public void Deactivate() => enabled = false;

        void FixedUpdate()
        {
            if (TargetIsInRange(cloudstrike.ControlledPlane))
            {
                foreach (var t in turrets)
                    t.AimToTarget(cloudstrike.ControlledPlane);

                elapsedLockTime += Time.fixedDeltaTime;

                if (elapsedLockTime > TimeToLock)
                    FireMissile(cloudstrike.ControlledPlane);
            }
            else
                elapsedLockTime = 0;
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
