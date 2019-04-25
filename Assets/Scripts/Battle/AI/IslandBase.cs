using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battle.AI.Buildings;
using Battle.AI.Control;
using Battle.Coalition;
using Battle.UI;
using Campaign;
using Campaign.Environment.Generation;
using Common;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Battle.AI
{
    public class IslandBase : MonoBehaviour
    {
        public TopHud StatusUI;

        public DefensePlacer DefensePlacer;
        public GameObject BuildingContainer;
        public Transform VehicleContainer;
        public Transform TurretContainer;
        public PatrolContainer Patrols;
        
        public TargetProvider TargetProvider;

        private IEnumerable<Building> buildings;
        private int hitPoints;

        void Start()
        {
            var islandLevel = 
                 StaticPersistence.GameState != null
                ? StaticPersistence.GameState.Mission.MissionIsland.Level
                : RandomService.GetRandom(1, 10);

            var islandName = StaticPersistence.GameState != null
                ? StaticPersistence.GameState.Mission.MissionIsland.Name
                : NameProvider.GetIslandName();
            
            StatusUI.Initialize(islandName, islandLevel);
            DefensePlacer.PlaceDefenses(islandLevel);
            
            buildings = BuildingContainer.GetComponentsInChildren<Building>();
            hitPoints = buildings.Count();
            TargetProvider = new CoalitionTargetProvider();

            foreach(var b in buildings)
                b.Initialize(this, VehicleContainer, TurretContainer, Patrols);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
                FinishMission();
        }

        public void MainBuildingDestroyed()
        {
            hitPoints--;
            if (hitPoints <= 0)
                FinishMission();
        }

        private void FinishMission()
        {
            StaticPersistence.GameState.SetIslandAlignment(StaticPersistence.GameState.Mission.MissionIsland.Name, Alignment.CloudStrike);
            StartCoroutine(WaitAndChangeScene());
        }

        private IEnumerator WaitAndChangeScene()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Campaign");
        }
    }
}
