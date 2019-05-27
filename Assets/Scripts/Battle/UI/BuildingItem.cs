using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class BuildingItem : MonoBehaviour
    {
        public HealthBar HealthBar;
        public Text BuildingName;

        public void Initialize(int baseHp) => HealthBar.Initialize(baseHp);

        public void UpdateHp(int hp)
        {
            HealthBar.UpdateHp(hp);
            if(hp <= 0)
                Destroy(gameObject, 1f);
        }

        public void SetName(string buildingName) => BuildingName.text = buildingName;
    }
}