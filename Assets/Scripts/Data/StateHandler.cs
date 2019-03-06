using System.Linq;
using Assets.Scripts.Campaign.Cloudstrike;
using Campaign.Environment;
using Campaign.Environment.Generation;
using Data.Dtos;
using UnityEngine;

namespace Data
{
    public class StateHandler : MonoBehaviour
    {
        public Carrier Carrier;
        public IslandPlacer Placer;

        public void SaveMapStateInMemory() => 
            StaticPersistence.GameState = new GameState(
            Placer.Islands.Select(i => Convert(i)).ToArray(),
            Placer.Cities.Select(c => Convert(c)).ToArray());

        public void StartMission(MissionData mission)
        {
            SaveMapStateInMemory();
            StaticPersistence.GameState.Carrier = new CarrierData
            {
                Position = Carrier.transform.position,
                Resources = Carrier.Resources
            };

            StaticPersistence.GameState.Mission = mission;
        }

        public GameState LoadStateFromMemory() => StaticPersistence.GameState;

        public void LoadCarrier() => Carrier.Initialize(StaticPersistence.GameState.Carrier);

        IslandData Convert(Island island) => new IslandData
        {
            Alignment = island.Alignment,
            Name = island.Name,
            Position = island.transform.position,
            SiloCount = island.SiloCount,
            SiloCapacity = island.SiloCapacity
        };

        CityData Convert(City island) => new CityData
        {
            Alignment = island.Alignment,
            Name = island.Name,
            Position = island.transform.position
        };
    }
}
