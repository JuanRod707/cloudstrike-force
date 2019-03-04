using System;
using System.Collections.Generic;
using System.Linq;
using Campaign;
using Data.Dtos;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class GameState
    {
        public List<IslandData> Islands;
        public List<CityData> Cities;
        public CarrierData Carrier;
        public MissionData Mission;

        public void SetIslandAlignment(string island, Alignment alignment) => GetIsland(island).Alignment = alignment;

        public GameState()
        {
        }

        public GameState(IEnumerable<IslandData> islands, IEnumerable<CityData> cities)
        {
            Islands = islands.ToList();
            Cities = cities.ToList();
        }

        public void SetCarrierPosition(Vector3 position) => Carrier = new CarrierData
        {
            Position = position
        };

        public void PrepareMission(string island) => Mission = new MissionData(GetIsland(island));

        IslandData GetIsland(string island) => Islands.First(i => i.Name.ToLower().Equals(island.ToLower()));
    }
}
