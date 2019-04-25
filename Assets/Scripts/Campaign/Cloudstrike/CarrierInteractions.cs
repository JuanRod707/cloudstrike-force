using Campaign.Environment;
using Campaign.UI;
using Data;
using Data.Dtos;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Campaign.Cloudstrike
{
    public class CarrierInteractions : MonoBehaviour
    {
        public IslandPanel Panel;
        public Carrier Carrier;

        private Island nearbyIsland;
        
        void Start() => Panel.Initialize(this);

        public void ArriveOnIsland(Island island)
        {
            nearbyIsland = island;
            Panel.Show(island.Name);
        }

        public void DepartFromIsland()
        {
            nearbyIsland = null;
            Panel.Hide();
        }

        public void AttackIsland()
        {
            FindObjectOfType<StateHandler>().StartMission(new MissionData(new IslandData { Name = nearbyIsland.Name }));
            SceneManager.LoadScene("Mission");
        }

        public void ClaimResources() => Carrier.AddResources(nearbyIsland.ClaimResources());

        public void Upgrade() => nearbyIsland.Upgrade();
    }
}
