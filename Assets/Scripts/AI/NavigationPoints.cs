using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace AI
{
    public class NavigationPoints : MonoBehaviour
    {
        private IEnumerable<Transform> navPoints;

        void Start() => navPoints = GetComponentsInChildren<Transform>().Where(t => t != transform);

        public Transform GetRandomNavPoint => navPoints.PickOne();
    }
}
