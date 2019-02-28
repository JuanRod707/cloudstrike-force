using Cloudstrike;
using UnityEngine;
using System.Collections.Generic;

namespace AI.Control
{
    public class TurretCoordinator : MonoBehaviour
    {
        public Transform TurretContainer;
         
        CloudstrikeReferences cloudstrike;
        IEnumerable<TurretAI> turrets;

        void Start()
        {
            cloudstrike = FindObjectOfType<CloudstrikeReferences>();
            turrets = TurretContainer.GetComponentsInChildren<TurretAI>();

            foreach (var t in turrets)
                t.Initialize();
        }

        void FixedUpdate()
        {
            foreach (var t in turrets)
                t.AimToTarget(cloudstrike.ControlledPlane.position);
        }
    }
}
