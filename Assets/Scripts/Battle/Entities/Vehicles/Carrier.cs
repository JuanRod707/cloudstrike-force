using Battle.Entities;
using Battle.UI;
using UnityEngine;

namespace Assets.Scripts.Battle.Entities.Vehicles
{
    public class Carrier : MonoBehaviour
    {
        public Health Health;
        public BottomHud HealthBarUI;

        void Start()
        {
            HealthBarUI.Initialize(Health.BaseHitPoints);
            Health.Initialize(Destroy, HealthBarUI.UpdateHp);
        }

        void Destroy()
        { }
    }
}
