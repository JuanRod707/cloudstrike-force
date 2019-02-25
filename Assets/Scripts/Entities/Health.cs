using UnityEngine;

namespace Entities
{
    public class Health : MonoBehaviour
    {
        public int BaseHitPoints;

        int currentHitPoints;

        void Start() => currentHitPoints = BaseHitPoints;
        
        public void ReceiveDamage(int damage)
        {
            currentHitPoints -= damage;
            Debug.Log($"Received {damage}, current hp: {currentHitPoints}");
        }
    }
}