using Data;
using Data.Dtos;
using UnityEngine;
using System.Linq;
using System;

namespace Campaign.Environment.Generation
{
    public class WorldLoader : MonoBehaviour
    {
        public WorldGenerator Generator;
        public IslandPlacer Placer;

        void Start()
        {
            NameProvider.ResetLists();
            if (StaticPersistence.GameState == null)
            {
                Generator.GenerateIslands();
                StaticPersistence.GameState = new GameState(
                        Placer.Islands.Select(i => Convert(i)).ToArray(),
                        Placer.Cities.Select(c => Convert(c)).ToArray());
            }
            else
                LoadMap();
        }

        private void LoadMap()
        {
            var gameState = StaticPersistence.GameState;

            foreach (var i in gameState.Islands)
                Placer.PlaceIsland(i);

            foreach (var c in gameState.Cities)
                Placer.PlaceCity(c);
        }

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
