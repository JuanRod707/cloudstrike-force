using System.Collections.Generic;
using Assets.Scripts.Battle.AI;
using Assets.Scripts.Battle.AI.Buildings;
using Assets.Scripts.Battle.Cloudstrike;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Battle.Coalition
{
    public class CoalitionTargetProvider : TargetProvider
    {
        public IEnumerable<Transform> PossibleTargets => new[] {cloudstrikeTarget};

        Transform cloudstrikeTarget = Object.FindObjectOfType<CloudstrikeReferences>().ControlledPlane;

        List<AICoordinator> coordinators = new List<AICoordinator>();

        public void RegisterController(AICoordinator coordinator)
        {
            coordinators.Add(coordinator);
            coordinator.UpdateTargets(PossibleTargets);
        }

        public void UpdateTargets(IEnumerable<Transform> possibleTargets)
        {
            foreach (var c in coordinators)
                c.UpdateTargets(PossibleTargets);
        }
    }
}
