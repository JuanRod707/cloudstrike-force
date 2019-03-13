using System.Collections.Generic;
using Battle.Cloudstrike;
using Battle.Coalition.AI.Control;
using UnityEngine;

namespace Battle.Coalition.Buildings
{
    public class TurretCoordinator : MonoBehaviour, AICoordinator
    {
        public Transform TurretContainer;
   
        CloudstrikeReferences cloudstrike;
        IEnumerable<TurretAI> turrets;

        public void Initialize()
        {
            cloudstrike = FindObjectOfType<CloudstrikeReferences>();
            turrets = TurretContainer.GetComponentsInChildren<TurretAI>();

            foreach (var t in turrets)
                t.Initialize();
        }

        public void Deactivate() => enabled = false;

        void FixedUpdate()
        {
            foreach (var t in turrets)
                t.AimToTarget(cloudstrike.ControlledPlane);
        }
    }
}
