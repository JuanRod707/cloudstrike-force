using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class SpotProvider : MonoBehaviour
    {
        List<Transform> positions;
        Transform[] allPositions;

        void Awake()
        {
            allPositions = GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
            positions = allPositions.ToList();
        }

        public Transform RandomSpot() => allPositions.PickOne();

        public Transform ConsumeSpot()
        {
            var candidate = positions.PickOne();

            positions.Remove(candidate);
            return candidate;
        } 
    }
}
