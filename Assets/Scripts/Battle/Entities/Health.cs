using System;
using UnityEngine;

namespace Battle.Entities
{
    public class Health : MonoBehaviour
    {
        public int BaseHitPoints;

        int currentHitPoints;
        Action doOnDestroy;
        Action<int> doOnUpdateHp = _ => { };

        public void Initialize(Action doOnDestroy)
        {
            this.doOnDestroy = doOnDestroy;
            currentHitPoints = BaseHitPoints;
        }
        
        public void Initialize(Action doOnDestroy, Action<int> doOnUpdateHp)
        {
            Initialize(doOnDestroy);
            this.doOnUpdateHp = doOnUpdateHp;
            
            doOnUpdateHp(currentHitPoints);
        }

        public void ReceiveDamage(int damage)
        {
            currentHitPoints -= damage;
            
            if (currentHitPoints <= 0)
            {
                currentHitPoints = 0;
                doOnDestroy?.Invoke();
            }
            
            doOnUpdateHp(currentHitPoints);
        }
    }
}