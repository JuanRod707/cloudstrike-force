using Battle.Entities;
using UnityEngine;

namespace Battle.Coalition.Buildings
{
    public abstract class Building : MonoBehaviour
    {
        public Health Health;
        public GameObject View;
        public GameObject Colliders;

        protected IslandBase islandBase;

        public virtual void Initialize(IslandBase faction) { }

        protected void Destroy()
        {
            islandBase.MainBuildingDestroyed();
            View.SetActive(false);
            Colliders.SetActive(false);
            enabled = false;
        }
    }
}
