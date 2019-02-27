using System;
using UnityEngine;

namespace Entities
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
            Debug.Log($"Received {damage}, current hp: {currentHitPoints}");

            if (currentHitPoints <= 0)
                doOnDestroy?.Invoke();
        }
    }
}