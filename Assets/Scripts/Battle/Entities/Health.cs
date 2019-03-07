using System;
using UnityEngine;

namespace Battle.Entities
{
    public class Health : MonoBehaviour
    {
        public int BaseHitPoints;

        int currentHitPoints;
        private Action doOnDestroy;

        public void Initialize(Action doOnDestroy)
        {
            this.doOnDestroy = doOnDestroy;
            currentHitPoints = BaseHitPoints;
        }

        public void ReceiveDamage(int damage)
        {
            currentHitPoints -= damage;
            Debug.Log($"{gameObject.name} Received {damage}, current hp: {currentHitPoints}");

            if (currentHitPoints <= 0)
                doOnDestroy?.Invoke();
        }
    }
}