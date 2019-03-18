using Assets.Scripts.Battle.Entities;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Buildings
{
    public class Building : MonoBehaviour
    {
        public Health Health;
        public GameObject View;
        public GameObject Colliders;

        private IslandBase islandBase;
        private AICoordinator function;

        public void Initialize(IslandBase faction)
        {
            islandBase = faction;
            Health.Initialize(Destroy);
            function = GetComponent<AICoordinator>();

            function?.Initialize(faction.TargetProvider);
        }

        private void Destroy()
        {
            islandBase.MainBuildingDestroyed();
            View.SetActive(false);
            Colliders.SetActive(false);
            function?.Deactivate();
        }
    }
}
