using System.Collections.Generic;
using Battle.AI;
using Battle.AI.Buildings;
using Battle.Cloudstrike;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Battle.Coalition
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
