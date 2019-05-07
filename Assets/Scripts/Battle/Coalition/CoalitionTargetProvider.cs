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
        public IEnumerable<Transform> PossibleSmallTargets => new[] {cloudstrikeTarget};
        public IEnumerable<Transform> PossibleBigTargets => new[] {cloudstrikeCarrier};

        Transform cloudstrikeTarget = Object.FindObjectOfType<CloudstrikeReferences>().ControlledPlane;
        Transform cloudstrikeCarrier = Object.FindObjectOfType<CloudstrikeReferences>().Carrier;

        List<AICoordinator> coordinators = new List<AICoordinator>();

        public void RegisterController(AICoordinator coordinator)
        {
            coordinators.Add(coordinator);
            coordinator.UpdateTargets(this);
        }

        public void UpdateTargets(IEnumerable<Transform> possibleTargets)
        {
            foreach (var c in coordinators)
                c.UpdateTargets(this);
        }
    }
}
