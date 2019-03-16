using System.Linq;
using Assets.Scripts.Battle.Weapons;
using Battle.Weapons;
using UnityEngine;

namespace Battle.Entities
{
    public class HitBox : MonoBehaviour
    {
        public Health AttachedHealth;
        public float DamageMultiplier = 1f;
        public float FgramentationDamageMultiplier = 1f;

        public void Damage(DamageMessage damage)
        {
            if (damage.Types.Contains(DamageType.Fragmentation))
                AttachedHealth.ReceiveDamage(DamageMessage.Create(damage, DamageMultiplier * FgramentationDamageMultiplier));
            else
                AttachedHealth.ReceiveDamage(damage);
        }
    }
}