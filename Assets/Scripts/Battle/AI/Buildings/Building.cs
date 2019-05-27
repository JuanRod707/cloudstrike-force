using System;
using Battle.AI.Control;
using Battle.Entities;
using UnityEngine;

namespace Battle.AI.Buildings
{
    public class Building : MonoBehaviour
    {
        public string Name;
        public Health Health;
        public GameObject View;
        public GameObject Colliders;

        private IslandBase islandBase;
        private AICoordinator function;

        public void Initialize(IslandBase faction, Transform vehicles, Transform turrets, PatrolContainer patrols)
        {
            islandBase = faction;
            Health.Initialize(Destroy);
            function = GetComponent<AICoordinator>();

            function?.Initialize(faction.TargetProvider, vehicles, turrets, patrols);
        }
        
        public void Initialize(IslandBase faction, Transform vehicles, Transform turrets, PatrolContainer patrols, Action<int> onHealthUpdate)
        {
            islandBase = faction;
            Health.Initialize(Destroy, onHealthUpdate);
            function = GetComponent<AICoordinator>();

            function?.Initialize(faction.TargetProvider, vehicles, turrets, patrols);
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
