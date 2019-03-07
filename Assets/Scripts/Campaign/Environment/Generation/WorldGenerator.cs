using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Campaign.Environment.Generation
{
    public class WorldGenerator : MonoBehaviour
    {
        public IslandRing[] Rings;
        public float MinimumSeparation;
        public int CityChance;
        public int MaxCities;
        public IslandPlacer Placer;

        private List<Transform> Islands;
        
        public void GenerateIslands()
        {
            Islands = new List<Transform>();
            foreach (var r in Rings)
                GenerateRing(r);
        }

        private void GenerateRing(IslandRing ring)
        {
            foreach (var _ in Enumerable.Range(0, ring.MaxIslands))
            {
                var island = RandomizeIsland(ring);
                CheckPosition(island.transform, ring.RingDistance);
                Islands.Add(island.transform);
            }
        }

        private GameObject RandomizeIsland(IslandRing ring)
        {
            var position = GetPositionInRing(ring.RingDistance);
            if (ring.CanGenerateCities && MaxCities > 0)
            {
                if (RandomService.RollD100(CityChance))
                {
                    MaxCities--;
                    return Placer.PlaceCity(position).gameObject;
                }
            }

            return Placer.PlaceIsland(position).gameObject;
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
        public bool CanGenerateCities;
    }
}
