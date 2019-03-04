using System.Collections;
using Battle.Coalition.Buildings;
using Campaign;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Battle.Coalition
{
    public class IslandBase : MonoBehaviour
    {
        public Building[] MainBuildings;

        private int hitPoints;

        void Start()
        {
            hitPoints = MainBuildings.Length;
            foreach(var b in MainBuildings)
                b.Initialize(this);
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
