using System.Collections.Generic;
using Battle.Cloudstrike;
using Battle.Entities;
using UnityEngine;

namespace Battle.AI.Control
{
    public class TurretCoordinator : MonoBehaviour
    {
        public Transform TurretContainer;
        public Health Health;
        public GameObject View;
         
        CloudstrikeReferences cloudstrike;
        IEnumerable<TurretAI> turrets;

        void Start()
        {
            cloudstrike = FindObjectOfType<CloudstrikeReferences>();
            turrets = TurretContainer.GetComponentsInChildren<TurretAI>();
            Health.Initialize(Destroy);

            foreach (var t in turrets)
                t.Initialize();
        }

        void FixedUpdate()
        {
            foreach (var t in turrets)
                t.AimToTarget(cloudstrike.ControlledPlane);
        }

        void Destroy()
        {
            View.SetActive(false);
            enabled = false;
        }
    }
}
