using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Campaign.Environment
{
    public class WorldGenerator : MonoBehaviour
    {
        public Transform IslandContainer;
        public GameObject IslandPrefab;
        public GameObject CityPrefab;
        public IslandRing[] Rings;
        public float MinimumSeparation;
        public int CityChance;
        public int MaxCities;

        private List<Transform> Islands;

        void Start() => GenerateIslands();

        private void GenerateIslands()
        {
            Islands = new List<Transform>();
            foreach (var r in Rings)
                GenerateRing(r);
        }

        private void GenerateRing(IslandRing ring)
        {
            foreach (var _ in Enumerable.Range(0, ring.MaxIslands))
            {
                var position = GetPositionInRing(ring.RingDistance);
                
                var island = Instantiate(RandomizeIsland(), position, Quaternion.identity);
                island.transform.SetParent(IslandContainer);
                CheckPosition(island.transform, ring.RingDistance);
                Islands.Add(island.transform);
            }
        }

        private GameObject RandomizeIsland()
        {
            if (MaxCities > 0)
            {
                if (RandomService.RollD100(CityChance))
                {
                    MaxCities--;
                    return CityPrefab;
                }
            }

            return IslandPrefab;
        }

        private void CheckPosition(Transform island, float ringDistance)
        {
            if (Islands.Any(it => Vector3.Distance(island.position, it.position) < MinimumSeparation))
            {
                Debug.Log("islands too close, moving them");
                island.position = GetPositionInRing(ringDistance);
                CheckPosition(island, ringDistance);
            }
        }

        Vector3 GetPositionInRing(float ringDistance)
        {
            var randomVector = UnityEngine.Random.insideUnitCircle.normalized * ringDistance;
            return new Vector3(randomVector.x, 0f, randomVector.y);
        }
    }

    [Serializable]
    public class IslandRing
    {
        public float RingDistance;
        public int MaxIslands;
    }
}
