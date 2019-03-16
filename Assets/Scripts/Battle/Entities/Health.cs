using System;
using System.Linq;
using Assets.Scripts.Battle.Weapons;
using Battle.Weapons;
using UnityEngine;

namespace Battle.Entities
{
    public class Health : MonoBehaviour
    {
        public int BaseHitPoints;
        public DamageMultiplier[] DamageEffects;

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

        public void ReceiveDamage(DamageMessage damage)
        {
            currentHitPoints -= CalculateTotalDamage(damage);
            
            if (currentHitPoints <= 0)
            {
                currentHitPoints = 0;
                doOnDestroy?.Invoke();
            }
            
            doOnUpdateHp(currentHitPoints);
        }

        int CalculateTotalDamage(DamageMessage damage)
        {
            var applicableEffects = DamageEffects.Where(i => damage.Types.Contains(i.DamageType)).ToArray();
            var multiplier = applicableEffects.Any() ? applicableEffects.Max(x => x.Multiplier) : 1f;
            var bestDamage = applicableEffects.Any() ? 
                applicableEffects.OrderByDescending(x => x.Multiplier).First().DamageType
                : damage.Types.First();

            Debug.Log(multiplier > 0 ? $"Entity recieves {damage.Value * multiplier} {bestDamage} damage" 
                : $"Entity is imune to {bestDamage} damage");

            return (int)(damage.Value * multiplier);
        }
    }
}