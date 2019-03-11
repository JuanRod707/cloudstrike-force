using System.Collections.Generic;
using Battle.Cloudstrike;
using Battle.Coalition.AI.Control;
using UnityEngine;

namespace Battle.Coalition.Buildings
{
    public class TurretCoordinator : Building
    {
        public Transform TurretContainer;
   
        CloudstrikeReferences cloudstrike;
        IEnumerable<TurretAI> turrets;

        public override void Initialize(IslandBase faction)
        {
            islandBase = faction;
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
    }
}
