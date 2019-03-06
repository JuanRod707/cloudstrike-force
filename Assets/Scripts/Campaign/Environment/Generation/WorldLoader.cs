using Data;
using UnityEngine;

namespace Campaign.Environment.Generation
{
    public class WorldLoader : MonoBehaviour
    {
        public WorldGenerator Generator;
        public IslandPlacer Placer;
        StateHandler stateHandler;

        void Start()
        {
            stateHandler = FindObjectOfType<StateHandler>();

            NameProvider.ResetLists();
            if (StaticPersistence.GameState == null)
            {
                Generator.GenerateIslands();
                stateHandler.SaveMapStateInMemory();
            }
            else
            {
                LoadMap();
                stateHandler.LoadCarrier();
            }
        }

        private void LoadMap()
        {
            var gameState = stateHandler.LoadStateFromMemory();

            foreach (var i in gameState.Islands)
                Placer.PlaceIsland(i);

            foreach (var c in gameState.Cities)
                Placer.PlaceCity(c);
        }
    }
}
