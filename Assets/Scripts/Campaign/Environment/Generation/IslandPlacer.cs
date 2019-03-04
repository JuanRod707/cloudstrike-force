using System.Collections.Generic;
using Data.Dtos;
using UnityEngine;

namespace Campaign.Environment.Generation
{
    public class IslandPlacer : MonoBehaviour
    {
        public Island IslandPrefab;
        public City CityPrefab;
        public Transform IslandContainer;

        private List<Island> islands = new List<Island>();
        private List<City> cities = new List<City>();

        public IEnumerable<Island> Islands => islands;
        public IEnumerable<City> Cities => cities;

        public Island PlaceIsland(Vector3 position)
        {
            var island = Instantiate(IslandPrefab, position, Quaternion.identity);
            island.transform.SetParent(IslandContainer);
            islands.Add(island);
            island.Initialize();
            return island;
        }
        
        public Island PlaceIsland(IslandData data)
        {
            var island = PlaceIsland(data.Position);
            island.Initialize(data);
            return island;
        }

        public City PlaceCity(Vector3 position)
        {
            var city = Instantiate(CityPrefab, position, Quaternion.identity);
            city.transform.SetParent(IslandContainer);
            cities.Add(city);
            city.Initialize();
            return city;
        }

        public City PlaceCity(CityData data)
        {
            var city = PlaceCity(data.Position);
            city.Initialize(data);
            return city;
        }
    }
}
